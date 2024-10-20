namespace IntegradorZeusPDV.MODEL.ClassesPDV
{
    public class Cliente
    {
        public decimal IDCliente { get; set; }

        public decimal TipoDocumento { get; set; }

        public string CNPJ { get; set; }

        public string CPF { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Nome { get; set; }

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }

        public decimal? IDEndereco { get; set; } = -1;

        public decimal? IDContato { get; set; } = -1;

        public decimal Ativo { get; set; } = 1;

        public decimal ConsumidorFinal { get; set; } = 0;

        public decimal Estrangeiro { get; set; } = 0;

        public string DocEstrangeiro { get; set; }

        public decimal TipoContribuinte { get; set; } = 0;

        public string _CPF_CNPJ { get { return TipoDocumento == 0 ? CNPJ : CPF; } }
        public string _DESCRICAO { get { return TipoDocumento == 0 ? RazaoSocial : Nome; } }

        // Utilizado no PDV para setar o email do cliente
        public string Email { get; set; }

        public string ChaveERP { get; set; }

        public Cliente() { }
    }
}
