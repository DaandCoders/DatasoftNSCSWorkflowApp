using DC.DMS.Services.Models.Others;
using DC.DMS.Services.ViewModels;
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
    public class RejectsHelper
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;

        public RejectsHelper(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DropDownHelper>> GetAllRemarksAsync()
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            var remarks = await _db.Rejects
                .Select(r => new DropDownHelper
                {
                    ID = r.ID,
                    Name = r.Description
                })
                .ToListAsync();
            return remarks;
        }
    }
}
