using DC.DMS.Services.Models.Log;
using DMS.Context.Data;

namespace DMS.API.WindowsServices.Helper
{
    internal class SyncHelper
    {
        private readonly ApplicationDbContext _db;

        public SyncHelper(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<(bool isSuccess, string? errorMessage)> WriteSyncLogsAsync(SyncLog syncLogs)
        {
            try
            {
                _db.SyncLogs.AddAsync(syncLogs);
                await _db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
