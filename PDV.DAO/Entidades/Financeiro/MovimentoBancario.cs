using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Financeiro
{
    public class MovimentoBancario
    {
        [CampoTabela("IDMOVIMENTOBANCARIO")]
        public decimal IDMovimentoBancario { get; set; } = -1;

        [CampoTabela("IDCONTABANCARIA")]
        public decimal IDContaBancaria { get; set; }

        [CampoTabela("IDNATUREZA")]
        public decimal? IDNatureza { get; set; }

        [CampoTabela("DATAMOVIMENTO")]
        public DateTime DataMovimento { get; set; } = DateTime.Now;

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("DOCUMENTO")]
        public string Documento { get; set; }

        [CampoTabela("SEQUENCIA")]
        public decimal Sequencia { get; set; } = 1;

        [CampoTabela("HISTORICO")]
        public string Historico { get; set; }

        [CampoTabela("TIPO")]
        public decimal Tipo { get; set; } //Credito ou Débito

        [CampoTabela("CONCILIACAO")]
        public DateTime? Conciliacao { get; set; } = null;

        public MovimentoBancario() { }
    }
}