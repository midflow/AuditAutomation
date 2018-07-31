using AuditAutomation.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.GenJson
{
    public class AuditRepository: IAuditRepository
    {
        protected List<Audit> _table = null;

        public IList<Audit> SelectAll()
        {
            //return _table.AsNoTracking().ToList();
            return _table.ToList();
        }    
        
        public Audit Select(string id)
        {
            return _table.Single(a => a.AuditId == id);
        }
       
    }
}
