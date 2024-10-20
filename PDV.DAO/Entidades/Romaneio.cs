using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades
{
    public class Romaneio
    {
        public decimal IDRomaneio { get; set; } = -1;
        public string Empresa { get; set; }
        public String Status { get; set; } //0-Aberto 1-Fechado 2-Cancelado 3 Entregue
        public DateTime DataInclusao { get; set; }
        public decimal TransportadoraID { get; set; }
        public string TransportadoraNome { get; set; }
        public decimal VeiculoID { get; set; }
        public string VeiculoDescricao { get; set; }
        public string MotoristaNome { get; set; }
        public decimal MotoristaID { get; set; }
        public int TotalItens { get; set; }
        public decimal ValorTotal { get; set; }
        public string Observacao { get; set; }
        public decimal IDUsuario { get; set; }



    }
}
