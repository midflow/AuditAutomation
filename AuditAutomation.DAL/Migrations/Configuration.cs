namespace AuditAutomation.DAL.Migrations
{
    using AuditAutomation.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuditAutomation.DAL.AuditReportDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuditAutomation.DAL.AuditReportDBEntities context)
        {
            context.Roles.AddOrUpdate(
                p => p.Name,
                new Role { Name = "CoAdministrator" },
                new Role { Name = "Owner" }
                );
            var users = new User[]
            {
                new User{ SignInName="demouser0@Geico.com", DisplayName="User0, Demo"},
                new User{ SignInName="demouser1@Geico.com", DisplayName="User1, Demo"},
                new User{ SignInName="demouser2@Geico.com", DisplayName="User2, Demo"},
                new User{ SignInName="demouser3@Geico.com", DisplayName="User3, Demo"},
                new User{ SignInName="demouser4@Geico.com", DisplayName="User4, Demo"},
                new User{ SignInName="demouser5@Geico.com", DisplayName="User5, Demo"},
                new User{ SignInName="demouser6@Geico.com", DisplayName="User6, Demo"},
                new User{ SignInName="demouser7@Geico.com", DisplayName="User7, Demo"},
                new User{ SignInName="demouser8@Geico.com", DisplayName="User8, Demo"},
                new User{ SignInName="demouser9@Geico.com", DisplayName="User9, Demo"}
            };
            context.Users.AddOrUpdate(users);
        }
    }
}
