using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuditAutomation.DAL;
using AutoMapper;

namespace AuditAutomation.Svc.Helpers
{
    public class Mapper
    {
        private MapperConfiguration _config;
        private IMapper _iMapper;
        public Mapper()
        {
            _config = ConfigurationHelper.RetrieveMapperConfiguration();
            _iMapper = _config.CreateMapper();
        }
        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : class where TSource : class
        {
            return _iMapper.Map<TDestination>(source);
        }
    }
}
