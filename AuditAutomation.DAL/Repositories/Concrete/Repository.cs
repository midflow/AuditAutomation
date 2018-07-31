using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL.Repositories.Concrete
{
     public class Repository : IRepository
    {
        public IBaseRepository<T> GetRepository<T>() where T : class
        {
            return new BaseRepository<T>();
        }
    }
}
