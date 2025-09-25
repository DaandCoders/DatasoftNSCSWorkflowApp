using DC.DMS.Services.Models;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using EFCore.BulkExtensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using static DC.DMS.Services.Enum.WorkflowEnums;


namespace DMS.DesktopApp.Helper
{
    public class MainDataHelper
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;

        public MainDataHelper(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }

        public async Task<(bool, string?)> InsertUpdateDQCClassificationAsync(int caseDirectoryID, int subDirectoryID)
        {
            try
            {
                await using var _db = await _dbContext.CreateDbContextAsync();
                var fileDetailList = await _db.ImageFileDetails
                    .Where(x => x.SubDirectory.FileDirectoryID == caseDirectoryID && x.SubDirectoryID == subDirectoryID)
                    .ToListAsync();
                foreach (var fileDetail in fileDetailList)
                {
                    fileDetail.Status = Status.QCDoneByClient;
                    fileDetail.UpdatedByClient = AppUser.ID;
                    fileDetail.ClientUpdatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                }
                var bulkConfig = new BulkConfig { PropertiesToIncludeOnUpdate = new List<string> { nameof(ImageFileDetail.Status) } };
                await _db.BulkUpdateAsync(fileDetailList, bulkConfig);
                return (true, null);
            }
            catch (Exception ex)
            {

                return (false, ex.Message);
            }
        }

     

        public async Task<(bool, int)> IsFileCompleteInQCAsync(int directoryID, int caseID, int subDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            int remainingFileCount = await _db.ImageFileDetails
                .Where(x => x.SubDirectory.FileDirectory.DirectoryID == directoryID
             && x.SubDirectory.FileDirectoryID == caseID
             && x.SubDirectoryID == subDirectoryID
             && x.Flag != Flag.Delete
             && x.Status != Status.QCDone).CountAsync();
            if (remainingFileCount > 0)
            {
                return (false, remainingFileCount);
            }
            else
            {
                return (true, 0);
            }
        }

        public async Task<(bool, int)> IsCaseDirectoryCompleteInQCAsync(int directoryID, int caseID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            int remainingFileCount = await _db.SubDirectories.Include(x=>x.FileDirectory)
                .Where(x => x.FileDirectory.DirectoryID == directoryID
             && x.FileDirectoryID == caseID
             && x.Status != Status.QCDone).CountAsync();

            if (remainingFileCount > 0)
            {
                return (false, remainingFileCount);
            }
            else
            {
                return (true, 0);
            }
        }

        public async Task<(bool, int)> IsCaseDirectoryCompleteInClassificationAsync(int directoryID, int caseID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            int remainingFileCount = await _db.SubDirectories.Include(x=>x.FileDirectory).Where(x => x.FileDirectory.DirectoryID == directoryID
             && x.FileDirectoryID == caseID
             && x.Status != Status.Classification).CountAsync();
            var remainingFileList = await _db.SubDirectories.Include(x=>x.FileDirectory).Where(x => x.FileDirectory.DirectoryID == directoryID
             && x.FileDirectoryID == caseID
             && x.Status != Status.Classification).Select(x => x.Name).ToListAsync();
            //if(remainingFileList. == "B Files")
            if (remainingFileList.Contains("B FILE") || remainingFileList.Contains("PAPER BOOK") || remainingFileList.Contains("OTHER FILE"))
            {
                remainingFileCount = remainingFileCount - remainingFileCount;
                if (remainingFileCount > 0)
                {
                    return (false, remainingFileCount);
                }
            }
            return (true, 0);
        }

       
        #region Private
      

        #endregion
    }
}
