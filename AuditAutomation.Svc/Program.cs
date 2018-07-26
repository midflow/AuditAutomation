﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AuditAutomation.Svc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            UnityContainer container = Bootstrapper.Initialize();
            ServicesToRun = new ServiceBase[]
            {
                container.BuildUp(new AuditAutomationSvc())
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}