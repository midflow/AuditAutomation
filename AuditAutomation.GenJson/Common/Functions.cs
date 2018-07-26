using AuditAutomation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.GenJson.Common
{
    public static class Functions
    {
        public static Boolean WriteToJson(IList<Audit> AuditList)
        {
            try
            {
                foreach (var audit in AuditList)
                {
                    string json = JsonConvert.SerializeObject(audit);

                    //write Json string to file
                    System.IO.File.WriteAllText(Helpers.ConfigurationHelper.RetreiveAppSetting(
                        Common.Constants.LOCAL_FILE_OUTPUT) + audit.AuditId + ".json", json);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
