using DC.DMS.Services.ViewModels;
using DMS.Context.Data;
using DMS.ContextHelper.ViewModels;
using Microsoft.EntityFrameworkCore;
using static DC.DMS.Services.Enum.WorkflowEnums;

namespace DMS.DesktopApp.Helper
{
    public class MasterHelper
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContext;

        public MasterHelper(IDbContextFactory<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DropDownHelper>> GetAllDepartments()
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.MasterDepartments.AsNoTracking()
                .Select(x => new DropDownHelper
                {
                    ID = x.ID,
                    Name = x.Name

                }).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<int> GetDepartmentRemainingFileCount(int departmentID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.FileDirectories.Include(x => x.FileDetail)
                .AsNoTracking()
                .Where(x => x.FileDetail.DepartmentID == departmentID && x.Status == Status.Dispatched)
               .GroupBy(x => new { x.Directory.ID, x.Directory.Name })
               .Select(g => new DropDownHelper
               {
                   ID = g.Key.ID,
                   Name = g.Key.Name
               }).CountAsync();
        }

        public async Task<List<DropDownHelper>> GetDepartmentAllBatches(int departmentID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.FileDirectories.AsNoTracking()
                .Include(x => x.FileDetail)
                .Include(x => x.Directory)
                .Where(x => x.FileDetail.DepartmentID == departmentID && x.Status == Status.Dispatched)
               .GroupBy(x => new { x.Directory.ID, x.Directory.Name })
               .Select(g => new DropDownHelper
               {
                   ID = g.Key.ID,
                   Name = g.Key.Name
               })
               .OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<DropDownHelper>> GetDepartmentAllFiles(int departmentID, int batchID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.FileDirectories.AsNoTracking()
                .Include(x => x.FileDetail)
                .Include(x => x.Directory)
                .Where(x => x.DirectoryID == batchID && x.FileDetail.DepartmentID == departmentID && x.Status == Status.Dispatched)
                .Select(x => new DropDownHelper
                {
                    ID = x.ID,
                    Name = x.Name
                }).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<DropDownHelper>> GetDepartmentAllSubFiles(int fileDirectoryID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.SubDirectories.AsNoTracking()
                .Where(x => x.FileDirectoryID == fileDirectoryID && x.Status == Status.Dispatched)
                .Select(x => new DropDownHelper
                {
                    ID = x.ID,
                    Name = x.Name
                }).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<DropDownHelper>> GetDepartmentAllSection(int departmentID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.MasterSections.AsNoTracking().Where(x => x.DepartmentID == departmentID).Select(x => new DropDownHelper
            {
                ID = x.ID,
                Name = x.Name
            }).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<DropDownHelper>> GetDepartmentAllSubSection(int departmentID, int sectionID)
        {
            await using var _db = await _dbContext.CreateDbContextAsync();
            return await _db.MasterSubSections.AsNoTracking().Where(x => x.DepartmentID == departmentID && x.SectionID.Equals(sectionID))
            .Select(x => new DropDownHelper
            {
                ID = x.ID,
                Name = x.Name
            }).OrderBy(x => x.Name).ToListAsync();
        }


    }
}
