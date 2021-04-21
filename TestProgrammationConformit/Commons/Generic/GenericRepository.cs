
using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using TestProgrammationConformit.Infrastructures;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestProgrammationConformit.Commons.Extensions;

namespace TestProgrammationConformit.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ConformitContext _dbContext ;

        public GenericRepository(ConformitContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges(); 
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges(); 
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges(); 
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate != null
                ? _dbContext.Set<T>().Where(predicate)
                : _dbContext.Set<T>(); 

        }

        public virtual IEnumerable<T> FindAllWithPagination(string sortField, Expression<Func<T, bool>> predicate = null,
            int page = 1, int rowCount = 10, bool orderAsc = true)
        {
            return QueryWithPagination(sortField, predicate, page, rowCount, orderAsc);
        }

        public virtual IEnumerable<T> QueryWithPagination(string sortField, Expression<Func<T, bool>> predicate = null,
            int page = 1, int rowCount = 10, bool orderAsc = true)
        {
            var offset = page <= 1 ? 0 : page - 1;
            var row = rowCount <= 0 ? 10 : rowCount;

            return (predicate == null
                ? _dbContext.Set<T>().AsNoTracking().CustomOrderBy(sortField, orderAsc).Skip(offset * row).Take(row)
                : _dbContext.Set<T>().AsNoTracking().Where(predicate).CustomOrderBy(sortField, orderAsc).Skip(offset * row).Take(row));


        }
    }
}
