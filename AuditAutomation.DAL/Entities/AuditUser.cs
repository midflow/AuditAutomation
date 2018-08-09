using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL.Entities
{
    public class AuditUser
    {
        [Key]
        public int Id { get; set; }
        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
