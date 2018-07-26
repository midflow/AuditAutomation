using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Bogus;
using Moq;
using AuditAutomation.Models;

namespace AuditAutomation.GenJson
{
    class Program
    {
        static string[] AuditIdList = new[]
                {
                    "234-56780-AXDC-DVCX",
                    "323-66354-HDHS-VNSD",
                    "322-42434-AXDC-DVCX",
                    "352-43322-BFXS-RRSS"
                };
        static string[] SubjectList = new[]
        {
                "CN=XXXXXX.dv2.bbswrs.aze2.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                "CN=XXXXXX.dv1.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                "CN=XXXXXX.dv1.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                "CN=XXXXXX.dv2.bbswrs.aze2.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US"
                };
        static string[] IssuerList = new[]
        {
                "CN=GEICO SHA256 SUB CA 01, DC=GEICO, DC=corp, DC=net",
                "CN=GEICODDC Private Primary Issuing CA, O=GEICO",
                "DC=Windows Azure CRP Certificate Generator"
                };
        static string[] ResourceTypeList = new[]
        {
                "Cloud service (classic)",
                "Virtual Machines (classic)",
                "Virtual Machines"
                };
        static string[] RegionNameList = new[]
        {
                "East US",
                "West US",
                "North Europe",
                "North Central US"
                };
        static string[] DataNameList = new[]
                {
                    "GE2XXXXXXXAPP01",
                    "gze-XXXXXX-DV1-cls-XXXXXX-001",
                    "GE3XXXXXXXAPP02",
                    "gze-XXXXXX-DV2-cls-XXXXXX-002"
                };
        //Get Location of generated file       
        static int minRand = int.Parse(System.Configuration.ConfigurationManager.AppSettings[Common.Constants.MIN_RAND]);
        static int maxRand = int.Parse(System.Configuration.ConfigurationManager.AppSettings[Common.Constants.MAX_RAND]);

