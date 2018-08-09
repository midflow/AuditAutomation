using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditAutomation.DAL.Entities
{
    public class AuditData
    {
        [Key, ForeignKey("Audit")]
        public int Id { get; set; }
        public virtual Audit Audit { get; set; }
        public virtual ICollection<ADGroup> ADGroups { get; set; }

    }
}
