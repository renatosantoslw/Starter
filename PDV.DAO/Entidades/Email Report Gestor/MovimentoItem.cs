namespace PDV.DAO.Entidades.Email_Report_Gestor
{
    public class MovimentoItem
    {
        public string Produto { get; set; }
        public string Codigo { get; set; }
        public string Grupo { get; set; }
        public decimal PrecoCusto { get; set; }
        public string Percentual { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal Desconto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal  Total { get; set; }
    }
}
