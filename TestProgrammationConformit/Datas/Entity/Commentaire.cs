using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProgrammationConformit.Datas.Entity
{
    public class Commentaire
    {
        [Key]
        public  int Id { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("Evenement")]
        public int EvenementId { get; set; }
        public virtual Evenement Evenement { get; set; }
    }
}
