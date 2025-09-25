using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace DMS.DesktopApp.Helpers
{
    public class DispatchPDF
    {
        private IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;

        public DispatchPDF(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }

        public async Task<(bool isSuccess, string? Path)> GetFilePath(int subDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var filePath = await _db.DispatchedData
                .Where(x => x.SubDirectoryID == subDirectoryID)
                .AsNoTracking()
                .Select(x => x.FilePath)
                .FirstOrDefaultAsync();
            if (string.IsNullOrEmpty(filePath))
            {
                return (false, null);
            }
            return (true, filePath);
        }

    }
}
