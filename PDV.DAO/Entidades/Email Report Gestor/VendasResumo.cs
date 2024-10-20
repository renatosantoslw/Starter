using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades.Email_Report_Gestor
{
    public class VendasResumo
    {
        public DateTime  Data { get; set; }
        public string Cliente { get; set; }

        public string Status { get; set; }
        public string  Produto { get; set; }
        public decimal  ValorProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Desconto { get; set; }
        public decimal  SubTotal { get; set; }
        public decimal TotalCliente  { get; set; }
    }
}
