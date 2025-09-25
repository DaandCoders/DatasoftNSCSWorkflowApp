using DMS.Context.Data;
using iText.Commons.Actions.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DesktopApp.Helpers
{
    public class ServerDateTimeHelper
    {
        private IDbContextFactory<ApplicationDbContext> _dbContext;
        public ServerDateTimeHelper(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DateTime> GetCurrentDateTimeAsync()
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return _db.Database.SqlQueryRaw<DateTime>("SELECT Now()").AsEnumerable().FirstOrDefault();
        }
    }
}
