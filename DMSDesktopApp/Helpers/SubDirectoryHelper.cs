using DC.DMS.Services.Models;
using DC.DMS.Services.ViewModels;
using DC.DMS.Services.WorkflowModels.Directories;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Helper
{
    public class SubDirectoryHelper
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;

        public SubDirectoryHelper(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache; 
            _translationService = translationService;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }

        public async Task<(bool, SubDirectory?, string?)> InsertUpdateDirectory(SubDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            (bool, SubDirectory?, string?) result;
            var IsFileExists = await _db.Directories.AnyAsync(x => x.Path == dir.Path);
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

        public async Task<List<DropDownHelper>> GetSubDirectoriesList(int fileDirectoryID, CallingFor callingFor)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            switch (callingFor)
            {
                case CallingFor.QC:
                    return await _db.SubDirectories.AsNoTracking()
               .Where(x => x.FileDirectoryID == fileDirectoryID && x.Status == Status.Scanned)
               .Select(x => new DropDownHelper
               {
                   ID = x.ID,
                   Name = x.Name,
               }).ToListAsync();

                case CallingFor.DepartmentQC:
                    return await _db.SubDirectories.AsNoTracking()
               .Where(x => x.FileDirectoryID == fileDirectoryID && x.Status == Status.QCDone)
               .Select(x => new DropDownHelper
               {
                   ID = x.ID,
                   Name = x.Name,
               }).ToListAsync();

                case CallingFor.Scanning:
                    return await _db.SubDirectories.AsNoTracking()
                .Where(x => x.FileDirectoryID == fileDirectoryID && x.Status == Status.FileReceive)
                .Select(x => new DropDownHelper
                {
                    ID = x.ID,
                    Name = x.Name,
                }).ToListAsync();

                default:
                    return new List<DropDownHelper>();
            }

        }

        #region Private
        private async Task<(bool, SubDirectory?, string?)> InsertRecordAsync(SubDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            dir.ScanCreateDateTime = _db.Database.SqlQueryRaw<DateTime>("SELECT Now()").AsEnumerable().FirstOrDefault();
            var userID = _db.ApplicationUsers.FirstOrDefault(x => x.UserName.Equals(AppUser.CurrentUserName)).ID;
            dir.ScanCreateBy = userID;
            _db.SubDirectories.Add(dir);

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

        private async Task<(bool, SubDirectory?, string?)> UpdateRecordAsync(SubDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string? errorMessage = null;
            SubDirectory directory = await _db.SubDirectories.Where(x => x.Path == dir.Path).FirstOrDefaultAsync();
            directory.UpdatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
            var userID = _db.ApplicationUsers.FirstOrDefault(x => x.UserName.Equals(AppUser.CurrentUserName)).ID;
            directory.UpdatedBy = userID;
            directory.FileCount = dir.FileCount;
            _db.SubDirectories.Attach(directory);
            _db.Entry(directory).Property(x => x.UpdatedBy).IsModified = true;
            _db.Entry(directory).Property(x => x.UpdatedDateTime).IsModified = true;
            _db.Entry(directory).Property(x => x.FileCount).IsModified = true;
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

        #endregion
    }
}
