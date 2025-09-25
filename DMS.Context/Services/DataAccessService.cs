using DC.DMS.Services.Models.Menus;
using DC.DMS.Services.ViewModels.Admin;
using DMS.Context.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace DMS.Context
{
    public class DataAccessService : IDataAccessService
    {
        private readonly IMemoryCache cache;
        private readonly ApplicationDbContext db;

        public DataAccessService(ApplicationDbContext context, IMemoryCache cache)
        {
            this.cache = cache;
            db = context;
        }

        public async Task<List<NavigationMenuViewModel>> GetMenuItemsAsync(ClaimsPrincipal principal)
        {
            var isAuthenticated = principal.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                return new List<NavigationMenuViewModel>();
            }

            var roleIds = await GetUserRoleIds(principal);

            var permissions = await cache.GetOrCreateAsync("Permissions",
                async x => await (from menu in db.NavigationMenus select menu).ToListAsync());

            var rolePermissions = await cache.GetOrCreateAsync("RolePermissions",
                async x => await (from menu in db.RoleMenuPermissions select menu).Include(x => x.NavigationMenu).ToListAsync());

            var data = (from menu in rolePermissions
                        join p in permissions on menu.NavigationMenuID equals p.ID
                        where roleIds.Contains(menu.RoleID)
                        select p)
                              .Select(m => new NavigationMenuViewModel()
                              {
                                  ID = m.ID,
                                  Name = m.Name,
                                  Area = m.Area,
                                  Visible = m.Visible,
                                  IsExternal = m.IsExternal,
                                  ActionName = m.ActionName,
                                  ExternalUrl = m.ExternalUrl,
                                  DisplayOrder = m.DisplayOrder,
                                  ParentMenuID = m.ParentMenuID,
                                  FontAwesomeIcon = m.FontAwesomeIcon,
                                  ControllerName = m.ControllerName,
                              }).Distinct().ToList();

            return data;
        }

        public async Task<bool> GetMenuItemsAsync(ClaimsPrincipal ctx, string ctrl, string act)
        {
            var result = false;
            var roleIds = await GetUserRoleIds(ctx);
            var data = await (from menu in db.RoleMenuPermissions
                              where roleIds.Contains(menu.RoleID)
                              select menu)
                              .Select(m => m.NavigationMenu)
                              .Distinct()
                              .ToListAsync();



            var roleIdsString = string.Join(",", roleIds);

            foreach (var item in data)
            {
                result = (item.ControllerName == ctrl && item.ActionName == act);
                if (result)
                {
                    break;
                }
            }

            return result;
        }

        public async Task<List<NavigationMenuViewModel>> GetPermissionsByRoleIdAsync(string id)
        {
            var items = await (from m in db.NavigationMenus
                               join rm in db.RoleMenuPermissions
                                on new { X1 = m.ID, X2 = id } equals new { X1 = rm.NavigationMenuID, X2 = rm.RoleID }
                                into rmp
                               from rm in rmp.DefaultIfEmpty()
                               select new NavigationMenuViewModel()
                               {
                                   ID = m.ID,
                                   Name = m.Name,
                                   Area = m.Area,
                                   ActionName = m.ActionName,
                                   ControllerName = m.ControllerName,
                                   IsExternal = m.IsExternal,
                                   ExternalUrl = m.ExternalUrl,
                                   DisplayOrder = m.DisplayOrder,
                                   ParentMenuID = m.ParentMenuID,
                                   Visible = m.Visible,
                                   FontAwesomeIcon=m.FontAwesomeIcon,
                                   Permitted = rm.RoleID == id
                               })
                               .AsNoTracking()
                               .ToListAsync();

            return items;
        }

        public async Task<bool> SetPermissionsByRoleIdAsync(string id, IEnumerable<Guid> permissionIds)
        {
            var existing = await db.RoleMenuPermissions.Where(x => x.RoleID == id).ToListAsync();
            db.RemoveRange(existing);

            foreach (var item in permissionIds)
            {
                await db.RoleMenuPermissions.AddAsync(new RoleMenuPermission()
                {
                    RoleID = id,
                    NavigationMenuID = item,
                });
            }

            var result = await db.SaveChangesAsync();

            // Remove existing permissions to roles so it can re evaluate and take effect
            cache.Remove("RolePermissions");

            return result > 0;
        }

        private async Task<List<string>> GetUserRoleIds(ClaimsPrincipal ctx)
        {
            var userId = GetUserId(ctx);
            List<string> data = await (from role in db.UserRoles
                                       where role.UserId == userId
                                       select role.RoleId).ToListAsync();

            return data;
        }

        private string GetUserId(ClaimsPrincipal user)
        {
            return ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
