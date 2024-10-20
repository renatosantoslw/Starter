using System;

namespace PDV.DAO.QueryModels
{
    public class MovimentoDeEstoquePorVendaQueryModel
    {
        public DateTime DataDe { get; set; }

        public DateTime DataAte { get; set; }

        public string Pesquisa { get; set; }
    }
}
