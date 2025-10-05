using DC.DMS.Services.ViewModels;
using DMS.Context.Data;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Reflection;
using ClosedXML.Excel; // Added for Excel export

namespace DMS.DesktopApp.Reports
{
    public partial class frmDayReport : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private int SelectedDepartmentID = 0;
        private int? SelectedDepartmentSectionID = 0;
        private MasterHelper MasterHelper;
        //DataSet ds;

        public frmDayReport(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            MasterHelper = new MasterHelper(this._dbContext);
            InitializeComponent();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            if (this.SelectedDepartmentID == 0)
            {
                int num1 = await this.GetAllDepartmentReports() ? 1 : 0;
            }
            else
            {
                int num2 = await this.GetDepartmentWiseReports(this.SelectedDepartmentID) ? 1 : 0;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void frmDaysReport_Load(object sender, EventArgs e)
        {
            dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dtpDateTo.Visible = false;
            lblDateTo.Visible = false;
            int num = await this.LoadDepartemntsAsync() ? 1 : 0;
            Text = $"DMS Workflow | Day Report v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
        }

        private async Task<bool> LoadDepartemntsAsync()
        {
            List<DropDownHelper> directoryList = await MasterHelper.GetAllDepartments();
            directoryList.Insert(0, new DropDownHelper()
            {
                ID = 0,
                Name = "All"
            });
            this.cobDepartment.DataSource = (object)directoryList;
            this.cobDepartment.DisplayMember = "Name";
            this.cobDepartment.ValueMember = "ID";
            bool flag = true;
            directoryList = null;
            return flag;
        }

        private async Task<bool> LoadSectionAsync(int departmentID)
        {
            List<DropDownHelper> departmentSectionList = await MasterHelper.GetDepartmentAllSection(departmentID);
            if (departmentSectionList.Count == 0)
                cobSection.Enabled = false;
            else
                cobSection.Enabled = true;

            departmentSectionList.Insert(0, new DropDownHelper()
            {
                ID = 0,
                Name = "All"
            });
            cobSection.DataSource = departmentSectionList;
            cobSection.DisplayMember = "Name";
            cobSection.ValueMember = "ID";
            bool flag = true;
            departmentSectionList = null;
            return flag;
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
                Title = "Export Report",
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
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            // frmAllOpratorRecords allOpratorRecords;
            int colIndex = e.ColumnIndex;
            if (colIndex > -1)
            {
                try
                {
                    string operatorName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (radSingleDate.Checked)
                    {
                        switch (cobWorkType.SelectedIndex)
                        {
                            case 0:
                                // dt = db.Select("select a.scancreatedatetime as 'Date Time', a.Name as 'File Name', b.filecount as 'Scanned Page Count', cd.barcode as 'Barcode' from casedirectories a inner join subdirectories b on a.id = b.casedirectoryid inner join users c on a.scancreateby = c.id inner join casedetails cd on cd.id=casedetailid where c.username = '" + operatorName + "' and cast(a.scancreatedatetime as date) = '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' order by a.scancreatedatetime");
                                break;
                            case 1:
                                //   dt = db.Select("select a.createdatetime as 'Date Time', CONCAT(a.caseyear,'_', Replace(b.name, '.','-'), '_', a.casenumber) as 'File Name', a.barcode as 'Barcode' from casedetails a inner join casetypes b on a.casetypeid=b.id inner join users c on a.createby=c.id where c.username = '" + operatorName + "' and cast(a.createdatetime as date) = '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' order by a.createdatetime");
                                break;
                            case 2:
                                //   dt = db.Select("SELECT distinct(c.id), c.QCCreateDateTime as 'Date Time', c.Name as 'File Name', cd.barcode as 'Barcode', count(a.casedirectoryid) as 'QC Image' FROM filedetails a inner join casedirectories c on a.CaseDirectoryID=c.id inner join users b on c.QCCreateby=b.id inner join casedetails cd on cd.id=c.casedetailid  where b.username = '" + operatorName + "' and cast(c.QCCreateDateTime as date) = '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' group by a.casedirectoryid order by c.QCCreateDateTime");
                                break;
                            case 3:
                                string query = "select a.CreateDateTime as 'Date Time', c.name as 'File Name', a.barcode as 'Barcode' from casedetails a inner join users b on a.CreateBy=b.id inner join casedirectories c on a.id=c.casedetailid where b.username = '" + operatorName + "' and cast(a.CreateDateTime as date) = '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' order by a.CreateDateTime";
                                //   dt = db.Select(query);
                                break;
                            case 4:
                                string query3 = "select distinct(c.id), c.classifiedcreatedatetime as 'Date Time', c.name as 'File Name', cd.barcode as 'Barcode',count(a.casedirectoryid) as 'QC Image' from filedetails a inner join maindata b on a.id=b.FileDetailID inner join casedirectories c on c.ID=a.CaseDirectoryID inner join users u on c.classifiedcreateby=u.id inner join casedetails cd on cd.id=c.casedetailid where u.username = '" + operatorName + "' and cast(c.classifiedcreatedatetime as date) = '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' group by a.casedirectoryid order by c.classifiedcreatedatetime;";
                                //    dt = db.Select(query3);
                                break;
                            case 5:
                                string query1 = "select distinct(c.id), c.ClientUpdatedDateTime as 'Date Time', c.name as 'File Name' from filedetails a inner join maindata b on a.id=b.FileDetailID inner join casedirectories c on c.ID=a.CaseDirectoryID inner join casedetails cd on cd.id=c.casedetailid inner join users u on c.UpdatedByClient=u.id where u.username = '" + operatorName + "' and cast(c.ClientUpdatedDateTime as date) = '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' order by c.ClientUpdatedDateTime;";
                                //  dt = db.Select(query1);
                                break;
                            default:
                                //dt = db.Select("select StudentInfo.RegisterID,CropData.Path,StudentInfo.UpdatedBy,StudentInfo.UpdatedDateTime as DateTime from StudentInfo Inner Join CropData on StudentInfo.RegisterID = CropData.RegisterID and StudentInfo.UpdatedBy='" + operatorName + "' and Convert(nvarchar,StudentInfo.UpdatedDateTime,120) like '" + dtpEntryDate.Value.ToString("yyyy-MM-dd") + "%' order by UpdatedDateTime;");
                                break;
                        }
                    }
                    else if (radBetweenDate.Checked)
                    {
                        switch (cobWorkType.SelectedIndex)
                        {
                            case 0:
                                //  dt = db.Select("select a.scancreatedatetime as 'Date Time', a.Name as 'File Name', b.filecount as 'Scanned Page Count', cd.barcode as 'Barcode' from casedirectories a inner join subdirectories b on a.id = b.casedirectoryid inner join users c on a.scancreateby = c.id inner join casedetails cd on cd.id=casedetailid where c.username = '" + operatorName + "' and cast(a.scancreatedatetime as date) between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd") + "%' order by a.scancreatedatetime");
                                break;
                            case 1:
                                // dt = db.Select("select a.createdatetime as 'Date Time', CONCAT(a.caseyear,'_', Replace(b.name, '.','-'), '_', a.casenumber) as 'File Name', a.barcode as 'Barcode' from casedetails a inner join casetypes b on a.casetypeid=b.id inner join users c on a.createby=c.id where c.username = '" + operatorName + "' and cast(a.createdatetime as date) between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd") + "%' order by a.createby");
                                break;
                            case 2:
                                //  dt = db.Select("SELECT distinct(c.id), c.QCCreateDateTime as 'Date Time', c.Name as 'File Name', cd.barcode as 'Barcode', count(a.casedirectoryid) as 'QC Image'  FROM filedetails a inner join casedirectories c on a.CaseDirectoryID=c.id inner join users b on c.QCCreateby=b.id inner join casedetails cd on cd.id=c.casedetailid where b.username = '" + operatorName + "' and cast(c.QCCreateDateTime as date) between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd") + "%' group by a.casedirectoryid order by c.QCCreateDateTime");
                                break;
                            case 3:
                                string query = "select a.CreateDateTime as 'Date Time', c.name as 'File Name',a.barcode as 'Barcode' from casedetails a inner join users b on a.CreateBy=b.id inner join casedirectories c on a.id=c.casedetailid where b.username = '" + operatorName + "' and cast(a.CreateDateTime as date) between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd") + "%' order by a.CreateDateTime";
                                // dt = db.Select(query);
                                break;
                            case 4:
                                string query1 = "select distinct(c.id), c.classifiedcreatedatetime as 'Date Time', c.name as 'File Name',cd.barcode as 'Barcode',count(a.casedirectoryid) as 'QC Image' from filedetails a inner join maindata b on a.id=b.FileDetailID inner join casedirectories c on c.ID=a.CaseDirectoryID inner join users u on c.classifiedcreateby=u.id inner join casedetails cd on cd.id=c.casedetailid where u.username = '" + operatorName + "' and cast(c.classifiedcreatedatetime as date) between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd") + "%'group by a.casedirectoryid order by c.classifiedcreatedatetime;";
                                // dt = db.Select(query1);
                                break;
                            case 5:
                                string query2 = "select distinct(c.id), c.ClientUpdatedDateTime as 'Date Time', c.name as 'File Name' from filedetails a inner join maindata b on a.id=b.FileDetailID inner join casedirectories c on c.ID=a.CaseDirectoryID inner join users u on c.UpdatedByClient=u.id where u.username = '" + operatorName + "' and cast(c.ClientUpdatedDateTime as date) between '" + dtpDateFrom.Value.ToString("yyyy-MM-dd") + "%' and '" + dtpDateTo.Value.ToString("yyyy-MM-dd") + "%' order by c.ClientUpdatedDateTime;";
                                // dt = db.Select(query2);
                                break;
                            default:
                                //dt = db.Select("select StudentInfo.RegisterID,CropData.Path,StudentInfo.UpdatedBy,StudentInfo.UpdatedDateTime as DateTime from StudentInfo Inner Join CropData on StudentInfo.RegisterID = CropData.RegisterID and StudentInfo.UpdatedBy='" + operatorName + "' and Convert(nvarchar,StudentInfo.UpdatedDateTime,120) like '" + dtpEntryDate.Value.ToString("yyyy-MM-dd") + "%' order by UpdatedDateTime;");
                                break;
                        }
                    }
                    //allOpratorRecords = new frmAllOpratorRecords(dt, cobWorkType.Text);
                    //allOpratorRecords.lblOperatorName.Text = operatorName;
                    //allOpratorRecords.ShowDialog();
                }
                catch (Exception)
                {
                }
                Cursor = Cursors.Default;
            }
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

        private async void cobDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedDepartmentID = (this.cobDepartment.SelectedItem as DropDownHelper).ID;
            await LoadSectionAsync(SelectedDepartmentID);
        }

