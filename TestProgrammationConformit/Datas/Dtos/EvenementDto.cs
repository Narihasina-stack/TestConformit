
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace TestProgrammationConformit.Datas.Dtos
{
    public class EvenementDto
    {
        public int? Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int PersonneId { get; set; }
        public virtual List<CommentaireDto> CommentaireList { get; set; }
        public virtual PersonneDto Personne { get; set; }
    }
}
