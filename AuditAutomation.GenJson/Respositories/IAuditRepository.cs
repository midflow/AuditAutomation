using AuditAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.GenJson
{
    public interface IAuditRepository
    {
        IList<Audit> SelectAll();

        Audit Select(string Id);
        
    }
}
