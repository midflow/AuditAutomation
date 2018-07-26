using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.Svc
{
    public partial class AuditAutomationSvc : ServiceBase
    {
        private EventLog eventLog;
        private ScheduleTimer scheduleTimer;
        public AuditAutomationSvc()
        {
            InitializeComponent();

            scheduleTimer = new ScheduleTimer();
            string eventSourceName = "Audit Automation";
            string logName = "Audit Automation";

            eventLog = new EventLog();
            if (!EventLog.SourceExists(eventSourceName))
            {
                EventLog.CreateEventSource(eventSourceName, logName);
            }
            eventLog.Source = eventSourceName;
            eventLog.Log = logName;
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("In OnStart");
            scheduleTimer.Start();
        }

        protected override void OnStop()
        {
            eventLog.WriteEntry("Stoped!");
            scheduleTimer.Stop();
        }
    }
}
