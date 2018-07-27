using AuditAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.Svc.Services
{
    public interface IAuditSvc
    {
        Audit ReadFile(string path);
        bool WriteFile(Audit data, string path);
        bool WriteDataToDB(Audit data);
    }
}
