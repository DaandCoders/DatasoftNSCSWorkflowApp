
using DMS.Context.Data;
using DMS.ContextHelper.ViewModels;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using static DC.DMS.Services.Enum.WorkflowEnums;




namespace DMS.DesktopApp.Helper
{
    public class DashboardHelper
    {
        private readonly ApplicationDbContext _db;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;

        public DashboardHelper(ApplicationDbContext dbContext, IMemoryCache cache, ITranslationService translationService)
        {
            _db = dbContext;
            _cache = cache;
            _translationService = translationService;

        }

        public async Task<StatusCountVM> DashboardCount()
        {
            var caseDerectory= await _db.FileDirectories.Select(x=>new { x.Status, x.ID }).ToListAsync();
            StatusCountVM statusCountVM = new StatusCountVM();
            statusCountVM.TotalFileReceived = caseDerectory.Select(x => x.Status == Status.FileReceive).Count();
            statusCountVM.TotalFileQC= caseDerectory.Select(x => x.Status == Status.QCDone).Count();
            statusCountVM.TotalFileClassified = caseDerectory.Select(x => x.Status == Status.Classification).Count();
            statusCountVM.TotalFileQCByClient = caseDerectory.Select(x => x.Status == Status.QCDoneByClient).Count();
            statusCountVM.TotalFileDispatched= caseDerectory.Select(x => x.Status == Status.Dispatched).Count();
            return statusCountVM;
        }
    }
}
