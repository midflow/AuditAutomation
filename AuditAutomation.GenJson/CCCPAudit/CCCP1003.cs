using AuditAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAutomation.GenJson.Common;
using System.Configuration;
using Moq;

namespace AuditAutomation.GenJson.CCCPAudit
{
    public class CCCP1003 : BaseCCCP,ICCCP
    {
        /// <summary>
        /// Generate Audit list for CCCP 1003
        /// </summary>
        /// <returns></returns>
        public IList<Audit> GenAuditList(int noAudit)
        {
           
            var listAudits = new List<Audit>();

            for (int iAudit = 0; iAudit < noAudit; iAudit++)
            {
                //Create Audits 
                var audit = base.GenAudit();
                
                audit.AuditSubcategoryType = Constants.AUDIT_1003;                
                //sample runid = "erhh-4435-czcssd-xxxxxx"
                audit.RunId = Functions.RandomLowerCaseString(4) + "-" + Functions.RandomNumberString(4) + "-"
                                + Functions.RandomLowerCaseString(6) + "-" + Functions.RandomLowerCaseString(6);

                audit.AuditCriteria = GenAuditCriterias();
                
                audit.Data = new AuditData() { ADGroups = GenADGroups(Constants.NO_ADGROUP) };
                audit.ADUsers = GenADUsers(Constants.NO_ADUSER);

                listAudits.Add(audit);
            }

            //mock the Audits using Moq
            var mockAuditRepository = new Mock<IAuditRepository>();

            //Return all Audits
            mockAuditRepository.Setup(a => a.SelectAll()).Returns(listAudits);

            return mockAuditRepository.Object.SelectAll();
        }
        /// <summary>
        /// Generate sample Audit Criterias for CCCP 1003
        /// </summary>
        /// <returns></returns>
        public AuditCriterias GenAuditCriterias()
        {
            return new AuditCriterias() { RoleDefinitionName = "CoAdministrator/Owner",
                ExcludeServiceAdministrators = Functions.random.Next(1) == 1
        };
        }

        public List<User> GenADUsers(int length)
        {
            var users = new List<User>();

            for (int i = 0; i < length; i++)
            {
                users.Add(base.GenUser());
            }
            return users;
        }
        public List<ADGroup> GenADGroups(int length)
        {
            var adGroupList = new List<ADGroup>();

            for (int i = 0; i < length; i++)
            {
                var adGroup = base.GenADGroup();

                adGroup.Users = GenADUsers(Constants.NO_ADUSER);

                adGroupList.Add(adGroup);

            }
            return adGroupList;
        }

    }
}
