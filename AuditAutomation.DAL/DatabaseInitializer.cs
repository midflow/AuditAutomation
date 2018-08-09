using System.Data.Entity;
namespace AuditAutomation.DAL
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<AuditReportDBEntities>
    {
    }
}
