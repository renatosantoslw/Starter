using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.PDV
{
    public class FluxoCaixa
    {
        [CampoTabela("IDFLUXOCAIXA")]
        [MaxLength(18)]
        public decimal IDFluxoCaixa { get; set; }

        [CampoTabela("IDUSUARIO")]
        [MaxLength(18)]
        public decimal IDUsuario { get; set; }

        [CampoTabela("VALORCAIXA")]
        [MaxLength(7.2)]
        public decimal ValorCaixa { get; set; }

        [CampoTabela("DATAABERTURACAIXA")]
        public DateTime DataAberturaCaixa { get; set; }

        [CampoTabela("DATAFECHAMENTOCAIXA")]
        public DateTime? DataFechamentoCaixa { get; set; }

        [CampoTabela("ABERTO")]
        [MaxLength(1)]
        public decimal Aberto { get; set; }

        [CampoTabela("VALORFECHAMENTOCAIXA")]
        [MaxLength(7.2)]
        public decimal ValorFechamentoCaixa { get; set; }

        [CampoTabela("OBSERVACAO")]
        [MaxLength(1000)]
        public string Observacao { get; set; }

        [CampoTabela("CAIXAID")]
        public int CaixaID { get; set; }

        public FluxoCaixa()
        {
        }
    }
}
