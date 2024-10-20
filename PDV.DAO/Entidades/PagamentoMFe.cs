using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades
{
    public class PagamentoMFe
    {
        [CampoTabela("IDPAGAMENTOMFE")]
        public decimal IDPagamentoMFe { get; set; } = -1;

        [CampoTabela("D")]
        public decimal IDVenda { get; set; } = -1;

        [CampoTabela("DataPagamento")]
        public DateTime DataPagamento { get; set; }

        [CampoTabela("ADQUIRENTE")]
        public string Adquirente { get; set; }

        [CampoTabela("AUTORIZACAO")]
        public string Autorizacao { get; set; }

        [CampoTabela("BANDEIRA")]
        public string Bandeira { get; set; }

        [CampoTabela("BINCARTAO")]
        public string BinCartao { get; set; }

        [CampoTabela("DATAEXPIRACAO")]
        public DateTime DataExpiracao { get; set; }

        [CampoTabela("DONOCARTAO")]
        public string DonoCartao { get; set; }

        [CampoTabela("NSU")]
        public string NSU { get; set; }

        [CampoTabela("QTDPARCELAS")]
        public string QtdParcelas { get; set; }

        [CampoTabela("ULTIMOSQUATRODIGITOS")]
        public string UltimosQuatroDigitos { get; set; }

        [CampoTabela("VALORCARTAO")]
        public string ValorCartao { get; set; }

        [CampoTabela("MFEENVIADODADOSCARTAO")]
        public string MfeEnviadoDadosCartao { get; set; }

        [CampoTabela("IDPagamento")]
        public int IDPagamento { get; set; }

        [CampoTabela("IDLocal")]
        public int IDLocal { get; set; }

        public PagamentoMFe()
        {
        }
    }
}
