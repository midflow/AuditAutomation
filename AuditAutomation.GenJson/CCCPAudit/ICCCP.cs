using AuditAutomation.GenJson.Common;
using AuditAutomation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.GenJson.CCCPAudit
{
    public class BaseCCCP
    {
        //abstract IList<Audit> GenAudit();
        //IList<Certificates> GenCertificateList(int length);
        //IList<Resources> GenResourceList(int length);
        //IList<Region> GenRegionList(int length);
        //AuditCriterias GenAuditCriterias() { }
        //IList<User> GenADUsers(int length);
        //AuditData GenAuditData(int length);
        protected Audit GenAudit()
        {
            //Create Audits 
            var audit = new Audit();
            //AuditID format: "1234-56780-AXDC-DVCX"
            audit.AuditId = Functions.RandomNumberString(4) + "-" + Functions.RandomNumberString(5) + "-"
                            + Functions.RandomUpperCaseString(4) + "-" + Functions.RandomUpperCaseString(4);  
            
            audit.SubscriptionId = Functions.RandomUpperCaseString(12);
            audit.AuditTimeStamp = DateTime.Now.AddDays(-Functions.random.Next(30)).ToString("MM_dd_yyyy_hh_mm_ss");// "07_05_2018_08_02_59";
            //audit.AuditSubcategoryType = "CCCP" + Functions.RandomNumberString(4);            
            //Sample SubscriptionName: "GZ-NP-IT-03"
            audit.SubscriptionName = Functions.RandomUpperCaseString(2) + "-" + Functions.RandomUpperCaseString(2) + "-"
                            + Functions.RandomUpperCaseString(2) + "-" + Functions.RandomNumberString(2);

            return audit;
        }

        protected Certificates GenCertificate()
        {
            var cer = new Certificates()
            {
                Subject = SampleDatas.SubjectList[Functions.random.Next(SampleDatas.SubjectList.Length)],
                Issuer = SampleDatas.IssuerList[Functions.random.Next(SampleDatas.IssuerList.Length)],
                NoOfDaysToExpire = Functions.random.Next(Common.Constants.MAX_DAY_EXPIRE),
                NotAfter = DateTime.Now.AddDays(Functions.random.Next(Common.Constants.MAX_DAY_EXPIRE)).ToString(),
                SerialNumber = Functions.RandomUpperCaseString(Common.Constants.SERIAL_LENGTH),
                Thumbprint = Functions.RandomUpperCaseString(Common.Constants.SERIAL_LENGTH)
            };

            return cer;
        }

        protected User GenUser()
        {
            var rndUser = "User" + Functions.random.Next(9);
            var u = new User()
            {
                DisplayName = rndUser + ", Demo",
                SignInName = "demo" + rndUser.ToLower() + "@Geico.com",
                RoleDefinitionName = GenRandomUserRole()
            };

            return u;
        }
        protected ADGroup GenADGroup()
        {           
            var adGroup = new ADGroup()
            {
                Name = Functions.RandomUpperCaseString(3) + "_" + Functions.RandomUpperCaseString(3) + "_"
                            + Functions.RandomString(11) + "-" + Functions.RandomUpperCaseString(4),
                Approver = Functions.RandomLowerCaseString(6)+ "@geico.com"
            };

            return adGroup;
        }
        
        private List<string> GenRandomUserRole()
        {            
            var randomNumber = Functions.random.Next(SampleDatas.DataUserRoleList.Length);

            return randomNumber == 1 ? (new string[] { SampleDatas.DataUserRoleList[Functions.random.Next(SampleDatas.DataUserRoleList.Length)] }).ToList() : SampleDatas.DataUserRoleList.ToList();            
        }
    }
    interface ICCCP
    {
        IList<Audit> GenAuditList(int length);
        //IList<Certificates> GenCertificateList(int length);
        //IList<Resources> GenResourceList(int length);
        //IList<Region> GenRegionList(int length);
        AuditCriterias GenAuditCriterias();
        //IList<User> GenADUsers(int length);
        //AuditData GenAuditData(int length);
        
    }
}
