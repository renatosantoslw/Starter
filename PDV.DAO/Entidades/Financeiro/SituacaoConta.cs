using System.Collections.Generic;

namespace PDV.DAO.Entidades.Financeiro
{
    public class SituacaoConta
    {
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }

        public SituacaoConta() { }

        public SituacaoConta(decimal _Codigo, string _Descricao) {
            Codigo = _Codigo;
            Descricao = _Descricao;
        }

        public static List<SituacaoConta> GetSituacoesConta()
        {
            List<SituacaoConta> Situacoes = new List<SituacaoConta>();
            Situacoes.Add(new SituacaoConta(0, "CANCELADO"));
            Situacoes.Add(new SituacaoConta(1, "ABERTO"));
            Situacoes.Add(new SituacaoConta(2, "PARCIAL"));
            Situacoes.Add(new SituacaoConta(3, "BAIXADO"));
            return Situacoes;
        }

    }
}
