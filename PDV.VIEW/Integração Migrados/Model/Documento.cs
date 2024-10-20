namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Documento")]
    public partial class Documento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Documento()
        {
            ChequeHistorico = new HashSet<ChequeHistorico>();
        }

        public int ID { get; set; }

        public int Codigo { get; set; }

        public int? Tipo { get; set; }

        public int? IDFilial { get; set; }

        public int? IDPessoa { get; set; }

        public int? IDTipoDocumento { get; set; }

        public int? IDBanco { get; set; }

        public int? IDPortador { get; set; }

        public int? IDAcrescimo { get; set; }

        public DateTime? Dt { get; set; }

        public DateTime? DtDigitacao { get; set; }

        public DateTime? DtVencimento { get; set; }

        public DateTime? DtPrevisao { get; set; }

        [StringLength(10)]
        public string NumDocumento { get; set; }

        [StringLength(10)]
        public string NumRequisicao { get; set; }

        public int? IDCondicao { get; set; }

        public int? Parcela { get; set; }

        public int? QtParcela { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Valor { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValorTotal { get; set; }

        public int? IDHistorico { get; set; }

        [StringLength(180)]
        public string ComplementoHist { get; set; }

        public int? CodBanco { get; set; }

        [StringLength(60)]
        public string Banco_Str { get; set; }

        [StringLength(8)]
        public string Agencia { get; set; }

        [StringLength(15)]
        public string Conta { get; set; }

        [StringLength(8)]
        public string Cheque { get; set; }

        [StringLength(60)]
        public string Emitente { get; set; }

        public byte? bEntrada { get; set; }

        public int? IDNota { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Saldo { get; set; }

        [StringLength(10)]
        public string Situacao { get; set; }

        public DateTime? DtUltimaBaixa { get; set; }

        public bool? bImpresso { get; set; }

        public bool? bGeradoPDF { get; set; }

        public bool? bGeradoRemessa { get; set; }

        public bool? bEnviadoEmail { get; set; }

        [StringLength(2)]
        public string MovimentoRemessa { get; set; }

        [StringLength(4)]
        public string NumBanco { get; set; }

        [StringLength(19)]
        public string CpfCnpj { get; set; }

        [StringLength(100)]
        public string NomeBanco { get; set; }

        public DateTime? IncData { get; set; }

        [StringLength(20)]
        public string IncUsuario { get; set; }

        public DateTime? AltData { get; set; }

        [StringLength(20)]
        public string AltUsuario { get; set; }

        [StringLength(8000)]
        public string Legado_Observacao { get; set; }

        [StringLength(100)]
        public string Legado_Fornecedor { get; set; }

        [StringLength(20)]
        public string Legado_NotaFiscal { get; set; }

        public int? IdPedidoMagento { get; set; }

        [StringLength(100)]
        public string NossoNumero { get; set; }

        public DateTime? DtEmailEnviado { get; set; }

        public int? IDContrato { get; set; }

        public int? IDArquivoRemessa { get; set; }

        public DateTime? DataDesconto { get; set; }

        public int? NumeroPedido { get; set; }

        public DateTime? DtTransferenciaOuBaixaRet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChequeHistorico> ChequeHistorico { get; set; }

        public virtual Condicao Condicao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
