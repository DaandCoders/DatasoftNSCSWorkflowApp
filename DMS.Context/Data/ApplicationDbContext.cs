using DC.DMS.Services.Models;
using DC.DMS.Services.Models.Auth;
using DC.DMS.Services.Models.BusinessDetails;
using DC.DMS.Services.Models.Log;
using DC.DMS.Services.Models.Main;
using DC.DMS.Services.Models.Masters;
using DC.DMS.Services.Models.Menus;
using DC.DMS.Services.Models.Others;
using DC.DMS.Services.Models.Translation;
using DC.DMS.Services.WorkflowModels;
using DC.DMS.Services.WorkflowModels.Directories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Cookie = DC.DMS.Services.Models.BusinessDetails.Cookie;
using ErrorLog = DC.DMS.Services.WorkflowModels.ErrorLog;

namespace DMS.Context.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly string serverName;
        private readonly string database;
        private readonly string uID;
        private readonly string password;
        private readonly string connectionString;
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region Others
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RoleMenuPermission> RoleMenuPermissions { get; set; }
        public DbSet<NavigationMenu> NavigationMenus { get; set; }
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<TermsAndCondition> TermsAndConditions { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }

        #endregion

        #region Translation
        public DbSet<Language> Languages { get; set; }
        public DbSet<Translations> Translations { get; set; }
        #endregion

        #region Main
        public DbSet<FileDetail> FileDetails { get; set; }
        public DbSet<DispatchData> DispatchedData { get; set; }
        public DbSet<SyncLog> SyncLogs { get; set; }
        #endregion

        #region Scan Workflow
        public DbSet<DCSDirectory> Directories{ get; set; }
        public DbSet<SubDirectory> SubDirectories{ get; set; }
        public DbSet<FileDirectory> FileDirectories{ get; set; }
        public DbSet<ImageFileDetail> ImageFileDetails { get; set; }
        public DbSet<Reject> Rejects { get; set; }
        public DbSet<ClientReject> ClientReject { get; set; }
        #endregion

        #region Master
        public DbSet<DCSClient> DCSClient { get; set; }
        public DbSet<MasterDepartment> MasterDepartments { get; set; }
        public DbSet<MasterSection> MasterSections { get; set; }
        public DbSet<MasterSubSection> MasterSubSections { get; set; }
        public DbSet<MasterCourt> MasterCourts { get; set; }
        #endregion

        #region Auth
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Question> Questions { get; set; }
        #endregion

        #region Log
        public DbSet<ErrorLog> ErrorLogs{ get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));
                foreach (var property in properties)
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }

            builder.Entity<SubDirectory>()
               .HasIndex(p => p.Path)
               .IsUnique(true);

            builder.Entity<DispatchData>()
                .HasIndex(p => p.FilePath)
                .IsUnique(true);

            builder.Entity<Language>()
                .HasIndex(p => p.Code)
                .IsUnique(true);

            builder.Entity<Translations>()
                .HasIndex(p => p.LanguageID);

            builder.Entity<Translations>()
                .HasIndex(p => p.TextKey)
                .IsUnique(true);

            builder.Entity<Cookie>()
                .HasOne(c => c.Creater)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Cookie>()
                .HasOne(c => c.Updater)
                .WithMany()
                .HasForeignKey(c => c.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PrivacyPolicy>()
                .HasOne(c => c.Creater)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PrivacyPolicy>()
                .HasOne(c => c.Updater)
                .WithMany()
                .HasForeignKey(c => c.UpdatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RoleMenuPermission>().HasKey(c => new { c.RoleID, c.NavigationMenuID });

            builder.Entity<IdentityUser>(entity => { entity.ToTable(name: "dmsusers"); });
            builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "dmsroles"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("dmsuserroles"); });
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("dmsuserclaims"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("dmsuserlogins"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("dmsusertokens"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("dmsroleclaims"); });

            builder.Entity<FileDetail>().ToTable("filedetails");
            builder.Entity<DCSDirectory>().ToTable("directories");
            builder.Entity<FileDirectory>().ToTable("filedirectories");
            builder.Entity<ImageFileDetail>().ToTable("imagefiledetails");
            builder.Entity<Language>().ToTable("langauges");
            builder.Entity<MasterCourt>().ToTable("mastercourts");
            builder.Entity<MasterDepartment>().ToTable("masterdepartments");
            builder.Entity<MasterSection>().ToTable("mastersections");
            builder.Entity<MasterSubSection>().ToTable("mastersubsections");
            builder.Entity<Translations>().ToTable("translations");
            builder.Entity<SubDirectory>().ToTable("subdirectories");
            builder.Entity<DispatchData>().ToTable("dispatcheddata");
            builder.Entity<User>().ToTable("users");
            builder.Entity<Role>().ToTable("roles");
            builder.Entity<Question>().ToTable("questions");
            builder.Entity<MasterCourt>().ToTable("mastercourts");
            builder.Entity<DCSClient>().ToTable("sitedetails");
            builder.Entity<ErrorLog>().ToTable("errorlogs");
            builder.Entity<SyncLog>().ToTable("synclogs");
            builder.Entity<Reject>().ToTable("rejects");
            builder.Entity<ClientReject>().ToTable("clientrejects");
        }
    }
}
