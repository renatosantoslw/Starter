using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades
{
    public class RomaneioVenda
    {
        public decimal IDRomaneioVenda { get; set; } = -1;
        public DateTime? DataFaturamento { get; set; }
        public decimal IDRomaneio { get; set; }
        public decimal IDVenda { get; set; }
        public string  Cliente { get; set; }
        public decimal ValorTotal { get; set; }
        public int TotalItens { get; set; }

        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Observacao { get; set; }

        public int Status { get; set; }
    }
}
