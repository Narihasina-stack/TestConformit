
using Microsoft.EntityFrameworkCore;


namespace TestProgrammationConformit.Infrastructures
{
    public class ConformitContext : DbContext
    {
        public ConformitContext(DbContextOptions options) : base(options)
        {
        }


        public virtual DbSet<Datas.Entity.Personne> Personnes { get; set; }
        public virtual DbSet<Datas.Entity.Commentaire> Commentaires { get; set; }
        public virtual DbSet<Datas.Entity.Evenement> Evenements { get; set; }
    }
}
