using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AuditAutomation.DAL.Entities
{
    public class AuditCriteria
    {
        [Key, ForeignKey("Audit")]
        public int Id { get; set; }
        public int? NoOfDaysToExpire { get; set; }
        public bool? IsPartOfBuildOU { get; set; }
        public string RoleDefinitionName { get; set; }
        public bool? ExcludeServiceAdministrators { get; set; }
        public int? QuotaLimit { get; set; }
        public virtual Audit Audit { get; set; }
        public virtual ICollection<ResourceLocation> ResourceLocation { get; set; }
        public virtual ICollection<ResourcePlan> ResourcePlan { get; set; }
    }
    
}
