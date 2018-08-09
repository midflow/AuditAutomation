using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL.Entities
{
    public class Data
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsAutoScaleEnabled { get; set; }
        public int? InstanceCount { get; set; }
        public string DistinguishedName { get; set; }
        public string PricingPlan { get; set; }
        public int? CurrentUsage { get; set; }
        public int? MaximumUsage { get; set; }
        public int? PercentageUsage { get; set; }
        public int? Count { get; set; }
        public int? Limit { get; set; }
        [Required]
        public int ResourcesId { get; set; }
        public virtual Resource Resources { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
    }
}
