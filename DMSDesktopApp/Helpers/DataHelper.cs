using DC.DMS.Services.Models;
using DC.DMS.Services.WorkflowModels;
using DC.DMS.Services.WorkflowModels.Directories;
using DMS.Context.Data;
using DMS.ContextData;
using DMS.ContextHelper.ViewModels;
using DMS.DesktopApp.Helper;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Helpers
{
    public class DataHelper
    {
        private IDbContextFactory<ApplicationDbContext> _dbContext;
        private ServerDateTimeHelper ServerDateTimeHelper;
        public DataHelper(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
            ServerDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> ChangesStatusByClient(int fileDirectoryID, int subDirectotyID, Status status, int batchID = 0)
        {
            try
            {
                switch (status)
                {
                    case Status.None:
                        break;
                    case Status.RejectedInDispatch:
                        await RejectInDispatch(subDirectotyID, fileDirectoryID, batchID);
                        break;
                    case Status.FileReceive:
                        await RejectDueToMetadata(subDirectotyID, fileDirectoryID, batchID);
                        break;
                    case Status.RejectedInScanning:
                        await RejectInScan(subDirectotyID, fileDirectoryID, batchID);
                        break;
                    case Status.QCDoneByClient:
                        await QCDoneByClient(subDirectotyID, fileDirectoryID, batchID);
                        break;
                    case Status.RejectedInQC:
                        await RejectedInQC(subDirectotyID, fileDirectoryID);
                        break;
                    default:
                        break;
                }

                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> RejectDueToMetadata(int subDirectotyID, int fileDirectoryID, int batchID)
        {
            #region ImageFileDetails update
            await UpdateStatusFileDetail(subDirectotyID, fileDirectoryID, Status.RejectedInQC);
            #endregion
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusFileDetail(int subDirectotyID, int fileDirectoryID, Status status)
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
            fileDetail.UpdatedByClient = AppUser.ID;
            fileDetail.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();


            _db.FileDetails.Attach(fileDetail);
            _db.Entry(fileDetail).Property(x => x.UpdatedByClient).IsModified = true;
            _db.Entry(fileDetail).Property(x => x.ClientUpdatedDateTime).IsModified = true;
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

        private async Task<(bool IsSuccess, string? ErrorMessage)> RejectInScan(int subDirectotyID, int fileDirectoryID, int batchID)
        {
            #region  Remove Dispatch
            await RemoveDispatchData(subDirectotyID, Status.QCDone);
            #endregion

            #region  Remove Image FileDetails
            await RemoveImageFileDetails(subDirectotyID, fileDirectoryID, Status.QCDone);
            #endregion

            #region  Remove Sub Directory
            await RemoveDirectory(subDirectotyID, fileDirectoryID, Status.QCDone);
            #endregion

            #region Update File Detail
            await UpdateStatusBatchFileDetail(fileDirectoryID, Status.FileReceive);
            #endregion

            #region  Remove File Directory
            await RemoveFileDirectory(fileDirectoryID, Status.RejectedInScanning);
            #endregion
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusBatchFileDetail(int fileDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var fileDetailID = await _db.FileDirectories
                .Where(x => x.ID == fileDirectoryID)
                .Select(x => x.FileDetailID)
                .FirstOrDefaultAsync();
            if (fileDetailID != 0)
            {
                var fileDetail = await _db.FileDetails
                    .Where(x => x.ID == fileDetailID)
                    .FirstOrDefaultAsync();
                if (fileDetail != null)
                {
                    fileDetail.Status = status;
                    fileDetail.UpdatedByClient = AppUser.ID;
                    fileDetail.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();
                    _db.FileDetails.Attach(fileDetail);
                    _db.Entry(fileDetail).Property(x => x.Status).IsModified = true;
                    _db.Entry(fileDetail).Property(x => x.UpdatedByClient).IsModified = true;
                    _db.Entry(fileDetail).Property(x => x.ClientUpdatedDateTime).IsModified = true;
                    try
                    {
                        await _db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return (false, ex.Message);
                    }
                }
            }
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> RemoveDispatchData(int subDirectotyID, Status qCDone)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var dispatchData = await _db.DispatchedData
                .Where(x => x.ID == subDirectotyID)
                .FirstOrDefaultAsync();
            if (dispatchData != null)
            {
                try
                {
                    _db.DispatchedData.Remove(dispatchData);
                    await _db.SaveChangesAsync();

                    if (File.Exists(dispatchData.FilePath))
                    {
                        File.Delete(dispatchData.FilePath);
                    }
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> RemoveFileDirectory(int fileDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            FileDirectory? fileDirectory = new FileDirectory();
            var subDirectoryList = await _db.SubDirectories
                .Where(x => x.FileDirectoryID == fileDirectoryID)
                .ToListAsync();
            if (subDirectoryList.Count != 0)
            {
                return (true, null);
            }

            fileDirectory = await _db.FileDirectories.Where(x => x.ID == fileDirectoryID).FirstOrDefaultAsync();
            if (fileDirectory != null)
            {
                _db.Remove(fileDirectory);
                await _db.SaveChangesAsync();
                if (Directory.Exists(fileDirectory.Path))
                {
                    Directory.Delete(fileDirectory.Path);
                }
            }
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> RemoveDirectory(int subDirectotyID, int fileDirectoryID, Status qCDone)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var subDirectory = await _db.SubDirectories.Where(x => x.ID == subDirectotyID).FirstOrDefaultAsync();
            if (subDirectory != null)
            {
                _db.Remove(subDirectory);
                await _db.SaveChangesAsync();

                if (Directory.Exists(subDirectory.Path))
                {
                    Directory.Delete(subDirectory.Path);
                }
            }
            return (true, null);

        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> RemoveImageFileDetails(int subDirectotyID, int fileDirectoryID, Status qCDone)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var imageFileDetails = await _db.ImageFileDetails
                .Where(x => x.SubDirectoryID == subDirectotyID).ToListAsync();
            try
            {
                _db.RemoveRange(imageFileDetails); // Fix: Removed incorrect type argument and used the variable directly.
                await _db.SaveChangesAsync();
                var imageFiles = imageFileDetails.Select(x => x.Path).ToList();

                foreach (var file in imageFiles)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file); // Delete the raw file from the disk
                    }
                    string cleanPath = file.Replace("Raw", "Clean");

                    if (File.Exists(cleanPath))
                    {
                        File.Delete(cleanPath); // Delete the clean file from the disk
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> RejectInDispatch(int subDirectotyID, int fileDirectoryID, int batchID)
        {
            #region ImageFileDetails update
            await UpdateStatusImageFileDetails(subDirectotyID, fileDirectoryID, Status.QCDone);
            #endregion

            #region Sub Directory Update
            await UpdateStatusSubDirectory(subDirectotyID, fileDirectoryID, Status.QCDone);
            #endregion

            #region File Directory Update
            await UpdateStatusFileDirectory(subDirectotyID, fileDirectoryID, Status.QCDone);
            #endregion
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> QCDoneByClient(int subDirectotyID, int fileDirectoryID, int batchID = 0)
        {
            if (batchID != 0)
            {
                await UpdateBatchWise(batchID, fileDirectoryID, subDirectotyID, Status.QCDoneByClient);
            }
            else
            {
                #region ImageFileDetails update
                await UpdateStatusImageFileDetails(subDirectotyID, fileDirectoryID, Status.QCDoneByClient);
                #endregion

                #region Sub Directory Update
                await UpdateStatusSubDirectory(subDirectotyID, fileDirectoryID, Status.QCDoneByClient);
                #endregion

                #region File Directory Update
                await UpdateStatusFileDirectory(subDirectotyID, fileDirectoryID, Status.QCDoneByClient);
                #endregion
            }


            return (true, null);

        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> RejectedInQC(int subDirectotyID, int fileDirectoryID)
        {
            #region ImageFileDetails update
            await UpdateStatusImageFileDetails(subDirectotyID, fileDirectoryID, Status.RejectedInQC);
            #endregion

            #region Sub Directory Update
            await UpdateStatusSubDirectory(subDirectotyID, fileDirectoryID, Status.RejectedInQC);
            #endregion

            #region File Directory Update
            await UpdateStatusFileDirectory(subDirectotyID, fileDirectoryID, Status.RejectedInQC);
            #endregion

            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateBatchWise(int batchID, int fileDirectoryID, int subDirectotyID, Status status)
        {
            #region ImageFileDetails update
            await UpdateStatusBatchImageFileDetail(batchID, Status.QCDoneByClient);
            #endregion

            #region Sub Directory Update
            await UpdateStatusBatchDirectory(batchID, Status.QCDoneByClient);
            #endregion

            #region File Directory Update batchwise
            await UpdateStatusBatchFileDirectory(batchID, fileDirectoryID, status);
            #endregion

            #region Update status for Directory
            await UpdateStatusDirectory(batchID, status);
            #endregion
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusDirectory(int batchID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var directory = await _db.Directories
                 .Where(x => x.ID == batchID && x.Status == Status.Dispatched)
                 .FirstOrDefaultAsync();
            if (directory != null)
            {
                directory.Status = status;
                directory.UpdatedByClient = AppUser.ID;
                directory.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();
                _db.Directories.Attach(directory);
                _db.Entry(directory).Property(x => x.Status).IsModified = true;
                _db.Entry(directory).Property(x => x.UpdatedByClient).IsModified = true;
                _db.Entry(directory).Property(x => x.ClientUpdatedDateTime).IsModified = true;

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusBatchDirectory(int batchID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            //SubDirectory isSubDirectoryExists = new SubDirectory();
            var subDirectoryList = await _db.SubDirectories.Include(x => x.FileDirectory)
                 .Where(x => x.FileDirectory.DirectoryID == batchID && x.Status == Status.Dispatched)
                 .ToListAsync();

            foreach (var subDirectory in subDirectoryList)
            {
                subDirectory.Status = status;
                subDirectory.UpdatedByClient = AppUser.ID;
                subDirectory.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();

                _db.SubDirectories.Attach(subDirectory);
                _db.Entry(subDirectory).Property(x => x.Status).IsModified = true;
                _db.Entry(subDirectory).Property(x => x.UpdatedByClient).IsModified = true;
                _db.Entry(subDirectory).Property(x => x.ClientUpdatedDateTime).IsModified = true;

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusBatchFileDirectory(int batchID, int fileDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var fileDirectory = await _db.FileDirectories
                .Where(x => x.ID == fileDirectoryID && x.DirectoryID == batchID && x.Status == Status.Dispatched)
                .ToListAsync();

            foreach (var file in fileDirectory)
            {
                file.Status = status;
                file.UpdatedByClient = AppUser.ID;
                file.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();

                _db.FileDirectories.Attach(file);
                _db.Entry(file).Property(x => x.Status).IsModified = true;
                _db.Entry(file).Property(x => x.UpdatedByClient).IsModified = true;
                _db.Entry(file).Property(x => x.ClientUpdatedDateTime).IsModified = true;

                try
                {
                    await _db.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }

            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusBatchImageFileDetail(int batchID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();

            var subDirectoryIDList = await _db.SubDirectories
                .Include(x => x.FileDirectory)
                .AsNoTracking()
                .Where(x => x.FileDirectory.DirectoryID == batchID && x.Status == Status.Dispatched)
                .Select(x => x.ID)
                .ToListAsync();


            ImageFileDetail isImageFileDetailExists = new ImageFileDetail();
            var imageFileDetails = await _db.ImageFileDetails
                .Where(x => subDirectoryIDList.Contains(x.SubDirectoryID)).ToListAsync();

            foreach (var imageFileDetail in imageFileDetails)
            {
                imageFileDetail.Status = status;
                imageFileDetail.UpdatedByClient = AppUser.ID;
                imageFileDetail.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();

                _db.ImageFileDetails.Attach(imageFileDetail);
                _db.Entry(imageFileDetail).Property(x => x.Status).IsModified = true;
                _db.Entry(imageFileDetail).Property(x => x.UpdatedByClient).IsModified = true;
                _db.Entry(imageFileDetail).Property(x => x.ClassifiedUpdateDateTime).IsModified = true;

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
            return (true, null);
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusSubDirectory(int subDirectotyID, int fileDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            SubDirectory subDirectory = new SubDirectory();
            subDirectory = await _db.SubDirectories
                .Where(x => x.FileDirectoryID == fileDirectoryID && x.ID == subDirectotyID)
                .FirstOrDefaultAsync();

            if (subDirectory != null)
            {
                subDirectory.Status = status;
                subDirectory.UpdatedByClient = AppUser.ID;
                subDirectory.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();

                _db.SubDirectories.Attach(subDirectory);
                _db.Entry(subDirectory).Property(x => x.Status).IsModified = true;
                _db.Entry(subDirectory).Property(x => x.UpdatedByClient).IsModified = true;
                _db.Entry(subDirectory).Property(x => x.ClientUpdatedDateTime).IsModified = true;


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
                return (false, "No File Found.");
            }
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusFileDirectory(int subDirectoryID, int fileDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            FileDirectory? fileDirectory = new FileDirectory();
            var subDirectoryList = await _db.SubDirectories
                .Where(x => x.FileDirectoryID == fileDirectoryID)
                .Select(x => x.Status)
                .ToListAsync();
            if (subDirectoryList.Any(x => x != status))
            {
                return (true, null);
            }
            fileDirectory = await _db.FileDirectories.Where(x => x.ID == fileDirectoryID).FirstOrDefaultAsync();
            if (fileDirectory != null)
            {
                fileDirectory.Status = status;
                fileDirectory.UpdatedByClient = AppUser.ID;
                fileDirectory.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();

                _db.FileDirectories.Attach(fileDirectory);
                _db.Entry(fileDirectory).Property(x => x.Status).IsModified = true;
                _db.Entry(fileDirectory).Property(x => x.UpdatedByClient).IsModified = true;
                _db.Entry(fileDirectory).Property(x => x.ClientUpdatedDateTime).IsModified = true;

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
                return (false, "No File Found for Opening in QC");
            }
        }

        private async Task<(bool IsSuccess, string? ErrorMessage)> UpdateStatusImageFileDetails(int subDirectotyID, int fileDirectoryID, Status status)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            ImageFileDetail isImageFileDetailExists = new ImageFileDetail();
            var imageFileDetails = await _db.ImageFileDetails
                .Where(x => x.SubDirectoryID == subDirectotyID).ToListAsync();
            foreach (var imageFileDetail in imageFileDetails)
            {
                imageFileDetail.Status = status;
                imageFileDetail.UpdatedByClient = AppUser.ID;
                imageFileDetail.ClientUpdatedDateTime = await ServerDateTimeHelper.GetCurrentDateTimeAsync();

                _db.ImageFileDetails.Attach(imageFileDetail);
                _db.Entry(imageFileDetail).Property(x => x.Status).IsModified = true;
                _db.Entry(imageFileDetail).Property(x => x.UpdatedByClient).IsModified = true;
                _db.Entry(imageFileDetail).Property(x => x.ClassifiedUpdateDateTime).IsModified = true;

                try
                {
                    await _db.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    return (false, ex.Message);
                }
            }
            return (true, null);
        }
    }
}
