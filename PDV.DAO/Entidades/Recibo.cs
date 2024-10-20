using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades
{
    public class Recibo
    {
        public string  Pessoa { get; set; }
        public string PessoaEndereco { get; set; }
        public string Referente { get; set; }
        public decimal Valor { get; set; }
        public string Importancia { get; set; }
        public string Emitente { get; set; }
        public string EmitenteEndereco { get; set; }
        public string EmitenteDocumento { get; set; }
        public string Data { get; set; }
    }
}
