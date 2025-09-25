using DC.DMS.Services.Models.Main;
using DC.DMS.Services.WorkflowModels;
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DesktopApp.Helpers
{
    public class ClientRejectHelper
    {
        private IDbContextFactory<ApplicationDbContext> _dbContext;
        private readonly IMemoryCache _cache;
        private readonly ITranslationService _translationService;
        private ServerDateTimeHelper serverDateTimeHelper;

        public ClientRejectHelper(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
            serverDateTimeHelper = new ServerDateTimeHelper(_dbContext);
        }

        public async Task<(bool IsSuccess, string? ErrorMessage)> SaveClientRejectAsync(ClientReject clientReject)
        {
            try
            {
                await using var _db = await _dbContext.CreateDbContextAsync();
                clientReject.CreatedDateTime = await serverDateTimeHelper.GetCurrentDateTimeAsync();
                clientReject.UpdatedDateTime = clientReject.CreatedDateTime;
                _db.ClientReject.Add(clientReject);
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
