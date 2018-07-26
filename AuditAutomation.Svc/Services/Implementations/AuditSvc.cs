using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AuditAutomation.Models;

namespace AuditAutomation.Svc.Services.Implementations
{
    public class AuditSvc : IAuditSvc
    {
        public Audit ReadFile(string path)
        {
            Audit audits = null;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    audits = JsonConvert.DeserializeObject<Audit>(line);
                }
            }
            catch (Exception e)
            {
            }
            return audits;
        }

        public bool WriteFile(Audit data, string path)
        {
            try
            {
                string stringToSave = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(path, stringToSave);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
