
using System.Collections.Generic;
using TestProgrammationConformit.Datas.Dtos;
using TestProgrammationConformit.Datas.Params;

namespace TestProgrammationConformit.Commons.Service.Evenement
{
    public interface IEvenementService
    {
        void Add(EvenementDto evenement);
        void Update(EvenementDto evenement);
        void Delete(int id);
        EvenementDto GetById(int id);
        IEnumerable<EvenementDto> GetAll(EvenementParams param);
        IEnumerable<EvenementDto> GetAllWithPagination(EvenementParams param, string sortField = "Id",
            int page = 1,
            int rowPerPage = 10,
            bool orderAsc = true);
    }
}
