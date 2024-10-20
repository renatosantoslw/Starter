using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades.Email_Report_Gestor
{
 
    public class FluxoCaixaDiario
    {
        public DateTime Data { get; set; }
        public string Pessoa { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
    }
}
