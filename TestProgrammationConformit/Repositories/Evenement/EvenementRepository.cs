
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestProgrammationConformit.Commons.Extensions;
using TestProgrammationConformit.Generic;
using TestProgrammationConformit.Infrastructures;

namespace TestProgrammationConformit.Repositories.Evenement
{
    public class EvenementRepository : GenericRepository<Datas.Entity.Evenement>, IEvenementRepository
    {
        public EvenementRepository(ConformitContext context): base(context)
        {

        }


        public override IEnumerable<Datas.Entity.Evenement> FindAll(Expression<Func<Datas.Entity.Evenement, bool>> predicate = null)
        {
            return predicate != null
                ? _dbContext.Set<Datas.Entity.Evenement>().AsNoTracking().Include(e=>e.Commentaires).Include(e=>e.Personne).Where(predicate)
                : _dbContext.Set<Datas.Entity.Evenement>().AsNoTracking().Include(e=>e.Commentaires).Include(e => e.Personne);

        }

        public override Datas.Entity.Evenement GetById(int id)
        {
            return _dbContext.Set<Datas.Entity.Evenement>().Include(e => e.Commentaires).Include(e => e.Personne).Where(x=>x.Id==id).FirstOrDefault();
        }
        public override IEnumerable<Datas.Entity.Evenement> FindAllWithPagination(string sortField, Expression<Func<Datas.Entity.Evenement, bool>> predicate = null,
            int page = 1, int rowCount = 10, bool orderAsc = true)
        {
            return QueryWithPagination(sortField, predicate, page, rowCount, orderAsc);
        }

        public override IEnumerable<Datas.Entity.Evenement> QueryWithPagination(string sortField, Expression<Func<Datas.Entity.Evenement, bool>> predicate = null,
            int page = 1, int rowCount = 10, bool orderAsc = true)
        {
            var offset = page <= 1 ? 0 : page - 1;
            var row = rowCount <= 0 ? 10 : rowCount;

            return (predicate == null
                ? _dbContext.Set<Datas.Entity.Evenement>().AsNoTracking().Include(e => e.Commentaires).Include(e => e.Personne).CustomOrderBy(sortField, orderAsc).Skip(offset * row).Take(row)
                : _dbContext.Set<Datas.Entity.Evenement>().AsNoTracking().Include(e => e.Commentaires).Include(e => e.Personne).Where(predicate).CustomOrderBy(sortField, orderAsc).Skip(offset * row).Take(row));


        }
    }
}
