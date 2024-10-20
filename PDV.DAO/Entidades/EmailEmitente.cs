using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class EmailEmitente
    {
        [CampoTabela("IDEMAILEMITENTE")]
        [MaxLength(18)]
        public decimal IDEmailEmitente { get; set; } = -1;

        [CampoTabela("IDEMITENTE")]
        [MaxLength(18)]
        public decimal IDEmitente { get; set; }

        [CampoTabela("AUTORIZARENVIAREMAIL")]
        [MaxLength(1)]
        public decimal AutorizarEnviarEmail { get; set; }

        [CampoTabela("AUTORIZARASSUNTO")]
        [MaxLength(150)]
        public string AutorizarAssunto { get; set; }

        [CampoTabela("AUTORIZARMENSAGEM")]
        [MaxLength(1000)]
        public string AutorizarMensagem { get; set; }

        [CampoTabela("CANCELARENVIAREMAIL")]
        [MaxLength(1)]
        public decimal CancelarEnviarEmail { get; set; }

        [CampoTabela("CANCELARASSUNTO")]
        [MaxLength(150)]
        public string CancelarAssunto { get; set; }

        [CampoTabela("CANCELARMENSAGEM")]
        [MaxLength(1000)]
        public string CancelarMensagem { get; set; }


        public EmailEmitente()
        {
        }
    }
}
