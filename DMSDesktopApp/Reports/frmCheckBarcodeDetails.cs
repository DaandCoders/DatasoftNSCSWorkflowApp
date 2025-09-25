
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Diagnostics;

namespace DMS.DesktopApp.Reports
{
    public partial class frmCheckBarcodeDetails : Form
    {
       
        private readonly ApplicationDbContext db;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        public frmCheckBarcodeDetails(ApplicationDbContext dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            db = dbContext;
            _cache = cache;
            _translationService = translationService;
        }

        private async void BtnOK_Click(object sender, EventArgs e)
        {
           //var result = 
        }
        private async void FrmDayReport_Load(object sender, EventArgs e)
        {
            dgvData.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
            dgvData.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
           // await LoadCaseTypeAsync();
        }
       
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDayReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            //UpdateStatusDisplay(this, "");
        }

       

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgvData.Columns)
                {
                    dt.Columns.Add(column.HeaderText);
                }
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (dgvData.Rows.Count - 1 > row.Index)
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }
                }
                string folderPath = Properties.Settings.Default.DriveLetter + ":" + "\\Reports";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                //bool result = new ExportReport(dt).Export(folderPath, "CaseDetails_" + DateTime.Now.ToString("dd-MM-yyyy"));
                //if (result)
                //{
                //    MessageBox.Show(this, "Case Details report exported successfully!", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //else
                //{
                //    MessageBox.Show(this, "Case Details export failed!", Default.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
            }
        }
    }
}
