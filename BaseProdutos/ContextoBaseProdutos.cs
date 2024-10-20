namespace BaseProdutos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextoBaseProdutos : DbContext
    {
        public ContextoBaseProdutos()
            : base("name=ContextoBaseProdutos")
        {
        }

        public virtual DbSet<ProdutoBase> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoBase>()
                .Property(e => e.Gtin)
                .IsUnicode(false);

            modelBuilder.Entity<ProdutoBase>()
                .Property(e => e.DescricaoNormalizada)
                .IsUnicode(false);

            modelBuilder.Entity<ProdutoBase>()
                .Property(e => e.DescricaoUpper)
                .IsUnicode(false);

            modelBuilder.Entity<ProdutoBase>()
                .Property(e => e.DescricaoAcento)
                .IsUnicode(false);

            modelBuilder.Entity<ProdutoBase>()
                .Property(e => e.Peso)
                .IsUnicode(false);

            modelBuilder.Entity<ProdutoBase>()
                .Property(e => e.Quantidade)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProdutoBase>()
                .Property(e => e.PrecoMedio)
                .HasPrecision(10, 2);
        }
    }
}
