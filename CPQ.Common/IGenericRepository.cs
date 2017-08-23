﻿using System;
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

        IQueryable<TEntity> Query();

        bool EntityExists(Guid id);

        IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        bool Delete(Guid id);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity FindByKey(Guid id);

        bool Insert(TEntity entity);

        bool Update(TEntity entity);
    }
}
