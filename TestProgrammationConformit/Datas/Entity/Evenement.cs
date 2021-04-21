

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace TestProgrammationConformit.Datas.Entity
{
    public class Evenement
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public  string Titre { get; set; }
        [StringLength(255)]
        public  string Description { get; set; }
        [ForeignKey("Personne")]
        public  int PersonneId { get; set; }
        public  virtual  Personne Personne { get; set; }
        public virtual List<Commentaire> Commentaires { get; set; }
    }
}
