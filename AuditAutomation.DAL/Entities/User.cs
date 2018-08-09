using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string SignInName { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<AuditUser> AuditUsers { get; set; }
        public virtual ICollection<UserADGroup> UserADGroups { get; set; }
    }
}
