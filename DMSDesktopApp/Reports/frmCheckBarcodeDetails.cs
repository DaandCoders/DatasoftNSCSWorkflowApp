using DMS.Context.Data;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace DMS.DesktopApp.Reports
{
    public partial class frmCheckBarcodeDetails : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        public frmCheckBarcodeDetails(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
        }

        private async void BtnOK_Click(object sender, EventArgs e)
        {
            dgvData.DataSource = null;
            lblRecordCount.Text = $"Records: 00";

            var barcode = txtBarcode.Text?.Trim();
            if (string.IsNullOrWhiteSpace(barcode))
            {
                MessageBox.Show("Enter barcode.");
                return;
            }
            btnOk.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var data = await GetBarcodeDetailsAsync(barcode);
                dgvData.DataSource = data;
                lblRecordCount.Text = $"Records: {data.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnOk.Enabled = true;
            }
        }

        private async Task<DataTable> GetBarcodeDetailsAsync(string barcode)
        {
            await using var db = await _dbContext.CreateDbContextAsync();
            // Query core timeline data per barcode
            var query = await (from fd in db.FileDetails.AsNoTracking()
                               where fd.Barcode == barcode
                               select new
                               {
                                   fd.Barcode,
                                   ReceivedDate = fd.CreatedDateTime,
                                   CurrentStatus = fd.Status.ToString(),
                                   ScanDate = db.FileDirectories
                                                .Where(fdir => fdir.FileDetailID == fd.ID && fdir.ScanCreateDateTime != null)
                                                .OrderBy(f => f.ScanCreateDateTime)
                                                .Select(f => f.ScanCreateDateTime)
                                                .FirstOrDefault(),
                                   QCDate = db.FileDirectories
                                               .Where(fdir => fdir.FileDetailID == fd.ID && fdir.QCCreateDateTime != null)
                                               .OrderBy(f => f.QCCreateDateTime)
                                               .Select(f => f.QCCreateDateTime)
                                               .FirstOrDefault(),
                                   DispatchDate = db.DispatchedData
                                                    .Where(d => d.SubDirectory.FileDirectory.FileDetailID == fd.ID && d.CreateDateTime != null)
                                                    .OrderBy(d => d.CreateDateTime)
                                                    .Select(d => d.CreateDateTime)
                                                    .FirstOrDefault()
                               }).ToListAsync();

            DataTable dt = new();
            dt.Columns.Add("Barcode");
            dt.Columns.Add("Received Date");
            dt.Columns.Add("Scan Date");
            dt.Columns.Add("QC Date");
            dt.Columns.Add("Dispatch Date");
            dt.Columns.Add("Current Status");

            foreach (var item in query)
            {
                dt.Rows.Add(
                    item.Barcode,
                    item.ReceivedDate?.ToString("dd-MM-yyyy HH:mm"),
                    item.ScanDate?.ToString("dd-MM-yyyy HH:mm"),
                    item.QCDate?.ToString("dd-MM-yyyy HH:mm"),
                    item.DispatchDate?.ToString("dd-MM-yyyy HH:mm"),
                    item.CurrentStatus
                );
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No record found for this barcode.");
            }
            return dt;
        }

        private async void FrmDayReport_Load(object sender, EventArgs e)
        {
            dgvData.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
            dgvData.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            Text = $"DMS Workflow | Check Barcode v{Assembly.GetExecutingAssembly().GetName().Version}";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDayReport_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                using var sfd = new SaveFileDialog
                {
                    Title = "Export Barcode Details",
                    Filter = "CSV (*.csv)|*.csv",
                    FileName = $"BarcodeDetails_{DateTime.Now:ddMMyyyy_HHmmss}.csv"
                };
                if (sfd.ShowDialog() != DialogResult.OK) return;
                try
                {
                    using var sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8);
                    // headers
                    var headers = dgvData.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText);
                    sw.WriteLine(string.Join(',', headers));
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.IsNewRow) continue;
                        var cells = row.Cells.Cast<DataGridViewCell>().Select(c => c.Value?.ToString()?.Replace(',', ' '));
                        sw.WriteLine(string.Join(',', cells));
                    }
                    sw.Flush();
                    MessageBox.Show("Exported successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Export failed: " + ex.Message);
                }
            }
        }
    }
}