        private async Task<bool> GetDepartmentWiseReports(int selectedDepartmentID)
        {
            if (selectedDepartmentID <= 0) return false;

            var hasRange = radSingleDate.Checked || radBetweenDate.Checked;
            if (!hasRange) return false;

            var startDate = DateTime.Parse(dtpDateFrom.Value.ToString("yyyy-MM-dd"));
            var endDate = radSingleDate.Checked
                ? startDate.AddDays(1).AddTicks(-1)
                : DateTime.Parse(dtpDateTo.Value.ToString("yyyy-MM-dd")).AddDays(1).AddTicks(-1);

            DataTable dt = new();
            bool success = false;

            await using var _db = await _dbContext.CreateDbContextAsync();
            Cursor = Cursors.WaitCursor;
            try
            {
                success = await GetSetReport(startDate, endDate, selectedDepartmentID, SelectedDepartmentSectionID);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return success;
        }

        private async Task<bool> GetAllDepartmentReports()
        {
            var hasRange = radSingleDate.Checked || radBetweenDate.Checked;
            if (!hasRange) return false;

            var startDate = DateTime.Parse(dtpDateFrom.Value.ToString("yyyy-MM-dd"));
            var endDate = radSingleDate.Checked
                ? startDate.AddDays(1).AddTicks(-1)
                : DateTime.Parse(dtpDateTo.Value.ToString("yyyy-MM-dd")).AddDays(1).AddTicks(-1);


            bool success = false;


            Cursor = Cursors.WaitCursor;
            try
            {
                success = await GetSetReport(startDate, endDate, null, null);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            return success;
        }

        private async Task<bool> GetSetReport(DateTime startDate, DateTime endDate, int? selectedDepartmentID, int? selectedDepartmentSectionID)
        {
            bool success = false;
            DataTable dt = new();
            await using var _db = await _dbContext.CreateDbContextAsync();
            switch (cobWorkType.SelectedIndex)
            {
                // Receiving
                case 0:
                    {
                        var receivingList = await (from fd in _db.FileDetails

                                                   join u in _db.ApplicationUsers
                                                    on fd.CreatedBy equals u.ID

                                                   where fd.CreatedDateTime >= startDate &&
                                                         fd.CreatedDateTime <= endDate &&
                                                         (selectedDepartmentID == null || fd.DepartmentID == selectedDepartmentID) &&
                                                         (selectedDepartmentSectionID == null || fd.SectionID == selectedDepartmentSectionID)

                                                   group new { fd } by u.UserName into g
                                                   select new
                                                   {
                                                       OperatorName = g.Key,
                                                       TotalFiles = g.Select(r => r.fd.ID).Distinct().Count(),
                                                   }).ToListAsync();

                        dt = ToDataTable(receivingList);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView.DataSource = null;
                            int sumTotal = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                                sumTotal += Convert.ToInt32(dt.Rows[i][1]);

                            var row = dt.NewRow();
                            row[0] = "Total";
                            row[1] = sumTotal;
                            dt.Rows.Add(row);

                            dataGridView.DataSource = dt;
                            btnExportReport.BackColor = Color.MediumSeaGreen;
                            btnExportReport.Enabled = true;
                            lblRecordCount.Text = "Total Record: " + dt.Rows.Count;
                            statusStrip1.Refresh();
                            success = true;
                        }
                        else
                        {
                            btnExportReport.BackColor = Color.LightGray;
                            btnExportReport.Enabled = false;
                            dataGridView.DataSource = null;
                            lblRecordCount.Text = "Total Record: 0";
                            MessageBox.Show(
                                "Oops! No working in the date: " + dtpDateFrom.Value.ToString("dd-MM-yyyy") + ".",
                                "No record found!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            success = false;
                        }
                        break;
                    }

                // Scanning
                case 1:
                    {
                        // Include TotalImages by summing SubDirectory.FileCount, and optionally filter by Department and Section
                        var scanningList = await (
                            from sd in _db.SubDirectories
                            join fd in _db.FileDirectories on sd.FileDirectoryID equals fd.ID
                            join u in _db.ApplicationUsers on fd.ScanCreateBy equals u.ID
                            where fd.ScanCreateDateTime >= startDate
                                  && fd.ScanCreateDateTime <= endDate
                                  && (selectedDepartmentID == null || fd.FileDetail!.DepartmentID == selectedDepartmentID)
                                  && (selectedDepartmentSectionID == null || fd.FileDetail!.SectionID == selectedDepartmentSectionID)
                            group new { sd, fd } by u.UserName into g
                            select new
                            {
                                OperatorName = g.Key,
                                TotalFiles = g.Select(r => r.fd.ID).Distinct().Count(),
                                TotalImages = g.Sum(r => r.sd.FileCount)
                            }
                        ).ToListAsync();

                        dt = ToDataTable(scanningList);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView.DataSource = null;

                            int sumFiles = 0;
                            int sumImages = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                sumFiles += Convert.ToInt32(dt.Rows[i][1]);
                                sumImages += Convert.ToInt32(dt.Rows[i][2]);
                            }

                            var row = dt.NewRow();
                            row[0] = "Total";
                            row[1] = sumFiles;
                            row[2] = sumImages;
                            dt.Rows.Add(row);

                            dataGridView.DataSource = dt;
                            btnExportReport.BackColor = Color.MediumSeaGreen;
                            btnExportReport.Enabled = true;
                            lblRecordCount.Text = "Total Record: " + dt.Rows.Count;
                            statusStrip1.Refresh();
                            success = true;
                        }
                        else
                        {
                            btnExportReport.BackColor = Color.LightGray;
                            btnExportReport.Enabled = false;
                            dataGridView.DataSource = null;
                            lblRecordCount.Text = "Total Record: 0";
                            MessageBox.Show(
                                "Oops! No working in the date: " + dtpDateFrom.Value.ToString("dd-MM-yyyy") + ".",
                                "No record found!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            success = false;
                        }
                        break;
                    }

                // QC
                case 2:
                    {
                        var qcList = await (from img in _db.ImageFileDetails

                                            join sd in _db.SubDirectories
                                            on img.SubDirectoryID equals sd.ID

                                            join fd in _db.FileDirectories
                                            on sd.FileDirectoryID equals fd.ID

                                            join u in _db.ApplicationUsers
                                             on fd.QCCreateBy equals u.ID

                                            where fd.QCCreateDateTime >= startDate &&
                                                  fd.QCCreateDateTime <= endDate &&
                                                  (selectedDepartmentID == null || fd.FileDetail!.DepartmentID == selectedDepartmentID) &&
                                                  (selectedDepartmentSectionID == null || fd.FileDetail!.SectionID == selectedDepartmentSectionID)

                                            group new { fd, img } by u.UserName into g
                                            select new
                                            {
                                                OperatorName = g.Key,
                                                TotalFiles = g.Select(r => r.fd.ID).Distinct().Count(),
                                                TotalImages = g.Select(r => r.img.ID).Count()
                                            }).ToListAsync();

                        dt = ToDataTable(qcList);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView.DataSource = null;

                            int sumFiles = 0;
                            int sumImages = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                sumFiles += Convert.ToInt32(dt.Rows[i][1]);
                                sumImages += Convert.ToInt32(dt.Rows[i][2]);
                            }

                            var row = dt.NewRow();
                            row[0] = "Total";
                            row[1] = sumFiles;
                            row[2] = sumImages;
                            dt.Rows.Add(row);

                            dataGridView.DataSource = dt;
                            btnExportReport.BackColor = Color.MediumSeaGreen;
                            btnExportReport.Enabled = true;
                            lblRecordCount.Text = "Total Record: " + dt.Rows.Count;
                            statusStrip1.Refresh();
                            success = true;
                        }
                        else
                        {
                            btnExportReport.BackColor = Color.LightGray;
                            btnExportReport.Enabled = false;
                            dataGridView.DataSource = null;
                            lblRecordCount.Text = "Total Record: 0";
                            MessageBox.Show(
                                "Oops! No working in the date: " + dtpDateFrom.Value.ToString("dd-MM-yyyy") + ".",
                                "No record found!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            success = false;
                        }
                        break;
                    }

                // Dispatch
                case 3:
                    {
                        var dispatchFlat = await _db.DispatchedData
                            .AsNoTracking()
                            .Where(x =>
                                x.CreateDateTime >= startDate &&
                                x.CreateDateTime <= endDate &&
                                (selectedDepartmentID == null || x.SubDirectory.FileDirectory.FileDetail!.DepartmentID == selectedDepartmentID) &&
                                (selectedDepartmentSectionID == null || x.SubDirectory.FileDirectory.FileDetail!.SectionID == selectedDepartmentSectionID))
                            .Select(x => new
                            {
                                OperatorName = x.CreateByUser.UserName,
                                FileId = x.SubDirectory.FileDirectory.ID,
                                PageCount = x.PageCount
                            })
                            .ToListAsync();

                        var dispatchList = dispatchFlat
                            .GroupBy(x => x.OperatorName)
                            .Select(g => new
                            {
                                OperatorName = g.Key,
                                TotalFiles = g.Select(r => r.FileId).Distinct().Count(),
                                TotalImages = g.Sum(r => r.PageCount)
                            })
                            .ToList();

                        dt = ToDataTable(dispatchList);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView.DataSource = null;

                            int sumFiles = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                                sumFiles += Convert.ToInt32(dt.Rows[i][1]);

                            var row = dt.NewRow();
                            row[0] = "Total";
                            row[1] = sumFiles;
                            dt.Rows.Add(row);

                            dataGridView.DataSource = dt;
                            btnExportReport.BackColor = Color.MediumSeaGreen;
                            btnExportReport.Enabled = true;
                            lblRecordCount.Text = "Total Record: " + dt.Rows.Count;
                            statusStrip1.Refresh();
                            success = true;
                        }
                        else
                        {
                            btnExportReport.BackColor = Color.LightGray;
                            btnExportReport.Enabled = false;
                            dataGridView.DataSource = null;
                            lblRecordCount.Text = "Total Record: 0";
                            MessageBox.Show(
                                "Oops! No working in the date: " + dtpDateFrom.Value.ToString("dd-MM-yyyy") + ".",
                                "No record found!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            success = false;
                        }
                        break;
                    }

                default:
                    success = false;
                    break;
            }

            return success;
        }

        private void cobSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedID = (this.cobSection.SelectedItem as DropDownHelper).ID;
            if (selectedID == 0)
                this.SelectedDepartmentSectionID = null;
            else
                this.SelectedDepartmentSectionID = selectedID;

        }
    }
}