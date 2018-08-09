using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditAutomation.DAL.Entities
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string ResourceType { get; set; }
        [Required]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Data> Data { get; set; }
    }
}
