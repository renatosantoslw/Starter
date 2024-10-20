namespace ModelAndroidAppSimples
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextoAppSimples : DbContext
    {
        public ContextoAppSimples()
            : base("name=ContextoAppSimples")
        {
        }

        public virtual DbSet<BaseAPP> BaseAPP { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Condicoes> Condicoes { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<Movimentos> Movimentos { get; set; }
        public virtual DbSet<PedidoItemMobile> PedidoItemMobile { get; set; }
        public virtual DbSet<PedidoMobile> PedidoMobile { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }
        public virtual DbSet<PedidoERP> PedidoERP { get; set; }
        public virtual DbSet<PedidoItemERP> PedidoItemERP { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseAPP>()
                .Property(e => e.Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<BaseAPP>()
                .Property(e => e.Vendedores)
                .IsUnicode(false);

            modelBuilder.Entity<BaseAPP>()
                .Property(e => e.Condicao)
                .IsUnicode(false);

            modelBuilder.Entity<BaseAPP>()
                .Property(e => e.Produto)
                .IsUnicode(false);

            modelBuilder.Entity<BaseAPP>()
                .Property(e => e.Pedido)
                .IsUnicode(false);

            modelBuilder.Entity<BaseAPP>()
                .Property(e => e.PedidoItem)
                .IsUnicode(false);

            modelBuilder.Entity<BaseAPP>()
                .Property(e => e.Documento)
                .IsUnicode(false);

            modelBuilder.Entity<BaseAPP>()
                .Property(e => e.Movimento)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Cep)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Condicoes>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.ValorEmAberto)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.Valor)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.ValorTotal)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.Pessoa)
                .IsUnicode(false);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.Detalhe)
                .IsUnicode(false);

            modelBuilder.Entity<Movimentos>()
                .Property(e => e.Detalhe)
                .IsUnicode(false);

            modelBuilder.Entity<Movimentos>()
                .Property(e => e.Valor)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Movimentos>()
                .Property(e => e.Operacao)
                .IsUnicode(false);

            modelBuilder.Entity<Movimentos>()
                .Property(e => e.Pessoa)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoItemMobile>()
                .Property(e => e.ProdutoNome)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoItemMobile>()
                .Property(e => e.Quantidade)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemMobile>()
                .Property(e => e.UnidadeNome)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoItemMobile>()
                .Property(e => e.Valor)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemMobile>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemMobile>()
                .Property(e => e.PercDesconto)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemMobile>()
                .Property(e => e.ValorDesconto)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemMobile>()
                .Property(e => e.Total)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.VendedorNome)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.ClienteNome)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.TotalProduto)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.PercDesconto)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.ValorDesconto)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.ValorAcrescimo)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.TotalPedido)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoMobile>()
                .Property(e => e.CondicaoNome)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.Preco)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.UnidadeNome)
                .IsUnicode(false);

            modelBuilder.Entity<Produtos>()
                .Property(e => e.Estoque)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Vendedores>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedores>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedores>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Vendedores>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoERP>()
                .Property(e => e.TotalPedido)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoERP>()
                .Property(e => e.Pessoa)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoERP>()
                .Property(e => e.TipoNota)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoERP>()
                .Property(e => e.Condicao)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoERP>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoERP>()
                .Property(e => e.VendedorNome)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoItemERP>()
                .Property(e => e.ProdutoNome)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoItemERP>()
                .Property(e => e.Quantidade)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemERP>()
                .Property(e => e.Unidade)
                .IsUnicode(false);

            modelBuilder.Entity<PedidoItemERP>()
                .Property(e => e.Valor)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemERP>()
                .Property(e => e.Desconto)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemERP>()
                .Property(e => e.Total)
                .HasPrecision(19, 2);

            modelBuilder.Entity<PedidoItemERP>()
                .Property(e => e.VendedorNome)
                .IsUnicode(false);
        }
    }
}
