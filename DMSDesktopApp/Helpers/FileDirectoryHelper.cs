using DC.DMS.Services.ViewModels;
using DC.DMS.Services.WorkflowModels.Directories;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Dispatch;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.IO;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Helper
{
    public class FileDirectoryHelper
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;

        public FileDirectoryHelper(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }

        public async Task<(bool, FileDirectory?, string?)> InsertUpdateDirectory(FileDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            (bool, FileDirectory?, string?) result;
            var IsFileExists = await _db.FileDirectories.AnyAsync(x => x.Path == dir.Path);
            if (!IsFileExists)
            {
                result = await InsertRecordAsync(dir);
            }
            else
            {
                result = await UpdateRecordAsync(dir);
            }
            if (result.Item1)
                return (true, result.Item2, null);
            else
                return (false, null, result.Item3);
        }

         #region Private
        private async Task<(bool, FileDirectory?, string?)> InsertRecordAsync(FileDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            dir.ScanCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
            var userID = _db.ApplicationUsers.FirstOrDefault(x => x.UserName.Equals(AppUser.CurrentUserName)).ID;
            dir.ScanCreateBy = userID;
            dir.ScanCreateDateTime = _db.Database.SqlQueryRaw<DateTime>("SELECT Now()").AsEnumerable().FirstOrDefault();
            _db.FileDirectories.Add(dir);

            try
            {
                await _db.SaveChangesAsync();
                return (true, dir, null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        private async Task<(bool, FileDirectory?, string?)> UpdateRecordAsync(FileDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string? errorMessage = null;
            FileDirectory directory = await _db.FileDirectories.Where(x => x.Path == dir.Path).FirstOrDefaultAsync();
            directory.UpdatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
            var userID = _db.ApplicationUsers.FirstOrDefault(x => x.UserName.Equals(AppUser.CurrentUserName)).ID;
            directory.UpdatedBy = userID;
            directory.SubDirectoryCount = dir.SubDirectoryCount;
            _db.FileDirectories.Attach(directory);
            _db.Entry(directory).Property(x => x.UpdatedBy).IsModified = true;
            _db.Entry(directory).Property(x => x.UpdatedDateTime).IsModified = true;
            _db.Entry(directory).Property(x => x.SubDirectoryCount).IsModified = true;
            try
            {
                await _db.SaveChangesAsync();
                return (true, directory, errorMessage);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return (false, null, errorMessage);
            }
        }

        public async Task<List<DropDownHelper>> GetFileDirectories(int directoryID, CallingFor callingFor)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            switch (callingFor)
            {
                case CallingFor.QC:
                    return await _db.FileDirectories.AsNoTracking()
                        .Where(x => x.DirectoryID == directoryID && x.Status == Status.Scanned && x.Flag != Flag.Delete)
                        .Select(x => new DropDownHelper
                        {
                            ID = x.ID,
                            Name = x.Name
                        })
                        .OrderBy(x => x.Name).ToListAsync();

                case CallingFor.Scanning:
                    return await _db.FileDirectories.AsNoTracking()
                        .Where(x => x.DirectoryID == directoryID && x.Status == Status.FileReceive && x.Flag != Flag.Delete)
                        .Select(x => new DropDownHelper
                        {
                            ID = x.ID,
                            Name = x.Name
                        })
                        .OrderBy(x => x.Name).ToListAsync();

                case CallingFor.Dipatch:
                    return await _db.FileDirectories.AsNoTracking()
                               .Where(x => x.DirectoryID == directoryID 
                               && x.Status == Status.QCDone 
                               && x.Flag != Flag.Delete)
                               .Select(x => new DropDownHelper
                               {
                                   ID = x.ID,
                                   Name = x.Name,
                               }).ToListAsync();
                default:
                    return new List<DropDownHelper>();
            }

        }

        #endregion
    }
}
