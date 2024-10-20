namespace ModelAndroidApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
          
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "IDVendedor", "dbo.Vendedor");
            DropIndex("dbo.Cliente", new[] { "IDVendedor" });
            DropTable("dbo.ReceberERP");
            DropTable("dbo.Produto");
            DropTable("dbo.Parcela");
            DropTable("dbo.NotaItem");
            DropTable("dbo.Nota");
            DropTable("dbo.Movimento");
            DropTable("dbo.FormaPagamento");
            DropTable("dbo.Estoque");
            DropTable("dbo.Empresa");
            DropTable("dbo.Documento");
            DropTable("dbo.Condicao");
            DropTable("dbo.Vendedor");
            DropTable("dbo.Cliente");
        }
    }
}
