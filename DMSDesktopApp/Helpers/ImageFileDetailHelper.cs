using DC.DMS.Services.Models;
using DC.DMS.Services.ViewModels;
using DMS.Context.Data;
using DMS.ContextHelper.ViewModels;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Helpers
{
    public class ImageFileDetailHelper
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;

        public ImageFileDetailHelper(IDbContextFactory<ApplicationDbContext> dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _cache = cache;
            _translationService = translationService;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }

        public async Task<List<ImageFileVM>> GetImageFiles(int subDirectoryID, CallingFor callingFor)
        {
            List<ImageFileVM> fileDetails = new List<ImageFileVM>();
            await using var _db = await _dbContext.CreateDbContextAsync();
            switch (callingFor)
            {
                case CallingFor.QC:
                    fileDetails = await _db.ImageFileDetails.AsNoTracking()
                        .Where(x => x.SubDirectoryID == subDirectoryID && x.Status == Status.Scanned && x.Flag != Flag.Delete)
                        .Select(x => new ImageFileVM
                        {
                            ID = x.ID,
                            SubDirectoryID = x.SubDirectoryID,
                            SerialNo = x.SerialNo,
                            Name = Path.GetFileNameWithoutExtension(x.Path),
                            Path = x.Path,
                            Status = x.Status,
                            Flag = x.Flag
                        }).OrderBy(x=>x.SerialNo).ToListAsync();
                    break;

                case CallingFor.DepartmentQC:
                    fileDetails = await _db.ImageFileDetails.AsNoTracking()
                        .Where(x => x.SubDirectoryID == subDirectoryID && x.Status == Status.QCDone && x.Flag != Flag.Delete)
                        .Select(x => new ImageFileVM
                        {
                            ID = x.ID,
                            SubDirectoryID = x.SubDirectoryID,
                            SerialNo = x.SerialNo,
                            Name = Path.GetFileNameWithoutExtension(x.Path),
                            Path = x.Path,
                            Status = x.Status,
                            Flag = x.Flag
                        }).OrderBy(x => x.SerialNo).ToListAsync();
                    break;
                default:
                    break;
            }
            return fileDetails;
        }
        
        public async Task<List<ImageFileDetail>> GetImageFiles(int subdirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.ImageFileDetails
                          .Where(x => x.SubDirectoryID == subdirectoryID && x.Flag!=Flag.Delete)
                          .OrderBy(x => x.SerialNo).ToListAsync();
        }
    }
}
