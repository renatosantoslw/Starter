using PDV.DAO.Atributos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades
{
    public class Caixa
    {
        [CampoTabela("IDCAIXA")]
        [MaxLength(18)]
        public decimal IDCaixa { get; set; } = -1;

        [CampoTabela("NUMEROCAIXA")]
        [MaxLength(50)]
        public string NumeroCaixa { get; set; }

        [CampoTabela("SERIALPOS")]
        [MaxLength(50)]
        public string SerialPOS { get; set; }

        [CampoTabela("NOMEPOS")]
        [MaxLength(50)]
        public string NomePOS { get; set; }


        [CampoTabela("ATIVO")]
        public bool Ativo { get; set; }

             
        [CampoTabela("TIPODEVENDA")]
        public String TipoDeVenda { get; set; }


        [CampoTabela("MOSTRAR_RELATORIO_CAIXA")]
       
        public bool Mostrar_Relatorio_Caixa { get; set; }



        public int TipoPDV { get; set; }

        public static readonly int Mercado = 1;

        public static readonly int Restaurante = 2;
    }
}
