using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL.Entities
{
    public class UserADGroup
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ADGroupId { get; set; }
        public virtual ADGroup ADGroup { get; set; }
    }
}
