
using System;
using System.Collections.Generic;
using TestProgrammationConformit.Datas.Entity;

namespace TestProgrammationConformit.Datas.Dtos
{
    public class CommentaireDto
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int EvenementId { get; set; }
        public virtual EvenementDto Evenement { get; set; }
    }
}
