namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa")]
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            Cheque = new HashSet<Cheque>();
            Documento = new HashSet<Documento>();
            PessoaAviso = new HashSet<PessoaAviso>();
            PessoaCliente = new HashSet<PessoaCliente>();
            PessoaCliente1 = new HashSet<PessoaCliente>();
            PessoaContabilista = new HashSet<PessoaContabilista>();
            PessoaEmail = new HashSet<PessoaEmail>();
            PessoaEndereco = new HashSet<PessoaEndereco>();
            PessoaEngenheiro = new HashSet<PessoaEngenheiro>();
            PessoaFuncionario = new HashSet<PessoaFuncionario>();
            PessoaSocio = new HashSet<PessoaSocio>();
            PessoaTelefone = new HashSet<PessoaTelefone>();
            PessoaTipoServicoTransporte = new HashSet<PessoaTipoServicoTransporte>();
            PessoaVendedor = new HashSet<PessoaVendedor>();
        }

        public int ID { get; set; }

        public int Codigo { get; set; }

        public byte? bCliente { get; set; }

        public byte? bFornecedor { get; set; }

        public byte? bVendedor { get; set; }

        public byte? bFuncionario { get; set; }

        public byte? bRevenda { get; set; }

        public byte? bClienteRevenda { get; set; }

        public byte? bFuncionarioCliente { get; set; }

        public byte? bOrgaoPublico { get; set; }

        public byte? bContribuinte { get; set; }

        public byte? bAtivo { get; set; }

        [StringLength(80)]
        public string Nome { get; set; }

        [StringLength(10)]
        public string TipoPessoa { get; set; }

        [StringLength(50)]
        public string Apelido { get; set; }

        [StringLength(80)]
        public string Fantasia { get; set; }

        [StringLength(20)]
        public string CNPJ_CPF { get; set; }

        [StringLength(20)]
        public string Inscricao { get; set; }

        [StringLength(30)]
        public string RG { get; set; }

        [StringLength(15)]
        public string Sexo { get; set; }

        [StringLength(30)]
        public string EstadoCivil { get; set; }

        [StringLength(100)]
        public string Http { get; set; }

        [StringLength(100)]
        public string Email1 { get; set; }

        [StringLength(100)]
        public string Email2 { get; set; }

        public DateTime? DtFundacao { get; set; }

        public DateTime? DtNascimento { get; set; }

        public DateTime? DtCadastro { get; set; }

        public int? IDFilial { get; set; }

        public int? IDClassificacao { get; set; }

        public int? IDPessoa { get; set; }

        [StringLength(2000)]
        public string Observacao { get; set; }

        public short? NumeroBanco { get; set; }

        [StringLength(20)]
        public string Agencia { get; set; }

        [StringLength(20)]
        public string ContaCorrente { get; set; }

        public DateTime? IncData { get; set; }

        [StringLength(20)]
        public string IncUsuario { get; set; }

        public DateTime? AltData { get; set; }

        [StringLength(20)]
        public string AltUsuario { get; set; }

        public bool bTransportadora { get; set; }

        [StringLength(8)]
        public string Placa { get; set; }

        [StringLength(2)]
        public string PlacaUF { get; set; }

        public int? IDIntegracao { get; set; }

        [StringLength(15)]
        public string Tratamento { get; set; }

        [StringLength(64)]
        public string SenhaLojaVirtual { get; set; }

        [StringLength(50)]
        public string InscricaoMunicipal { get; set; }

        public byte? bSTRevenda { get; set; }

        public int? IDMercadoLivre { get; set; }

        public bool? bCorreio { get; set; }

        public int? IDSISeCommerce { get; set; }

        public bool bShlTransportadora { get; set; }

        public int CodShl { get; set; }

        public bool? bContabilista { get; set; }

        public int? IDServico { get; set; }

        public decimal ValorHoraAtendimento { get; set; }

        [StringLength(10)]
        public string HorasContratadas { get; set; }

        public bool? bFaturarPorPadrao { get; set; }

        [StringLength(200)]
        public string MotivoInativacao { get; set; }

        public DateTime? DataInativacao { get; set; }

        public int? DiasPadraoLeitura { get; set; }

        [StringLength(50)]
        public string SenhaRevenda { get; set; }

        public bool bConsumidorFinal { get; set; }

        public int? IDRevendaCentralCliente { get; set; }

        public int? DiaVencimentoCartao { get; set; }

        public decimal? TaxaDescontoCartao { get; set; }

        public decimal? TaxaAntecipacaoCartao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cheque> Cheque { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documento> Documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaAviso> PessoaAviso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaCliente> PessoaCliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaCliente> PessoaCliente1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaContabilista> PessoaContabilista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaEmail> PessoaEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaEndereco> PessoaEndereco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaEngenheiro> PessoaEngenheiro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaFuncionario> PessoaFuncionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaSocio> PessoaSocio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaTelefone> PessoaTelefone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaTipoServicoTransporte> PessoaTipoServicoTransporte { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PessoaVendedor> PessoaVendedor { get; set; }
    }
}
