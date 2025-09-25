using DC.DMS.Services.Models.Menus;
using DMS.Context.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DMS.ContextData
{
    public class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                var _userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var _roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!context.ApplicationUsers.Any(usr => usr.UserName == "admin@test.com"))
                {
                    var user = new IdentityUser()
                    {
                        UserName = "admin@test.com",
                        Email = "admin@test.com",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "P@ssw0rd").Result;
                }

                if (!context.ApplicationUsers.Any(usr => usr.UserName == "manager@test.com"))
                {
                    var user = new IdentityUser()
                    {
                        UserName = "manager@test.com",
                        Email = "manager@test.com",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "P@ssw0rd").Result;
                }

                if (!context.ApplicationUsers.Any(usr => usr.UserName == "employee@test.com"))
                {
                    var user = new IdentityUser()
                    {
                        UserName = "employee@test.com",
                        Email = "employee@test.com",
                        EmailConfirmed = true,
                    };

                    var userResult = _userManager.CreateAsync(user, "P@ssw0rd").Result;
                }

                if (!_roleManager.RoleExistsAsync("Admin").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("Manager").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "Manager" }).Result;
                }

                if (!_roleManager.RoleExistsAsync("Employee").Result)
                {
                    var role = _roleManager.CreateAsync(new IdentityRole { Name = "Employee" }).Result;
                }

                var adminUser = _userManager.FindByNameAsync("admin@test.com").Result;
                var adminRole = _userManager.AddToRolesAsync(adminUser, new string[] { "Admin" }).Result;

                var managerUser = _userManager.FindByNameAsync("manager@test.com").Result;
                var managerRole = _userManager.AddToRolesAsync(managerUser, new string[] { "Manager" }).Result;

                var employeeUser = _userManager.FindByNameAsync("employee@test.com").Result;
                var userRole = _userManager.AddToRolesAsync(employeeUser, new string[] { "Employee" }).Result;

                var permissions = GetPermissions();
                foreach (var item in permissions)
                {
                    if (!context.NavigationMenus.Any(n => n.Name == item.Name))
                    {
                        context.NavigationMenus.Add(item);
                    }
                }

                var _adminRole = _roleManager.Roles.Where(x => x.Name == "Admin").FirstOrDefault();
                var _managerRole = _roleManager.Roles.Where(x => x.Name == "Manager").FirstOrDefault();
                var _employeeRole = _roleManager.Roles.Where(x => x.Name == "Employee").FirstOrDefault();

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0") });
                }

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c") });
                }

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c") });
                }

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("F704BDFD-D3EA-4A6F-9463-DA47ED3657AB")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("F704BDFD-D3EA-4A6F-9463-DA47ED3657AB") });
                }

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("913BF559-DB46-4072-BD01-F73F3C92E5D5")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("913BF559-DB46-4072-BD01-F73F3C92E5D5") });
                }

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("3C1702C5-C34F-4468-B807-3A1D5545F734")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("3C1702C5-C34F-4468-B807-3A1D5545F734") });
                }

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("94C22F11-6DD2-4B9C-95F7-9DD4EA1002E6")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("94C22F11-6DD2-4B9C-95F7-9DD4EA1002E6") });
                }

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _managerRole.Id && x.NavigationMenuID == new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _managerRole.Id, NavigationMenuID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0") });
                }

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _managerRole.Id && x.NavigationMenuID == new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _managerRole.Id, NavigationMenuID = new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c") });
                }
                
                //Company
                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("22fe1783-13af-43c1-a358-6dbf8b074bab")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("22fe1783-13af-43c1-a358-6dbf8b074bab") });
                }
                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("d6e30cba-113e-437a-9a94-97d3f1dbb6bc")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("d6e30cba-113e-437a-9a94-97d3f1dbb6bc") });
                }
                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("58ec804a-74cd-4661-86ed-e754c235f456")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("58ec804a-74cd-4661-86ed-e754c235f456") });
                }
                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("661402df-67d1-4262-be5e-e37cd73ee5e5")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("661402df-67d1-4262-be5e-e37cd73ee5e5") });
                }

                //Reports

                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("0E62EF44-9663-4D9C-B4CD-DA33C1E530FD")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("0E62EF44-9663-4D9C-B4CD-DA33C1E530FD") });
                }

                // Sales
                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("423b2a9d-f37b-487a-b385-f146692f5017")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("423b2a9d-f37b-487a-b385-f146692f5017") });
                }

                // Cash Back
                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("a25b1a1d-38ae-49af-bcbf-b7e00ba530d9")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("a25b1a1d-38ae-49af-bcbf-b7e00ba530d9") });
                }

                //Payments
                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("79d8544f-b91a-456e-bcff-46ccbdbc5945")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("79d8544f-b91a-456e-bcff-46ccbdbc5945") });
                }

                //GST
                if (!context.RoleMenuPermissions.Any(x => x.RoleID == _adminRole.Id && x.NavigationMenuID == new Guid("38260183-5f36-4801-bf66-c8b919cbffa1")))
                {
                    context.RoleMenuPermissions.Add(new RoleMenuPermission() { RoleID = _adminRole.Id, NavigationMenuID = new Guid("38260183-5f36-4801-bf66-c8b919cbffa1") });
                }

                context.SaveChanges();
            }
        }
        private static List<NavigationMenu> GetPermissions()
        {
            return new List<NavigationMenu>()
            {
                #region Admin
                new NavigationMenu()
                {
                    ID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    Name = "Admin",
                    ControllerName = "",
                    ActionName = "",
                    ParentMenuID = null,
                    FontAwesomeIcon="fa-solid fa-user-tie",
                    DisplayOrder=1,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("283264d6-0e5e-48fe-9d6e-b1599aa0892c"),
                    Name = "Roles",
                    ControllerName = "Account",
                    Area="Admin",
                    ActionName = "Roles",
                    ParentMenuID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=1,
                    FontAwesomeIcon=null,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("7cd0d373-c57d-4c70-aa8c-22791983fe1c"),
                    Name = "Users",
                    ControllerName = "Account",
                    ActionName = "Users",
                    Area="Admin",
                    FontAwesomeIcon=null,
                    ParentMenuID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=3,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("F704BDFD-D3EA-4A6F-9463-DA47ED3657AB"),
                    Name = "External Google Link",
                    ControllerName = "",
                    ActionName = "",
                    IsExternal = true,
                    ExternalUrl = "https://www.google.com/",
                    ParentMenuID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=2,
                    FontAwesomeIcon=null,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID= new Guid("913BF559-DB46-4072-BD01-F73F3C92E5D5"),
                    Name = "Create Role",
                    ControllerName = "Account",
                    ActionName = "CreateRole",
                    Area="Admin",
                    ParentMenuID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=3,
                    FontAwesomeIcon=null,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("3C1702C5-C34F-4468-B807-3A1D5545F734"),
                    Name = "Edit User",
                    ControllerName = "Account",
                    ActionName = "EditUser",
                    Area="Admin",
                    ParentMenuID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=3,
                    FontAwesomeIcon=null,
                    Visible = false,
                },
                new NavigationMenu()
                {
                    ID = new Guid("94C22F11-6DD2-4B9C-95F7-9DD4EA1002E6"),
                    Name = "Edit Role Permission",
                    ControllerName = "Account",
                    ActionName = "EditRolePermission",
                    Area="Admin",
                    ParentMenuID = new Guid("13e2f21a-4283-4ff8-bb7a-096e7b89e0f0"),
                    DisplayOrder=3,
                    FontAwesomeIcon=null,
                    Visible = false,
                },
                #endregion

                #region Company
                new NavigationMenu()
                {
                    ID = new Guid("22fe1783-13af-43c1-a358-6dbf8b074bab"),
                    Name = "Company",
                    ControllerName = "",
                    ActionName = "",
                    ParentMenuID = null,
                    DisplayOrder=2,
                    FontAwesomeIcon="fa-regular fa-building",
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("d6e30cba-113e-437a-9a94-97d3f1dbb6bc"),
                    Name = "Index",
                    ControllerName = "Companies",
                    ActionName = "Index",
                    Area="Admin",
                    ParentMenuID = new Guid("22fe1783-13af-43c1-a358-6dbf8b074bab"),
                    DisplayOrder=1,
                    FontAwesomeIcon=null,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("58ec804a-74cd-4661-86ed-e754c235f456"),
                    Name = "Create",
                    ControllerName = "Companies",
                    ActionName = "Create",
                    Area="Admin",
                    ParentMenuID = new Guid("22fe1783-13af-43c1-a358-6dbf8b074bab"),
                    DisplayOrder=2,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("661402df-67d1-4262-be5e-e37cd73ee5e5"),
                    Name = "Edit",
                    ControllerName = "Companies",
                    ActionName = "Edit",
                    Area="Admin",
                    ParentMenuID = new Guid("22fe1783-13af-43c1-a358-6dbf8b074bab"),
                    DisplayOrder=3,
                    Visible = false,
                },
                #endregion

                #region Reports

                new NavigationMenu()
                {
                    ID = new Guid("0E62EF44-9663-4D9C-B4CD-DA33C1E530FD"),
                    Name = "Reports",
                    ControllerName = "",
                    ActionName = "",
                    ParentMenuID = null,
                    FontAwesomeIcon="fa-solid fa-chart-column",
                    DisplayOrder=1,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("423b2a9d-f37b-487a-b385-f146692f5017"),
                    Name = "Home",
                    ControllerName = "Homes",
                    ActionName = "Index",
                    Area="Reports",
                    ParentMenuID = new Guid("0E62EF44-9663-4D9C-B4CD-DA33C1E530FD"),
                    DisplayOrder=1,
                    FontAwesomeIcon=null,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("a25b1a1d-38ae-49af-bcbf-b7e00ba530d9"),
                    Name = "Scann",
                    ControllerName = "Scanns",
                    ActionName = "Index",
                    Area="Reports",
                    ParentMenuID = new Guid("0E62EF44-9663-4D9C-B4CD-DA33C1E530FD"),
                    DisplayOrder=2,
                    FontAwesomeIcon=null,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("79d8544f-b91a-456e-bcff-46ccbdbc5945"),
                    Name = "QualityCheck",
                    ControllerName = "QualityChecks",
                    ActionName = "Index",
                    Area="Reports",
                    ParentMenuID = new Guid("0E62EF44-9663-4D9C-B4CD-DA33C1E530FD"),
                    DisplayOrder=3,
                    FontAwesomeIcon=null,
                    Visible = true,
                },
                new NavigationMenu()
                {
                    ID = new Guid("38260183-5f36-4801-bf66-c8b919cbffa1"),
                    Name = "Dispatch",
                    ControllerName = "Dispatchs",
                    ActionName = "Index",
                    Area="Reports",
                    ParentMenuID = new Guid("0E62EF44-9663-4D9C-B4CD-DA33C1E530FD"),
                    DisplayOrder=4,
                    FontAwesomeIcon=null,
                    Visible = true,
                },
                #endregion

            };
        }
    }
}
