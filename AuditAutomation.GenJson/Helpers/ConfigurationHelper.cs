using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.GenJson.Helpers
{
    public static class ConfigurationHelper
    {
        public static string RetreiveAppSetting(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }
    }
}
