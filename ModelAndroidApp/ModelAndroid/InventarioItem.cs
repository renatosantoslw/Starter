using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndroidApp
{
    public class InventarioItem
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public int ProdutoID { get; set; }
        public string ProdutoNome { get; set; }

        public string Codigo { get; set; }

        public decimal Quantidade { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioNome { get; set; }
        public int EmpresaID { get; set; }
        public string EmpresaNome { get; set; }
        public bool Status { get; set; }
    }
}
