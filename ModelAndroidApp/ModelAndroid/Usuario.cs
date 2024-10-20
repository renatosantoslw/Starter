using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndroidApp
{
    public class Usuario
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Senha { get; set; }

        public int? IDVendedor { get; set; }

        public int? EmpresaID { get; set; }
    }
}
