using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.NFe
{
    public class DuplicataNFe
    {
        [CampoTabela("IDDUPLICATANFE")]
        public decimal IDDuplicataNFe { get; set; } = -1;

        [CampoTabela("NUMERODOCUMENTO")]
        public string NumeroDocumento { get; set; }

        [CampoTabela("DATAVENCIMENTO")]
        public DateTime DataVencimento { get; set; }

        [CampoTabela("VALOR")]
        public decimal Valor { get; set; }

        [CampoTabela("IDNFE")]
        public decimal IDNFe { get; set; }

        [CampoTabela("IDFORMADEPAGAMENTO")]
        public decimal IDFormaDePagamento { get; set; }


        public DuplicataNFe()
        {

        }
    }
}