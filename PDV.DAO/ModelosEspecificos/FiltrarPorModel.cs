namespace PDV.DAO.ModelosEspecificos
{
    public class FiltrarPorModel
    {
        public FiltrarPorModel(string nomeColunaBanco, string descricao)
        {
            NomeColunaBanco = nomeColunaBanco;
            Descricao = descricao;
        }

        public string NomeColunaBanco { get; set; }

        public string Descricao { get; set; }
    }
}
