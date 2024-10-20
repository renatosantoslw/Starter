namespace ModelAndroidApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseAPP",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Servico = c.String(),
                        Emitente = c.String(),
                        Clientes = c.String(),
                        Fornecedores = c.String(),
                        Transportadoras = c.String(),
                        Usuarios = c.String(),
                        Produtos = c.String(),
                        IntegracaoFiscal = c.String(),
                        NCM = c.String(),
                        FormaDePagamento = c.String(),
                        UnidadeMedida = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BaseAPPs");
        }
    }
}
