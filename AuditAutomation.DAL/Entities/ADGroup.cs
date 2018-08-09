using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL.Entities
{
    public class ADGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Approver { get; set; }
        [Required]
        public int AuditDataId { get; set; }
        public virtual AuditData AuditData { get; set; }
        public virtual ICollection<UserADGroup> UserADGroups { get; set; }

    }
}
