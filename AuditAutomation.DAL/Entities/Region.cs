using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditAutomation.DAL.Entities
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
