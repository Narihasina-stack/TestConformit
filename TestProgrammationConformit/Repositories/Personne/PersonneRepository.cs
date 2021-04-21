
using TestProgrammationConformit.Generic;
using TestProgrammationConformit.Infrastructures;

namespace TestProgrammationConformit.Repositories.Personne
{
    public class PersonneRepository : GenericRepository<Datas.Entity.Personne>, IPersonneRepository
    {
        public PersonneRepository (ConformitContext context) : base(context)
        {

        }
    }

}
