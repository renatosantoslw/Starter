using System;

namespace PDV.DAO.QueryModels
{
    public class ResumoPorProdutoGenericoReportModel
    {
        public DateTime DataDe { get; set; }

        public DateTime DataAte { get; set; }

        public string Status { get; set; }

        public string IDsOperacaoString { get; set; }

        public string Titulo { get; set; }

        public string FiltrarPor { get; set; }
    }
}
