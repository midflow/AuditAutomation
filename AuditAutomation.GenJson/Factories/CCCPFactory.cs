using AuditAutomation.GenJson.CCCPAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AuditAutomation.GenJson.Factories
{
    /// <summary>  
    /// The 'Creator' Abstract Class  
    /// </summary> 
    static class CCCPFactory
    {
        static IUnityContainer cont = null;
        static CCCPFactory()
        {
            cont = new UnityContainer();
            cont.RegisterType <ICCCP, CCCP2005> ("CCCP2005");
            cont.RegisterType<ICCCP, CCCP4005>("CCCP4005");
            cont.RegisterType <ICCCP, CCCP1005> ("CCCP1005");
            cont.RegisterType<ICCCP, CCCP1003>("CCCP1003");
            cont.RegisterType<ICCCP, CCCP3002>("CCCP3002");
        }
        public static ICCCP Create(string Type)
        {
            return cont.Resolve<ICCCP>(Type);
        }
    }
}
