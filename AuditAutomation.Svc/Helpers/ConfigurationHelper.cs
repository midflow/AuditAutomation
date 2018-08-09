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
                config.CreateMap<Audit, DAL.Entities.Audit>()
                .ForMember(c => c.Regions, option => option.MapFrom(o => o.Region));
                config.CreateMap<AuditCriterias, DAL.Entities.AuditCriteria>()
                .ForMember(c => c.ResourceLocation, option => option.Ignore())
                .ForMember(c => c.ResourcePlan, option => option.Ignore());
                config.CreateMap<Region, DAL.Entities.Region>();
                config.CreateMap<Resources, DAL.Entities.Resource>();
                config.CreateMap<Data, DAL.Entities.Data>();
                config.CreateMap<Certificates, DAL.Entities.Certificate>();
                config.CreateMap<ADGroup, DAL.Entities.ADGroup>();
                config.CreateMap<AuditData, DAL.Entities.AuditData>();
                //config.CreateMap<, DAL.Entities.Resource>(); ResourceLocation
                //ResourcePlan
                config.CreateMap<User, DAL.Entities.User>()
                .ForMember(c => c.UserRoles, option => option.Ignore());
                config.CreateMap<Certificates, DAL.Entities.Certificate>();
            });
        }
    }
}
