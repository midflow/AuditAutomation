using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AuditAutomation.Svc.Helpers
{
    public static class ConfigurationHelper
    {
        public static string RetreiveAppSetting(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }
    }
}
