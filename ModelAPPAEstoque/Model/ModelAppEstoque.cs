namespace ModelAPPAEstoque.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelAppEstoque : DbContext
    {
        public ModelAppEstoque()
            : base("name=ModelAppEstoque")
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<InventarioItem> InventarioItem { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.IDEmpresaERP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.CNPJ)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.UnidadeNome)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);
        }
    }
}
