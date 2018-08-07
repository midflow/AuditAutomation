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
    public class CCCP4005 : BaseCCCP, ICCCP
    {
        /// <summary>
        /// Generate Audit list for CCCP 4005
        /// </summary>
        /// <returns></returns>
        public IList<Audit> GenAuditList(int noAudit)
        {

            var listAudits = new List<Audit>();

            for (int iAudit = 0; iAudit < noAudit; iAudit++)
            {
                //Create Audits 
                var audit = base.GenAudit();

                //sample runid = "erhh-4435-czcssd-xxxxxx"
                audit.RunId = Functions.RandomLowerCaseString(4) + "-" + Functions.RandomNumberString(4) + "-"
                                + Functions.RandomLowerCaseString(6) + "-" + Functions.RandomLowerCaseString(6);

                audit.AuditSubcategoryType = Constants.AUDIT_4005;
                audit.AuditCriteria = GenAuditCriterias();
                audit.Region = GenRegionList(Constants.NO_REGION_CCCP4005);

                listAudits.Add(audit);
            }

            //mock the Audits using Moq
            var mockAuditRepository = new Mock<IAuditRepository>();

            //Return all Audits
            mockAuditRepository.Setup(a => a.SelectAll()).Returns(listAudits);

            return mockAuditRepository.Object.SelectAll();
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
                    Data = GenDataList(Constants.NO_DATA_CCCP4005)
                };

                resourceList.Add(res);
            }

            return resourceList;
        }

        private List<Data> GenDataList(int length)
        {
            var dataList = new List<Data>();

            for (int i = 0; i < length; i++)
            {
                var data = new Data()
                {
                    Name = SampleDatas.DataNameList[Functions.random.Next(SampleDatas.DataNameList.Length)],
                    InstanceCount = Functions.random.Next(10)
                };

                dataList.Add(data);
            }
            return dataList;
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
                    Resources = GenResourceList(Constants.NO_RESOURCE_CCCP4005)
                };

                regionList.Add(reg);
            }
            return regionList;
        }
        public AuditCriterias GenAuditCriterias()
        {
            return new AuditCriterias() { };
        }


    }
}
