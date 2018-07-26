using AuditAutomation.Svc.Common;
using AuditAutomation.Svc.Helpers;
using AuditAutomation.Svc.Services;
using AuditAutomation.Svc.Services.Implementations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace AuditAutomation.Svc.Processors
{
    public class AuditProccessor
    {
        public IAuditSvc _auditService;

        public AuditProccessor()
        {
            _auditService = Bootstrapper.Container.Resolve<IAuditSvc>(); // resolve dynamic object allocator
        }
        public void Process()
        {
            var pathLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var localDirectoryInput = ConfigurationHelper.RetreiveAppSetting(Constants.LOCAL_DICRECTORY_INPUT);
            var localDirectoryOutput = ConfigurationHelper.RetreiveAppSetting(Constants.LOCAL_DICRECTORY_OUTPUT);
            var fileType = ConfigurationHelper.RetreiveAppSetting(Constants.FILE_TYPE);
            var jsonFiles = Directory.GetFiles(localDirectoryInput, fileType, SearchOption.AllDirectories);
            foreach (var filePath in jsonFiles)
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    var fileName = Path.GetFileName(filePath);
                    var audit = _auditService.ReadFile(filePath);
                    _auditService.WriteFile(audit, localDirectoryOutput + @"\" + fileName);
                }
            }
        }
    }
}
