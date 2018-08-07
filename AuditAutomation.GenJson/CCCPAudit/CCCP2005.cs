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
    public class CCCP2005:BaseCCCP,ICCCP
    {        
        /// <summary>
        /// Generate Audit list for CCCP 2005
        /// </summary>
        /// <returns></returns>
        public IList<Audit> GenAuditList(int noAudit)
        {            
            
            var listAudits = new List<Audit>();

            for (int iAudit = 0; iAudit < noAudit; iAudit++)
            {
                //Create Audits 
                var audit = base.GenAudit();
                audit.AuditSubcategoryType = Constants.AUDIT_2005;
                audit.AuditCriteria = GenAuditCriterias();                
                audit.Region = GenRegionList(Constants.NO_REGION);
                
                listAudits.Add(audit);
            }

            //mock the Audits using Moq
            var mockAuditRepository = new Mock<IAuditRepository>();

            //Return all Audits
            mockAuditRepository.Setup(a => a.SelectAll()).Returns(listAudits);

            return mockAuditRepository.Object.SelectAll();
        }


        /// <summary>
        /// Generate Samples Certificates
        /// </summary>
        /// <param name="length">size of List</param>
        /// <returns></returns>
        public IList<Certificates> GenCertificateList(int length)
        {
            var certificateList = new List<Certificates>();

            for (int i = 0; i < length; i++)
            {                
                certificateList.Add(base.GenCertificate());
            }
            return certificateList;
        }

        /// <summary>
        /// Generate sample Resources
        /// </summary>
        /// <param name="length">size of List</param>
        /// <returns></returns>
        public IList<Resources> GenResourceList(int length)
        {
            var resourceList = new List<Resources>();

            for (int i = 0; i < length; i++)
            {
                var res = new Resources()
                {
                    ResourceType = SampleDatas.ResourceTypeList[Functions.random.Next(SampleDatas.ResourceTypeList.Length)],
                    Data = new List<Data>()
                    {
                        new Data()
                        {
                            Name = SampleDatas.DataNameList[Functions.random.Next(SampleDatas.DataNameList.Length)],
                            Certificates = GenCertificateList(Constants.NO_CERTIFICATE)
                        }
                    }
                };

                resourceList.Add(res);
            }

            return resourceList;
        }
        /// <summary>
        /// Generate sample regions
        /// </summary>
        /// <param name="length">size of List</param>
        /// <returns></returns>
        public IList<Region> GenRegionList(int length)
        {
            var regionList = new List<Region>();

            for (int i = 0; i < length; i++)
            {
                var reg = new Region()
                {
                    Name = SampleDatas.RegionNameList[Functions.random.Next(SampleDatas.RegionNameList.Length)],
                    Resources = GenResourceList(Constants.NO_RESOURCE)
                };

                regionList.Add(reg);
            }
            return regionList;
        }
        public AuditCriterias GenAuditCriterias() {
            return new AuditCriterias() { NoOfDaysToExpire = Functions.random.Next(Constants.MAX_DAY_EXPIRE) };
        }
        public IList<User> GenADUsers(int length)
        {
            return null;
        }
        public AuditData GenAuditData(int length)
        {
            return null;
        }

    }
}
