﻿using AuditAutomation.Models;
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
    public class CCCP1005 : BaseCCCP,ICCCP
    {
        /// <summary>
        /// Generate Audit list for CCCP 1005
        /// </summary>
        /// <returns></returns>
        public IList<Audit> GenAuditList(int noAudit)
        {
            //number of Audits to generate           
            var listAudits = new List<Audit>();

            for (int iAudit = 0; iAudit < noAudit; iAudit++)
            {
                //Create Audits 
                var audit = base.GenAudit();

                audit.AuditSubcategoryType = Constants.AUDIT_1005;
                //sample runid = "erhh-4435-czcssd-xxxxxx"
                audit.RunId = Functions.RandomLowerCaseString(4) + "-" + Functions.RandomNumberString(4) + "-"
                                + Functions.RandomLowerCaseString(6) + "-" + Functions.RandomLowerCaseString(6);

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
        /// Generate sample Resources for CCCP 1005
        /// </summary>
        /// <param name="length">size of List</param>
        /// <returns></returns>
        public IList<Resources> GenResourceList(int length)
        {
            var resourceList = new List<Resources>();

            for (int i = 0; i < length; i++)
            {
                var name = SampleDatas.DataNameList[Functions.random.Next(SampleDatas.DataNameList.Length)];
                var res = new Resources()
                {
                    ResourceType = SampleDatas.ResourceTypeList[Functions.random.Next(SampleDatas.ResourceTypeList.Length)],
                    Data = new List<Data>()
                    {                        
                        new Data()
                        {
                            Name = name,
                            DistinguishedName = "CN=" + name + ",OU=SHRD,OU=Workloads-NP,OU=Workloads,OU=Build,OU=Servers,DC=GEICODDC,DC=net"
                        }
                    }
                };

                resourceList.Add(res);
            }

            return resourceList;
        }
        /// <summary>
        /// Generate sample regions for CCCP 1005
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
                    Resources = GenResourceList(Constants.NO_RESOURCE_CCCP1005)
                };

                regionList.Add(reg);
            }
            return regionList;
        }
        /// <summary>
        /// Generate sample Audit Criterias for CCCP 1005
        /// </summary>
        /// <returns></returns>
        public AuditCriterias GenAuditCriterias()
        {
            return new AuditCriterias() { IsPartOfBuildOU = Functions.random.Next(1)==1 };
        }        
    }
}
