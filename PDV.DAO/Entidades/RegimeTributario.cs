
namespace PDV.DAO.Entidades
{
    public class RegimeTributario
    {
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }

        public RegimeTributario()
        {
        }

        public RegimeTributario(decimal _Codigo, string _Descricao)
        {
            Codigo = _Codigo;
            Descricao = _Descricao;
        }
    }
}
