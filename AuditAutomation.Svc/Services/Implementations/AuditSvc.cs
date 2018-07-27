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
        private IAuditCriteriaRepository _auditCriteriaRepository;
        private ICertificateRepository _certificateRepository;
        private IDataRepository _dataRepository;
        private IRegionRepository _regionRepository;
        private IResourceReposiroty _resourceReposiroty;

        [Dependency]
        public IAuditRepository AuditRepository { get => _auditRepository; set => _auditRepository = value; }
        [Dependency]
        public IAuditCriteriaRepository AuditCriteriaRepository { get => _auditCriteriaRepository; set => _auditCriteriaRepository = value; }
        [Dependency]
        public ICertificateRepository Certificate { get => _certificateRepository; set => _certificateRepository = value; }
        [Dependency]
        public IDataRepository Data { get => _dataRepository; set => _dataRepository = value; }
        [Dependency]
        public IRegionRepository Region { get => _regionRepository; set => _regionRepository = value; }
        [Dependency]
        public IResourceReposiroty Resource { get => _resourceReposiroty; set => _resourceReposiroty = value; }

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
                //var auditFromDB = _auditRepository.Get(o => o.AuditId == data.AuditId);
                if (true)
                {
                    DAL.Audit dbAudit = new DAL.Audit
                    {
                        AuditId = data.AuditId,
                        AuditSubcategoryType = data.AuditSubcategoryType,
                        AuditTimeStamp = data.AuditTimeStamp,
                        SubscriptionId = data.SubscriptionId,
                        SubscriptionName = data.SubscriptionName
                    };

                    List<DAL.AuditCriteria> aa = new List<DAL.AuditCriteria>();
                    DAL.AuditCriteria ar = new DAL.AuditCriteria();
                    ar.NoOfDaysToExpire = data.AuditCriteria.NoOfDaysToExpire;
                    aa.Add(ar);
                    dbAudit.AuditCriterias = aa;

                    List<DAL.Region> rgList = new List<DAL.Region>();
                    foreach (var itemRegion in data.Region)
                    {
                        DAL.Region rg = new DAL.Region();
                        rg.Name = itemRegion.Name;
                        List<DAL.Resource> rsList = new List<DAL.Resource>();
                        foreach (var resource in itemRegion.Resources)
                        {
                            DAL.Resource rs = new DAL.Resource();
                            rs.ResourceType = resource.ResourceType;
                            List<DAL.Datum> dtList = new List<DAL.Datum>();
                            foreach (var datum in resource.Data)
                            {
                                DAL.Datum dt = new DAL.Datum();
                                dt.Name = datum.Name;
                                List<DAL.Certificate> cList = new List<DAL.Certificate>();
                                foreach (var certificate in datum.Certificates)
                                {
                                    DAL.Certificate c = new DAL.Certificate();
                                    c.Subject = certificate.Subject;
                                    c.NoOfDaysToExpire = certificate.NoOfDaysToExpire;
                                    c.NotAfter = certificate.NotAfter;
                                    c.Issuer = certificate.Issuer;
                                    c.SerialNumber = certificate.SerialNumber;
                                    c.Thumbprint = certificate.Thumbprint;
                                    cList.Add(c);
                                }
                                dt.Certificates = cList;
                                dtList.Add(dt);
                            }
                            rs.Data = dtList;
                            rsList.Add(rs);
                        }

                        rg.Resources = rsList;
                        rgList.Add(rg);
                    }

                    dbAudit.Regions = rgList;
                    _auditRepository.Add(dbAudit);
                    _auditRepository.SaveChanges();
                }
                
                isOK = true;
            }
            return isOK;
        }
    }
}
