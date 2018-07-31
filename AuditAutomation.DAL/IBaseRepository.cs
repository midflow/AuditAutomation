using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity FindById(object id);
        IQueryable<TEntity> List();
        void Delete(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);
        void SaveChanges();
    }
}
