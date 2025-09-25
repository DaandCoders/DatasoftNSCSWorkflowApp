

using Microsoft.EntityFrameworkCore;
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.Extensions.Caching.Memory;
using DC.DMS.Services.WorkflowModels;
using DMS.ContextHelper.ViewModels;
using DMS.ContextData;

using DC.DMS.Services.Models;
using static DC.DMS.Services.Enum.WorkflowEnums;
using DMS.DesktopApp.Helpers;
using DC.DMS.Services.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;

namespace DMS.DesktopApp.Helper
{
    public class DirectoryHelper
    {
        private IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;

        public DirectoryHelper(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
            //  fileDetailsHelper = new FileDetailsHelper();
        }

        public async Task<(bool, DCSDirectory?, string?)> InsertUpdateDirectory(DCSDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            (bool, DCSDirectory?, string?) result;
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

        public async Task<(List<FileDirectoryVM>, List<SubDirectoryVM>, List<ImageFileVM>)> GetFilesDetailsWithDirectoriesAsync(int dirID, CallingFor callingFor, int courtID, int fileStatusID)
        {
            List<ImageFileDetail> fileDetails = new List<ImageFileDetail>();
            var userID = AppUser.ID;
            await using var _db = await _dbContext.CreateDbContextAsync();
            var isFlag = _db.ApplicationUsers.Where(x => x.ID == userID).Select(x => x.Flag).FirstOrDefault();
            switch (callingFor)
            {
                case CallingFor.QC:
                    switch (AppDetails.ID)
                    {
                        case 1:
                            fileDetails = await _db.ImageFileDetails
                                                .Include(x => x.SubDirectory)
                                                .ThenInclude(x => x.FileDirectory)
                                                .Include(x => x.SubDirectory.FileDirectory.FileDetail)
                                                .Where(x => x.SubDirectory.FileDirectory.DirectoryID == dirID
                                                && x.Status == Status.Scanned).ToListAsync();
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (fileDetails != null)
            {
                var CaseDirectories = fileDetails.Select(x => new FileDirectoryVM
                {
                    ID = x.SubDirectory.FileDirectory.ID,
                    DirectoryID = x.SubDirectory.FileDirectory.DirectoryID,
                    Name = x.SubDirectory.FileDirectory.Name,
                    Path = x.SubDirectory.FileDirectory.Path,
                    Status = x.SubDirectory.FileDirectory.Status,
                    //CreateBy = x.CreatedBy

                }).DistinctBy(x => x.ID).ToList();
                var SubDirectories = fileDetails.Select(x => new SubDirectoryVM
                {
                    ID = x.SubDirectory.ID,
                    CaseDirectoryID = x.SubDirectory.FileDirectoryID,
                    Name = x.SubDirectory.Name,
                    Path = x.SubDirectory.Path
                }).DistinctBy(x => x.ID).ToList();

                var fileList = fileDetails.Select(x => new ImageFileVM
                {
                    ID = x.ID,
                    FileDirectoryID = x.SubDirectory.FileDirectoryID,
                    SubDirectoryID = x.SubDirectoryID,
                    SerialNo = x.SerialNo,
                    Name = Path.GetFileNameWithoutExtension(x.Path),
                    Path = x.Path,
                    Status = x.Status,
                    QCCreateBy = x.QCCreateBy
                }).OrderBy(x => x.SerialNo).ToList();
                return (CaseDirectories, SubDirectories, fileList);
            }
            else
            {
                return (null, null, null);
            }
        }


        public async Task<List<string>> GetClassificationDoneDirectories()
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.Directories
                .Where(y => y.Status == Status.QCDone || y.Status == Status.None)
                .Select(x => x.Name).ToListAsync();
        }

        public async Task<List<SelectionDirectoryVM>> GetDirectoriesForSelection()
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.Directories.AsNoTracking()
                .Where(x => x.Status == Status.None).Select(x => new SelectionDirectoryVM
                {
                    ID = x.ID,
                    Name = x.Name

                }).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<SelectionCourtVM>> GetMainDirectoriesForSelection(int mainDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.FileDirectories.Include(x => x.FileDetail)
                .Where(x => x.DirectoryID == mainDirectoryID).Select(x => new SelectionCourtVM
                {
                    ID = Convert.ToInt32(x.FileDetail.ID),
                }).Distinct().ToListAsync();
        }

        public async Task<int?> GetRemainingFilesCount(int mainDirectoryID, CallingFor callingFor)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            switch (callingFor)
            {
                case CallingFor.QC:

                    return await _db.FileDirectories.Include(x => x.FileDetail).AsNoTracking()
                        .Where(x => x.DirectoryID == mainDirectoryID && x.Status == Status.Scanned).CountAsync();
                case CallingFor.Scanning:

                    return await _db.FileDirectories.Include(x => x.FileDetail).AsNoTracking()
                        .Where(x => x.DirectoryID == mainDirectoryID && x.Status == Status.FileReceive).CountAsync();
                default:
                    return null;
            }

        }

        public async Task<bool> FileDirectoryQCCompleted(int caseDirectoryID, int userID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var caseDirectory = await _db.FileDirectories.Where(x => x.ID == caseDirectoryID).FirstOrDefaultAsync();
            if (caseDirectory != null)
            {
                caseDirectory.Status = Status.QCDone;
                caseDirectory.QCCreateBy = userID;
                caseDirectory.QCCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();

                _db.FileDirectories.Attach(caseDirectory);
                _db.Entry(caseDirectory).Property(x => x.Status).IsModified = true;
                _db.Entry(caseDirectory).Property(x => x.QCCreateBy).IsModified = true;
                _db.Entry(caseDirectory).Property(x => x.UpdatedDateTime).IsModified = true;
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> SubDirectoryQCCompleted(int subDirectoryID, int userID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var subDirectory = await _db.SubDirectories.Where(x => x.ID == subDirectoryID).FirstOrDefaultAsync();
            if (subDirectory != null)
            {
                subDirectory.Status = Status.QCDone;
                subDirectory.QCCreateBy = userID;
                subDirectory.QCCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();

                _db.SubDirectories.Attach(subDirectory);
                _db.Entry(subDirectory).Property(x => x.Status).IsModified = true;
                _db.Entry(subDirectory).Property(x => x.QCCreateBy).IsModified = true;
                _db.Entry(subDirectory).Property(x => x.QCCreateDateTime).IsModified = true;
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        #region Private
        private async Task<(bool, DCSDirectory?, string?)> InsertRecordAsync(DCSDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var userID = _db.ApplicationUsers.FirstOrDefault(x => x.UserName.Equals(AppUser.CurrentUserName)).ID;
            dir.CreatedBy = userID;
            dir.CreatedDateTime = _db.Database.SqlQueryRaw<DateTime>("SELECT Now()").AsEnumerable().FirstOrDefault();
            _db.Directories.Add(dir);
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

        private async Task<(bool, DCSDirectory?, string?)> UpdateRecordAsync(DCSDirectory dir)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string? errorMessage = null;
            DCSDirectory directory = await _db.Directories.Where(x => x.Path == dir.Path).FirstOrDefaultAsync();
            directory.UpdatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
            var userID = _db.ApplicationUsers.FirstOrDefault(x => x.UserName.Equals(AppUser.CurrentUserName)).ID;
            directory.UpdatedBy = userID;
            directory.FileCount = dir.FileCount;
            directory.SubDirectoryCount = dir.SubDirectoryCount;
            _db.Directories.Attach(directory);
            _db.Entry(directory).Property(x => x.UpdatedBy).IsModified = true;
            _db.Entry(directory).Property(x => x.UpdatedDateTime).IsModified = true;
            _db.Entry(directory).Property(x => x.FileCount).IsModified = true;
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

        #endregion
    }
}
