using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using FizzWare.NBuilder;

namespace MookupCerExpireData
{
    class Program
    {        
        static void Main(string[] args)
        {
            //Create some mock Audits   
            
            //1. Certificates
            IList<Certificates> cer1 = new List<Certificates>
            {
                new Certificates{Subject="CN=XXXXXX.dv1.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                    Issuer ="CN=GEICO SHA256 SUB CA 01, DC=GEICO, DC=corp, DC=net", NoOfDaysToExpire=89, NotAfter="/Date(1558020852000)/",
                    SerialNumber ="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"},
                new Certificates{Subject="CN=XXXXXX.dv1.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                    Issuer ="CN=GEICO SHA256 SUB CA 01, DC=GEICO, DC=corp, DC=net", NoOfDaysToExpire=45, NotAfter="/Date(1558020852000)/",
                    SerialNumber ="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"}
            };        
            IList<Certificates> cer2 = new List<Certificates>
            {
                new Certificates{Subject="CN=GEICODDC Private Primary Issuing CA, O=GEICO",
                    Issuer ="CN=GEICODDC Private Primary Issuing CA, O=GEICO", NoOfDaysToExpire=90, NotAfter="10/09/2018 1:19:44 PM",
                    SerialNumber ="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"},
                new Certificates{Subject="DC=Windows Azure CRP Certificate Generator",
                    Issuer ="DC=Windows Azure CRP Certificate Generator", NoOfDaysToExpire=65, NotAfter="09/14/2018 9:57:59 AM",
                    Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"}
            };
            IList<Certificates> cer3 = new List<Certificates>
            {
                new Certificates{Subject="CN=XXXXXX.pd8.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                    Issuer ="CN=GEICO SHA256 SUB CA 01, DC=GEICO, DC=corp, DC=net", NoOfDaysToExpire=89, NotAfter="/Date(1558020852000)/",
                    SerialNumber ="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"},
                new Certificates{Subject="CN=XXXXXX.pd8.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                    Issuer ="CN=GEICO SHA256 SUB CA 01, DC=GEICO, DC=corp, DC=net", NoOfDaysToExpire=45, NotAfter="/Date(1558020852000)/",
                    Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"}
            };
            IList<Certificates> cer4 = new List<Certificates>
            {
                new Certificates{Subject="CN=GEICODDC Private Primary Issuing CA, O=GEICO",
                    Issuer ="CN=GEICODDC Private Primary Issuing CA, O=GEICO", NoOfDaysToExpire=90, NotAfter="10/09/2018 1:19:44 PM",
                    SerialNumber ="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"},
                new Certificates{Subject="DC=Windows Azure CRP Certificate Generator",
                    Issuer ="DC=Windows Azure CRP Certificate Generator", NoOfDaysToExpire=65, NotAfter="09/14/2018 9:57:59 AM",
                    Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"}
            };
            IList<Certificates> cer5 = new List<Certificates>
            {
                 new Certificates{Subject="CN=GEICODDC Private Primary Issuing CA, O=GEICO",
                    Issuer ="CN=GEICODDC Private Primary Issuing CA, O=GEICO", NoOfDaysToExpire=90, NotAfter="10/09/2018 1:19:44 PM",
                    SerialNumber ="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"},
                new Certificates{Subject="DC=Windows Azure CRP Certificate Generator",
                    Issuer ="DC=Windows Azure CRP Certificate Generator", NoOfDaysToExpire=65, NotAfter="09/14/2018 9:57:59 AM",
                    Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"}
            };
            IList<Certificates> cer6 = new List<Certificates>
            {
                new Certificates{Subject="CN=XXXXXX.pd8.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                    Issuer ="CN=GEICO SHA256 SUB CA 01, DC=GEICO, DC=corp, DC=net", NoOfDaysToExpire=89, NotAfter="/Date(1558020852000)/",
                    SerialNumber ="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"},
                new Certificates{Subject="CN=XXXXXX.pd8.bbswrs.aze1.cloud.geico.net, OU=API Access, O=GEICO, L=Chevy Chase, S=Maryland, C=US",
                    Issuer ="CN=GEICO SHA256 SUB CA 01, DC=GEICO, DC=corp, DC=net", NoOfDaysToExpire=45, NotAfter="/Date(1558020852000)/",
                    Thumbprint="XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"}
            };

            //2. Datas
            IList<Data> data1 = new List<Data> {
                new Data{Name="gze-XXXXXX-DV1-cls-XXXXXX-001", Certificates= cer1}
            };
            IList<Data> data2 = new List<Data> {
                new Data{Name="GE2XXXXXXXAPP01", Certificates= cer2}
            };
            IList<Data> data3 = new List<Data> {
                new Data{Name="GZEXXXXXXXXXX02", Certificates= cer3}
            };
            IList<Data> data4 = new List<Data> {
                new Data{Name="gzw-XXXXXX-PD8-cls-XXXXXX-001", Certificates= cer4}
            };
            IList<Data> data5 = new List<Data> {
                new Data{Name="GZW2XXXXXXXAPP01", Certificates= cer5}
            };
            IList<Data> data6 = new List<Data> {
                new Data{Name="GZWXXXXXXXXXX02", Certificates= cer6}
            };

            //3. Resources
            IList<Resources> resources1 = new List<Resources>
            {
                new Resources {ResourceType="Cloud service (classic)", Data = data1},
                new Resources {ResourceType="Virtual Machines (classic)", Data = data2},
                new Resources {ResourceType="Virtual Machines", Data = data3}
            };
            IList<Resources> resources2 = new List<Resources>
            {
                new Resources {ResourceType="Cloud service (classic)", Data = data4},
                new Resources {ResourceType="Virtual Machines (classic)", Data = data5},
                new Resources {ResourceType="Virtual Machines", Data = data6}
            };
            
            //4. Regions
            IList<Region> region = new List<Region>
            {
                new Region{ Name="East US", Resources = resources1},
                new Region{ Name="West US", Resources = resources2},                
            };

            //5.Audit
            IList<Audits> audits = new List<Audits>
            {
                new Audits{AuditId="1234-56780-AXDC-DVCX" ,AuditSubcategoryType="CCCP2005", AuditTimeStamp="07_05_2018_08_02_59",
                    SubscriptionId ="xxxxxxxxxxxxxxx", SubscriptionName="GZ-NP-IT-03",
                    AuditCriteria = new AuditCriterias{NoOfDaysToExpire=90},
                    Region = region
                }
            };

            var mock = new Mock<IAuditRepository>();

            var rs = mock.Setup(a => a.SelectAll()).Returns(audits);

            string json = JsonConvert.SerializeObject(mock.Object.SelectAll().SingleOrDefault());

            //write string to file
            System.IO.File.WriteAllText("AuditCertificates.json", json);

            Console.WriteLine(json);
            Console.ReadLine();
            
        }

    }


}
