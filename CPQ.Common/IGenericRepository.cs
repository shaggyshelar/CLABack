using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CPQ.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Query(string query);
        bool EntityExists(Guid id);
        bool Delete(Guid id);
        TEntity FindByKey(Guid id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
    }
}
