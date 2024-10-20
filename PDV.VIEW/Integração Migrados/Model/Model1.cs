namespace PDV.VIEW.Integração_Migrados.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cheque> Cheque { get; set; }
        public virtual DbSet<ChequeHistorico> ChequeHistorico { get; set; }
        public virtual DbSet<Condicao> Condicao { get; set; }
        public virtual DbSet<CondicaoParcela> CondicaoParcela { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaAviso> PessoaAviso { get; set; }
        public virtual DbSet<PessoaCliente> PessoaCliente { get; set; }
        public virtual DbSet<PessoaContabilista> PessoaContabilista { get; set; }
        public virtual DbSet<PessoaEmail> PessoaEmail { get; set; }
        public virtual DbSet<PessoaEndereco> PessoaEndereco { get; set; }
        public virtual DbSet<PessoaEngenheiro> PessoaEngenheiro { get; set; }
        public virtual DbSet<PessoaFuncionario> PessoaFuncionario { get; set; }
        public virtual DbSet<PessoaSocio> PessoaSocio { get; set; }
        public virtual DbSet<PessoaTelefone> PessoaTelefone { get; set; }
        public virtual DbSet<PessoaTipoServicoTransporte> PessoaTipoServicoTransporte { get; set; }
        public virtual DbSet<PessoaVendedor> PessoaVendedor { get; set; }
        public virtual DbSet<PlanoConta> PlanoConta { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<v_PessoaDados> v_PessoaDados { get; set; }
        public virtual DbSet<v_Produtos> v_Produtos { get; set; }

        public virtual DbSet<VWContasReceber> VWContasReceber { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cheque>()
                .Property(e => e.Banco)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.Agencia)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.ContaCorrente)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.Emitente)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.CNPJCPF_Emitente)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.IncUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .Property(e => e.AltUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Cheque>()
                .HasMany(e => e.ChequeHistorico)
                .WithOptional(e => e.Cheque)
                .HasForeignKey(e => e.IDCheque);

            modelBuilder.Entity<ChequeHistorico>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<ChequeHistorico>()
                .Property(e => e.Movimento)
                .IsUnicode(false);

            modelBuilder.Entity<ChequeHistorico>()
                .Property(e => e.OrigemMovimento)
                .IsUnicode(false);

            modelBuilder.Entity<Condicao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Condicao>()
                .Property(e => e.TipoDt)
                .IsUnicode(false);

            modelBuilder.Entity<Condicao>()
                .Property(e => e.TipoVlr)
                .IsUnicode(false);

            modelBuilder.Entity<Condicao>()
                .Property(e => e.Desconto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Condicao>()
                .Property(e => e.Variacao)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Condicao>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Condicao>()
                .HasMany(e => e.CondicaoParcela)
                .WithRequired(e => e.Condicao)
                .HasForeignKey(e => e.IDCondicao);

            modelBuilder.Entity<Condicao>()
                .HasMany(e => e.Documento)
                .WithOptional(e => e.Condicao)
                .HasForeignKey(e => e.IDCondicao);

            modelBuilder.Entity<Condicao>()
                .HasMany(e => e.PessoaCliente)
                .WithOptional(e => e.Condicao)
                .HasForeignKey(e => e.IDCondicao);

            modelBuilder.Entity<CondicaoParcela>()
                .Property(e => e.TipoDt)
                .IsUnicode(false);

            modelBuilder.Entity<CondicaoParcela>()
                .Property(e => e.TipoVlr)
                .IsUnicode(false);

            modelBuilder.Entity<CondicaoParcela>()
                .Property(e => e.VlrPerc)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Documento>()
                .Property(e => e.NumDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.NumRequisicao)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.ComplementoHist)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Banco_Str)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Agencia)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Conta)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Cheque)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Emitente)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Situacao)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.MovimentoRemessa)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.NumBanco)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.CpfCnpj)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.NomeBanco)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.IncUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.AltUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Legado_Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Legado_Fornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .Property(e => e.Legado_NotaFiscal)
                .IsUnicode(false);

            modelBuilder.Entity<Documento>()
                .HasMany(e => e.ChequeHistorico)
                .WithOptional(e => e.Documento)
                .HasForeignKey(e => e.IDDocumento);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.TipoPessoa)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Apelido)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Fantasia)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.CNPJ_CPF)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Inscricao)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.EstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Http)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Email1)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Email2)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Agencia)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.ContaCorrente)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.IncUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.AltUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Placa)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.PlacaUF)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Tratamento)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.SenhaLojaVirtual)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.InscricaoMunicipal)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.HorasContratadas)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.MotivoInativacao)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.SenhaRevenda)
                .IsUnicode(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Cheque)
                .WithOptional(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Documento)
                .WithOptional(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaAviso)
                .WithOptional(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaCliente)
                .WithOptional(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaCliente1)
                .WithOptional(e => e.Pessoa1)
                .HasForeignKey(e => e.IDVendedor);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaContabilista)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaEmail)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaEndereco)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaEngenheiro)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaFuncionario)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaSocio)
                .WithOptional(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaTelefone)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaTipoServicoTransporte)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.PessoaVendedor)
                .WithRequired(e => e.Pessoa)
                .HasForeignKey(e => e.IDPessoa);

            modelBuilder.Entity<PessoaAviso>()
                .Property(e => e.Ordem)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaAviso>()
                .Property(e => e.Aviso)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaCliente>()
                .Property(e => e.NomeConjuge)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaCliente>()
                .Property(e => e.NomePai)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaCliente>()
                .Property(e => e.NomeMae)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaContabilista>()
                .Property(e => e.CRC)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaContabilista>()
                .Property(e => e.CNPJEscritorio)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEmail>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEndereco>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEndereco>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEndereco>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEndereco>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEndereco>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEndereco>()
                .Property(e => e.Contato)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEndereco>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEndereco>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaEngenheiro>()
                .Property(e => e.CREA)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaFuncionario>()
                .Property(e => e.NumCarteiraTrab)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaTelefone>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaTelefone>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaTelefone>()
                .Property(e => e.Contato)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaTelefone>()
                .Property(e => e.Operadora)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaTipoServicoTransporte>()
                .Property(e => e.CodContrato)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaVendedor>()
                .Property(e => e.ComissaoVendedor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PessoaVendedor>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<PessoaVendedor>()
                .Property(e => e.ComissaoServicoVendedor)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PlanoConta>()
                .Property(e => e.Classificacao)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoConta>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoConta>()
                .Property(e => e.Cod_Nat_CC)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Barra)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DescReduzida)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.BarraFornecedor)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DescLonga1)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DescLonga2)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DescLonga3)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.PesoLiquido)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Produto>()
                .Property(e => e.PesoBruto)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DescontoFornecedor)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqISS)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.ClassFiscal)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqContrib)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqContribNormal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.ReducaoContrib)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Produto>()
                .Property(e => e.TextoLeiContrib)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqNContrib)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqNContribNormal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.ReducaoNContrib)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Produto>()
                .Property(e => e.TextoLeiNContrib)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.LucroST)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.pRedBCST)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqSubstTributaria)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqSimplesSubst)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.pPIS_Q08)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Produto>()
                .Property(e => e.pCOFINS_S08)
                .HasPrecision(15, 4);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliquotaIPI)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Produto>()
                .Property(e => e.NCM)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.InfAdicionais)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqCupomContrib)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AliqCupomNContrib)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.CaminhoImagem)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.IncUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.AltUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.BarraFornecedor2)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.BarraFornecedor3)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.BarraFornecedor4)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.BarraFornecedor5)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Largura)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Altura)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Comprimento)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Peso)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Localizacao)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DescricaoAnterior)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.RAZAO_Fab)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.CNPJ_Fab)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.CBenef)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Tara)
                .HasPrecision(19, 2);

            modelBuilder.Entity<Produto>()
                .HasOptional(e => e.Produto1)
                .WithRequired(e => e.Produto2);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaNome)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaCNPJ_CPF)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaInscRG)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaEndereco)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaBairro)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaCidade)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaUF)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaTelefone)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaCidadeIBGE)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaCEP)
                .IsUnicode(false);

            modelBuilder.Entity<v_PessoaDados>()
                .Property(e => e.PessoaComplemento)
                .IsUnicode(false);

            modelBuilder.Entity<v_Produtos>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<v_Produtos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<v_Produtos>()
                .Property(e => e.Unidade)
                .IsUnicode(false);

            modelBuilder.Entity<v_Produtos>()
                .Property(e => e.DescReduzida)
                .IsUnicode(false);

            modelBuilder.Entity<v_Produtos>()
                .Property(e => e.Grupo)
                .IsUnicode(false);

            modelBuilder.Entity<v_Produtos>()
                .Property(e => e.NomeTrocado)
                .IsUnicode(false);

            modelBuilder.Entity<v_Produtos>()
                .Property(e => e.Barra)
                .IsUnicode(false);

            modelBuilder.Entity<v_Produtos>()
                .Property(e => e.BarraFornecedor)
                .IsUnicode(false);
        }
    }
}
