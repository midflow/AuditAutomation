namespace AuditAutomation.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ADGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Approver = c.String(),
                        AuditDataId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditData", t => t.AuditDataId)
                .Index(t => t.AuditDataId);
            
            CreateTable(
                "dbo.AuditData",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Audit", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Audit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuditId = c.String(),
                        SubscriptionName = c.String(),
                        SubscriptionId = c.String(),
                        AuditTimeStamp = c.String(),
                        AuditSubcategoryType = c.String(),
                        RunId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuditCriteria",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NoOfDaysToExpire = c.Int(),
                        IsPartOfBuildOU = c.Boolean(),
                        RoleDefinitionName = c.String(),
                        ExcludeServiceAdministrators = c.Boolean(),
                        QuotaLimit = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Audit", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ResourceLocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuditCriteriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditCriteria", t => t.AuditCriteriaId)
                .Index(t => t.AuditCriteriaId);
            
            CreateTable(
                "dbo.ResourcePlan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuditCriteriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditCriteria", t => t.AuditCriteriaId)
                .Index(t => t.AuditCriteriaId);
            
            CreateTable(
                "dbo.AuditUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuditId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Audit", t => t.AuditId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.AuditId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignInName = c.String(),
                        DisplayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserADGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ADGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ADGroup", t => t.ADGroupId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ADGroupId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AuditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Audit", t => t.AuditId)
                .Index(t => t.AuditId);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceType = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.RegionId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsAutoScaleEnabled = c.Boolean(),
                        InstanceCount = c.Int(),
                        DistinguishedName = c.String(),
                        PricingPlan = c.String(),
                        CurrentUsage = c.Int(),
                        MaximumUsage = c.Int(),
                        PercentageUsage = c.Int(),
                        Count = c.Int(),
                        Limit = c.Int(),
                        ResourcesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resource", t => t.ResourcesId)
                .Index(t => t.ResourcesId);
            
            CreateTable(
                "dbo.Certificate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        NotAfter = c.String(),
                        Issuer = c.String(),
                        SerialNumber = c.String(),
                        Thumbprint = c.String(),
                        NoOfDaysToExpire = c.Int(),
                        DataId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data", t => t.DataId)
                .Index(t => t.DataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditData", "Id", "dbo.Audit");
            DropForeignKey("dbo.Resource", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Data", "ResourcesId", "dbo.Resource");
            DropForeignKey("dbo.Certificate", "DataId", "dbo.Data");
            DropForeignKey("dbo.Region", "AuditId", "dbo.Audit");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserADGroup", "UserId", "dbo.User");
            DropForeignKey("dbo.UserADGroup", "ADGroupId", "dbo.ADGroup");
            DropForeignKey("dbo.AuditUser", "UserId", "dbo.User");
            DropForeignKey("dbo.AuditUser", "AuditId", "dbo.Audit");
            DropForeignKey("dbo.ResourcePlan", "AuditCriteriaId", "dbo.AuditCriteria");
            DropForeignKey("dbo.ResourceLocation", "AuditCriteriaId", "dbo.AuditCriteria");
            DropForeignKey("dbo.AuditCriteria", "Id", "dbo.Audit");
            DropForeignKey("dbo.ADGroup", "AuditDataId", "dbo.AuditData");
            DropIndex("dbo.Certificate", new[] { "DataId" });
            DropIndex("dbo.Data", new[] { "ResourcesId" });
            DropIndex("dbo.Resource", new[] { "RegionId" });
            DropIndex("dbo.Region", new[] { "AuditId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserADGroup", new[] { "ADGroupId" });
            DropIndex("dbo.UserADGroup", new[] { "UserId" });
            DropIndex("dbo.AuditUser", new[] { "UserId" });
            DropIndex("dbo.AuditUser", new[] { "AuditId" });
            DropIndex("dbo.ResourcePlan", new[] { "AuditCriteriaId" });
            DropIndex("dbo.ResourceLocation", new[] { "AuditCriteriaId" });
            DropIndex("dbo.AuditCriteria", new[] { "Id" });
            DropIndex("dbo.AuditData", new[] { "Id" });
            DropIndex("dbo.ADGroup", new[] { "AuditDataId" });
            DropTable("dbo.Certificate");
            DropTable("dbo.Data");
            DropTable("dbo.Resource");
            DropTable("dbo.Region");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserADGroup");
            DropTable("dbo.User");
            DropTable("dbo.AuditUser");
            DropTable("dbo.ResourcePlan");
            DropTable("dbo.ResourceLocation");
            DropTable("dbo.AuditCriteria");
            DropTable("dbo.Audit");
            DropTable("dbo.AuditData");
            DropTable("dbo.ADGroup");
        }
    }
}
