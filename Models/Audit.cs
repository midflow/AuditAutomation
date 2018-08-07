using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.Models
{
    /// <summary>
    /// audit data for Audit Automation
    /// </summary>
    public class Audit
    {
        public string AuditId { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionId { get; set; }
        public string AuditTimeStamp { get; set; }
        public string AuditSubcategoryType { get; set; }
        public string RunId { get; set; } //unique id for all JSON's for CCCP4005 - AutoScaling and CCCP1005 - Build OU Audit for the specific audit run
        public virtual AuditCriterias AuditCriteria { get; set; }
        public virtual ICollection<Region> Region { get; set; }
        //All the individual users should be reviewed and approved by the Subscription DevOps Manager. 
        public ICollection<User> ADUsers { get; set; }//CCCP-1003 - Co-Admin Audit
        public AuditData Data { get; set; }//CCCP-1003 - Co-Admin Audit
    }
    /// <summary>
    /// For CCCP-1003 - Co-Admin Audit
    /// </summary>
    public class AuditData
    {
        public ICollection<ADGroup> ADGroups { get; set; }
    }

    public class AuditCriterias
    {
        public int? NoOfDaysToExpire { get; set; }
        public bool? IsPartOfBuildOU { get; set; } //For CCCP1005 - Build OU Audit
        public ICollection<string> ResourceLocation { get; set; } //CCCP-2009 App Insight Resource Plan
        public ICollection<string> ResourcePlan { get; set; }//CCCP-2009 App Insight Resource Plan
        public string RoleDefinitionName { get; set; }//CCCP-1003 - Co-Admin Audit
        public bool? ExcludeServiceAdministrators { get; set; }//CCCP-1003 - Co-Admin Audit
        public int? QuotaLimit { get; set; }//CCCP-3002 -Azure Resources Quota Limit Audit
    }

    public class Region
    {
        public string Name { get; set; }
        public ICollection<Resources> Resources { get; set; }
    }

    public class Resources
    {
        public string ResourceType { get; set; }
        public ICollection<Data> Data { get; set; }
    }

    public class Data
    {
        public string Name { get; set; }
        public bool? IsAutoScaleEnabled { get; set; } //For CCCP4005 - AutoScaling
        public int? InstanceCount { get; set; } //For CCCP4005 - AutoScaling
        public string DistinguishedName { get; set; } //For CCCP1005 - Build OU Audit
        public string PricingPlan { get; set; }//CCCP-2009 App Insight Resource Plan
        public ICollection<Certificates> Certificates { get; set; }
        public ICollection<ADGroup> ADGroups { get; set; }//CCCP-1003 - Co-Admin Audit
        //below for CCCP-3002 -Azure Resources Quota Limit Audit
        public int? CurrentUsage { get; set; }
        public int? MaximumUsage { get; set; }
        public int? PercentageUsage { get; set; }
        public int? Count { get; set; }
        public int? Limit { get; set; }
    }

    public class Certificates
    {
        public string Subject { get; set; }
        public string NotAfter { get; set; }
        public string Issuer { get; set; }
        public string SerialNumber { get; set; }
        public string Thumbprint { get; set; }
        public int? NoOfDaysToExpire { get; set; }
    }
    //CCCP-1003 - Co-Admin Audit
    public class User
    {
        public string SignInName { get; set; }
        public string DisplayName { get; set; }
        public ICollection<string> RoleDefinitionName { get; set; }
    }

    //CCCP-1003 - Co-Admin Audit
    public class ADGroup
    {
        public string Name { get; set; }
        public string Approver { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
