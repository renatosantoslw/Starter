namespace PDV.DAO.Entidades.Estoque.NFeImportacao
{
    public class NFeEntradaXml
    {
        public decimal IDNFeEntradaXml { get; set; }
        public decimal IDNFeEntrada { get; set; }
        public byte[] Xml { get; set; }

        public NFeEntradaXml() { }
    }
}
