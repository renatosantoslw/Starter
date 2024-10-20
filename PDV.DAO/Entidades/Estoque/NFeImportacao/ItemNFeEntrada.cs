namespace PDV.DAO.Entidades.Estoque.NFeImportacao
{
    public class ItemNFeEntrada
    {
        public int CodSequencial { get; set; }


        public decimal IDItemNFeEntrada { get; set; }
        public decimal IDNFeEntrada { get; set; }
        public int IDProduto { get; set; }
        public int IDConversaoUnidadeDeMedida { get; set; }

        public string CEAN { get; set; }
        public string XPROD { get; set; }
        public string NCM { get; set; }
        public string CEST { get; set; }
        public string CFOP { get; set; }
        public string UCOM { get; set; }
        public decimal QCOM { get; set; }
        public decimal VUNCOM { get; set; }
        public decimal VPROD { get; set; }
        public string CEANTRIB { get; set; }
        public string UTRIB { get; set; }
        public decimal QTRIB { get; set; }
        public decimal VUNTRIB { get; set; }
        public decimal VFRETE { get; set; }
        public decimal VSEG { get; set; }
        public decimal VDESC { get; set; }
        public decimal VOUTRO { get; set; }
        public int INDTOT { get; set; }
        public decimal VTOTTRIB { get; set; }
        public string ORIG { get; set; }
        public string CSTICMS { get; set; }
        public int MODBC { get; set; }
        public decimal PREDBC { get; set; }
        public decimal VBCICMS { get; set; }
        public decimal PICMS { get; set; }
        public decimal VICMS { get; set; }
        public int MODBCST { get; set; }
        public decimal PMVAST { get; set; }
        public decimal PREDBCST { get; set; }
        public decimal VBCST { get; set; }
        public decimal PICMSST { get; set; }
        public decimal VICMSST { get; set; }
        public decimal VBCUFDEST { get; set; }
        public decimal PFCPUFDEST { get; set; }
        public decimal PICMSUFDEST { get; set; }
        public decimal PICMSINTER { get; set; }
        public decimal PICMSINTERPART { get; set; }
        public decimal VFCPUFDEST { get; set; }
        public decimal VICMSUFDEST { get; set; }
        public decimal VICMSUFREMET { get; set; }
        public string CENQ { get; set; }
        public string CSTIPI { get; set; }
        public decimal VBCIPI { get; set; }
        public decimal PIPI { get; set; }
        public decimal VIPI { get; set; }
        public string CSTPIS { get; set; }
        public decimal VBCPIS { get; set; }
        public decimal PPIS { get; set; }
        public decimal VPIS { get; set; }
        public string CSTCOFINS { get; set; }
        public decimal VBCOFINS { get; set; }
        public decimal PCOFINS { get; set; }
        public decimal VCOFINS { get; set; }

        /* Campos Utilizados para Mostrar em Tela */
        public string CodProdutoFonecedor { get; set; }
        public string DescricaoProduto { get; set; }
        public string UNEntrada { get; set; }
        public string UNSaida { get; set; }
        public decimal QuantidadeEntrada { get; set; }
        public decimal QuantidadeSaida { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorVenda { get; set; }
        public int IDDeposito { get; set; } //Almoxarifado
        public int IDRegraImposto { get; set; }
        public decimal ValorTotalItem { get; set; }

        public ItemNFeEntrada() { }
    }
}