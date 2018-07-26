using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAutomation.Svc.Services;
using AuditAutomation.Svc.Services.Implementations;
using CommonServiceLocator;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using Unity.ServiceLocation;

namespace AuditAutomation.Svc
{
    public static class Bootstrapper
    {
        private static UnityContainer _container = new UnityContainer();
        public static UnityContainer Initialize()
        {
            _container.RegisterType<IAuditSvc, AuditSvc>(); //register service for auto DI
            return _container;
        }

        public static UnityContainer Container
        {           
            get
            {
                return _container;
            }
            
        }
    }
}
