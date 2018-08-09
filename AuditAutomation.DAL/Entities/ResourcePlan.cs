﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL.Entities
{
    public class ResourcePlan
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int AuditCriteriaId { get; set; }
        public virtual AuditCriteria AuditCriteria { get; set; }
    }
}
