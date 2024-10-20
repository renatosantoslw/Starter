using System;
using System.Collections.Generic;
using System.Text;

namespace AppFiscal.Model.APP
{
    public class BaseAPP
    {
        public int ID { get; set; }
        //Cada coluna representa uma entidade , nela vai ser gravada o JSON do quem do ERP
        public String Servico { get; set; }
        public String Emitente { get; set; }
        public String Clientes { get; set; }
        public String Fornecedores { get; set; }
        public String Transportadoras { get; set; }
        public String Usuarios { get; set; }
        public String Produtos { get; set; }
        public String IntegracaoFiscal { get; set; }
        public String NCM { get; set; }
        public String FormaDePagamento { get; set; }
        public String UnidadeMedida { get; set; }
    }
}
