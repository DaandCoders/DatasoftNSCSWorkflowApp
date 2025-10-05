using ClosedXML.Excel;
using DC.DMS.Services.ViewModels;
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
    public partial class frmClientReport : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private int SelectedDepartmentID = 0;
        private int? SelectedDepartmentSectionID = 0;
        private MasterHelper MasterHelper;

        // Helper class for summary aggregation
        private sealed class DepartmentSummary
        {
            public int DepartmentID { get; set; }
            public string DepartmentName { get; set; } = string.Empty;
            public int TotalReceived { get; set; }
            public int TotalScanFile { get; set; }
            public int TotalScanImages { get; set; }
            public int TotalQCFile { get; set; }
            public int TotalQCImages { get; set; }
            public int TotalDispatchedFile { get; set; }
            public int TotalDispatchedImages { get; set; }
        }

        public frmClientReport(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            MasterHelper = new MasterHelper(this._dbContext);
            InitializeComponent();
           
        }

        // Common method to toggle button enable state and color
        private void SetControlState(Button button, bool enabled, Color? enabledColor = null, Color? disabledColor = null)
        {
            button.Enabled = enabled;
            button.BackColor = enabled ? (enabledColor ?? Color.MediumSeaGreen) : (disabledColor ?? Color.LightGray);
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            lblRecordCount.Text = "Total Record: 00";

            var sw = Stopwatch.StartNew();
            Cursor = Cursors.WaitCursor;
            SetControlState(btnExportReport, false);
            _ = await this.GetAllDepartmentReports();
            sw.Stop();
            Cursor = Cursors.Default;
            lblElapsed.Text = $"Time Taken: {sw.Elapsed:hh\\:mm\\:ss}";
            SetControlState(btnExportReport, true);
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private async void frmDaysReport_Load(object sender, EventArgs e)
        {
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dtpDateTo.Visible = false;
            lblDateTo.Visible = false;
            Text = $"DMS Workflow | Client Report v{Assembly.GetExecutingAssembly().GetName().Version}";
            SetControlState(btnExportReport, false);
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Title = "Export Client Report",
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"DayReport_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Report");

                // Headers
                int colIndex = 1;
                foreach (DataGridViewColumn col in dataGridView.Columns)
                {
                    ws.Cell(1, colIndex).Value = col.HeaderText;
                    ws.Cell(1, colIndex).Style.Font.Bold = true;
                    ws.Cell(1, colIndex).Style.Fill.BackgroundColor = XLColor.LightGray;
                    colIndex++;
                }

                // Rows
                int rowIndex = 2;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.IsNewRow) continue;
                    for (int c = 0; c < dataGridView.Columns.Count; c++)
                    {
                        var val = row.Cells[c].Value;
                        if (val is DateTime dtVal)
                            ws.Cell(rowIndex, c + 1).Value = dtVal;
                        else if (val is int intVal)
                            ws.Cell(rowIndex, c + 1).Value = intVal;
                        else if (val is long longVal)
                            ws.Cell(rowIndex, c + 1).Value = longVal;
                        else if (val is double dblVal)
                            ws.Cell(rowIndex, c + 1).Value = dblVal;
                        else if (val is decimal decVal)
                            ws.Cell(rowIndex, c + 1).Value = decVal;
                        else if (val is bool boolVal)
                            ws.Cell(rowIndex, c + 1).Value = boolVal;
                        else
                            ws.Cell(rowIndex, c + 1).Value = val?.ToString();
                    }
                    rowIndex++;
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);
                MessageBox.Show("Report exported successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message);
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new(typeof(T).Name);
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in props)
            {
                var type = p.PropertyType;
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type)!;
                dataTable.Columns.Add(p.Name, type);
            }
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) { }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (e.ColumnIndex > -1)
            {
                try { } catch { }
            }
            Cursor = Cursors.Default;
        }

        private void radBetweenDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateTo.Visible = true;
            lblDateTo.Visible = true;
        }

        private void radSingleDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateTo.Visible = false;
            lblDateTo.Visible = false;
        }

        private async Task<bool> GetAllDepartmentReports()
        {
            if (!(radSingleDate.Checked || radBetweenDate.Checked)) return false;
            var startDate = DateTime.Parse(dtpDateFrom.Value.ToString("yyyy-MM-dd"));
            var endDate = radSingleDate.Checked ? startDate.AddDays(1).AddTicks(-1) : DateTime.Parse(dtpDateTo.Value.ToString("yyyy-MM-dd")).AddDays(1).AddTicks(-1);
            bool success;
            Cursor = Cursors.WaitCursor;
            try { success = await GetSetReport(startDate, endDate, null, null); }
            finally { Cursor = Cursors.Default; }
            return success;
        }

        private async Task<bool> GetSetReport(DateTime startDate, DateTime endDate, int? selectedDepartmentID, int? selectedDepartmentSectionID)
        {
            bool success = false;
            await using var _db = await _dbContext.CreateDbContextAsync();

            // Build a distinct set of active department IDs within the date range from all activity sources
            var activeDepartmentIdsQuery = (
                    from fd in _db.FileDetails.AsNoTracking()
                    where fd.CreatedDateTime >= startDate && fd.CreatedDateTime <= endDate
                    select fd.DepartmentID
                )
                .Concat(from fdir in _db.FileDirectories.AsNoTracking()
                        where fdir.ScanCreateDateTime >= startDate && fdir.ScanCreateDateTime <= endDate
                        select fdir.FileDetail!.DepartmentID)
                .Concat(from fdir in _db.FileDirectories.AsNoTracking()
                        where fdir.QCCreateDateTime >= startDate && fdir.QCCreateDateTime <= endDate
                        select fdir.FileDetail!.DepartmentID)
                .Concat(from dd in _db.DispatchedData.AsNoTracking()
                        where dd.CreateDateTime >= startDate && dd.CreateDateTime <= endDate
                        select dd.SubDirectory.FileDirectory.FileDetail!.DepartmentID)
                .Where(id => id != null)
                .Distinct();

            // Optionally filter by selectedDepartmentID if provided
            if (selectedDepartmentID.HasValue)
                activeDepartmentIdsQuery = activeDepartmentIdsQuery.Where(id => id == selectedDepartmentID.Value);

            // Single LINQ projection with correlated subqueries for each aggregate
            var summaryList = await (
                from deptId in activeDepartmentIdsQuery
                join dept in _db.MasterDepartments.AsNoTracking() on deptId equals dept.ID
                orderby dept.Name
                select new DepartmentSummary
                {
                    DepartmentID = dept.ID,
                    DepartmentName = dept.Name,
                    TotalReceived = _db.FileDetails.AsNoTracking()
                        .Where(fd => fd.DepartmentID == dept.ID && fd.CreatedDateTime >= startDate && fd.CreatedDateTime <= endDate)
                        .Count(),
                    TotalScanFile = _db.FileDirectories.AsNoTracking()
                        .Where(fd => fd.FileDetail!.DepartmentID == dept.ID && fd.ScanCreateDateTime >= startDate && fd.ScanCreateDateTime <= endDate)
                        .Select(fd => fd.ID)
                        .Distinct()
                        .Count(),
                    TotalScanImages = _db.SubDirectories.AsNoTracking()
                        .Where(sd => sd.FileDirectory.FileDetail!.DepartmentID == dept.ID && sd.FileDirectory.ScanCreateDateTime >= startDate && sd.FileDirectory.ScanCreateDateTime <= endDate)
                        .Select(sd => (int?)sd.FileCount)
                        .Sum() ?? 0,
                    TotalQCFile = _db.FileDirectories.AsNoTracking()
                        .Where(fd => fd.FileDetail!.DepartmentID == dept.ID && fd.QCCreateDateTime >= startDate && fd.QCCreateDateTime <= endDate)
                        .Select(fd => fd.ID)
                        .Distinct()
                        .Count(),
                    TotalQCImages = _db.ImageFileDetails.AsNoTracking()
                        .Where(img => img.SubDirectory.FileDirectory.FileDetail!.DepartmentID == dept.ID && img.SubDirectory.FileDirectory.QCCreateDateTime >= startDate && img.SubDirectory.FileDirectory.QCCreateDateTime <= endDate)
                        .Count(),
                    TotalDispatchedFile = _db.DispatchedData.AsNoTracking()
                        .Where(d => d.SubDirectory.FileDirectory.FileDetail!.DepartmentID == dept.ID && d.CreateDateTime >= startDate && d.CreateDateTime <= endDate)
                        .Select(d => d.SubDirectory.FileDirectoryID)
                        .Distinct()
                        .Count(),
                    TotalDispatchedImages = _db.DispatchedData.AsNoTracking()
                        .Where(d => d.SubDirectory.FileDirectory.FileDetail!.DepartmentID == dept.ID && d.CreateDateTime >= startDate && d.CreateDateTime <= endDate)
                        .Select(d => (int?)d.PageCount)
                        .Sum() ?? 0
                }
            ).ToListAsync();

            // Build DataTable for UI
            DataTable summary = new();
            summary.Columns.Add("S.No.", typeof(int));
            summary.Columns.Add("Department", typeof(string));
            summary.Columns.Add("Total Received", typeof(int));
            summary.Columns.Add("Total Scan File", typeof(int));
            summary.Columns.Add("Total Scan Images", typeof(int));
            summary.Columns.Add("Total QC File", typeof(int));
            summary.Columns.Add("Total QC Images", typeof(int));
            summary.Columns.Add("Total Dispatched File", typeof(int));
            summary.Columns.Add("Total Dispatched Images", typeof(int));

            int serial = 1;
            int tReceived = 0, tScanFile = 0, tScanImages = 0, tQCFile = 0, tQCImages = 0, tDispFile = 0, tDispImages = 0;
            foreach (var ds in summaryList)
            {
                // Skip departments that have zero across all metrics (defensive)
                if (ds.TotalReceived == 0 && ds.TotalScanFile == 0 && ds.TotalScanImages == 0 && ds.TotalQCFile == 0 && ds.TotalQCImages == 0 && ds.TotalDispatchedFile == 0 && ds.TotalDispatchedImages == 0)
                    continue;

                summary.Rows.Add(serial++, ds.DepartmentName, ds.TotalReceived, ds.TotalScanFile, ds.TotalScanImages, ds.TotalQCFile, ds.TotalQCImages, ds.TotalDispatchedFile, ds.TotalDispatchedImages);
                tReceived += ds.TotalReceived;
                tScanFile += ds.TotalScanFile;
                tScanImages += ds.TotalScanImages;
                tQCFile += ds.TotalQCFile;
                tQCImages += ds.TotalQCImages;
                tDispFile += ds.TotalDispatchedFile;
                tDispImages += ds.TotalDispatchedImages;
            }

            if (summary.Rows.Count > 0)
            {
                var totalRow = summary.NewRow();
                totalRow[0] = DBNull.Value;
                totalRow[1] = "Total";
                totalRow[2] = tReceived;
                totalRow[3] = tScanFile;
                totalRow[4] = tScanImages;
                totalRow[5] = tQCFile;
                totalRow[6] = tQCImages;
                totalRow[7] = tDispFile;
                totalRow[8] = tDispImages;
                summary.Rows.Add(totalRow);
            }

            dataGridView.DataSource = summary;
            SetControlState(btnExportReport, summary.Rows.Count > 0);
            lblRecordCount.Text = "Total Record: " + summary.Rows.Count;
            statusStrip1.Refresh();
            success = summary.Rows.Count > 0;
            return success;
        }
    }
}