using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades.Email_Report_Gestor
{
    public class PosicaoDeEstoque
    {
        public string  Produto { get; set; }
        public string Unidade { get; set; }
        public string Grupo { get; set; }

        public decimal Custo { get; set; }
        public int Saldo { get; set; }

        public decimal TotalCusto { get; set; }


    }
}
