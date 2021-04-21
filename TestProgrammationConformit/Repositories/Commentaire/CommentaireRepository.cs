
using TestProgrammationConformit.Generic;
using TestProgrammationConformit.Infrastructures;

namespace TestProgrammationConformit.Repositories.Commentaire
{
    public class CommentaireRepository : GenericRepository<Datas.Entity.Commentaire>, ICommentaireRepository
    {
        public CommentaireRepository(ConformitContext context) : base(context)
        {
            
        }

       

    }
}
