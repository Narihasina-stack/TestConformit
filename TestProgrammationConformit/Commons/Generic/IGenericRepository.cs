

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace TestProgrammationConformit.Generic
{
    public interface IGenericRepository <T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate = null);

        IEnumerable<T> FindAllWithPagination(string sortField, Expression<Func<T, bool>> predicate = null,
            int page = 1, int rowCount = 10, bool orderAsc = true);
    }
}
