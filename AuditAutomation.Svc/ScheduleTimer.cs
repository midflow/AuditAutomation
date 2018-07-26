using AuditAutomation.Svc.Common;
using AuditAutomation.Svc.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using AuditAutomation.Svc.Processors;

namespace AuditAutomation.Svc
{
    public class ScheduleTimer
    {
        public double _timeInterval;
        public Timer _timer = null;
        public AuditProccessor _auditProccessor = null;

        public ScheduleTimer()
        {
            _auditProccessor = new AuditProccessor();
            _timeInterval = double.Parse(ConfigurationHelper.RetreiveAppSetting(Constants.TIME_INTERVAL));
            _timer = new Timer(_timeInterval);
            _timer.Elapsed += new ElapsedEventHandler(OnTimer);
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            _auditProccessor.Process();
        }

        public void Start()
        {
            if (_timer.Enabled == false)
            {
                _timer.Enabled = true;
            }

        }
        public void Stop()
        {
            if (_timer.Enabled == true)
            {
                _timer.Enabled = false;
            }
        }
    }
}
