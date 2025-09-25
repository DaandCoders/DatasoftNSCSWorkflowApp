using DMS.API.WindowsServices;
using DMS.API.WindowsServices.Tool;
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;
using System.Diagnostics;

namespace DMS.DesktopApp.Sync
{
    public partial class frmDataSync : Form
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        BackgroundWorker worker;
        List<string> TableNames;
        int Counter = 0;
        int TotalRecords = 0;
        Stopwatch executionWatch;
        DateTime? SelectedSyncDate = DateTime.Now;

        public frmDataSync(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            ClientAPI.BaseUrl = Settings.Default.BaseUrl;
            ClientAPI.DataSyncUrl = Settings.Default.GetSyncDataUrl;
            TableNames = new List<string>{
               "ApplicationUsers","FileDetails","Directories","FileDirectories","SubDirectories","ImageFileDetails","DispatchedData"
            };
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy != true)
            {
                executionWatch = Stopwatch.StartNew();
                backgroundWorker.RunWorkerAsync();
            }
            btnClose.Text = "&Cancel";
            dtSyncDate.Enabled = false;
            btnSync.Enabled = false;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 0)
            {
                tsProgressBar.Visible = true;
                lblResult.Visible = true;
            }

            tsProgressBar.Value = e.ProgressPercentage;
            lblResult.Text = (e.ProgressPercentage.ToString()) + " %";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            executionWatch.Stop();
            lblResult.Visible = true;
            if (e.Cancelled == true)
            {
                lblResult.Text = "Canceled!";
                statusStrip.Refresh();
            }
            else if (e.Error != null)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "Error: " + e.Error.Message;
                statusStrip.Refresh();
            }
            else
            {
                lblResult.Text = "Please Wait...";
                lblResult.Text = "Done!";
                statusStrip.Refresh();
                tsProgressBar.Visible = false;

                TimeSpan timeTaken = executionWatch.Elapsed;
                lblTotalTimeTaken.Text = $"Time Taken: {timeTaken.Hours.ToString().PadLeft(2, '0')}:{timeTaken.Minutes.ToString().PadLeft(2, '0')}:{timeTaken.Seconds.ToString().PadLeft(2, '0')}";
                MessageBox.Show($"Data for date {dtSyncDate.Text} synced sucessfully!", "Process complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblResult.Text = "";
                lblErrorMessage.Visible = false;
            }
            btnClose.Text = "&Close";
            dtSyncDate.Enabled = true;
            btnSync.Enabled = true;
            TotalRecords = 0;
            Counter = 0;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker = sender as BackgroundWorker;
            // Run SyncStartAsync in a background thread
            Task.Run(async () => await SyncStartAsync(e)).Wait();
            worker.ReportProgress(0);
        }

        private async Task SyncStartAsync(DoWorkEventArgs e)
        {
            var syncClient = new DataSyncClient(_dbContext);
            int TotalRecords = TableNames.Count;
            double value;
            int percentage = 0;


            foreach (var table in TableNames)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    worker.ReportProgress(0);
                    break;
                }
                Counter++;
                await syncClient.SyncTableAsync(table, SelectedSyncDate);

                value = ((double)Counter / TotalRecords) * 100;
                percentage = Convert.ToInt32(Math.Round(value, 0));
                Thread.Sleep(50);
                worker.ReportProgress(percentage);
            }
        }

        private void frmDataSync_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            lblResult.Visible = false;
        }

        private void dtSyncDate_ValueChanged(object sender, EventArgs e)
        {
            SelectedSyncDate = dtSyncDate.Value;
        }

        public async Task<(bool isSuccess, string errorMessage)> SyncTableAsync(string tableName, DateTime? selectedSyncDate)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var dbSetProperty = _db.GetType().GetProperty(tableName);
            if (dbSetProperty == null)
            {
                throw new NotSupportedException($"Table {tableName} is not supported.");
            }

            var dbSet = dbSetProperty.GetValue(_db);
            if (dbSet == null)
            {
                throw new Exception($"Failed to retrieve DbSet for table {tableName}.");
            }

            var queryable = dbSet as IQueryable<object>;
            if (queryable == null)
            {
                throw new Exception($"Failed to cast DbSet for table {tableName} to IQueryable.");
            }

            // Fetch rows based on the selectedSyncDate
            var rows = await queryable
                .Where(entity => entity.GetType().GetProperty("CreatedDateTime") != null &&
                                 entity.GetType().GetProperty("CreatedDateTime").GetValue(entity) != null &&
                                 ((DateTime)entity.GetType().GetProperty("CreatedDateTime").GetValue(entity)).Date == selectedSyncDate.Value.Date)
                .Select(entity => entity.GetType()
                    .GetProperties()
                    .ToDictionary(
                        prop => prop.Name,
                        prop => prop.GetValue(entity, null)
                    ))
                .ToListAsync();

            if (rows.Count == 0)
            {
                return (true, "No rows to sync.");
            }

            // Sync rows in batches
            int batchSize = 1000; // Adjust batch size as needed
            return await new APIServices().SyncDataInBatchesAsync(tableName, rows, batchSize);
        }

        private void chkBoxCheckUncheck_CheckedChanged(object sender, EventArgs e)
        {
            //if (sender is CheckBox chkBox && !chkBox.Checked)
            //{
            //    string tableName = chkBox.Tag?.ToString();
            //    var result = MessageBox.Show(this, "Are you sure you want to uncheck this? it could be impact on the data process.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.No)
            //    {
            //        chkBox.Checked = true;
            //    }
            //    else
            //    {
            //        chkBox.Checked = false;
            //    }
            //}

            if (sender is CheckBox chkBox)
            {
                string tableName = chkBox.Tag?.ToString();

                if (chkBox.Checked)
                {
                    // Add the table name if checked and not already in the list
                    if (!string.IsNullOrEmpty(tableName) && !TableNames.Contains(tableName))
                    {
                        TableNames.Add(tableName);
                    }
                }
                else
                {
                    // Show warning before removing
                    var result = MessageBox.Show(this, "Are you sure you want to uncheck this? It could impact the data process.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        chkBox.Checked = true;
                    }
                    else
                    {
                        // Remove the table name from the list if unchecked
                        if (!string.IsNullOrEmpty(tableName) && TableNames.Contains(tableName))
                        {
                            TableNames.Remove(tableName);
                        }
                    }
                }
            }
        }

        //static async Task SyncTableDataAsync(string tableName)
        //{
        //    // Adjust the connection string to your MySQL client data.
        //    // Suggestion: store/retrieve settings securely.
        //    string mySqlConnStr = "Server=CLIENT_MYSQL_SERVER;Database=ClientDb;User ID=client_user;Password=client_password;";
        //    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

        //    try
        //    {
        //        using (var connection = new MySqlConnection(mySqlConnStr))
        //        {
        //            await connection.OpenAsync();
        //            string query = $"SELECT * FROM `{tableName}`";

        //            using (var command = new MySqlCommand(query, connection))
        //            using (var reader = await command.ExecuteReaderAsync())
        //            {
        //                while (await reader.ReadAsync())
        //                {
        //                    var row = new Dictionary<string, object>();
        //                    for (int i = 0; i < reader.FieldCount; i++)
        //                    {
        //                        row[reader.GetName(i)] = reader.GetValue(i);
        //                    }
        //                    rows.Add(row);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error reading table {tableName} from MySQL: {ex.Message}");
        //        return;
        //    }

        //    // Prepare the payload for API upload.
        //    var payload = new
        //    {
        //        TableName = tableName,
        //        Rows = rows
        //    };

        //    string apiUrl = "https://your-live-server.com/api/dataupload/upload"; // Update with your live server URL

        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            string jsonPayload = JsonConvert.SerializeObject(payload);
        //            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        //            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine($"Table {tableName} synced successfully.");
        //            }
        //            else
        //            {
        //                string errorResponse = await response.Content.ReadAsStringAsync();
        //                Console.WriteLine($"Error syncing table {tableName}: {response.StatusCode} - {errorResponse}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error during API call for table {tableName}: {ex.Message}");
        //    }
        //}

    }
}
