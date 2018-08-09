using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditAutomation.DAL.Entities
{
    public class Certificate
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string NotAfter { get; set; }
        public string Issuer { get; set; }
        public string SerialNumber { get; set; }
        public string Thumbprint { get; set; }
        public int? NoOfDaysToExpire { get; set; }
        [Required]
        public int DataId { get; set; }
        public virtual Data Data { get; set; }
    }
}
