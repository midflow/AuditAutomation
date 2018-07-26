using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.Models
{
    
    public class Audit
    {
        public string AuditId { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionId { get; set; }
        public string AuditTimeStamp { get; set; }
        public string AuditSubcategoryType { get; set; }
        public virtual AuditCriterias AuditCriteria { get; set; }
        public virtual IList<Region> Region { get; set; }
    }

    public class AuditCriterias
    {
        public int NoOfDaysToExpire { get; set; }
    }

    public class Region
    {
        public string Name { get; set; }
        public IList<Resources> Resources { get; set; }
    }

    public class Resources
    {
        public string ResourceType { get; set; }
        public IList<Data> Data { get; set; }
    }

    public class Data
    {
        public string Name { get; set; }
        public IList<Certificates> Certificates { get; set; }
    }

    public class Certificates
    {
        public string Subject { get; set; }
        public string NotAfter { get; set; }
        public string Issuer { get; set; }
        public string SerialNumber { get; set; }
        public string Thumbprint { get; set; }
        public int NoOfDaysToExpire { get; set; }
    }
}
