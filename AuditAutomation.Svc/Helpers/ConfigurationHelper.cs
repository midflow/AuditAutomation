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

                config.CreateMap<Region, DAL.Region>()
                    .ForMember(c => c.Resources, option => option.MapFrom(o => o.Resources));

                config.CreateMap<Resources, DAL.Resource>()
                    .ForMember(c => c.Data, option => option.MapFrom(o => o.Data));

                config.CreateMap<Data, DAL.Datum>()
                    .ForMember(c => c.Certificates, option => option.MapFrom(o => o.Certificates));

                config.CreateMap<Certificates, DAL.Certificate>();
            });
        }
    }
}
