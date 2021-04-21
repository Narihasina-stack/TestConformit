
using System.Collections.Generic;
using TestProgrammationConformit.Datas.Dtos;
using TestProgrammationConformit.Datas.Params;

namespace TestProgrammationConformit.Commons.Service.Personne
{
    public interface IPersonneService
    {
        void Add(PersonneDto personne);
        void Update(PersonneDto personne);
        void Delete(int id);
        PersonneDto GetById(int id);
        IEnumerable<PersonneDto> GetAll(PersonneParams param);
        IEnumerable<PersonneDto> GetAllWithPagination(PersonneParams param, string sortField = "Id",
            int page = 1,
            int rowPerPage = 10,
            bool orderAsc = true);


    }
}
