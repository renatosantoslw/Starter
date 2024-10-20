using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.Financeiro
{
    public class Talonario
    {

        [CampoTabela("IDTALONARIO")]
        public decimal IDTalonario { get; set; } = -1;

        [CampoTabela("IDCONTABANCARIA")]
        public decimal IDContaBancaria { get; set; }

        [CampoTabela("NUMERO")]
        public string Numero { get; set; }

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; } = DateTime.Now;

        [CampoTabela("INICIO")]
        public decimal Inicio { get; set; }

        [CampoTabela("FIM")]
        public decimal Fim { get; set; }

        [CampoTabela("ATIVO")]
        public decimal Ativo { get; set; } = 1;

        [CampoTabela("OBS")]
        public byte[] Obs { get; set; }

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        public Talonario() { }
    }
}
