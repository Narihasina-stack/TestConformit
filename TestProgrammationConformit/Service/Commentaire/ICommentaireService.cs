
using System.Collections.Generic;
using TestProgrammationConformit.Datas.Dtos;
using TestProgrammationConformit.Datas.Params;

namespace TestProgrammationConformit.Commons.Service.Commentaire
{
    public interface ICommentaireService
    {
        void Add(CommentaireDto commentaire);
        void Update(CommentaireDto commentaire);
        void Delete(int id);
        CommentaireDto GetById(int id);
        IEnumerable<CommentaireDto> GetAll(CommentaireParams param);
        IEnumerable<CommentaireDto> GetAllWithPagination(CommentaireParams param, string sortField = "Id",
            int page = 1,
            int rowPerPage = 10,
            bool orderAsc = true);
    }
}
