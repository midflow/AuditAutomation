using AuditAutomation.DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AuditAutomation.DAL
{
    public class AuditReportDBEntities : DbContext
    {
        public AuditReportDBEntities() : base("AuditReportDBEntities")
        {
        }

        static AuditReportDBEntities()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Audit>().ToTable("Audit");
            modelBuilder.Entity<AuditCriteria>().ToTable("AuditCriteria");
            modelBuilder.Entity<Certificate>().ToTable("Certificate");
            modelBuilder.Entity<Data>().ToTable("Data");
            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<Resource>().ToTable("Resource");
            modelBuilder.Entity<ADGroup>().ToTable("ADGroup");
            modelBuilder.Entity<AuditData>().ToTable("AuditData");
            modelBuilder.Entity<ResourceLocation>().ToTable("ResourceLocation");
            modelBuilder.Entity<ResourcePlan>().ToTable("ResourcePlan");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<AuditUser>().ToTable("AuditUser");
            modelBuilder.Entity<UserADGroup>().ToTable("UserADGroup");
        }
        public static AuditReportDBEntities Create()
        {
            return new AuditReportDBEntities();
        }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditCriteria> AuditCriterias { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ADGroup> ADGroups { get; set; }
        public DbSet<AuditData> AuditData { get; set; }
        public DbSet<ResourceLocation> ResourceLocations { get; set; }
        public DbSet<ResourcePlan> ResourcePlans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AuditUser> AuditUsers { get; set; }
        public DbSet<UserADGroup> userADGroups { get; set; }
    }
}