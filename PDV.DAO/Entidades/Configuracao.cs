namespace PDV.DAO.Entidades
{
    public class Configuracao
    {
        public decimal IDConfiguracao { get; set; }
        public string Chave { get; set; }
        public byte[] Valor { get; set; }

        public object ValorJS { get; set; }

        public Configuracao()
        {
        }
    }
}
