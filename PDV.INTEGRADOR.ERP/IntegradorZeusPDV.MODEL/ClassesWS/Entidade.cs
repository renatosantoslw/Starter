namespace IntegradorZeusPDV.MODEL.ClassesWS
{
    public class Entidade
    {
        public decimal Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj_Cpf { get; set; }
        public string Nacimento { get; set; }
        public char Ativo { get; set; }

        public Entidade() { }
    }
}
