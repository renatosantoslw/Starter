namespace ConrollerLicença
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Documento)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Observação)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Chave)
                .IsUnicode(false);
        }
    }
}
