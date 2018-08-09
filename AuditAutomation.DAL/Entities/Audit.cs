using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace AuditAutomation.DAL.Entities
{
    public class Audit
    {
        [Key]
        public int Id { get; set; }
        public string AuditId { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionId { get; set; }
        public string AuditTimeStamp { get; set; }
        public string AuditSubcategoryType { get; set; }
        public string RunId { get; set; }
        public virtual AuditCriteria AuditCriteria { get; set; }
        public virtual AuditData Data { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
        public virtual ICollection<AuditUser> AuditUsers { get; set; }

    }
}
