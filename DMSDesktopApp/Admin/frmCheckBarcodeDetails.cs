using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Diagnostics;

namespace HighCourtWorkflow.Admin
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

        }
        private async void FrmDayReport_Load(object sender, EventArgs e)
        {
            dgvData.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
            dgvData.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDayReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            //UpdateStatusDisplay(this, "");
        }

        private async void dataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

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
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radSearchWithCaseDetails_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radSearchWithBarcode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radSearchWithCaseDetails_Click(object sender, EventArgs e)
        {
            
        }

        private void radSearchWithBarcode_Click(object sender, EventArgs e)
        {
            
        }
    }
}
