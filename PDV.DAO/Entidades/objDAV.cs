using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades
{
    public class objDAV
    {
        public string Codigo { get; set; }
        public string Data { get; set; }
        public string Vendedor { get; set; }
        public string Cliente { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string codigoProduto { get; set; }
        public string Produto { get; set; }
        public string Quantidade { get; set; }
        public string UN { get; set; }
        public string Valor { get; set; }
        public string Desconto { get; set; }
        public string valorTotal { get; set; }

        public byte[] imagemproduto { get; set; }
        public string Observacao { get; set; }
    }
}
