using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades
{
    public class SuprimentoCaixa
    {
        [CampoTabela("IDSUPRIMENTOCAIXA")]
        public decimal IDSuprimentocaixa { get; set; }
        [CampoTabela("IDUSUARIO")]
        public decimal IDUsuario { get; set; }
        [CampoTabela("IDUSUARIOCADASTRO")]
        public decimal IDUsuarioCadastro { get; set; }
        [CampoTabela("IDFLUXOCAIXA")]
        public decimal IDFluxoCaixa { get; set; }
        [CampoTabela("DATASUPRIMENTOCAIXA")]
        public DateTime? DataSuprimentocaixa { get; set; }
        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }
        [CampoTabela("OBSERVACAO")]
        public string Observacao { get; set; }

        public SuprimentoCaixa() { }
    }
}
