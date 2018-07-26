using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Moq;
using AuditAutomation.Models;

namespace AuditAutomation.GenJson
{
    class Program
    {
        #region "List Data"
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
        #endregion
        //using for random function
        static Random random = new Random();
        //Get Location of generated file       
        static int minRand = int.Parse(System.Configuration.ConfigurationManager.AppSettings[Common.Constants.MIN_RAND]);
        static int maxRand = int.Parse(System.Configuration.ConfigurationManager.AppSettings[Common.Constants.MAX_RAND]);
        /// <summary>
        /// Main console
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                //Create Mock Audit with Moq
                IList<Audit> listAudit = GenAuditsByMoq();                

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
        /// <summary>
        /// Generate Audit list
        /// </summary>
        /// <returns></returns>
        static IList<Audit> GenAuditsByMoq()
        {            
            //number of Audits to generate
            int noAudit = random.Next(minRand, maxRand);
            var listAudits = new List<Audit>();

            for (int iAudit = 0; iAudit < noAudit; iAudit++)
            {
                //Create Audits 
                var audit = new Audit();
                //AuditID format: "1234-56780-AXDC-DVCX"
                audit.AuditId = RandomNumberString(4) + "-" + RandomNumberString(5) + "-"
                                + RandomUpperCaseString(4) + "-" + RandomUpperCaseString(4);
                audit.AuditCriteria = new AuditCriterias() { NoOfDaysToExpire = random.Next(Common.Constants.MAX_DAY_EXPIRE) };
                audit.SubscriptionId = RandomUpperCaseString(12);
                audit.AuditTimeStamp = DateTime.Now.AddDays(-random.Next(30)).ToString("MM_dd_yyyy_hh_mm_ss");// "07_05_2018_08_02_59";
                audit.AuditSubcategoryType = "CCCP" + RandomNumberString(4);
                audit.Region = GenRegionList(Common.Constants.NO_REGION);
                //Sample SubscriptionName: "GZ-NP-IT-03"
                audit.SubscriptionName = RandomUpperCaseString(2) + "-" + RandomUpperCaseString(2) + "-"
                                + RandomUpperCaseString(2) + "-" + RandomNumberString(2);

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
        static IList<Certificates> GenCertificateList(int length)
        {
            var certificateList = new List<Certificates>();

            for (int i = 0; i < length; i++)
            {
                var cer = new Certificates()
                {
                    Subject = SubjectList[random.Next(SubjectList.Length - 1)],
                    Issuer = IssuerList[random.Next(IssuerList.Length - 1)],
                    NoOfDaysToExpire = random.Next(Common.Constants.MAX_DAY_EXPIRE),
                    NotAfter = DateTime.Now.AddDays(random.Next(Common.Constants.MAX_DAY_EXPIRE)).ToString(),
                    SerialNumber = RandomUpperCaseString(Common.Constants.SERIAL_LENGTH),
                    Thumbprint = RandomUpperCaseString(Common.Constants.SERIAL_LENGTH)
                };

                certificateList.Add(cer);
            }
            return certificateList;
        }
        /// <summary>
        /// Generate sample Resources
        /// </summary>
        /// <param name="length">size of List</param>
        /// <returns></returns>
        static IList<Resources> GenResourceList(int length)
        {
            var resourceList = new List<Resources>();

            for (int i = 0; i < length; i++)
            {
                var res = new Resources()
                {
                    ResourceType = ResourceTypeList[random.Next(ResourceTypeList.Length - 1)],
                    Data = new List<Data>()
                    {
                        new Data()
                        {
                            Name = DataNameList[random.Next(DataNameList.Length-1)],
                            Certificates = GenCertificateList(Common.Constants.NO_CERTIFICATE)
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
        static IList<Region> GenRegionList(int length)
        {
            var regionList = new List<Region>();

            for (int i = 0; i < length; i++)
            {
                var reg = new Region()
                {
                    Name = RegionNameList[random.Next(RegionNameList.Length - 1)],
                    Resources = GenResourceList(Common.Constants.NO_RESOURCE)
                };

                regionList.Add(reg);
            }
            return regionList;
        }        
        /// <summary>
        /// Generate random string with numbers or letters like "YYEere232"
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns></returns>
        static string RandomString(int length)
        {            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Generate random string with number like "1232343"
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns></returns>
        static string RandomNumberString(int length)
        {           
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Generate random string with UPPERCASE
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns></returns>
        static string RandomUpperCaseString(int length)
        {            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Generate random string with lowercase
        /// </summary>
        /// <param name="length">length of string</param>
        /// <returns></returns>
        static string RandomLowerCaseString(int length)
        {            
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
