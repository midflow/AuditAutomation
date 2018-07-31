using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuditAutomation.DAL
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AuditReportDBEntities _dbContext;
        public AuditReportDBEntities DBContext
        {
            get
            {
                return _dbContext;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseRepository()
        {
            _dbContext = new AuditReportDBEntities();
        }

        public void Add(TEntity entity)
        {
            DBContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            DBContext.Set<TEntity>().Remove(entity);
        }

        public TEntity FindById(object id)
        {
            return DBContext.Set<TEntity>().Find(new object[] { id });
        }

        public IQueryable<TEntity> List()
        {
            return DBContext.Set<TEntity>();
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var entry = DBContext.Entry(entity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                DBContext.Set<TEntity>().Attach(entity);
                entry = DBContext.Entry(entity);
            }
            entry.State = System.Data.Entity.EntityState.Modified;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            var query = DBContext.Set<TEntity>();
            var entity = (where != null ? query.Where(where) : query).FirstOrDefault();
            return entity;
        }
    }
}
