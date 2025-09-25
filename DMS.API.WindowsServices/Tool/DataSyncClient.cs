
using DC.DMS.Services.Models.Log;
using DMS.API.WindowsServices.Helper;
using DMS.Context.Data;
using DMS.ContextData;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.API.WindowsServices.Tool
{
    public class DataSyncClient
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;

        public DataSyncClient(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
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

            if (selectedSyncDate.HasValue)
            {
                if (tableName == "ApplicationUsers")
                {
                    queryable = _db.ApplicationUsers
                        .Where(f => f.CreatedDateTime.Date == selectedSyncDate.Value.Date
                        || f.DeactivatedDateTime == selectedSyncDate.Value.Date
                        || f.LockedDateTime == selectedSyncDate.Value.Date
                        || f.LastLogin == selectedSyncDate.Value.Date)
                        .Cast<object>();
                }
                else if (tableName == "FileDetails")
                {
                    queryable = _db.FileDetails
                        .Where(f => f.CreatedDateTime.HasValue &&
                        f.CreatedDateTime.Value.Date == selectedSyncDate.Value.Date)
                        .Cast<object>();
                }
                else if (tableName == "Directories")
                {
                    queryable = _db.Directories
                        .Where(f => f.CreatedDateTime.Date == selectedSyncDate.Value.Date
                        || (f.UpdatedDateTime.HasValue && f.UpdatedDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ClientUpdatedDateTime.HasValue && f.ClientUpdatedDateTime.Value.Date == selectedSyncDate.Value.Date))
                        .Cast<object>();
                }
                else if (tableName == "SubDirectories")
                {
                    queryable = _db.SubDirectories
                        .Where(f => (f.ScanCreateDateTime.HasValue && f.ScanCreateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.CreatedDateTime.HasValue && f.CreatedDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.QCCreateDateTime.HasValue && f.QCCreateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ClassifiedCreateDateTime.HasValue && f.ClassifiedCreateDateTime.Value.Date == selectedSyncDate.Value.Date)

                        || (f.UpdatedDateTime.HasValue && f.UpdatedDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ScanUpdateDateTime.HasValue && f.ScanUpdateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.QCUpdateDateTime.HasValue && f.QCUpdateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ScanUpdateDateTime.HasValue && f.ScanUpdateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ClassifiedUpdateDateTime.HasValue && f.ClassifiedUpdateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ClientUpdatedDateTime.HasValue && f.ClientUpdatedDateTime.Value.Date == selectedSyncDate.Value.Date))
                        .Cast<object>();
                }
                else if (tableName == "ImageFileDetails")
                {
                    queryable = _db.ImageFileDetails
                        .Where(f => (f.CreatedDateTime.HasValue && f.CreatedDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ScanCreateDateTime.HasValue && f.ScanCreateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.QCCreateDateTime.HasValue && f.QCCreateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ClassifiedCreateDateTime.HasValue && f.ClassifiedCreateDateTime.Value.Date == selectedSyncDate.Value.Date)

                        || (f.UpdatedDateTime.HasValue && f.UpdatedDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ScanUpdateDateTime.HasValue && f.ScanUpdateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.QCUpdateDateTime.HasValue && f.QCUpdateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ClassifiedUpdateDateTime.HasValue && f.ClassifiedUpdateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.ClientUpdatedDateTime.HasValue && f.ClientUpdatedDateTime.Value.Date == selectedSyncDate.Value.Date)
                        )
                        .Cast<object>();
                }
                else if (tableName == "FileDirectories")
                {
                    queryable = _db.FileDirectories
                        .Where(f =>
                            (f.CreatedDateTime.HasValue && f.CreatedDateTime.Value.Date == selectedSyncDate.Value.Date) ||
                            (f.ScanCreateDateTime.HasValue && f.ScanCreateDateTime.Value.Date == selectedSyncDate.Value.Date) ||
                            (f.QCCreateDateTime.HasValue && f.QCCreateDateTime.Value.Date == selectedSyncDate.Value.Date) ||
                            (f.ClassifiedCreateDateTime.HasValue && f.ClassifiedCreateDateTime.Value.Date == selectedSyncDate.Value.Date) ||
                            (f.UpdatedDateTime.HasValue && f.UpdatedDateTime.Value.Date == selectedSyncDate.Value.Date) ||
                            (f.ScanUpdateDateTime.HasValue && f.ScanUpdateDateTime.Value.Date == selectedSyncDate.Value.Date) ||
                            (f.QCUpdateDateTime.HasValue && f.QCUpdateDateTime.Value.Date == selectedSyncDate.Value.Date) ||
                            (f.ClassifiedUpdateDateTime.HasValue && f.ClassifiedUpdateDateTime.Value.Date == selectedSyncDate.Value.Date) ||
                            (f.ClientUpdatedDateTime.HasValue && f.ClientUpdatedDateTime.Value.Date == selectedSyncDate.Value.Date))
                        .Cast<object>();
                }
                else if (tableName == "DispatchedData")
                {
                    queryable = _db.DispatchedData
                        .Where(f => (f.CreateDateTime.HasValue && f.CreateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        || (f.UpdateDateTime.HasValue && f.UpdateDateTime.Value.Date == selectedSyncDate.Value.Date)
                        )
                        .Cast<object>();
                }
                else
                {
                    throw new NotSupportedException($"Filtering for table {tableName} is not implemented.");
                }
            }


            var entities = await queryable
                .ToListAsync();

            var rows = entities
                .Select(entity => entity.GetType()
                    .GetProperties()
                    .ToDictionary(
                        prop => prop.Name,
                        prop => prop.GetValue(entity, null)
                    )
                )
                .ToList();
            if (rows.Count == 0)
            {
                return (true, string.Empty);
            }

            var payload = new
            {
                TableName = tableName,
                Rows = rows
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            //var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = null;

            var syncLog = new SyncLog
            {
                TableName = tableName,
                Operation = SyncOperation.Insert,
                SyncedData = jsonPayload,
                ErrorMessage = null,
                UserID = AppUser.ID,
                SyncDateTime = DatabaseTimeHelper.GetCurrentDatabaseDateTime(_db)
            };

            try
            {
                //var syncResponse = await new APIServices().SyncDataAsync(jsonPayload);
                //var streamData = new MemoryStream(Encoding.UTF8.GetBytes(jsonPayload));
                var syncResponse = await new APIServices().SyncDataInBatchesAsync(tableName,rows, 1000);
                
                if (syncResponse.IsSuccess)
                {
                    syncLog.ErrorMessage = null;
                    syncLog.Status = SyncStatus.OK;
                }
                else
                {
                    syncLog.ErrorMessage = syncResponse.errorMessage;
                    syncLog.Status = SyncStatus.Error;
                }

                var syncLogResult = await new SyncHelper(_db)
                    .WriteSyncLogsAsync(syncLog);
                if (!syncLogResult.isSuccess)
                {
                    return (false, syncLogResult.errorMessage);
                }
                else
                {
                    return (true, string.Empty);
                }
            }
            catch (Exception ex)
            {
                syncLog.ErrorMessage = ex.Message;
                syncLog.Status = SyncStatus.Error;
                var syncLogResult = await new SyncHelper(_db)
                .WriteSyncLogsAsync(syncLog);
                if (!syncLogResult.isSuccess)
                {
                    return (false, syncLogResult.errorMessage);
                }
                else
                {
                    return (true, string.Empty);
                }
            }

        }

    }
}
