using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using AutoMapper;
using AuditAutomation.Models;

namespace AuditAutomation.Svc.Helpers
{
    public static class ConfigurationHelper
    {
        public static string RetreiveAppSetting(string name)
        {
            return System.Configuration.ConfigurationManager.AppSettings[name];
        }
        public static MapperConfiguration RetrieveMapperConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Audit, DAL.Audit>()
                    .ForMember(c => c.Regions, option => option.MapFrom(o => o.Region));
                config.CreateMap<AuditCriterias, DAL.AuditCriteria>();
                config.CreateMap<Region, DAL.Region>();
                config.CreateMap<Resources, DAL.Resource>();
                config.CreateMap<Data, DAL.Datum>();
                config.CreateMap<Certificates, DAL.Certificate>();
            });
        }
    }
}
