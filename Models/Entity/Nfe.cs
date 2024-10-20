using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Nfe
    {
        public Nfe()
        {
            Documentoreferenciadonves = new HashSet<Documentoreferenciadonfe>();
            Duplicatanves = new HashSet<Duplicatanfe>();
            Movimentofiscals = new HashSet<Movimentofiscal>();
            Produtonves = new HashSet<Produtonfe>();
            Volumenves = new HashSet<Volumenfe>();
        }

        public int Idnfe { get; set; }
        public int? Idcliente { get; set; }
        public int? Idtipoatendimento { get; set; }
        public int? Idfinalidade { get; set; }
        public int? Idcfop { get; set; }
        public int? Idusuario { get; set; }
        public int? Idtransportadora { get; set; }
        public DateTime? Emissao { get; set; }
        public DateTime? Saida { get; set; }
        public decimal? Modelo { get; set; }
        public decimal? Serie { get; set; }
        public string Placa { get; set; }
        public string Antt { get; set; }
        public string Veiculo { get; set; }
        public decimal? Fretepor { get; set; }
        public string Informacoescomplementares { get; set; }
        public decimal? Indpagamento { get; set; }
        public int? Idformadepagamento { get; set; }
        public int? Idvenda { get; set; }

        public virtual Cfop IdcfopNavigation { get; set; }
        public virtual Finalidade IdfinalidadeNavigation { get; set; }
        public virtual Formadepagamento IdformadepagamentoNavigation { get; set; }
        public virtual Tipoatendimento IdtipoatendimentoNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Documentoreferenciadonfe> Documentoreferenciadonves { get; set; }
        public virtual ICollection<Duplicatanfe> Duplicatanves { get; set; }
        public virtual ICollection<Movimentofiscal> Movimentofiscals { get; set; }
        public virtual ICollection<Produtonfe> Produtonves { get; set; }
        public virtual ICollection<Volumenfe> Volumenves { get; set; }
    }
}
