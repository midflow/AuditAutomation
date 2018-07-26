using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.Svc.Model
{
    public class Audit11
    {
        public string AuditId { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionId { get; set; }
        public string AuditTimeStamp { get; set; }
        public string AuditSubcategoryType { get; set; }
        public AuditCriteria AuditCriteria { get; set; }
        public IList<Region> Region { get; set; }
    }

    public class AuditCriteria
    {
        public int NoOfDaysToExpire { get; set; }
    }

    public class Region
    {
        public string Name { get; set; }
        public IList<Resource> Resources { get; set; }
    }

    public class Resource
    {
        public string ResourceType { get; set; }
        public IList<Data> Data { get; set; }
    }

    public class Data
    {
        public string Name { get; set; }
        public IList<Certificate> Certificates { get; set; }
    }

    public class Certificate
    {
        public string Subject { get; set; }
        public string NotAfter { get; set; }
        public string Issuer { get; set; }
        public string SerialNumber { get; set; }
        public string Thumbprint { get; set; }
        public int NoOfDaysToExpire { get; set; }
    }
}
