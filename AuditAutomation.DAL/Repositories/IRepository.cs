using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL.Repositories
{
    public interface IRepository
    {
        IBaseRepository<T> GetRepository<T>() where T : class;
    }
}
