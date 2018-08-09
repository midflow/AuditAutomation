using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAutomation.DAL.Repositories;
using AuditAutomation.DAL;
using AuditAutomation.Models;
using Newtonsoft.Json;
using Unity.Attributes;
using AuditAutomation.Svc.Helpers;

namespace AuditAutomation.Svc.Services.Implementations
{
    public class AuditSvc : IAuditSvc
    {
        private IRepository _repository;
        [Dependency]
        public IRepository Repository { get => _repository; set => _repository = value; }

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
                var auditRepository = _repository.GetRepository<DAL.Entities.Audit>();
                var auditFromDB = auditRepository.FirstOrDefault(o => o.AuditId == data.AuditId);
                if (auditFromDB == null)
                {
                    Mapper mapper = new Mapper();
                    DAL.Entities.Audit dbAudit = mapper.Map<Audit, DAL.Entities.Audit>(data);
                    auditRepository.Add(dbAudit);
                    auditRepository.SaveChanges();
                }
                isOK = true;
            }
            return isOK;
        }
    }
}
