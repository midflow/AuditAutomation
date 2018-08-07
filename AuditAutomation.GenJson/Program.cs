using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Moq;
using AuditAutomation.Models;
using System.Configuration;
using AuditAutomation.GenJson.CCCPAudit;
using AuditAutomation.GenJson.Factories;
using AuditAutomation.GenJson.Common;

namespace AuditAutomation.GenJson
{
    class Program
    {
        
        /// <summary>
        /// Main console
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                var CCCPType = Constants.AUDIT_4005;

                if (args.Length > 0 && !string.IsNullOrEmpty(args[0])){

                    switch (args[0])
                    {
                        case "4005":
                            CCCPType = Constants.AUDIT_4005;
                            break;
                        case "4001":
                            CCCPType = Constants.AUDIT_4001;
                            break;
                        case "1005":
                            CCCPType = Constants.AUDIT_1005;
                            break;
                        case "1003":
                            CCCPType = Constants.AUDIT_1003;
                            break;
                        case "3002":
                            CCCPType = Constants.AUDIT_3002;
                            break;
                        case "2005":
                            CCCPType = Constants.AUDIT_2005;
                            break;
                    }
                }

                //number of Audits to generate

                int noAudit = int.Parse(ConfigurationManager.AppSettings[Common.Constants.NO_AUDIT]);
                var CCCP = CCCPFactory.Create(CCCPType);
                //Create Mock Audit with Moq
                ///var CCCP = new CCCP4005();
                IList<Audit> listAudit = CCCP.GenAuditList(noAudit);

                //Gen Json file with Audit List
                string errorMsg = "";
                var rs = Functions.WriteToJson(listAudit, out errorMsg);

                if (!rs)
                {
                    Console.WriteLine(errorMsg);
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
       
 
    }
}
