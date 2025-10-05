using DC.DMS.Services.Models;
using DC.DMS.Services.Models.Main;
using DC.DMS.Services.Models.Masters;
using DC.DMS.Services.WorkflowModels;
using DC.DMS.Services.WorkflowModels.Directories;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.ContextHelper.ViewModels;
using DMS.DesktopApp.Helpers;
using DMS.DesktopApp.Helpers.Translations;
using EFCore.BulkExtensions;
using iText.IO.Image;
using iText.Kernel.Pdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using static DC.DMS.Services.Enum.WorkflowEnums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DMS.DesktopApp.Helper
{
    public class FileDetailHelper
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private readonly ServerDateTimeHelper serverDateTimeHelper;

        public FileDetailHelper(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> DeleteBlankFilesAsync(List<string> file)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            (bool, string?) result;

            for (int i = 0; i < file.Count; i++)
            {
                file[i] = file[i].Replace("\\Delete\\", "\\");
            }

            var fileList = await _db.ImageFileDetails.Where(x => file.Contains(x.Path)).ToListAsync();

            if (fileList.Count > 0)
            {
                _db.ImageFileDetails.RemoveRange(fileList);
                try
                {
                    await _db.SaveChangesAsync();
                    return (true, null);
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
            else
            {
                return (false, "File not found");
            }
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> StatusUpdate(Status status, int fileDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();

            var fileDetailID = await _db.FileDirectories
                .Where(x => x.ID == fileDirectoryID).AsNoTracking()
                .Select(x => x.FileDetailID)
                .FirstOrDefaultAsync();

            var fileDetail = await _db.FileDetails
                .Where(x => x.ID == fileDetailID).Select(x => x).FirstOrDefaultAsync();

            if (fileDetail == null)
            {
                return (false, "file metadata not found");
            }
            fileDetail.Status = status;
            fileDetail.UpdatedBy = AppUser.ID;
            fileDetail.UpdatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();


            _db.FileDetails.Attach(fileDetail);
            _db.Entry(fileDetail).Property(x => x.UpdatedBy).IsModified = true;
            _db.Entry(fileDetail).Property(x => x.UpdatedDateTime).IsModified = true;
            _db.Entry(fileDetail).Property(x => x.Status).IsModified = true;

            try
            {
                await _db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> CheckAndUpdateStatus(int fileDetailID, int fileDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();

            // Mirror decompiled logic
            var subDirectoryList = await _db.SubDirectories
                .Where(x => x.FileDirectoryID == fileDirectoryID)
                .Select(x => x.Status)
                .ToListAsync();

            // Decompiled condition: if count != 2 AND all are Scanned then short‑circuit success
            if (subDirectoryList.Count != 2 && subDirectoryList.All(x => x == Status.Scanned))
            {
                return (true, null);
            }

            var fileDetail = await _db.FileDetails
                .Where(x => x.ID == fileDetailID)
                .Select(x => x)
                .FirstOrDefaultAsync();

            if (fileDetail == null)
            {
                return (false, "file metadata not found");
            }

            fileDetail.Status = status;
            fileDetail.UpdatedBy = AppUser.ID;
            fileDetail.UpdatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();

            _db.FileDetails.Attach(fileDetail);
            _db.Entry(fileDetail).Property(x => x.UpdatedBy).IsModified = true;
            _db.Entry(fileDetail).Property(x => x.UpdatedDateTime).IsModified = true;
            _db.Entry(fileDetail).Property(x => x.Status).IsModified = true;

            try
            {
                await _db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }

        public async Task<List<ImageFileVM>> OnInsertUpdateImageListAsync(List<ImageFileVM> newFileDetails, int userID)
        {
            var newFileDetail = newFileDetails.Where(x => x.ID == 0).FirstOrDefault();
            var currentFileList = await GetFileDetailsAsync(newFileDetail.SubDirectoryID);

            List<ImageFileDetail> newUpdateFileDetailList = new List<ImageFileDetail>();
            int serialNo = 1;
            foreach (var item in newFileDetails)
            {
                ImageFileDetail fileDetail = new ImageFileDetail();
                fileDetail = currentFileList.Where(x => x.ID == item.ID).FirstOrDefault();

                if (fileDetail == null)
                {
                    await using var _db = await _dbContext.CreateDbContextAsync();
                    fileDetail = new ImageFileDetail();
                    // fileDetail.DirectoryID = newFileDetail.DirectoryID;
                    //fileDetail.FileDirectoryID = newFileDetail.FileDirectoryID;
                    fileDetail.SubDirectoryID = newFileDetail.SubDirectoryID;
                    fileDetail.SerialNo = serialNo;
                    fileDetail.Path = newFileDetail.Path;
                    fileDetail.DPI = 0;
                    fileDetail.Dimensions = null;
                    fileDetail.Size = null;
                    fileDetail.PaperSize = null;
                    fileDetail.Status = Status.Scanned;
                    fileDetail.Flag = Flag.None;
                    fileDetail.ScanCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                    fileDetail.ScanCreateBy = userID;
                    newUpdateFileDetailList.Add(fileDetail);
                    _db.ImageFileDetails.Add(fileDetail);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    fileDetail.SerialNo = serialNo;
                    newUpdateFileDetailList.Add(fileDetail);
                }
                serialNo++;

            }
            try
            {

                //For Bulk Operation
                //await _db.BulkInsertAsync(newUpdateFileDetailList, new BulkConfig { SetOutputIdentity = true,  PreserveInsertOrder = true,  });
            }
            catch (Exception ex)
            {

                throw;
            }


            var updateFileList = await GetFileDetailsVMQAAsync(newFileDetail.DirectoryID, newFileDetail.FileDirectoryID, newFileDetail.SubDirectoryID);
            return updateFileList;
        }

        public async Task<List<ImageFileVM>> OnReorderUpdateImageListAsync(int subDirectoryID, List<ImageFileVM> newFileDetails, int userID)
        {
            var currentFileList = await GetFileDetailsAsync(subDirectoryID);

            List<ImageFileDetail> newUpdateFileDetailList = new List<ImageFileDetail>();
            int serialNo = 1;
            await using var _db = await _dbContext.CreateDbContextAsync();
            foreach (var item in newFileDetails)
            {
                ImageFileDetail fileDetail = new ImageFileDetail();
                fileDetail = currentFileList.Where(x => x.ID == item.ID).FirstOrDefault();

                if (fileDetail == null)
                {

                    fileDetail = new ImageFileDetail();
                    fileDetail.SubDirectoryID = subDirectoryID;
                    fileDetail.SerialNo = serialNo;
                    fileDetail.Path = item.Path;
                    fileDetail.DPI = 0;
                    fileDetail.Dimensions = null;
                    fileDetail.Size = null;
                    fileDetail.PaperSize = null;
                    fileDetail.Status = Status.Scanned;
                    fileDetail.Flag = Flag.None;
                    fileDetail.UpdatedDateTime = _db.Database.SqlQueryRaw<DateTime>("SELECT Now()").AsEnumerable().FirstOrDefault();
                    fileDetail.UpdatedBy = userID;
                    newUpdateFileDetailList.Add(fileDetail);
                }
                else
                {
                    fileDetail.SerialNo = serialNo;
                    newUpdateFileDetailList.Add(fileDetail);
                }
                serialNo++;
            }

            newUpdateFileDetailList = newUpdateFileDetailList
                .GroupBy(x => x.Path)
                .Select(g => g.First())
                .ToList();

            await _db.BulkInsertOrUpdateAsync(newUpdateFileDetailList, new BulkConfig { SetOutputIdentity = true, PreserveInsertOrder = true });
            var updateFileList = await GetAllFileDetailsVMAsync(0, 0, subDirectoryID);
            return updateFileList;
        }

        public async Task<bool> OnDeleteUpdateImageListAsync(int fileID, List<ImageFileVM> newFileDetails, int userID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var file = _db.ImageFileDetails.Where(x => x.ID == fileID).First();
            if (file != null)
            {
                file.Flag = Flag.Delete;
                file.UpdatedBy = userID;
                file.UpdatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                _db.ImageFileDetails.Attach(file);
                await _db.SaveChangesAsync();
            }
            int subDirectoryID = newFileDetails.Select(x => x.SubDirectoryID).FirstOrDefault();
            return true;
        }

        public async Task<List<ImageFileDetail>> GetFileDetailsAsync(int subDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.ImageFileDetails
                .Where(x => x.SubDirectoryID == subDirectoryID && x.Flag != Flag.Delete).ToListAsync();
        }

        public async Task<FileDetail?> GetFileDetailsByFileDirectoryAsync(int fileDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var fileDetail = await _db.FileDirectories.AsNoTracking()
                .Include(x => x.FileDetail).ThenInclude(x => x.CreateByUser)
                .Where(x => x.ID == fileDirectoryID && x.Flag != Flag.Delete)
                .Select(x => x.FileDetail)
                .FirstOrDefaultAsync();
            if (fileDetail != null)
                return fileDetail;
            return null;
        }

        public async Task<List<ImageFileVM>> GetAllFileDetailsVMAsync(int directoryID, int caseDirectoryID, int subDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.ImageFileDetails
                .Where(x => x.SubDirectoryID == subDirectoryID
             && x.Flag != Flag.Delete).Select(x => new ImageFileVM
             {
                 ID = x.ID,
                 SubDirectoryID = x.SubDirectoryID,
                 SerialNo = x.SerialNo,
                 Name = Path.GetFileNameWithoutExtension(x.Path),
                 Path = x.Path,
                 Status = x.Status,
             }).OrderBy(x => x.SerialNo).ToListAsync();
        }

        public async Task<List<ImageFileVM>> GetFileDetailsVMQAAsync(int directoryID, int caseDirectoryID, int subDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.ImageFileDetails.Include(x => x.SubDirectory).ThenInclude(x => x.FileDirectory).Where(x => x.SubDirectory.FileDirectory.DirectoryID == directoryID
             && x.SubDirectory.FileDirectory.ID == caseDirectoryID
             && (x.Status == Status.Scanned || x.Status == Status.Classification)
             && x.Flag != Flag.Delete
             && x.SubDirectoryID == subDirectoryID).Select(x => new ImageFileVM
             {
                 ID = x.ID,
                 // DirectoryID = x.DirectoryID,
                 // FileDirectoryID = x.FileDirectoryID,
                 SubDirectoryID = x.SubDirectoryID,
                 SerialNo = x.SerialNo,
                 Name = Path.GetFileNameWithoutExtension(x.Path),
                 Path = x.Path,
                 Status = x.Status,
             }).OrderBy(x => x.SerialNo).ToListAsync();
        }

        public async Task<bool> UpdateImageDT(int fileID, int userID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var fileDetail = await _db.ImageFileDetails.Where(x => x.ID == fileID && x.Flag != Flag.Delete).FirstOrDefaultAsync();
            if (fileDetail != null)
            {
                fileDetail.QCCreateBy = userID;
                //fileDetail.Status = Status.QCDone;
                fileDetail.QCCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                _db.ImageFileDetails.Attach(fileDetail);
                _db.Entry(fileDetail).Property(x => x.UpdatedBy).IsModified = true;
                _db.Entry(fileDetail).Property(x => x.UpdatedDateTime).IsModified = true;
                //_db.Entry(fileDetail).Property(x => x.Status).IsModified = true;
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ImageFileDetail>> GetFileDetails(int subDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.ImageFileDetails
                .Where(x => x.SubDirectoryID == subDirectoryID
                && x.Status == status && x.Flag != Flag.Delete).ToListAsync();
        }

        public async Task<List<ImageFileVM>> UpdateImageListAsync(int subDirectoryID, List<ImageFileVM> newFileDetails, int userID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            List<ImageFileDetail> newUpdateFileDetailList = new List<ImageFileDetail>();
            foreach (var item in newFileDetails)
            {
                ImageFileDetail fileDetail = new ImageFileDetail();

                fileDetail = new ImageFileDetail();
                fileDetail.SubDirectoryID = subDirectoryID;
                fileDetail.SerialNo = item.SerialNo;
                fileDetail.Path = item.Path;
                fileDetail.DPI = 0;
                fileDetail.Dimensions = null;
                fileDetail.Size = null;
                fileDetail.PaperSize = null;
                fileDetail.Status = Status.Scanned;
                fileDetail.Flag = Flag.None;
                fileDetail.UpdatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                fileDetail.UpdatedBy = userID;
                fileDetail.ScanCreateDateTime = fileDetail.UpdatedDateTime;
                fileDetail.ScanCreateBy = userID;
                newUpdateFileDetailList.Add(fileDetail);
            }

            newUpdateFileDetailList = newUpdateFileDetailList
                .GroupBy(x => x.Path)
                .Select(g => g.First())
                .ToList();

            await _db.BulkInsertOrUpdateAsync(newUpdateFileDetailList,
                new BulkConfig
                {
                    SetOutputIdentity = true,
                    PreserveInsertOrder = true,
                    UpdateByProperties = new List<string> { "Path" } // Use Path as the unique key
                }
                );

            var updateFileList = newUpdateFileDetailList
                .Where(x => x.SubDirectoryID == subDirectoryID
             && x.Flag != Flag.Delete).Select(x => new ImageFileVM
             {
                 ID = x.ID,
                 SubDirectoryID = x.SubDirectoryID,
                 SerialNo = x.SerialNo,
                 Name = Path.GetFileNameWithoutExtension(x.Path),
                 Path = x.Path,
                 Status = x.Status,
             }).OrderBy(x => x.SerialNo).ToList();

            return updateFileList;
        }

        public async Task<List<ImageFileDetail>> UpdateImageFilesStatus(int subDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var fileDeatailList = await GetFileDetails(subDirectoryID, Status.Scanned);
            if (fileDeatailList != null)
            {
                foreach (var fileDetail in fileDeatailList)
                {
                    fileDetail.Status = Status.QCDone;
                    fileDetail.QCCreateBy = AppUser.ID;
                    fileDetail.QCCreateDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                }
                var bulkConfig = new BulkConfig { PropertiesToIncludeOnUpdate = new List<string> { nameof(ImageFileDetail.Status), nameof(ImageFileDetail.QCCreateBy), nameof(ImageFileDetail.QCCreateDateTime) } };
                await _db.BulkUpdateAsync(fileDeatailList, bulkConfig);
                return fileDeatailList;
            }
            else
            {
                return new List<ImageFileDetail>();
            }
        }

        public async Task<int> GetImageCountOfFiles(int subDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.ImageFileDetails
                          .Where(x => x.SubDirectoryID == subDirectoryID && x.Flag != Flag.Delete)
                          .CountAsync();
        }

        #region Private

        #endregion


        public async Task<bool> FilesStatusChangeAfterDispatchAsync(int subDirectoryID, int caseDirectoryID, Status status)
        {
            string? errorMessage = null;
            await using var _db = await _dbContext.CreateDbContextAsync();

            var fileDetailList = _db.ImageFileDetails.Include(x => x.SubDirectory)
                .Where(x => x.SubDirectoryID == subDirectoryID
                && x.SubDirectory.FileDirectoryID == caseDirectoryID && x.Flag != Flag.Delete);

            foreach (var fileDetail in fileDetailList)
            {
                fileDetail.Status = status;
            }
            try
            {
                var bulkConfig = new BulkConfig { PropertiesToIncludeOnUpdate = new List<string> { nameof(FileDetail.Status) } };
                _db.BulkUpdate(fileDetailList, bulkConfig);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public async Task<bool> FileDirectoryDispatchDoneAsync(int fileDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string? errorMessage = null;

            FileDirectory fileDirectory = _db.FileDirectories
                .Where(x => x.ID == fileDirectoryID && x.Flag != Flag.Delete).FirstOrDefault();

            if (fileDirectory == null)
            {
                errorMessage = "File Directory not found.";
                return false;
            }

            fileDirectory.Status = Status.Dispatched;

            _db.FileDirectories.Attach(fileDirectory);
            _db.Entry(fileDirectory).Property(x => x.Status).IsModified = true;

            try
            {
                await _db.SaveChangesAsync();

                var fileDetails = _db.FileDetails
                     .Where(x => x.ID == fileDirectory.FileDetailID && x.Flag != Flag.Delete)
                     .FirstOrDefaultAsync();

                if (fileDetails != null)
                {
                    fileDetails.Result.Status = Status.Dispatched;
                    _db.FileDetails.Attach(fileDetails.Result);
                    _db.Entry(fileDetails.Result).Property(x => x.Status).IsModified = true;
                    await _db.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public async Task SubDirectoryDispatchDoneAsync(int subDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string? errorMessage = null;
            SubDirectory subDirectoryStatusSave = _db.SubDirectories.Where(x => x.ID == subDirectoryID && x.Flag != Flag.Delete).FirstOrDefault();
            subDirectoryStatusSave.Status = Status.Dispatched;
            _db.SubDirectories.Attach(subDirectoryStatusSave);
            _db.Entry(subDirectoryStatusSave).Property(x => x.Status).IsModified = true;
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public async Task<List<SelectionFileDetailVM>> GetRecivingDateForSelection()
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var result = await _db.FileDetails.AsNoTracking()
           .Where(x => x.Status == Status.FileReceive && x.Flag != Flag.Delete)
           .Distinct()
           .Select(x => new SelectionFileDetailVM
           {
               ID = Convert.ToInt32(x.ID),
               CreateDate = x.CreatedDateTime.Value.ToString("dd-MM-yyyy")
           }).Distinct().ToListAsync();

            var finalResult = result.DistinctBy(x => x.CreateDate).ToList();
            return finalResult;

        }

        public async Task<List<FileDetail>> GetCaseDetailsList(Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            switch (AppDetails.ID)
            {
                case 1:
                    try
                    {
                        // var status = 7;
                        return await _db.FileDetails
                            .Include(x => x.Department)
                            .Where(x => x.Status == status && x.Flag != Flag.Delete).ToListAsync();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                default:
                    return await _db.FileDetails.Include(x => x.Department).Where(x => x.Status == status && x.Flag != Flag.Delete).ToListAsync();
            }
        }

        public async Task DirectoriesDispatchDoneAsync(int directoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            string? errorMessage = null;
            var caseDirectoriesdispatchCount = _db.FileDirectories.Where(x => x.DirectoryID == directoryID && x.Status != Status.Dispatched && x.Flag != Flag.Delete).Count();
            if (caseDirectoriesdispatchCount == 0)
            {
                DCSDirectory directoryStatusSave = _db.Directories.Where(x => x.ID == directoryID).FirstOrDefault();
                directoryStatusSave.Status = Status.Dispatched;
                _db.Directories.Attach(directoryStatusSave);
                _db.Entry(directoryStatusSave).Property(x => x.Status).IsModified = true;
                try
                {
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }
            }

        }

        public int ReceivedFilesCount(int? userID=null , Status? status=null)
        {
            using var _db = _dbContext.CreateDbContext();
            var query = _db.FileDetails.AsNoTracking()
                .Where(x => x.Flag != Flag.Delete);

            if (userID.HasValue)
            {
                switch (status)
                {

                    case Status.Dispatched:
                        query = query.Where(x => x.CreateByUser.ID == userID.Value && x.Status==Status.Dispatched);
                        break;
                    case Status.FileReceive:
                        query = query.Where(x => x.CreateByUser.ID == userID.Value && x.Status == Status.FileReceive);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                query.Where(x => x.Status == Status.FileReceive);
            }

                return query.Count();
        }
        private int DispatchCount(int? userID = null, Status? status = null)
        {
            using var _db = _dbContext.CreateDbContext();
            var query = _db.DispatchedData.AsNoTracking()
                .Where(x => x.Flag != Flag.Delete);

            if (userID.HasValue)
            {
                query = query.Where(x => x.CreateByUser.ID == userID.Value && x.Status == Status.Dispatched);
            }
            else
            {
                query.Where(x => x.Status == Status.Dispatched);
            }

            return query.Count();
        }

        // Generic helper for FileDirectory status counts with optional user filter (by FileDetail creator)
        private int CountFileDirectories(Status status, int? userID)
        {
            using var _db = _dbContext.CreateDbContext();

            var query = _db.FileDirectories.AsNoTracking()
                .Where(x => x.Flag != Flag.Delete);

            if (userID.HasValue)
            {
                // Filter by creator of underlying FileDetail
                switch (status)
                {
                    
                    case Status.QCDone:
                        query = query.Where(x => x.QCCreateByUser.ID == userID.Value);
                        break;
                    
                    case Status.Dispatched:
                        break;
                    case Status.FileReceive:
                        query = query.Where(x => x.CreateByUser.ID == userID.Value);
                        break;
                    case Status.Scanned:
                        query = query.Where(x => x.ScanCreateByUser.ID == userID.Value);
                        break;
                    
                    default:
                        break;
                }
                
            }
            else
            {
                switch (status)
                {

                    case Status.QCDone:
                        query = query.Where(x => x.Status==Status.QCDone);
                        break;

                    case Status.Dispatched:
                        break;
                    case Status.FileReceive:
                        query = query.Where(x => x.Status == Status.FileReceive);
                        break;
                    case Status.Scanned:
                        query = query.Where(x => x.Status == Status.Scanned);
                        break;

                    default:
                        break;
                }
            }
                return query.Count();
        }

        public int ScannedFilesCount(int? userID = null) => CountFileDirectories(Status.Scanned, userID);
        public int QCFilesCount(int? userID = null) => CountFileDirectories(Status.QCDone, userID);
        public int DispatchFilesCount(int? userID = null) => DispatchCount(userID, Status.Dispatched);
        public int ClientQCFilesCount(int? userID = null) => CountFileDirectories(Status.QCDoneByClient, userID);
    }
}

