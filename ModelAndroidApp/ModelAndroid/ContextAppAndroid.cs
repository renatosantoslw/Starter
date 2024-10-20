namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using AppFiscal.Model.APP;

    public partial class ContextAppAndroid : DbContext
    {
        public ContextAppAndroid()
            : base("name=ModelAppForcaVendas")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Condicao> Condicao { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; }
        public virtual DbSet<Movimento> Movimento { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<NotaItem> NotaItem { get; set; }
        public virtual DbSet<Parcela> Parcela { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ReceberERP> ReceberERP { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }
        public virtual DbSet<Versao> Versao { get; set; }
        public virtual DbSet<BaseAPP> BaseAPP { get; set; }

        public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<InventarioItem> InventarioItem { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ContextAppAndroid>(null);



        }
    }
}
