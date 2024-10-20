using System;

namespace PDV.DAO.QueryModels
{
    public class ResumoVendasQueryModel
    {
        public DateTime DataDe { get; set; }

        public DateTime DataAte { get; set; }

        public string Status { get; set; }

        public string IDsOperacaoString { get; set; }
    }
}
