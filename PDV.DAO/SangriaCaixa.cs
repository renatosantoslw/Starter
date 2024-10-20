using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades
{
    public class SangriaCaixa
    {
        [CampoTabela("IDSANGRIACAIXA")]
        public decimal IDSangriaCaixa { get; set; }
        [CampoTabela("IDUSUARIO")]
        public decimal IDUsuario { get; set; }
        [CampoTabela("IDUSUARIOCADASTRO")]
        public decimal IDUsuarioCadastro { get; set; }
        [CampoTabela("IDFLUXOCAIXA")]
        public decimal IDFluxoCaixa { get; set; }
        [CampoTabela("DATASANGRIA")]
        public DateTime? DataSangria { get; set; }
        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }
        [CampoTabela("OBSERVACAO")]
        public string Observacao { get; set; }

        public SangriaCaixa() { }
    }
}
