using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.NFe
{
    public class NFe
    {
        [CampoTabela("IDNFE")]
        public decimal IDNFe { get; set; } = -1;

        [CampoTabela("IDCFOP")]
        public decimal IDCFOP { get; set; }

        [CampoTabela("EMISSAO")]
        public DateTime Emissao { get; set; } = DateTime.Now;

        [CampoTabela("SAIDA")]
        public DateTime Saida { get; set; } = DateTime.Now;

        [CampoTabela("MODELO")]
        public decimal Modelo { get; set; }

        [CampoTabela("SERIE")]
        public decimal Serie { get; set; }

        [CampoTabela("IDUSUARIO")]
        public decimal IDUsuario { get; set; }

        [CampoTabela("IDFINALIDADE")]
        public decimal IDFinalidade { get; set; } = -1;

        [CampoTabela("IDTIPOATENDIMENTO")]
        public decimal IDTipoAtendimento { get; set; } = -1;

        [CampoTabela("IDCLIENTE")]
        public decimal IDCliente { get; set; }

        [CampoTabela("IDTRANSPORTADORA")]
        public decimal? IDTransportadora { get; set; }

        [CampoTabela("PLACA")]
        public string Placa { get; set; }
        
        [CampoTabela("ANTT")]
        public string ANTT { get; set; }

        [CampoTabela("VEICULO")]
        public string Veiculo { get; set; }

        [CampoTabela("FRETEPOR")]
        public decimal FretePor { get; set; }

        [CampoTabela("INFORMACOESCOMPLEMENTARES")]
        public string InformacoesComplementares { get; set; }

        [CampoTabela("INDPAGAMENTO")]
        public decimal INDPagamento { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal? IDFormaDePagamento { get; set; }

        public decimal IDVenda { get; set; } = -1;
        public NFe() { }
    }
}