using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAutomation.DAL.Repositories;
using AuditAutomation.Models;
using Newtonsoft.Json;
using Unity.Attributes;

namespace AuditAutomation.Svc.Services.Implementations
{
    public class AuditSvc : IAuditSvc
    {
        private IAuditRepository _auditRepository;

        [Dependency]
        public IAuditRepository AuditRepository { get => _auditRepository; set => _auditRepository = value; }

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

        public bool WriteDataToDB(Audit data)
        {
            bool isOK = false;
            if (data != null)
            {
                var auditFromDB = _auditRepository.Get(o => o.AuditId == data.AuditId);
                if (auditFromDB == null)
                {
                    DAL.Audit dbAudit = new DAL.Audit
                    {
                        AuditId = data.AuditId,
                        AuditSubcategoryType = data.AuditSubcategoryType,
                        AuditTimeStamp = data.AuditTimeStamp,
                        SubscriptionId = data.SubscriptionId,
                        SubscriptionName = data.SubscriptionName
                    };
                    _auditRepository.Add(dbAudit);
                }

                if (auditFromDB != null)
                {
                    DAL.AuditCriteria auditCriteria = new DAL.AuditCriteria
                    {
                        NoOfDaysToExpire = data.AuditCriteria.NoOfDaysToExpire,
                        AuditId = auditFromDB.Id,
                    };
                }

                _auditRepository.SaveChanges();
                isOK = true;
            }
            return isOK;
        }
    }
}