        static void Main(string[] args)
        {
            try
            {
                //Create Mock Audit with Moq
                IList<Audit> listAudit = GenAuditsByMoq();

                //Create fake data with Bogus
                //IList<Audit> listAudit = GenAuditsByBogus();

                //Gen Json file with Audit List
                var rs = Common.Functions.WriteToJson(listAudit);

                if (!rs)
                {
                    Console.WriteLine("Could not generate Json file. Press any key to exit!");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine("Generate Json file successfully. Press any key to exit!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        static protected IList<Certificates> GenCertificateList(int length)
        {
            var certificateList = new List<Certificates>();

            for (int i = 0; i < length; i++)
            {
                var cer = new Certificates()
                {
                    Subject = SubjectList[getRandom(SubjectList.Length - 1)],
                    Issuer = IssuerList[getRandom(IssuerList.Length - 1)],
                    NoOfDaysToExpire = getRandom(99),
                    NotAfter = DateTime.Now.ToString(),
                    SerialNumber = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                    Thumbprint = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
                };

                certificateList.Add(cer);
            }
            return certificateList;
        }

        static protected IList<Resources> GenResourceList(int length)
        {
            var resourceList = new List<Resources>();

            for (int i = 0; i < length; i++)
            {
                var res = new Resources()
                {
                    ResourceType = ResourceTypeList[getRandom(ResourceTypeList.Length - 1)],
                    Data = new List<Data>()
                    {
                        new Data()
                        {
                            Name = DataNameList[getRandom(DataNameList.Length-1)],
                            Certificates = GenCertificateList(2)
                        }
                    }
                };

                resourceList.Add(res);
            }

            return resourceList;
        }

        static protected IList<Region> GenRegionList(int length)
        {
            var regionList = new List<Region>();

            for (int i = 0; i < length; i++)
            {
                var reg = new Region()
                {
                    Name = RegionNameList[getRandom(RegionNameList.Length - 1)],
                    Resources = GenResourceList(3)
                };

                regionList.Add(reg);
            }
            return regionList;
        }

        static protected int getRandom(int max)
        {
            var rnd = new Random();
            return rnd.Next(max);
        }

        static protected IList<Audit> GenAuditsByMoq()
        {            
            var rnd = new Random();

            //number of Audits to gen
            int noAudit = rnd.Next(minRand, maxRand);
            var listAudits = new List<Audit>();

            for (int iAudit = 0; iAudit < noAudit; iAudit++)
            {
                //Create Audits 
                var audit = new Audit();

                audit.AuditId = iAudit.ToString() + AuditIdList[rnd.Next(3)];
                audit.AuditCriteria = new AuditCriterias() { NoOfDaysToExpire = rnd.Next(10, 99) };
                audit.SubscriptionId = "xxxxxxxxxxxxxxx";
                audit.AuditTimeStamp = "07_05_2018_08_02_59";
                audit.AuditSubcategoryType = "CCCP200" + iAudit;
                audit.Region = GenRegionList(2);

                listAudits.Add(audit);
            }

            //mock the Audits using Moq
            var mockAuditRepository = new Mock<IAuditRepository>();

            //Return all Audits
            mockAuditRepository.Setup(a => a.SelectAll()).Returns(listAudits);

            return mockAuditRepository.Object.SelectAll();
        }

        static protected IList<Audit> GenAuditsByBogus()
        {
            //1. Certificates           
            var certificate = new Faker<Certificates>()
                    .RuleFor(c => c.Subject, f => f.PickRandom(SubjectList))
                    .RuleFor(c => c.Issuer, f => f.PickRandom(IssuerList))
                    .RuleFor(c => c.NoOfDaysToExpire, f => f.Random.Number(10, 99))
                    .RuleFor(c => c.NotAfter, f => f.Date.Future().ToString("MM/dd/yyy hh:mm:ss tt"))
                    .RuleFor(c => c.SerialNumber, f => f.Random.Replace("????????????????????????????????????"))
                    .RuleFor(c => c.Thumbprint, f => f.Random.Replace("????????????????????????????????????"));

            //2. Datas 
            var datas = new Faker<Data>()
                   .RuleFor(d => d.Name, f => f.Random.Replace("???-??????-??#-???-??????-###"))
                   .RuleFor(d => d.Certificates, f => certificate.Generate(2).ToList());

            //3. Resources
            var resource = new Faker<Resources>()
                .RuleFor(r => r.ResourceType, f => f.PickRandom(ResourceTypeList))
                .RuleFor(r => r.Data, f => datas.Generate(1).ToList());

            //4. Regions
            var regions = new Faker<Region>()
                .RuleFor(ri => ri.Name, f => f.PickRandom(RegionNameList))
                .RuleFor(ri => ri.Resources, f => resource.Generate(3).ToList());

            //5. AuditCreteria
            var auditCriteria = new Faker<AuditCriterias>()
                .RuleFor(ac => ac.NoOfDaysToExpire, f => f.Random.Number(10, 99));

            //6.Audit
            var audits = new Faker<Audit>()
                .RuleFor(a => a.AuditId, f => f.Random.Replace("####-#####-????-????"))
                .RuleFor(a => a.SubscriptionName, f => f.Random.Replace("??-??-??-##"))
                .RuleFor(a => a.SubscriptionId, f => f.Random.Replace("???????????????"))
                .RuleFor(a => a.AuditTimeStamp, f => f.Date.Past().ToString("MM_dd_yyyy_hh_mm_ss"))
                .RuleFor(a => a.AuditSubcategoryType, f => f.Random.Replace("CCCP####"))
                .RuleFor(a => a.AuditCriteria, f => auditCriteria.Generate(1).SingleOrDefault())
                .RuleFor(a => a.Region, f => regions.Generate(2).ToList());

            var rnd = new Random();

            List<Audit> fakeAudits = audits.Generate(rnd.Next(minRand, maxRand));

            return fakeAudits;
        }

    }
}
