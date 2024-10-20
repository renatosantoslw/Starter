using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Models.Entity
{
    public partial class ROOTSYSContext : DbContext
    {
        public ROOTSYSContext()
        {
        }

        public ROOTSYSContext(DbContextOptions<ROOTSYSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Almoxarifado> Almoxarifados { get; set; }
        public virtual DbSet<Averbacaoseguradoramdfe> Averbacaoseguradoramdves { get; set; }
        public virtual DbSet<Baixapagamento> Baixapagamentos { get; set; }
        public virtual DbSet<Baixarecebimento> Baixarecebimentos { get; set; }
        public virtual DbSet<Banco> Bancos { get; set; }
        public virtual DbSet<Bandeiracartao> Bandeiracartaos { get; set; }
        public virtual DbSet<Caixa> Caixas { get; set; }
        public virtual DbSet<Carregamentomdfe> Carregamentomdves { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Centrocusto> Centrocustos { get; set; }
        public virtual DbSet<Cfop> Cfops { get; set; }
        public virtual DbSet<Chequecontapagar> Chequecontapagars { get; set; }
        public virtual DbSet<Chequecontareceber> Chequecontarecebers { get; set; }
        public virtual DbSet<Ciotmdfe> Ciotmdves { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Comandum> Comanda { get; set; }
        public virtual DbSet<Condutor> Condutors { get; set; }
        public virtual DbSet<Conferenciacaixapdv> Conferenciacaixapdvs { get; set; }
        public virtual DbSet<Configuracao> Configuracaos { get; set; }
        public virtual DbSet<Contabancarium> Contabancaria { get; set; }
        public virtual DbSet<Contacobranca> Contacobrancas { get; set; }
        public virtual DbSet<Contapagar> Contapagars { get; set; }
        public virtual DbSet<Contareccobranca> Contareccobrancas { get; set; }
        public virtual DbSet<Contareceber> Contarecebers { get; set; }
        public virtual DbSet<Contarecobranca> Contarecobrancas { get; set; }
        public virtual DbSet<Contato> Contatos { get; set; }
        public virtual DbSet<Contatoclientefornecedor> Contatoclientefornecedors { get; set; }
        public virtual DbSet<Contratantemdfe> Contratantemdves { get; set; }
        public virtual DbSet<Conversaounidadedemedidum> Conversaounidadedemedida { get; set; }
        public virtual DbSet<Cstcofin> Cstcofins { get; set; }
        public virtual DbSet<Csticm> Csticms { get; set; }
        public virtual DbSet<Cstipi> Cstipis { get; set; }
        public virtual DbSet<Cstpi> Cstpis { get; set; }
        public virtual DbSet<Documentofiscalmdfe> Documentofiscalmdves { get; set; }
        public virtual DbSet<Documentoreferenciadonfe> Documentoreferenciadonves { get; set; }
        public virtual DbSet<Downloadnfe> Downloadnves { get; set; }
        public virtual DbSet<Duplicatadac> Duplicatadacs { get; set; }
        public virtual DbSet<Duplicatanfce> Duplicatanfces { get; set; }
        public virtual DbSet<Duplicatanfe> Duplicatanves { get; set; }
        public virtual DbSet<Emailemitente> Emailemitentes { get; set; }
        public virtual DbSet<Emitente> Emitentes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Eventomdfe> Eventomdves { get; set; }
        public virtual DbSet<Eventonfe> Eventonves { get; set; }
        public virtual DbSet<Finalidade> Finalidades { get; set; }
        public virtual DbSet<Fluxocaixa> Fluxocaixas { get; set; }
        public virtual DbSet<Formadepagamento> Formadepagamentos { get; set; }
        public virtual DbSet<Fornecedor> Fornecedors { get; set; }
        public virtual DbSet<Historicoclientefornecedor> Historicoclientefornecedors { get; set; }
        public virtual DbSet<Historicofinanceiro> Historicofinanceiros { get; set; }
        public virtual DbSet<Integracaofiscal> Integracaofiscals { get; set; }
        public virtual DbSet<Inventario> Inventarios { get; set; }
        public virtual DbSet<Iteminventario> Iteminventarios { get; set; }
        public virtual DbSet<Itemmenu> Itemmenus { get; set; }
        public virtual DbSet<Itemnfeentradum> Itemnfeentrada { get; set; }
        public virtual DbSet<Itempedidocompra> Itempedidocompras { get; set; }
        public virtual DbSet<Itemtransferenciaestoque> Itemtransferenciaestoques { get; set; }
        public virtual DbSet<Itemvendum> Itemvenda { get; set; }
        public virtual DbSet<Lacrerodoviariomdfe> Lacrerodoviariomdves { get; set; }
        public virtual DbSet<Manifestacaodestinatario> Manifestacaodestinatarios { get; set; }
        public virtual DbSet<Maquina> Maquinas { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Mdfe> Mdves { get; set; }
        public virtual DbSet<Motivocancelamento> Motivocancelamentos { get; set; }
        public virtual DbSet<Movimentobancario> Movimentobancarios { get; set; }
        public virtual DbSet<Movimentoestoque> Movimentoestoques { get; set; }
        public virtual DbSet<Movimentofiscal> Movimentofiscals { get; set; }
        public virtual DbSet<Movimentofiscalmdfe> Movimentofiscalmdves { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Natureza> Naturezas { get; set; }
        public virtual DbSet<Ncm> Ncms { get; set; }
        public virtual DbSet<Nfe> Nves { get; set; }
        public virtual DbSet<Nfeentradaxml> Nfeentradaxmls { get; set; }
        public virtual DbSet<Nfeentradum> Nfeentrada { get; set; }
        public virtual DbSet<Nfereferenciadamdfe> Nfereferenciadamdves { get; set; }
        public virtual DbSet<Origemproduto> Origemprodutos { get; set; }
        public virtual DbSet<Pagamentomfe> Pagamentomves { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Pedidocompra> Pedidocompras { get; set; }
        public virtual DbSet<Percursomdfe> Percursomdves { get; set; }
        public virtual DbSet<Perfilacesso> Perfilacessos { get; set; }
        public virtual DbSet<Perfilacessoitemmenu> Perfilacessoitemmenus { get; set; }
        public virtual DbSet<Portarium> Portaria { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Produtocomposicao> Produtocomposicaos { get; set; }
        public virtual DbSet<Produtofornecedor> Produtofornecedors { get; set; }
        public virtual DbSet<Produtonfe> Produtonves { get; set; }
        public virtual DbSet<Produtonfecofin> Produtonfecofins { get; set; }
        public virtual DbSet<Produtonfeicm> Produtonfeicms { get; set; }
        public virtual DbSet<Produtonfepartilhaicm> Produtonfepartilhaicms { get; set; }
        public virtual DbSet<Produtonfepi> Produtonfepis { get; set; }
        public virtual DbSet<Proprietarioveiculomdfe> Proprietarioveiculomdves { get; set; }
        public virtual DbSet<Requisitante> Requisitantes { get; set; }
        public virtual DbSet<Responsavelsegurocargamdfe> Responsavelsegurocargamdves { get; set; }
        public virtual DbSet<Retiradacaixa> Retiradacaixas { get; set; }
        public virtual DbSet<Romaneio> Romaneios { get; set; }
        public virtual DbSet<Romaneiovendum> Romaneiovenda { get; set; }
        public virtual DbSet<Saldoestoqueinicial> Saldoestoqueinicials { get; set; }
        public virtual DbSet<Sangriacaixa> Sangriacaixas { get; set; }
        public virtual DbSet<Seguradora> Seguradoras { get; set; }
        public virtual DbSet<Seguradoramdfe> Seguradoramdves { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }
        public virtual DbSet<Suprimentocaixa> Suprimentocaixas { get; set; }
        public virtual DbSet<Talonario> Talonarios { get; set; }
        public virtual DbSet<Tipoatendimento> Tipoatendimentos { get; set; }
        public virtual DbSet<Tipodeoperacao> Tipodeoperacaos { get; set; }
        public virtual DbSet<Tipooperacao> Tipooperacaos { get; set; }
        public virtual DbSet<Transferenciaestoque> Transferenciaestoques { get; set; }
        public virtual DbSet<Transportadora> Transportadoras { get; set; }
        public virtual DbSet<Unidadedemedidum> Unidadedemedida { get; set; }
        public virtual DbSet<Unidadefederativa> Unidadefederativas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Valepedagiomdfe> Valepedagiomdves { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }
        public virtual DbSet<Veiculotracaomdfe> Veiculotracaomdves { get; set; }
        public virtual DbSet<Vendum> Venda { get; set; }
        public virtual DbSet<Volumenfe> Volumenves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=ROOTSYS;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Almoxarifado>(entity =>
            {
                entity.HasKey(e => e.Idalmoxarifado)
                    .HasName("almoxarifado_pkey");

                entity.ToTable("almoxarifado");

                entity.Property(e => e.Idalmoxarifado)
                    .ValueGeneratedNever()
                    .HasColumnName("idalmoxarifado");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(30)
                    .HasColumnName("descricao");

                entity.Property(e => e.Tipo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Averbacaoseguradoramdfe>(entity =>
            {
                entity.HasKey(e => e.Idaverbacaoseguradoramdfe)
                    .HasName("averbacaoseguradoramdfe_pkey");

                entity.ToTable("averbacaoseguradoramdfe");

                entity.Property(e => e.Idaverbacaoseguradoramdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idaverbacaoseguradoramdfe");

                entity.Property(e => e.Idseguradoramdfe).HasColumnName("idseguradoramdfe");

                entity.Property(e => e.Numeroaverbacao)
                    .HasMaxLength(40)
                    .HasColumnName("numeroaverbacao");

                entity.HasOne(d => d.IdseguradoramdfeNavigation)
                    .WithMany(p => p.Averbacaoseguradoramdves)
                    .HasForeignKey(d => d.Idseguradoramdfe)
                    .HasConstraintName("averbacaoseguradoramdfe_idseguradoramdfe_fkey");
            });

            modelBuilder.Entity<Baixapagamento>(entity =>
            {
                entity.HasKey(e => e.Idbaixapagamento)
                    .HasName("baixapagamento_pkey");

                entity.ToTable("baixapagamento");

                entity.Property(e => e.Idbaixapagamento)
                    .ValueGeneratedNever()
                    .HasColumnName("idbaixapagamento");

                entity.Property(e => e.Baixa)
                    .HasColumnType("date")
                    .HasColumnName("baixa");

                entity.Property(e => e.Complmhisfin)
                    .HasMaxLength(30)
                    .HasColumnName("complmhisfin");

                entity.Property(e => e.Dataconciliacao)
                    .HasColumnType("date")
                    .HasColumnName("dataconciliacao");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("desconto");

                entity.Property(e => e.Idcontabancaria).HasColumnName("idcontabancaria");

                entity.Property(e => e.Idcontapagar).HasColumnName("idcontapagar");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Idhistoricofinanceiro).HasColumnName("idhistoricofinanceiro");

                entity.Property(e => e.Juros)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("juros");

                entity.Property(e => e.Multa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("multa");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdcontabancariaNavigation)
                    .WithMany(p => p.Baixapagamentos)
                    .HasForeignKey(d => d.Idcontabancaria)
                    .HasConstraintName("baixapagamento_idcontabancaria_fkey");

                entity.HasOne(d => d.IdcontapagarNavigation)
                    .WithMany(p => p.Baixapagamentos)
                    .HasForeignKey(d => d.Idcontapagar)
                    .HasConstraintName("baixapagamento_idcontapagar_fkey");

                entity.HasOne(d => d.IdformadepagamentoNavigation)
                    .WithMany(p => p.Baixapagamentos)
                    .HasForeignKey(d => d.Idformadepagamento)
                    .HasConstraintName("baixapagamento_idformadepagamento_fkey");

                entity.HasOne(d => d.IdhistoricofinanceiroNavigation)
                    .WithMany(p => p.Baixapagamentos)
                    .HasForeignKey(d => d.Idhistoricofinanceiro)
                    .HasConstraintName("baixapagamento_idhistoricofinanceiro_fkey");
            });

            modelBuilder.Entity<Baixarecebimento>(entity =>
            {
                entity.HasKey(e => e.Idbaixarecebimento)
                    .HasName("baixarecebimento_pkey");

                entity.ToTable("baixarecebimento");

                entity.Property(e => e.Idbaixarecebimento)
                    .ValueGeneratedNever()
                    .HasColumnName("idbaixarecebimento");

                entity.Property(e => e.Baixa)
                    .HasColumnType("date")
                    .HasColumnName("baixa");

                entity.Property(e => e.Complmhisfin)
                    .HasMaxLength(30)
                    .HasColumnName("complmhisfin");

                entity.Property(e => e.Dataconciliacao)
                    .HasColumnType("date")
                    .HasColumnName("dataconciliacao");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("desconto");

                entity.Property(e => e.Idcontabancaria).HasColumnName("idcontabancaria");

                entity.Property(e => e.Idcontareceber).HasColumnName("idcontareceber");

                entity.Property(e => e.Idfluxocaixa).HasColumnName("idfluxocaixa");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Idhistoricofinanceiro).HasColumnName("idhistoricofinanceiro");

                entity.Property(e => e.Juros)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("juros");

                entity.Property(e => e.Multa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("multa");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdcontabancariaNavigation)
                    .WithMany(p => p.Baixarecebimentos)
                    .HasForeignKey(d => d.Idcontabancaria)
                    .HasConstraintName("baixarecebimento_idcontabancaria_fkey");

                entity.HasOne(d => d.IdcontareceberNavigation)
                    .WithMany(p => p.Baixarecebimentos)
                    .HasForeignKey(d => d.Idcontareceber)
                    .HasConstraintName("baixarecebimento_idcontareceber_fkey");

                entity.HasOne(d => d.IdformadepagamentoNavigation)
                    .WithMany(p => p.Baixarecebimentos)
                    .HasForeignKey(d => d.Idformadepagamento)
                    .HasConstraintName("baixarecebimento_idformadepagamento_fkey");

                entity.HasOne(d => d.IdhistoricofinanceiroNavigation)
                    .WithMany(p => p.Baixarecebimentos)
                    .HasForeignKey(d => d.Idhistoricofinanceiro)
                    .HasConstraintName("baixarecebimento_idhistoricofinanceiro_fkey");
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(e => e.Idbanco)
                    .HasName("banco_pkey");

                entity.ToTable("banco");

                entity.Property(e => e.Idbanco)
                    .ValueGeneratedNever()
                    .HasColumnName("idbanco");

                entity.Property(e => e.Codbacen)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("codbacen");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Site)
                    .HasMaxLength(100)
                    .HasColumnName("site");
            });

            modelBuilder.Entity<Bandeiracartao>(entity =>
            {
                entity.HasKey(e => e.Idbandeiracartao)
                    .HasName("bandeiracartao_pkey");

                entity.ToTable("bandeiracartao");

                entity.Property(e => e.Idbandeiracartao)
                    .ValueGeneratedNever()
                    .HasColumnName("idbandeiracartao");

                entity.Property(e => e.Codigo)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Caixa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("caixa");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Idcaixa).HasColumnName("idcaixa");

                entity.Property(e => e.Nomepos)
                    .HasMaxLength(50)
                    .HasColumnName("nomepos");

                entity.Property(e => e.Numerocaixa)
                    .HasMaxLength(50)
                    .HasColumnName("numerocaixa");

                entity.Property(e => e.Serialpos)
                    .HasMaxLength(50)
                    .HasColumnName("serialpos");

                entity.Property(e => e.Tipodevenda)
                    .HasMaxLength(15)
                    .HasColumnName("tipodevenda");

                entity.Property(e => e.Tipopdv).HasColumnName("tipopdv");
            });

            modelBuilder.Entity<Carregamentomdfe>(entity =>
            {
                entity.HasKey(e => e.Idcarregamentomdfe)
                    .HasName("carregamentomdfe_pkey");

                entity.ToTable("carregamentomdfe");

                entity.Property(e => e.Idcarregamentomdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idcarregamentomdfe");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.Property(e => e.Idmunicipiocarregamento).HasColumnName("idmunicipiocarregamento");

                entity.Property(e => e.Idunidadefederativacarregamento).HasColumnName("idunidadefederativacarregamento");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Carregamentomdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("carregamentomdfe_idmdfe_fkey");

                entity.HasOne(d => d.IdmunicipiocarregamentoNavigation)
                    .WithMany(p => p.Carregamentomdves)
                    .HasForeignKey(d => d.Idmunicipiocarregamento)
                    .HasConstraintName("carregamentomdfe_idmunicipiocarregamento_fkey");

                entity.HasOne(d => d.IdunidadefederativacarregamentoNavigation)
                    .WithMany(p => p.Carregamentomdves)
                    .HasForeignKey(d => d.Idunidadefederativacarregamento)
                    .HasConstraintName("carregamentomdfe_idunidadefederativacarregamento_fkey");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("categoria_pkey");

                entity.ToTable("categoria");

                entity.Property(e => e.Idcategoria)
                    .ValueGeneratedNever()
                    .HasColumnName("idcategoria");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(6)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .HasColumnName("descricao");

                entity.Property(e => e.Imagem).HasColumnName("imagem");
            });

            modelBuilder.Entity<Centrocusto>(entity =>
            {
                entity.HasKey(e => e.Idcentrocusto)
                    .HasName("tipotitulo_pkey");

                entity.ToTable("centrocusto");

                entity.Property(e => e.Idcentrocusto)
                    .ValueGeneratedNever()
                    .HasColumnName("idcentrocusto");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(20)
                    .HasColumnName("descricao");

                entity.Property(e => e.Sigla)
                    .HasMaxLength(4)
                    .HasColumnName("sigla");

                entity.Property(e => e.Tipodemovimento).HasColumnName("tipodemovimento");
            });

            modelBuilder.Entity<Cfop>(entity =>
            {
                entity.HasKey(e => e.Idcfop)
                    .HasName("cfop_pkey");

                entity.ToTable("cfop");

                entity.Property(e => e.Idcfop)
                    .ValueGeneratedNever()
                    .HasColumnName("idcfop");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(4)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasColumnType("ntext")
                    .HasColumnName("descricao");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Chequecontapagar>(entity =>
            {
                entity.HasKey(e => e.Idchequecontapagar)
                    .HasName("chequecontapagar_pkey");

                entity.ToTable("chequecontapagar");

                entity.Property(e => e.Idchequecontapagar)
                    .ValueGeneratedNever()
                    .HasColumnName("idchequecontapagar");

                entity.Property(e => e.Compensado)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("compensado");

                entity.Property(e => e.Cruzado)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("cruzado");

                entity.Property(e => e.Datacompensacao)
                    .HasColumnType("date")
                    .HasColumnName("datacompensacao");

                entity.Property(e => e.Datadevolucao)
                    .HasColumnType("date")
                    .HasColumnName("datadevolucao");

                entity.Property(e => e.Devolvido)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("devolvido");

                entity.Property(e => e.Emissao)
                    .HasColumnType("date")
                    .HasColumnName("emissao");

                entity.Property(e => e.Idbaixapagamento).HasColumnName("idbaixapagamento");

                entity.Property(e => e.Idtalonario).HasColumnName("idtalonario");

                entity.Property(e => e.Numero)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("numero");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.Property(e => e.Vencimento)
                    .HasColumnType("date")
                    .HasColumnName("vencimento");

                entity.HasOne(d => d.IdbaixapagamentoNavigation)
                    .WithMany(p => p.Chequecontapagars)
                    .HasForeignKey(d => d.Idbaixapagamento)
                    .HasConstraintName("chequecontapagar_idbaixapagamento_fkey");

                entity.HasOne(d => d.IdtalonarioNavigation)
                    .WithMany(p => p.Chequecontapagars)
                    .HasForeignKey(d => d.Idtalonario)
                    .HasConstraintName("chequecontapagar_idtalonario_fkey");
            });

            modelBuilder.Entity<Chequecontareceber>(entity =>
            {
                entity.HasKey(e => e.Idchequecontareceber)
                    .HasName("chequecontareceber_pkey");

                entity.ToTable("chequecontareceber");

                entity.Property(e => e.Idchequecontareceber)
                    .ValueGeneratedNever()
                    .HasColumnName("idchequecontareceber");

                entity.Property(e => e.Compensado)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("compensado");

                entity.Property(e => e.Cruzado)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("cruzado");

                entity.Property(e => e.Datacompensacao)
                    .HasColumnType("date")
                    .HasColumnName("datacompensacao");

                entity.Property(e => e.Datadevolucao)
                    .HasColumnType("date")
                    .HasColumnName("datadevolucao");

                entity.Property(e => e.Datarepasse)
                    .HasColumnType("date")
                    .HasColumnName("datarepasse");

                entity.Property(e => e.Devolvido)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("devolvido");

                entity.Property(e => e.Emissao)
                    .HasColumnType("date")
                    .HasColumnName("emissao");

                entity.Property(e => e.Idbaixarecebimento).HasColumnName("idbaixarecebimento");

                entity.Property(e => e.Numero)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("numero");

                entity.Property(e => e.Obsrepasse).HasColumnName("obsrepasse");

                entity.Property(e => e.Repasse)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("repasse");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.Property(e => e.Vencimento)
                    .HasColumnType("date")
                    .HasColumnName("vencimento");

                entity.HasOne(d => d.IdbaixarecebimentoNavigation)
                    .WithMany(p => p.Chequecontarecebers)
                    .HasForeignKey(d => d.Idbaixarecebimento)
                    .HasConstraintName("chequecontareceber_idbaixarecebimento_fkey");
            });

            modelBuilder.Entity<Ciotmdfe>(entity =>
            {
                entity.HasKey(e => e.Idciotmdfe)
                    .HasName("ciotmdfe_pkey");

                entity.ToTable("ciotmdfe");

                entity.Property(e => e.Idciotmdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idciotmdfe");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Codigo)
                    .HasColumnType("decimal(12, 0)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Ciotmdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("ciotmdfe_idmdfe_fkey");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("cliente_pkey");

                entity.ToTable("cliente");

                entity.Property(e => e.Idcliente)
                    .ValueGeneratedNever()
                    .HasColumnName("idcliente");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Consumidorfinal)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("consumidorfinal");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Docestrangeiro)
                    .HasMaxLength(60)
                    .HasColumnName("docestrangeiro");

                entity.Property(e => e.Estrangeiro)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("estrangeiro");

                entity.Property(e => e.Idcontato).HasColumnName("idcontato");

                entity.Property(e => e.Idendereco).HasColumnName("idendereco");

                entity.Property(e => e.Idvendedor).HasColumnName("idvendedor");

                entity.Property(e => e.Inscricaoestadual)
                    .HasMaxLength(20)
                    .HasColumnName("inscricaoestadual");

                entity.Property(e => e.Inscricaomunicipal)
                    .HasMaxLength(20)
                    .HasColumnName("inscricaomunicipal");

                entity.Property(e => e.Limitedecredito)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("limitedecredito");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .HasColumnName("nome");

                entity.Property(e => e.Nomefantasia)
                    .HasMaxLength(150)
                    .HasColumnName("nomefantasia");

                entity.Property(e => e.Razaosocial)
                    .HasMaxLength(150)
                    .HasColumnName("razaosocial");

                entity.Property(e => e.Tipocontribuinte)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("tipocontribuinte");

                entity.Property(e => e.Tipodocumento).HasColumnName("tipodocumento");
            });

            modelBuilder.Entity<Comandum>(entity =>
            {
                entity.HasKey(e => e.Idcomanda)
                    .HasName("comanda_pkey");

                entity.ToTable("comanda");

                entity.Property(e => e.Idcomanda)
                    .ValueGeneratedNever()
                    .HasColumnName("idcomanda");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(15)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .HasColumnName("descricao");

                entity.Property(e => e.Nomecliente)
                    .HasMaxLength(450)
                    .HasColumnName("nomecliente");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Condutor>(entity =>
            {
                entity.HasKey(e => e.Idcondutor)
                    .HasName("condutor_pkey");

                entity.ToTable("condutor");

                entity.Property(e => e.Idcondutor)
                    .ValueGeneratedNever()
                    .HasColumnName("idcondutor");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Idunidadefederativa).HasColumnName("idunidadefederativa");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdunidadefederativaNavigation)
                    .WithMany(p => p.Condutors)
                    .HasForeignKey(d => d.Idunidadefederativa)
                    .HasConstraintName("condutor_idunidadefederativa_fkey");
            });

            modelBuilder.Entity<Conferenciacaixapdv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("conferenciacaixapdv");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Diferenca)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("diferenca");

                entity.Property(e => e.Idconferenciacaixapdv).HasColumnName("idconferenciacaixapdv");

                entity.Property(e => e.Idfluxocaixa).HasColumnName("idfluxocaixa");

                entity.Property(e => e.Idformapagamento).HasColumnName("idformapagamento");

                entity.Property(e => e.Nomeformapagamento)
                    .HasMaxLength(150)
                    .HasColumnName("nomeformapagamento");

                entity.Property(e => e.Valorcalculado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorcalculado");

                entity.Property(e => e.Valordigitado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valordigitado");
            });

            modelBuilder.Entity<Configuracao>(entity =>
            {
                entity.HasKey(e => e.Idconfiguracao)
                    .HasName("configuracao_pkey");

                entity.ToTable("configuracao");

                entity.Property(e => e.Idconfiguracao)
                    .ValueGeneratedNever()
                    .HasColumnName("idconfiguracao");

                entity.Property(e => e.Chave)
                    .HasMaxLength(200)
                    .HasColumnName("chave");

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<Contabancarium>(entity =>
            {
                entity.HasKey(e => e.Idcontabancaria)
                    .HasName("contabancaria_pkey");

                entity.ToTable("contabancaria");

                entity.Property(e => e.Idcontabancaria)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontabancaria");

                entity.Property(e => e.Agencia)
                    .HasMaxLength(10)
                    .HasColumnName("agencia");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Caixa)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("caixa");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Conta)
                    .HasMaxLength(60)
                    .HasColumnName("conta");

                entity.Property(e => e.Digito)
                    .HasMaxLength(1)
                    .HasColumnName("digito");

                entity.Property(e => e.Digitoagencia)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("digitoagencia");

                entity.Property(e => e.Idbanco).HasColumnName("idbanco");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .HasColumnName("nome");

                entity.Property(e => e.Operacao)
                    .HasMaxLength(3)
                    .HasColumnName("operacao");

                entity.HasOne(d => d.IdbancoNavigation)
                    .WithMany(p => p.Contabancaria)
                    .HasForeignKey(d => d.Idbanco)
                    .HasConstraintName("contabancaria_idbanco_fkey");
            });

            modelBuilder.Entity<Contacobranca>(entity =>
            {
                entity.HasKey(e => e.Idcontacobranca)
                    .HasName("contacobranca_pkey");

                entity.ToTable("contacobranca");

                entity.Property(e => e.Idcontacobranca)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontacobranca");

                entity.Property(e => e.Aceite)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("aceite");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Carteira)
                    .HasMaxLength(5)
                    .HasColumnName("carteira");

                entity.Property(e => e.Cedente)
                    .HasMaxLength(20)
                    .HasColumnName("cedente");

                entity.Property(e => e.Cnab)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("cnab");

                entity.Property(e => e.Diaspagto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("diaspagto");

                entity.Property(e => e.Especie)
                    .HasMaxLength(5)
                    .HasColumnName("especie");

                entity.Property(e => e.Especiedoc)
                    .HasMaxLength(5)
                    .HasColumnName("especiedoc");

                entity.Property(e => e.Idcontabancaria).HasColumnName("idcontabancaria");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Instrucoes)
                    .HasColumnType("ntext")
                    .HasColumnName("instrucoes");

                entity.Property(e => e.Leiaute)
                    .HasMaxLength(30)
                    .HasColumnName("leiaute");

                entity.Property(e => e.Localpagto)
                    .HasMaxLength(150)
                    .HasColumnName("localpagto");

                entity.Property(e => e.Nossonumero)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("nossonumero");

                entity.Property(e => e.Numeroremessa)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("numeroremessa");

                entity.Property(e => e.Percentualjuros)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("percentualjuros");

                entity.Property(e => e.Registro)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("registro");

                entity.Property(e => e.Taxa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("taxa");

                entity.Property(e => e.Valormulta)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("valormulta");

                entity.Property(e => e.Variacaocarteira)
                    .HasMaxLength(5)
                    .HasColumnName("variacaocarteira");

                entity.HasOne(d => d.IdcontabancariaNavigation)
                    .WithMany(p => p.Contacobrancas)
                    .HasForeignKey(d => d.Idcontabancaria)
                    .HasConstraintName("contacobranca_idcontabancaria_fkey");

                entity.HasOne(d => d.IdformadepagamentoNavigation)
                    .WithMany(p => p.Contacobrancas)
                    .HasForeignKey(d => d.Idformadepagamento)
                    .HasConstraintName("contacobranca_idformadepagamento_fkey");
            });

            modelBuilder.Entity<Contapagar>(entity =>
            {
                entity.HasKey(e => e.Idcontapagar)
                    .HasName("contapagar_pkey");

                entity.ToTable("contapagar");

                entity.Property(e => e.Idcontapagar)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontapagar");

                entity.Property(e => e.Complmhisfin)
                    .HasMaxLength(100)
                    .HasColumnName("complmhisfin");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("desconto");

                entity.Property(e => e.Emissao)
                    .HasColumnType("date")
                    .HasColumnName("emissao");

                entity.Property(e => e.Fluxo)
                    .HasColumnType("date")
                    .HasColumnName("fluxo");

                entity.Property(e => e.Idcentrocusto).HasColumnName("idcentrocusto");

                entity.Property(e => e.Idcontabancaria).HasColumnName("idcontabancaria");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Idhistoricofinanceiro).HasColumnName("idhistoricofinanceiro");

                entity.Property(e => e.Idnfeentrada).HasColumnName("idnfeentrada");

                entity.Property(e => e.Idpedidocompra).HasColumnName("idpedidocompra");

                entity.Property(e => e.Juros)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("juros");

                entity.Property(e => e.Multa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("multa");

                entity.Property(e => e.Ord)
                    .HasMaxLength(10)
                    .HasColumnName("ord");

                entity.Property(e => e.Origem)
                    .HasMaxLength(25)
                    .HasColumnName("origem");

                entity.Property(e => e.Parcela)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("parcela");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("saldo");

                entity.Property(e => e.Situacao)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("situacao");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(10)
                    .HasColumnName("titulo");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.Property(e => e.Valortotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valortotal");

                entity.Property(e => e.Vencimento)
                    .HasColumnType("date")
                    .HasColumnName("vencimento");

                entity.HasOne(d => d.IdcontabancariaNavigation)
                    .WithMany(p => p.Contapagars)
                    .HasForeignKey(d => d.Idcontabancaria)
                    .HasConstraintName("contapagar_idcontabancaria_fkey");

                entity.HasOne(d => d.IdformadepagamentoNavigation)
                    .WithMany(p => p.Contapagars)
                    .HasForeignKey(d => d.Idformadepagamento)
                    .HasConstraintName("contapagar_idformadepagamento_fkey");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Contapagars)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("contapagar_idfornecedor_fkey");

                entity.HasOne(d => d.IdnfeentradaNavigation)
                    .WithMany(p => p.Contapagars)
                    .HasForeignKey(d => d.Idnfeentrada)
                    .HasConstraintName("contapagar_idnfeentrada_fkey");

                entity.HasOne(d => d.IdpedidocompraNavigation)
                    .WithMany(p => p.Contapagars)
                    .HasForeignKey(d => d.Idpedidocompra)
                    .HasConstraintName("contapagar_idpedidocompra_fkey");
            });

            modelBuilder.Entity<Contareccobranca>(entity =>
            {
                entity.HasKey(e => e.Idcontareccobranca)
                    .HasName("contareccobranca_pkey");

                entity.ToTable("contareccobranca");

                entity.Property(e => e.Idcontareccobranca)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontareccobranca");

                entity.Property(e => e.Cancelamento)
                    .HasColumnType("date")
                    .HasColumnName("cancelamento");

                entity.Property(e => e.Emissao)
                    .HasColumnType("date")
                    .HasColumnName("emissao");

                entity.Property(e => e.Idcontacobranca).HasColumnName("idcontacobranca");

                entity.Property(e => e.Idcontareceber).HasColumnName("idcontareceber");

                entity.Property(e => e.Nossonumero)
                    .HasMaxLength(200)
                    .HasColumnName("nossonumero");

                entity.Property(e => e.Numerocontroleparticipante)
                    .HasMaxLength(100)
                    .HasColumnName("numerocontroleparticipante");

                entity.Property(e => e.Numerodocumento)
                    .HasMaxLength(100)
                    .HasColumnName("numerodocumento");

                entity.Property(e => e.Status)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("status");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.Property(e => e.Vencimento)
                    .HasColumnType("date")
                    .HasColumnName("vencimento");

                entity.HasOne(d => d.IdcontacobrancaNavigation)
                    .WithMany(p => p.Contareccobrancas)
                    .HasForeignKey(d => d.Idcontacobranca)
                    .HasConstraintName("contareccobranca_idcontacobranca_fkey");

                entity.HasOne(d => d.IdcontareceberNavigation)
                    .WithMany(p => p.Contareccobrancas)
                    .HasForeignKey(d => d.Idcontareceber)
                    .HasConstraintName("contareccobranca_idcontareceber_fkey");
            });

            modelBuilder.Entity<Contareceber>(entity =>
            {
                entity.HasKey(e => e.Idcontareceber)
                    .HasName("contareceber_pkey");

                entity.ToTable("contareceber");

                entity.Property(e => e.Idcontareceber)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontareceber");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Complmhisfin)
                    .HasMaxLength(100)
                    .HasColumnName("complmhisfin");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("desconto");

                entity.Property(e => e.Emissao)
                    .HasColumnType("date")
                    .HasColumnName("emissao");

                entity.Property(e => e.Fluxo)
                    .HasColumnType("date")
                    .HasColumnName("fluxo");

                entity.Property(e => e.Idcentrocusto).HasColumnName("idcentrocusto");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Idcontabancaria).HasColumnName("idcontabancaria");

                entity.Property(e => e.Idcontareceberrenegociacao).HasColumnName("idcontareceberrenegociacao");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Idhistoricofinanceiro).HasColumnName("idhistoricofinanceiro");

                entity.Property(e => e.Idmovimentofiscal).HasColumnName("idmovimentofiscal");

                entity.Property(e => e.Idordemdeservico).HasColumnName("idordemdeservico");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Idvenda).HasColumnName("idvenda");

                entity.Property(e => e.Juros)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("juros");

                entity.Property(e => e.Multa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("multa");

                entity.Property(e => e.Origem)
                    .HasMaxLength(30)
                    .HasColumnName("origem");

                entity.Property(e => e.Pagamento)
                    .HasColumnType("date")
                    .HasColumnName("pagamento");

                entity.Property(e => e.Parcela)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("parcela");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("saldo");

                entity.Property(e => e.Situacao)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("situacao");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(10)
                    .HasColumnName("titulo");

                entity.Property(e => e.Ultimamodificacao).HasColumnName("ultimamodificacao");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.Property(e => e.Valortotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valortotal");

                entity.Property(e => e.Vencimento)
                    .HasColumnType("date")
                    .HasColumnName("vencimento");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Contarecebers)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("contareceber_idcliente_fkey");

                entity.HasOne(d => d.IdcontareceberrenegociacaoNavigation)
                    .WithMany(p => p.InverseIdcontareceberrenegociacaoNavigation)
                    .HasForeignKey(d => d.Idcontareceberrenegociacao)
                    .HasConstraintName("contareceber_idcontareceberrenegociacao_fkey");

                entity.HasOne(d => d.IdformadepagamentoNavigation)
                    .WithMany(p => p.Contarecebers)
                    .HasForeignKey(d => d.Idformadepagamento)
                    .HasConstraintName("contareceber_idformadepagamento_fkey");

                entity.HasOne(d => d.IdmovimentofiscalNavigation)
                    .WithMany(p => p.Contarecebers)
                    .HasForeignKey(d => d.Idmovimentofiscal)
                    .HasConstraintName("contareceber_idmovimentofiscal_fkey");
            });

            modelBuilder.Entity<Contarecobranca>(entity =>
            {
                entity.HasKey(e => e.Idcontarecobranca)
                    .HasName("contarecobranca_pkey");

                entity.ToTable("contarecobranca");

                entity.Property(e => e.Idcontarecobranca)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontarecobranca");

                entity.Property(e => e.Emissao)
                    .HasColumnType("date")
                    .HasColumnName("emissao");

                entity.Property(e => e.Idcontareceber).HasColumnName("idcontareceber");

                entity.Property(e => e.Nossonumero)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("nossonumero");

                entity.Property(e => e.Status)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("status");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.Property(e => e.Vencimento)
                    .HasColumnType("date")
                    .HasColumnName("vencimento");

                entity.HasOne(d => d.IdcontareceberNavigation)
                    .WithMany(p => p.Contarecobrancas)
                    .HasForeignKey(d => d.Idcontareceber)
                    .HasConstraintName("contarecobranca_idcontareceber_fkey");
            });

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasKey(e => e.Idcontato)
                    .HasName("contato_pkey");

                entity.ToTable("contato");

                entity.Property(e => e.Idcontato)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontato");

                entity.Property(e => e.Celular)
                    .HasMaxLength(11)
                    .HasColumnName("celular");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Emailalternativo)
                    .HasMaxLength(100)
                    .HasColumnName("emailalternativo");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<Contatoclientefornecedor>(entity =>
            {
                entity.HasKey(e => e.Idcontatoclientefornecedor)
                    .HasName("contatoclientefornecedor_pkey");

                entity.ToTable("contatoclientefornecedor");

                entity.Property(e => e.Idcontatoclientefornecedor)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontatoclientefornecedor");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(20)
                    .HasColumnName("cargo");

                entity.Property(e => e.Datanascimento)
                    .HasColumnType("date")
                    .HasColumnName("datanascimento");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .HasColumnName("nome");

                entity.Property(e => e.Sexo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefone1)
                    .HasMaxLength(20)
                    .HasColumnName("telefone1");

                entity.Property(e => e.Telefone2)
                    .HasMaxLength(20)
                    .HasColumnName("telefone2");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Contatoclientefornecedors)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("contatoclientefornecedor_idcliente_fkey");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Contatoclientefornecedors)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("contatoclientefornecedor_idfornecedor_fkey");
            });

            modelBuilder.Entity<Contratantemdfe>(entity =>
            {
                entity.HasKey(e => e.Idcontratantemdfe)
                    .HasName("contratantemdfe_pkey");

                entity.ToTable("contratantemdfe");

                entity.Property(e => e.Idcontratantemdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idcontratantemdfe");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Contratantemdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("contratantemdfe_idmdfe_fkey");
            });

            modelBuilder.Entity<Conversaounidadedemedidum>(entity =>
            {
                entity.HasKey(e => e.Idconversaounidadedemedida)
                    .HasName("conversaounidadedemedida_pkey");

                entity.ToTable("conversaounidadedemedida");

                entity.Property(e => e.Idconversaounidadedemedida)
                    .ValueGeneratedNever()
                    .HasColumnName("idconversaounidadedemedida");

                entity.Property(e => e.Calculo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("calculo");

                entity.Property(e => e.Fator)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("fator");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Idunidadedemedidaentrada).HasColumnName("idunidadedemedidaentrada");

                entity.Property(e => e.Idunidadedemedidasaida).HasColumnName("idunidadedemedidasaida");

                entity.HasOne(d => d.IdunidadedemedidaentradaNavigation)
                    .WithMany(p => p.ConversaounidadedemedidumIdunidadedemedidaentradaNavigations)
                    .HasForeignKey(d => d.Idunidadedemedidaentrada)
                    .HasConstraintName("conversaounidadedemedida_idunidadedemedidaentrada_fkey");

                entity.HasOne(d => d.IdunidadedemedidasaidaNavigation)
                    .WithMany(p => p.ConversaounidadedemedidumIdunidadedemedidasaidaNavigations)
                    .HasForeignKey(d => d.Idunidadedemedidasaida)
                    .HasConstraintName("conversaounidadedemedida_idunidadedemedidasaida_fkey");
            });

            modelBuilder.Entity<Cstcofin>(entity =>
            {
                entity.HasKey(e => e.Idcstcofins)
                    .HasName("cstcofins_pkey");

                entity.ToTable("cstcofins");

                entity.Property(e => e.Idcstcofins)
                    .ValueGeneratedNever()
                    .HasColumnName("idcstcofins");

                entity.Property(e => e.Cst)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("cst");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Csticm>(entity =>
            {
                entity.HasKey(e => e.Idcsticms)
                    .HasName("csticms_pkey");

                entity.ToTable("csticms");

                entity.Property(e => e.Idcsticms)
                    .ValueGeneratedNever()
                    .HasColumnName("idcsticms");

                entity.Property(e => e.Cstcsosn)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("cstcsosn");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Cstipi>(entity =>
            {
                entity.HasKey(e => e.Idcstipi)
                    .HasName("cstipi_pkey");

                entity.ToTable("cstipi");

                entity.Property(e => e.Idcstipi)
                    .ValueGeneratedNever()
                    .HasColumnName("idcstipi");

                entity.Property(e => e.Cst)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("cst");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Cstpi>(entity =>
            {
                entity.HasKey(e => e.Idcstpis)
                    .HasName("cstpis_pkey");

                entity.ToTable("cstpis");

                entity.Property(e => e.Idcstpis)
                    .ValueGeneratedNever()
                    .HasColumnName("idcstpis");

                entity.Property(e => e.Cst)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("cst");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Documentofiscalmdfe>(entity =>
            {
                entity.HasKey(e => e.Iddocumentofiscalmdfe)
                    .HasName("documentofiscalmdfe_pkey");

                entity.ToTable("documentofiscalmdfe");

                entity.Property(e => e.Iddocumentofiscalmdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("iddocumentofiscalmdfe");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.Property(e => e.Idmunicipiodescarga).HasColumnName("idmunicipiodescarga");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Documentofiscalmdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("documentofiscalmdfe_idmdfe_fkey");

                entity.HasOne(d => d.IdmunicipiodescargaNavigation)
                    .WithMany(p => p.Documentofiscalmdves)
                    .HasForeignKey(d => d.Idmunicipiodescarga)
                    .HasConstraintName("documentofiscalmdfe_idmunicipiodescarga_fkey");
            });

            modelBuilder.Entity<Documentoreferenciadonfe>(entity =>
            {
                entity.HasKey(e => e.Iddocumentoreferenciadonfe)
                    .HasName("documentoreferenciadonfe_pkey");

                entity.ToTable("documentoreferenciadonfe");

                entity.Property(e => e.Iddocumentoreferenciadonfe)
                    .ValueGeneratedNever()
                    .HasColumnName("iddocumentoreferenciadonfe");

                entity.Property(e => e.Chave)
                    .HasMaxLength(44)
                    .HasColumnName("chave");

                entity.Property(e => e.Codigodocumentoreferenciado).HasColumnName("codigodocumentoreferenciado");

                entity.Property(e => e.Idnfe).HasColumnName("idnfe");

                entity.Property(e => e.Idunidadefederativa).HasColumnName("idunidadefederativa");

                entity.HasOne(d => d.IdnfeNavigation)
                    .WithMany(p => p.Documentoreferenciadonves)
                    .HasForeignKey(d => d.Idnfe)
                    .HasConstraintName("documentoreferenciadonfe_idnfe_fkey");

                entity.HasOne(d => d.IdunidadefederativaNavigation)
                    .WithMany(p => p.Documentoreferenciadonves)
                    .HasForeignKey(d => d.Idunidadefederativa)
                    .HasConstraintName("documentoreferenciadonfe_idunidadefederativa_fkey");
            });

            modelBuilder.Entity<Downloadnfe>(entity =>
            {
                entity.HasKey(e => e.Iddownloadnfe)
                    .HasName("downloadnfe_pkey");

                entity.ToTable("downloadnfe");

                entity.Property(e => e.Iddownloadnfe)
                    .ValueGeneratedNever()
                    .HasColumnName("iddownloadnfe");

                entity.Property(e => e.Cstat)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("cstat");

                entity.Property(e => e.Dhresp).HasColumnName("dhresp");

                entity.Property(e => e.Idmanifestacaodestinatario).HasColumnName("idmanifestacaodestinatario");

                entity.Property(e => e.Maxnsu)
                    .HasColumnType("decimal(15, 0)")
                    .HasColumnName("maxnsu");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(1000)
                    .HasColumnName("motivo");

                entity.Property(e => e.Tpamb)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("tpamb");

                entity.Property(e => e.Ultnsu)
                    .HasColumnType("decimal(15, 0)")
                    .HasColumnName("ultnsu");

                entity.Property(e => e.Xml).HasColumnName("xml");

                entity.HasOne(d => d.IdmanifestacaodestinatarioNavigation)
                    .WithMany(p => p.Downloadnves)
                    .HasForeignKey(d => d.Idmanifestacaodestinatario)
                    .HasConstraintName("downloadnfe_idmanifestacaodestinatario_fkey");
            });

            modelBuilder.Entity<Duplicatadac>(entity =>
            {
                entity.HasKey(e => e.Idduplicatadac)
                    .HasName("duplicatadac_pkey");

                entity.ToTable("duplicatadac");

                entity.Property(e => e.Idduplicatadac)
                    .ValueGeneratedNever()
                    .HasColumnName("idduplicatadac");

                entity.Property(e => e.Datavencimento)
                    .HasColumnType("date")
                    .HasColumnName("datavencimento");

                entity.Property(e => e.Idcompra).HasColumnName("idcompra");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Pagamento)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("pagamento");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Duplicatanfce>(entity =>
            {
                entity.HasKey(e => e.Idduplicatanfce)
                    .HasName("duplicatanfce_pkey");

                entity.ToTable("duplicatanfce");

                entity.Property(e => e.Idduplicatanfce)
                    .ValueGeneratedNever()
                    .HasColumnName("idduplicatanfce");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Controle)
                    .HasMaxLength(50)
                    .HasColumnName("controle");

                entity.Property(e => e.Datapagamento)
                    .HasColumnType("date")
                    .HasColumnName("datapagamento");

                entity.Property(e => e.Datavencimento)
                    .HasColumnType("date")
                    .HasColumnName("datavencimento");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Idvenda).HasColumnName("idvenda");

                entity.Property(e => e.Pagamento)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("pagamento");

                entity.Property(e => e.Troco)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("troco")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdformadepagamentoNavigation)
                    .WithMany(p => p.Duplicatanfces)
                    .HasForeignKey(d => d.Idformadepagamento)
                    .HasConstraintName("duplicatanfce_idformadepagamento_fkey");

                entity.HasOne(d => d.IdvendaNavigation)
                    .WithMany(p => p.Duplicatanfces)
                    .HasForeignKey(d => d.Idvenda)
                    .HasConstraintName("duplicatanfce_idvenda_fkey");
            });

            modelBuilder.Entity<Duplicatanfe>(entity =>
            {
                entity.HasKey(e => e.Idduplicatanfe)
                    .HasName("duplicatanfe_pkey");

                entity.ToTable("duplicatanfe");

                entity.Property(e => e.Idduplicatanfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idduplicatanfe");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Datavencimento)
                    .HasColumnType("date")
                    .HasColumnName("datavencimento");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Idnfe).HasColumnName("idnfe");

                entity.Property(e => e.Numerodocumento)
                    .HasMaxLength(250)
                    .HasColumnName("numerodocumento");

                entity.Property(e => e.Pagamento).HasColumnName("pagamento");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdnfeNavigation)
                    .WithMany(p => p.Duplicatanves)
                    .HasForeignKey(d => d.Idnfe)
                    .HasConstraintName("duplicatanfe_idnfe_fkey");
            });

            modelBuilder.Entity<Emailemitente>(entity =>
            {
                entity.HasKey(e => e.Idemailemitente)
                    .HasName("emailemitente_pkey");

                entity.ToTable("emailemitente");

                entity.Property(e => e.Idemailemitente)
                    .ValueGeneratedNever()
                    .HasColumnName("idemailemitente");

                entity.Property(e => e.Autorizarassunto)
                    .HasMaxLength(150)
                    .HasColumnName("autorizarassunto");

                entity.Property(e => e.Autorizarenviaremail)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("autorizarenviaremail");

                entity.Property(e => e.Autorizarmensagem)
                    .HasColumnType("ntext")
                    .HasColumnName("autorizarmensagem");

                entity.Property(e => e.Cancelarassunto)
                    .HasMaxLength(150)
                    .HasColumnName("cancelarassunto");

                entity.Property(e => e.Cancelarenviaremail)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("cancelarenviaremail");

                entity.Property(e => e.Cancelarmensagem)
                    .HasColumnType("ntext")
                    .HasColumnName("cancelarmensagem");

                entity.Property(e => e.Idemitente).HasColumnName("idemitente");

                entity.HasOne(d => d.IdemitenteNavigation)
                    .WithMany(p => p.Emailemitentes)
                    .HasForeignKey(d => d.Idemitente)
                    .HasConstraintName("emailemitente_idemitente_fkey");
            });

            modelBuilder.Entity<Emitente>(entity =>
            {
                entity.HasKey(e => e.Idemitente)
                    .HasName("emitente_pkey");

                entity.ToTable("emitente");

                entity.Property(e => e.Idemitente)
                    .ValueGeneratedNever()
                    .HasColumnName("idemitente");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Certificado).HasColumnName("certificado");

                entity.Property(e => e.Chaveacessovalidador)
                    .HasMaxLength(150)
                    .HasColumnName("chaveacessovalidador");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(1000)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Cnae)
                    .HasColumnType("decimal(7, 0)")
                    .HasColumnName("cnae");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Cnpjsoftwarehouse)
                    .HasMaxLength(150)
                    .HasColumnName("cnpjsoftwarehouse");

                entity.Property(e => e.Codigoativacao)
                    .HasMaxLength(150)
                    .HasColumnName("codigoativacao");

                entity.Property(e => e.Cregtribissqn)
                    .HasMaxLength(150)
                    .HasColumnName("cregtribissqn");

                entity.Property(e => e.Crt)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("crt");

                entity.Property(e => e.Csc)
                    .HasMaxLength(200)
                    .HasColumnName("csc");

                entity.Property(e => e.Datalocal)
                    .HasMaxLength(1000)
                    .HasColumnName("datalocal");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Fone)
                    .HasMaxLength(20)
                    .HasColumnName("fone");

                entity.Property(e => e.Idcsc)
                    .HasMaxLength(6)
                    .HasColumnName("idcsc");

                entity.Property(e => e.Idendereco).HasColumnName("idendereco");

                entity.Property(e => e.Indratissqn)
                    .HasMaxLength(150)
                    .HasColumnName("indratissqn");

                entity.Property(e => e.Inscricaoestadual)
                    .HasMaxLength(20)
                    .HasColumnName("inscricaoestadual");

                entity.Property(e => e.Inscricaomunicipal)
                    .HasMaxLength(20)
                    .HasColumnName("inscricaomunicipal");

                entity.Property(e => e.Logomarca).HasColumnName("logomarca");

                entity.Property(e => e.Logopropraganda).HasColumnName("logopropraganda");

                entity.Property(e => e.Modeloimpressaodav)
                    .HasColumnName("modeloimpressaodav")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Nomecertificado)
                    .HasMaxLength(150)
                    .HasColumnName("nomecertificado");

                entity.Property(e => e.Nomefantasia)
                    .HasMaxLength(150)
                    .HasColumnName("nomefantasia");

                entity.Property(e => e.Nomelogomarca)
                    .HasMaxLength(150)
                    .HasColumnName("nomelogomarca");

                entity.Property(e => e.Nomelogopropraganda)
                    .HasMaxLength(300)
                    .HasColumnName("nomelogopropraganda");

                entity.Property(e => e.Pastainput)
                    .HasMaxLength(150)
                    .HasColumnName("pastainput");

                entity.Property(e => e.Pastaoutput)
                    .HasMaxLength(150)
                    .HasColumnName("pastaoutput");

                entity.Property(e => e.Pastaxml)
                    .HasMaxLength(150)
                    .HasColumnName("pastaxml");

                entity.Property(e => e.Proximonumeronfce)
                    .HasColumnName("proximonumeronfce")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Proximonumeronfe)
                    .HasColumnName("proximonumeronfe")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Razaosocial)
                    .HasMaxLength(150)
                    .HasColumnName("razaosocial");

                entity.Property(e => e.Senhacertificado)
                    .HasMaxLength(200)
                    .HasColumnName("senhacertificado");

                entity.Property(e => e.Signac)
                    .HasMaxLength(1000)
                    .HasColumnName("signac");

                entity.Property(e => e.Ultimalinhacabecalho)
                    .HasMaxLength(150)
                    .HasColumnName("ultimalinhacabecalho");

                entity.Property(e => e.Versaoxml)
                    .HasMaxLength(15)
                    .HasColumnName("versaoxml");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.Idendereco)
                    .HasName("endereco_pkey");

                entity.ToTable("endereco");

                entity.Property(e => e.Idendereco)
                    .ValueGeneratedNever()
                    .HasColumnName("idendereco");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(150)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(150)
                    .HasColumnName("complemento");

                entity.Property(e => e.Idmunicipio).HasColumnName("idmunicipio");

                entity.Property(e => e.Idpais).HasColumnName("idpais");

                entity.Property(e => e.Idunidadefederativa).HasColumnName("idunidadefederativa");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(150)
                    .HasColumnName("logradouro");

                entity.Property(e => e.Numero)
                    .HasColumnType("decimal(6, 0)")
                    .HasColumnName("numero");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .HasColumnName("telefone");

                entity.HasOne(d => d.IdmunicipioNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.Idmunicipio)
                    .HasConstraintName("endereco_idmunicipio_fkey");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("endereco_idpais_fkey");

                entity.HasOne(d => d.IdunidadefederativaNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.Idunidadefederativa)
                    .HasConstraintName("endereco_idunidadefederativa_fkey");
            });

            modelBuilder.Entity<Eventomdfe>(entity =>
            {
                entity.HasKey(e => e.Ideventomdfe)
                    .HasName("eventomdfe_pkey");

                entity.ToTable("eventomdfe");

                entity.Property(e => e.Ideventomdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("ideventomdfe");

                entity.Property(e => e.Cstat)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("cstat");

                entity.Property(e => e.Descevento)
                    .HasMaxLength(200)
                    .HasColumnName("descevento");

                entity.Property(e => e.Dhevento).HasColumnName("dhevento");

                entity.Property(e => e.Idmovimentofiscalmdfe).HasColumnName("idmovimentofiscalmdfe");

                entity.Property(e => e.Nprot)
                    .HasMaxLength(200)
                    .HasColumnName("nprot");

                entity.Property(e => e.Nseqevento)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("nseqevento");

                entity.Property(e => e.Tipoevento)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipoevento");

                entity.Property(e => e.Xmotivo)
                    .HasMaxLength(200)
                    .HasColumnName("xmotivo");

                entity.HasOne(d => d.IdmovimentofiscalmdfeNavigation)
                    .WithMany(p => p.Eventomdves)
                    .HasForeignKey(d => d.Idmovimentofiscalmdfe)
                    .HasConstraintName("eventomdfe_idmovimentofiscalmdfe_fkey");
            });

            modelBuilder.Entity<Eventonfe>(entity =>
            {
                entity.HasKey(e => e.Ideventonfe)
                    .HasName("eventonfe_pkey");

                entity.ToTable("eventonfe");

                entity.Property(e => e.Ideventonfe)
                    .ValueGeneratedNever()
                    .HasColumnName("ideventonfe");

                entity.Property(e => e.Cstat)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("cstat");

                entity.Property(e => e.Descevento).HasColumnName("descevento");

                entity.Property(e => e.Dhevento).HasColumnName("dhevento");

                entity.Property(e => e.Idmovimentofiscal).HasColumnName("idmovimentofiscal");

                entity.Property(e => e.InutilizacaoNnffin)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("inutilizacao_nnffin");

                entity.Property(e => e.InutilizacaoNnfini)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("inutilizacao_nnfini");

                entity.Property(e => e.InutilizacaoSerie)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("inutilizacao_serie");

                entity.Property(e => e.Nprot).HasColumnName("nprot");

                entity.Property(e => e.Nseqevento)
                    .HasMaxLength(200)
                    .HasColumnName("nseqevento");

                entity.Property(e => e.Tipoevento)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipoevento");

                entity.Property(e => e.Xcorrecao).HasColumnName("xcorrecao");

                entity.Property(e => e.Xml).HasColumnName("xml");

                entity.Property(e => e.Xmotivo).HasColumnName("xmotivo");

                entity.HasOne(d => d.IdmovimentofiscalNavigation)
                    .WithMany(p => p.Eventonves)
                    .HasForeignKey(d => d.Idmovimentofiscal)
                    .HasConstraintName("eventonfe_idmovimentofiscal_fkey");
            });

            modelBuilder.Entity<Finalidade>(entity =>
            {
                entity.HasKey(e => e.Idfinalidade)
                    .HasName("finalidade_pkey");

                entity.ToTable("finalidade");

                entity.Property(e => e.Idfinalidade)
                    .ValueGeneratedNever()
                    .HasColumnName("idfinalidade");

                entity.Property(e => e.Codigo)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Fluxocaixa>(entity =>
            {
                entity.HasKey(e => e.Idfluxocaixa)
                    .HasName("fluxocaixa_pkey");

                entity.ToTable("fluxocaixa");

                entity.Property(e => e.Idfluxocaixa)
                    .ValueGeneratedNever()
                    .HasColumnName("idfluxocaixa");

                entity.Property(e => e.Aberto)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("aberto");

                entity.Property(e => e.Caixaid).HasColumnName("caixaid");

                entity.Property(e => e.Dataaberturacaixa).HasColumnName("dataaberturacaixa");

                entity.Property(e => e.Datafechamentocaixa).HasColumnName("datafechamentocaixa");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Observacao)
                    .HasColumnType("ntext")
                    .HasColumnName("observacao");

                entity.Property(e => e.Valorcaixa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorcaixa");

                entity.Property(e => e.Valorfechamentocaixa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorfechamentocaixa");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Fluxocaixas)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("fluxocaixa_idusuario_fkey");
            });

            modelBuilder.Entity<Formadepagamento>(entity =>
            {
                entity.HasKey(e => e.Idformadepagamento)
                    .HasName("formadepagamento_pkey");

                entity.ToTable("formadepagamento");

                entity.Property(e => e.Idformadepagamento)
                    .ValueGeneratedNever()
                    .HasColumnName("idformadepagamento");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Codigo)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .HasColumnName("descricao");

                entity.Property(e => e.DiasIntervalo).HasColumnName("dias_intervalo");

                entity.Property(e => e.FatorCheqComEntrada)
                    .HasColumnType("decimal(8, 6)")
                    .HasColumnName("fator_cheq_com_entrada");

                entity.Property(e => e.FatorCheqSemEntrada)
                    .HasColumnType("decimal(8, 6)")
                    .HasColumnName("fator_cheq_sem_entrada");

                entity.Property(e => e.FatorDupComEntrada)
                    .HasColumnType("decimal(8, 6)")
                    .HasColumnName("fator_dup_com_entrada");

                entity.Property(e => e.FatorDupSemEntrada)
                    .HasColumnType("decimal(8, 6)")
                    .HasColumnName("fator_dup_sem_entrada");

                entity.Property(e => e.Idbandeiracartao).HasColumnName("idbandeiracartao");

                entity.Property(e => e.Identificacao)
                    .HasMaxLength(200)
                    .HasColumnName("identificacao");

                entity.Property(e => e.Pdv).HasColumnName("pdv");

                entity.Property(e => e.Periodicidade)
                    .HasMaxLength(150)
                    .HasColumnName("periodicidade");

                entity.Property(e => e.QtdParcelas).HasColumnName("qtd_parcelas");

                entity.Property(e => e.Tef).HasColumnName("tef");

                entity.Property(e => e.Transacao).HasColumnName("transacao");

                entity.Property(e => e.UsaCalendarioComercial)
                    .HasMaxLength(1)
                    .HasColumnName("usa_calendario_comercial")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdbandeiracartaoNavigation)
                    .WithMany(p => p.Formadepagamentos)
                    .HasForeignKey(d => d.Idbandeiracartao)
                    .HasConstraintName("formadepagamento_idbandeiracartao_fkey");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.Idfornecedor)
                    .HasName("fornecedor_pkey");

                entity.ToTable("fornecedor");

                entity.Property(e => e.Idfornecedor)
                    .ValueGeneratedNever()
                    .HasColumnName("idfornecedor");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Idendereco).HasColumnName("idendereco");

                entity.Property(e => e.Inscricaoestadual)
                    .HasColumnType("decimal(14, 0)")
                    .HasColumnName("inscricaoestadual");

                entity.Property(e => e.Isento)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("isento");

                entity.Property(e => e.Razaosocial)
                    .HasMaxLength(200)
                    .HasColumnName("razaosocial");

                entity.HasOne(d => d.IdenderecoNavigation)
                    .WithMany(p => p.Fornecedors)
                    .HasForeignKey(d => d.Idendereco)
                    .HasConstraintName("fornecedor_idendereco_fkey");
            });

            modelBuilder.Entity<Historicoclientefornecedor>(entity =>
            {
                entity.HasKey(e => e.Idhistoricoclientefornecedor)
                    .HasName("historicoclientefornecedor_pkey");

                entity.ToTable("historicoclientefornecedor");

                entity.Property(e => e.Idhistoricoclientefornecedor)
                    .ValueGeneratedNever()
                    .HasColumnName("idhistoricoclientefornecedor");

                entity.Property(e => e.Assunto)
                    .HasMaxLength(50)
                    .HasColumnName("assunto");

                entity.Property(e => e.Datahistorico).HasColumnName("datahistorico");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Observacao)
                    .HasColumnType("ntext")
                    .HasColumnName("observacao");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Historicoclientefornecedors)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("historicoclientefornecedor_idcliente_fkey");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Historicoclientefornecedors)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("historicoclientefornecedor_idfornecedor_fkey");
            });

            modelBuilder.Entity<Historicofinanceiro>(entity =>
            {
                entity.HasKey(e => e.Idhistoricofinanceiro)
                    .HasName("historicofinanceiro_pkey");

                entity.ToTable("historicofinanceiro");

                entity.Property(e => e.Idhistoricofinanceiro)
                    .ValueGeneratedNever()
                    .HasColumnName("idhistoricofinanceiro");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .HasColumnName("descricao");

                entity.Property(e => e.Tipodemovimento).HasColumnName("tipodemovimento");
            });

            modelBuilder.Entity<Integracaofiscal>(entity =>
            {
                entity.HasKey(e => e.Idintegracaofiscal)
                    .HasName("integracaofiscal_pkey");

                entity.ToTable("integracaofiscal");

                entity.Property(e => e.Idintegracaofiscal)
                    .ValueGeneratedNever()
                    .HasColumnName("idintegracaofiscal");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");

                entity.Property(e => e.Estoque)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("estoque");

                entity.Property(e => e.Financeiro)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("financeiro");

                entity.Property(e => e.Icms)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("icms");

                entity.Property(e => e.IcmsCdiferenciado)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("icms_cdiferenciado");

                entity.Property(e => e.IcmsDif)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("icms_dif");

                entity.Property(e => e.IcmsDiferenciado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("icms_diferenciado");

                entity.Property(e => e.IcmsIpi)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("icms_ipi");

                entity.Property(e => e.IcmsRed)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("icms_red");

                entity.Property(e => e.IcmsRedst)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("icms_redst");

                entity.Property(e => e.IcmsSt)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("icms_st");

                entity.Property(e => e.IcmsStCdiferenciado)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("icms_st_cdiferenciado");

                entity.Property(e => e.IcmsStDiferenciado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("icms_st_diferenciado");

                entity.Property(e => e.Idcfop).HasColumnName("idcfop");

                entity.Property(e => e.Idcstcofins).HasColumnName("idcstcofins");

                entity.Property(e => e.Idcsticms).HasColumnName("idcsticms");

                entity.Property(e => e.Idcstipi).HasColumnName("idcstipi");

                entity.Property(e => e.Idcstpis).HasColumnName("idcstpis");

                entity.Property(e => e.Idportaria).HasColumnName("idportaria");

                entity.Property(e => e.Idtipooperacao).HasColumnName("idtipooperacao");

                entity.Property(e => e.Ipi)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ipi");

                entity.Property(e => e.Sequencia)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("sequencia");

                entity.HasOne(d => d.IdcfopNavigation)
                    .WithMany(p => p.Integracaofiscals)
                    .HasForeignKey(d => d.Idcfop)
                    .HasConstraintName("integracaofiscal_idcfop_fkey");

                entity.HasOne(d => d.IdcstcofinsNavigation)
                    .WithMany(p => p.Integracaofiscals)
                    .HasForeignKey(d => d.Idcstcofins)
                    .HasConstraintName("integracaofiscal_idcstcofins_fkey");

                entity.HasOne(d => d.IdcsticmsNavigation)
                    .WithMany(p => p.Integracaofiscals)
                    .HasForeignKey(d => d.Idcsticms)
                    .HasConstraintName("integracaofiscal_idcsticms_fkey");

                entity.HasOne(d => d.IdcstipiNavigation)
                    .WithMany(p => p.Integracaofiscals)
                    .HasForeignKey(d => d.Idcstipi)
                    .HasConstraintName("integracaofiscal_idcstipi_fkey");

                entity.HasOne(d => d.IdcstpisNavigation)
                    .WithMany(p => p.Integracaofiscals)
                    .HasForeignKey(d => d.Idcstpis)
                    .HasConstraintName("integracaofiscal_idcstpis_fkey");

                entity.HasOne(d => d.IdportariaNavigation)
                    .WithMany(p => p.Integracaofiscals)
                    .HasForeignKey(d => d.Idportaria)
                    .HasConstraintName("integracaofiscal_idportaria_fkey");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.Idinventario)
                    .HasName("inventario_pkey");

                entity.ToTable("inventario");

                entity.Property(e => e.Idinventario)
                    .ValueGeneratedNever()
                    .HasColumnName("idinventario");

                entity.Property(e => e.Datainventario)
                    .HasColumnType("date")
                    .HasColumnName("datainventario");
            });

            modelBuilder.Entity<Iteminventario>(entity =>
            {
                entity.HasKey(e => e.Iditeminventario)
                    .HasName("iteminventario_pkey");

                entity.ToTable("iteminventario");

                entity.Property(e => e.Iditeminventario)
                    .ValueGeneratedNever()
                    .HasColumnName("iditeminventario");

                entity.Property(e => e.Idalmoxarifado).HasColumnName("idalmoxarifado");

                entity.Property(e => e.Idinventario).HasColumnName("idinventario");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("quantidade");

                entity.HasOne(d => d.IdalmoxarifadoNavigation)
                    .WithMany(p => p.Iteminventarios)
                    .HasForeignKey(d => d.Idalmoxarifado)
                    .HasConstraintName("iteminventario_idalmoxarifado_fkey");

                entity.HasOne(d => d.IdinventarioNavigation)
                    .WithMany(p => p.Iteminventarios)
                    .HasForeignKey(d => d.Idinventario)
                    .HasConstraintName("iteminventario_idinventario_fkey");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Iteminventarios)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("iteminventario_idproduto_fkey");
            });

            modelBuilder.Entity<Itemmenu>(entity =>
            {
                entity.HasKey(e => e.Iditemmenu)
                    .HasName("itemmenu_pkey");

                entity.ToTable("itemmenu");

                entity.Property(e => e.Iditemmenu)
                    .ValueGeneratedNever()
                    .HasColumnName("iditemmenu");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .HasColumnName("descricao");

                entity.Property(e => e.Iditemmenusuperior).HasColumnName("iditemmenusuperior");

                entity.HasOne(d => d.IditemmenusuperiorNavigation)
                    .WithMany(p => p.InverseIditemmenusuperiorNavigation)
                    .HasForeignKey(d => d.Iditemmenusuperior)
                    .HasConstraintName("itemmenu_iditemmenusuperior_fkey");
            });

            modelBuilder.Entity<Itemnfeentradum>(entity =>
            {
                entity.HasKey(e => e.Iditemnfeentrada)
                    .HasName("itemnfeentrada_pkey");

                entity.ToTable("itemnfeentrada");

                entity.Property(e => e.Iditemnfeentrada)
                    .ValueGeneratedNever()
                    .HasColumnName("iditemnfeentrada");

                entity.Property(e => e.Cean)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cean");

                entity.Property(e => e.Ceantrib)
                    .HasMaxLength(14)
                    .HasColumnName("ceantrib");

                entity.Property(e => e.Cenq)
                    .HasMaxLength(3)
                    .HasColumnName("cenq");

                entity.Property(e => e.Cest)
                    .HasMaxLength(7)
                    .HasColumnName("cest");

                entity.Property(e => e.Cfop)
                    .HasMaxLength(4)
                    .HasColumnName("cfop");

                entity.Property(e => e.Cprod)
                    .HasMaxLength(100)
                    .HasColumnName("cprod");

                entity.Property(e => e.Cstcofins)
                    .HasMaxLength(2)
                    .HasColumnName("cstcofins");

                entity.Property(e => e.Csticms)
                    .HasMaxLength(3)
                    .HasColumnName("csticms");

                entity.Property(e => e.Cstipi)
                    .HasMaxLength(2)
                    .HasColumnName("cstipi");

                entity.Property(e => e.Cstpis)
                    .HasMaxLength(2)
                    .HasColumnName("cstpis");

                entity.Property(e => e.Idconversaounidadedemedida).HasColumnName("idconversaounidadedemedida");

                entity.Property(e => e.Idnfeentrada).HasColumnName("idnfeentrada");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Indtot).HasColumnName("indtot");

                entity.Property(e => e.Modbc).HasColumnName("modbc");

                entity.Property(e => e.Modbcst).HasColumnName("modbcst");

                entity.Property(e => e.Ncm)
                    .HasMaxLength(8)
                    .HasColumnName("ncm");

                entity.Property(e => e.Orig)
                    .HasMaxLength(1)
                    .HasColumnName("orig");

                entity.Property(e => e.Pcofins)
                    .HasColumnType("decimal(5, 4)")
                    .HasColumnName("pcofins");

                entity.Property(e => e.Pfcpufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pfcpufdest");

                entity.Property(e => e.Picms)
                    .HasColumnType("decimal(6, 4)")
                    .HasColumnName("picms");

                entity.Property(e => e.Picmsinter)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("picmsinter");

                entity.Property(e => e.Picmsinterpart)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("picmsinterpart");

                entity.Property(e => e.Picmsst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("picmsst");

                entity.Property(e => e.Picmsufdest)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("picmsufdest");

                entity.Property(e => e.Pipi)
                    .HasColumnType("decimal(5, 4)")
                    .HasColumnName("pipi");

                entity.Property(e => e.Pmvast)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pmvast");

                entity.Property(e => e.Ppis)
                    .HasColumnType("decimal(5, 4)")
                    .HasColumnName("ppis");

                entity.Property(e => e.Predbc)
                    .HasColumnType("decimal(5, 4)")
                    .HasColumnName("predbc");

                entity.Property(e => e.Predbcst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("predbcst");

                entity.Property(e => e.Qcom)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("qcom");

                entity.Property(e => e.Qtrib)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("qtrib");

                entity.Property(e => e.Ucom)
                    .HasMaxLength(6)
                    .HasColumnName("ucom");

                entity.Property(e => e.Utrib)
                    .HasMaxLength(6)
                    .HasColumnName("utrib");

                entity.Property(e => e.Vbcicms)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcicms");

                entity.Property(e => e.Vbcipi)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcipi");

                entity.Property(e => e.Vbcofins)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcofins");

                entity.Property(e => e.Vbcpis)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcpis");

                entity.Property(e => e.Vbcst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcst");

                entity.Property(e => e.Vbcufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcufdest");

                entity.Property(e => e.Vcofins)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vcofins");

                entity.Property(e => e.Vdesc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vdesc");

                entity.Property(e => e.Vfcpufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vfcpufdest");

                entity.Property(e => e.Vfrete)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vfrete");

                entity.Property(e => e.Vicms)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicms");

                entity.Property(e => e.Vicmsst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsst");

                entity.Property(e => e.Vicmsufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsufdest");

                entity.Property(e => e.Vicmsufremet)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsufremet");

                entity.Property(e => e.Vipi)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vipi");

                entity.Property(e => e.Voutro)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("voutro");

                entity.Property(e => e.Vpis)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vpis");

                entity.Property(e => e.Vprod)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("vprod");

                entity.Property(e => e.Vseg)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vseg");

                entity.Property(e => e.Vtottrib)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vtottrib");

                entity.Property(e => e.Vuncom)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("vuncom");

                entity.Property(e => e.Vuntrib)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vuntrib");

                entity.Property(e => e.Xprod)
                    .HasMaxLength(120)
                    .HasColumnName("xprod");

                entity.HasOne(d => d.IdconversaounidadedemedidaNavigation)
                    .WithMany(p => p.Itemnfeentrada)
                    .HasForeignKey(d => d.Idconversaounidadedemedida)
                    .HasConstraintName("itemnfeentrada_idconversaounidadedemedida_fkey");

                entity.HasOne(d => d.IdnfeentradaNavigation)
                    .WithMany(p => p.Itemnfeentrada)
                    .HasForeignKey(d => d.Idnfeentrada)
                    .HasConstraintName("itemnfeentrada_idnfeentrada_fkey");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Itemnfeentrada)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("itemnfeentrada_idproduto_fkey");
            });

            modelBuilder.Entity<Itempedidocompra>(entity =>
            {
                entity.HasKey(e => e.Iditempedidocompra)
                    .HasName("itempedidocompra_pkey");

                entity.ToTable("itempedidocompra");

                entity.Property(e => e.Iditempedidocompra)
                    .ValueGeneratedNever()
                    .HasColumnName("iditempedidocompra");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("desconto");

                entity.Property(e => e.Descontoporcentagem)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("descontoporcentagem");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .HasColumnName("descricao");

                entity.Property(e => e.Idpedidocompra).HasColumnName("idpedidocompra");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.Property(e => e.Valorunitario)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorunitario");

                entity.HasOne(d => d.IdpedidocompraNavigation)
                    .WithMany(p => p.Itempedidocompras)
                    .HasForeignKey(d => d.Idpedidocompra)
                    .HasConstraintName("itempedidocompra_idpedidocompra_fkey");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Itempedidocompras)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("itempedidocompra_idproduto_fkey");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Itempedidocompras)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("itempedidocompra_idusuario_fkey");
            });

            modelBuilder.Entity<Itemtransferenciaestoque>(entity =>
            {
                entity.HasKey(e => e.Iditemtransferenciaestoque)
                    .HasName("itemtransferenciaestoque_pkey");

                entity.ToTable("itemtransferenciaestoque");

                entity.Property(e => e.Iditemtransferenciaestoque)
                    .ValueGeneratedNever()
                    .HasColumnName("iditemtransferenciaestoque");

                entity.Property(e => e.Idalmoxarifadoentrada).HasColumnName("idalmoxarifadoentrada");

                entity.Property(e => e.Idalmoxarifadosaida).HasColumnName("idalmoxarifadosaida");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Idtransferenciaestoque).HasColumnName("idtransferenciaestoque");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("quantidade");

                entity.HasOne(d => d.IdalmoxarifadoentradaNavigation)
                    .WithMany(p => p.ItemtransferenciaestoqueIdalmoxarifadoentradaNavigations)
                    .HasForeignKey(d => d.Idalmoxarifadoentrada)
                    .HasConstraintName("itemtransferenciaestoque_idalmoxarifadoentrada_fkey");

                entity.HasOne(d => d.IdalmoxarifadosaidaNavigation)
                    .WithMany(p => p.ItemtransferenciaestoqueIdalmoxarifadosaidaNavigations)
                    .HasForeignKey(d => d.Idalmoxarifadosaida)
                    .HasConstraintName("itemtransferenciaestoque_idalmoxarifadosaida_fkey");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Itemtransferenciaestoques)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("itemtransferenciaestoque_idproduto_fkey");

                entity.HasOne(d => d.IdtransferenciaestoqueNavigation)
                    .WithMany(p => p.Itemtransferenciaestoques)
                    .HasForeignKey(d => d.Idtransferenciaestoque)
                    .HasConstraintName("itemtransferenciaestoque_idtransferenciaestoque_fkey");
            });

            modelBuilder.Entity<Itemvendum>(entity =>
            {
                entity.HasKey(e => e.Iditemvenda)
                    .HasName("itemvenda_pkey");

                entity.ToTable("itemvenda");

                entity.Property(e => e.Iditemvenda)
                    .ValueGeneratedNever()
                    .HasColumnName("iditemvenda");

                entity.Property(e => e.Altura)
                    .HasColumnType("decimal(30, 10)")
                    .HasColumnName("altura");

                entity.Property(e => e.Area)
                    .HasColumnType("decimal(30, 10)")
                    .HasColumnName("area");

                entity.Property(e => e.Descontoporcentagem)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("descontoporcentagem");

                entity.Property(e => e.Descontovalor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("descontovalor");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .HasColumnName("descricao");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Idvenda).HasColumnName("idvenda");

                entity.Property(e => e.Largura)
                    .HasColumnType("decimal(30, 10)")
                    .HasColumnName("largura");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subtotal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Valorunitarioitem)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorunitarioitem");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Itemvenda)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("itemvenda_idproduto_fkey");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Itemvenda)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("itemvenda_idusuario_fkey");

                entity.HasOne(d => d.IdvendaNavigation)
                    .WithMany(p => p.Itemvenda)
                    .HasForeignKey(d => d.Idvenda)
                    .HasConstraintName("itemvenda_idvenda_fkey");
            });

            modelBuilder.Entity<Lacrerodoviariomdfe>(entity =>
            {
                entity.HasKey(e => e.Idlacrerodoviariomdfe)
                    .HasName("lacrerodoviariomdfe_pkey");

                entity.ToTable("lacrerodoviariomdfe");

                entity.Property(e => e.Idlacrerodoviariomdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idlacrerodoviariomdfe");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .HasColumnName("numero");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Lacrerodoviariomdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("lacrerodoviariomdfe_idmdfe_fkey");
            });

            modelBuilder.Entity<Manifestacaodestinatario>(entity =>
            {
                entity.HasKey(e => e.Idmanifestacaodestinatario)
                    .HasName("manifestacaodestinatario_pkey");

                entity.ToTable("manifestacaodestinatario");

                entity.Property(e => e.Idmanifestacaodestinatario)
                    .ValueGeneratedNever()
                    .HasColumnName("idmanifestacaodestinatario");

                entity.Property(e => e.Chavenfe)
                    .HasMaxLength(44)
                    .HasColumnName("chavenfe");

                entity.Property(e => e.Cstat)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("cstat");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(1000)
                    .HasColumnName("motivo");

                entity.Property(e => e.Numeroevento)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("numeroevento");

                entity.Property(e => e.Orgao)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("orgao");

                entity.Property(e => e.Tipoambiente)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipoambiente");

                entity.Property(e => e.Tipomanifestacao)
                    .HasColumnType("decimal(6, 0)")
                    .HasColumnName("tipomanifestacao");
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.HasKey(e => e.Idmaquina)
                    .HasName("maquina_pkey");

                entity.ToTable("maquina");

                entity.Property(e => e.Idmaquina)
                    .ValueGeneratedNever()
                    .HasColumnName("idmaquina");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("descricao");

                entity.Property(e => e.Ultimologin)
                    .HasMaxLength(255)
                    .HasColumnName("ultimologin");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.Idmarca)
                    .HasName("marca_pkey");

                entity.ToTable("marca");

                entity.Property(e => e.Idmarca)
                    .ValueGeneratedNever()
                    .HasColumnName("idmarca");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(6)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .HasColumnName("descricao");

                entity.Property(e => e.Marcadeproduto).HasColumnName("marcadeproduto");

                entity.Property(e => e.Marcadeveiculo).HasColumnName("marcadeveiculo");
            });

            modelBuilder.Entity<Mdfe>(entity =>
            {
                entity.HasKey(e => e.Idmdfe)
                    .HasName("mdfe_pkey");

                entity.ToTable("mdfe");

                entity.Property(e => e.Idmdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idmdfe");

                entity.Property(e => e.Cmdf)
                    .HasColumnType("decimal(8, 0)")
                    .HasColumnName("cmdf");

                entity.Property(e => e.Codigounpesocarga)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("codigounpesocarga");

                entity.Property(e => e.Datacadastro).HasColumnName("datacadastro");

                entity.Property(e => e.Emissao).HasColumnName("emissao");

                entity.Property(e => e.Idemitente).HasColumnName("idemitente");

                entity.Property(e => e.Idunidadefederativadescarregamento).HasColumnName("idunidadefederativadescarregamento");

                entity.Property(e => e.Informacoesadicionais)
                    .HasMaxLength(2000)
                    .HasColumnName("informacoesadicionais");

                entity.Property(e => e.Informacoescomplementares).HasColumnName("informacoescomplementares");

                entity.Property(e => e.Modalidadetransporte)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("modalidadetransporte");

                entity.Property(e => e.Modelo)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("modelo");

                entity.Property(e => e.Nmdf)
                    .HasColumnType("decimal(9, 0)")
                    .HasColumnName("nmdf");

                entity.Property(e => e.Pesobrutototal)
                    .HasColumnType("decimal(11, 4)")
                    .HasColumnName("pesobrutototal");

                entity.Property(e => e.Serie)
                    .HasColumnType("decimal(3, 0)")
                    .HasColumnName("serie");

                entity.Property(e => e.Tipoambiente)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipoambiente");

                entity.Property(e => e.Tipoemissao)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipoemissao");

                entity.Property(e => e.Tipoemitente)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipoemitente");

                entity.Property(e => e.Tipotransportador)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipotransportador");

                entity.HasOne(d => d.IdemitenteNavigation)
                    .WithMany(p => p.Mdves)
                    .HasForeignKey(d => d.Idemitente)
                    .HasConstraintName("mdfe_idemitente_fkey");

                entity.HasOne(d => d.IdunidadefederativadescarregamentoNavigation)
                    .WithMany(p => p.Mdves)
                    .HasForeignKey(d => d.Idunidadefederativadescarregamento)
                    .HasConstraintName("mdfe_idunidadefederativadescarregamento_fkey");
            });

            modelBuilder.Entity<Motivocancelamento>(entity =>
            {
                entity.HasKey(e => e.Idmotivocancelamento)
                    .HasName("motivocancelamento_pkey");

                entity.ToTable("motivocancelamento");

                entity.Property(e => e.Idmotivocancelamento)
                    .ValueGeneratedNever()
                    .HasColumnName("idmotivocancelamento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .HasColumnName("nome");

                entity.Property(e => e.Tipo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Movimentobancario>(entity =>
            {
                entity.HasKey(e => e.Idmovimentobancario)
                    .HasName("movimentobancario_pkey");

                entity.ToTable("movimentobancario");

                entity.Property(e => e.Idmovimentobancario)
                    .ValueGeneratedNever()
                    .HasColumnName("idmovimentobancario");

                entity.Property(e => e.Conciliacao).HasColumnName("conciliacao");

                entity.Property(e => e.Datamovimento).HasColumnName("datamovimento");

                entity.Property(e => e.Documento)
                    .HasMaxLength(10)
                    .HasColumnName("documento");

                entity.Property(e => e.Historico)
                    .HasMaxLength(50)
                    .HasColumnName("historico");

                entity.Property(e => e.Idcontabancaria).HasColumnName("idcontabancaria");

                entity.Property(e => e.Idnatureza).HasColumnName("idnatureza");

                entity.Property(e => e.Sequencia)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("sequencia");

                entity.Property(e => e.Tipo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipo");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdcontabancariaNavigation)
                    .WithMany(p => p.Movimentobancarios)
                    .HasForeignKey(d => d.Idcontabancaria)
                    .HasConstraintName("movimentobancario_idcontabancaria_fkey");

                entity.HasOne(d => d.IdnaturezaNavigation)
                    .WithMany(p => p.Movimentobancarios)
                    .HasForeignKey(d => d.Idnatureza)
                    .HasConstraintName("movimentobancario_idnatureza_fkey");
            });

            modelBuilder.Entity<Movimentoestoque>(entity =>
            {
                entity.HasKey(e => e.Idmovimentoestoque)
                    .HasName("movimentoestoque_pkey");

                entity.ToTable("movimentoestoque");

                entity.Property(e => e.Idmovimentoestoque)
                    .ValueGeneratedNever()
                    .HasColumnName("idmovimentoestoque");

                entity.Property(e => e.Datamovimento)
                    .HasColumnType("datetime")
                    .HasColumnName("datamovimento");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .HasColumnName("descricao");

                entity.Property(e => e.Idalmoxarifado).HasColumnName("idalmoxarifado");

                entity.Property(e => e.Iditeminventario).HasColumnName("iditeminventario");

                entity.Property(e => e.Iditemnfeentrada).HasColumnName("iditemnfeentrada");

                entity.Property(e => e.Iditempedidocompra).HasColumnName("iditempedidocompra");

                entity.Property(e => e.Iditemtransferenciaestoque).HasColumnName("iditemtransferenciaestoque");

                entity.Property(e => e.Iditemvenda).HasColumnName("iditemvenda");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Idprodutonfe).HasColumnName("idprodutonfe");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.Saldoalmoxarifado)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("saldoalmoxarifado");

                entity.Property(e => e.Saldoatual)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("saldoatual");

                entity.Property(e => e.Tipo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdalmoxarifadoNavigation)
                    .WithMany(p => p.Movimentoestoques)
                    .HasForeignKey(d => d.Idalmoxarifado)
                    .HasConstraintName("movimentoestoque_idalmoxarifadoentrada_fkey");

                entity.HasOne(d => d.IditeminventarioNavigation)
                    .WithMany(p => p.Movimentoestoques)
                    .HasForeignKey(d => d.Iditeminventario)
                    .HasConstraintName("movimentoestoque_iditeminventario_fkey");

                entity.HasOne(d => d.IditemnfeentradaNavigation)
                    .WithMany(p => p.Movimentoestoques)
                    .HasForeignKey(d => d.Iditemnfeentrada)
                    .HasConstraintName("movimentoestoque_iditemnfeentrada_fkey");

                entity.HasOne(d => d.IditempedidocompraNavigation)
                    .WithMany(p => p.Movimentoestoques)
                    .HasForeignKey(d => d.Iditempedidocompra)
                    .HasConstraintName("movimentoestoque_iditempedidocompra_fkey");

                entity.HasOne(d => d.IditemtransferenciaestoqueNavigation)
                    .WithMany(p => p.Movimentoestoques)
                    .HasForeignKey(d => d.Iditemtransferenciaestoque)
                    .HasConstraintName("movimentoestoque_iditemtransferenciaestoque_fkey");

                entity.HasOne(d => d.IditemvendaNavigation)
                    .WithMany(p => p.Movimentoestoques)
                    .HasForeignKey(d => d.Iditemvenda)
                    .HasConstraintName("movimentoestoque_iditemvenda_fkey");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Movimentoestoques)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("movimentoestoque_idproduto_fkey");

                entity.HasOne(d => d.IdprodutonfeNavigation)
                    .WithMany(p => p.Movimentoestoques)
                    .HasForeignKey(d => d.Idprodutonfe)
                    .HasConstraintName("movimentoestoque_idprodutonfe_fkey");
            });

            modelBuilder.Entity<Movimentofiscal>(entity =>
            {
                entity.HasKey(e => e.Idmovimentofiscal)
                    .HasName("movimentofiscal_pkey");

                entity.ToTable("movimentofiscal");

                entity.Property(e => e.Idmovimentofiscal)
                    .ValueGeneratedNever()
                    .HasColumnName("idmovimentofiscal");

                entity.Property(e => e.Ambiente)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ambiente");

                entity.Property(e => e.Cancelada)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("cancelada");

                entity.Property(e => e.Chave)
                    .HasMaxLength(150)
                    .HasColumnName("chave");

                entity.Property(e => e.Contingencia)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("contingencia");

                entity.Property(e => e.Cstat)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("cstat");

                entity.Property(e => e.Dataemissao).HasColumnName("dataemissao");

                entity.Property(e => e.Dhrecbto).HasColumnName("dhrecbto");

                entity.Property(e => e.Emitida)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("emitida");

                entity.Property(e => e.Idnfe).HasColumnName("idnfe");

                entity.Property(e => e.Idvenda).HasColumnName("idvenda");

                entity.Property(e => e.Numero)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("numero");

                entity.Property(e => e.Protocolo)
                    .HasMaxLength(300)
                    .HasColumnName("protocolo");

                entity.Property(e => e.Serie)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("serie");

                entity.Property(e => e.Tipodocumento)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("tipodocumento");

                entity.Property(e => e.Xmlcancelamento).HasColumnName("xmlcancelamento");

                entity.Property(e => e.Xmlenvio).HasColumnName("xmlenvio");

                entity.Property(e => e.Xmlretorno).HasColumnName("xmlretorno");

                entity.Property(e => e.Xmotivo)
                    .HasMaxLength(500)
                    .HasColumnName("xmotivo");

                entity.HasOne(d => d.IdnfeNavigation)
                    .WithMany(p => p.Movimentofiscals)
                    .HasForeignKey(d => d.Idnfe)
                    .HasConstraintName("movimentofiscal_idnfe_fkey");
            });

            modelBuilder.Entity<Movimentofiscalmdfe>(entity =>
            {
                entity.HasKey(e => e.Idmovimentofiscalmdfe)
                    .HasName("movimentofiscalmdfe_pkey");

                entity.ToTable("movimentofiscalmdfe");

                entity.Property(e => e.Idmovimentofiscalmdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idmovimentofiscalmdfe");

                entity.Property(e => e.Ambiente)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ambiente");

                entity.Property(e => e.Cancelada)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("cancelada");

                entity.Property(e => e.Chave)
                    .HasMaxLength(44)
                    .HasColumnName("chave");

                entity.Property(e => e.Cstat)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("cstat");

                entity.Property(e => e.Dataemissao).HasColumnName("dataemissao");

                entity.Property(e => e.Emitida)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("emitida");

                entity.Property(e => e.Encerrada)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("encerrada");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(500)
                    .HasColumnName("motivo");

                entity.Property(e => e.Numero)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("numero");

                entity.Property(e => e.Recebimento).HasColumnName("recebimento");

                entity.Property(e => e.Serie)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("serie");

                entity.Property(e => e.Tipodocumento)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("tipodocumento");

                entity.Property(e => e.Xmlenvio).HasColumnName("xmlenvio");

                entity.Property(e => e.Xmlretorno).HasColumnName("xmlretorno");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Movimentofiscalmdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("movimentofiscalmdfe_idmdfe_fkey");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.Idmunicipio)
                    .HasName("municipio_pkey");

                entity.ToTable("municipio");

                entity.Property(e => e.Idmunicipio)
                    .ValueGeneratedNever()
                    .HasColumnName("idmunicipio");

                entity.Property(e => e.Codigoibge)
                    .HasColumnType("decimal(38, 0)")
                    .HasColumnName("codigoibge");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(30)
                    .HasColumnName("descricao");

                entity.Property(e => e.Idunidadefederativa).HasColumnName("idunidadefederativa");

                entity.Property(e => e.Mesorregiaogeografica)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("mesorregiaogeografica");

                entity.Property(e => e.Microrregiaogeografica)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("microrregiaogeografica");

                entity.Property(e => e.Nomemesorregiao)
                    .HasMaxLength(30)
                    .HasColumnName("nomemesorregiao");

                entity.Property(e => e.Nomemicrorregiao)
                    .HasMaxLength(30)
                    .HasColumnName("nomemicrorregiao");

                entity.HasOne(d => d.IdunidadefederativaNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.Idunidadefederativa)
                    .HasConstraintName("municipio_idunidadefederativa_fkey");
            });

            modelBuilder.Entity<Natureza>(entity =>
            {
                entity.HasKey(e => e.Idnatureza)
                    .HasName("natureza_pkey");

                entity.ToTable("natureza");

                entity.Property(e => e.Idnatureza)
                    .ValueGeneratedNever()
                    .HasColumnName("idnatureza");

                entity.Property(e => e.Aplicacao)
                    .HasColumnType("ntext")
                    .HasColumnName("aplicacao");

                entity.Property(e => e.Conta)
                    .HasMaxLength(10)
                    .HasColumnName("conta");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(50)
                    .HasColumnName("descricao");

                entity.Property(e => e.Idnaturezasuperior).HasColumnName("idnaturezasuperior");

                entity.Property(e => e.Tipo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdnaturezasuperiorNavigation)
                    .WithMany(p => p.InverseIdnaturezasuperiorNavigation)
                    .HasForeignKey(d => d.Idnaturezasuperior)
                    .HasConstraintName("natureza_idnaturezasuperior_fkey");
            });

            modelBuilder.Entity<Ncm>(entity =>
            {
                entity.HasKey(e => e.Idncm)
                    .HasName("ncm_pkey");

                entity.ToTable("ncm");

                entity.Property(e => e.Idncm)
                    .ValueGeneratedNever()
                    .HasColumnName("idncm");

                entity.Property(e => e.Chave)
                    .HasMaxLength(100)
                    .HasColumnName("chave");

                entity.Property(e => e.Codigo)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(1000)
                    .HasColumnName("descricao");

                entity.Property(e => e.Estadual)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("estadual");

                entity.Property(e => e.Ex)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("ex");

                entity.Property(e => e.Fonte)
                    .HasMaxLength(100)
                    .HasColumnName("fonte");

                entity.Property(e => e.Idunidadefederativa).HasColumnName("idunidadefederativa");

                entity.Property(e => e.Importadosfederal)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("importadosfederal");

                entity.Property(e => e.Municipal)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("municipal");

                entity.Property(e => e.Nacionalfederal)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("nacionalfederal");

                entity.Property(e => e.Tipo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipo");

                entity.Property(e => e.Versao)
                    .HasMaxLength(100)
                    .HasColumnName("versao");

                entity.Property(e => e.Vigenciafim)
                    .HasColumnType("date")
                    .HasColumnName("vigenciafim");

                entity.Property(e => e.Vigenciainicio)
                    .HasColumnType("date")
                    .HasColumnName("vigenciainicio");

                entity.HasOne(d => d.IdunidadefederativaNavigation)
                    .WithMany(p => p.Ncms)
                    .HasForeignKey(d => d.Idunidadefederativa)
                    .HasConstraintName("ncm_idunidadefederativa_fkey");
            });

            modelBuilder.Entity<Nfe>(entity =>
            {
                entity.HasKey(e => e.Idnfe)
                    .HasName("nfe_pkey");

                entity.ToTable("nfe");

                entity.Property(e => e.Idnfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idnfe");

                entity.Property(e => e.Antt)
                    .HasMaxLength(100)
                    .HasColumnName("antt");

                entity.Property(e => e.Emissao).HasColumnName("emissao");

                entity.Property(e => e.Fretepor)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("fretepor");

                entity.Property(e => e.Idcfop).HasColumnName("idcfop");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Idfinalidade).HasColumnName("idfinalidade");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Idtipoatendimento).HasColumnName("idtipoatendimento");

                entity.Property(e => e.Idtransportadora).HasColumnName("idtransportadora");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Idvenda).HasColumnName("idvenda");

                entity.Property(e => e.Indpagamento)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("indpagamento");

                entity.Property(e => e.Informacoescomplementares)
                    .HasColumnType("ntext")
                    .HasColumnName("informacoescomplementares");

                entity.Property(e => e.Modelo)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("modelo");

                entity.Property(e => e.Placa)
                    .HasMaxLength(8)
                    .HasColumnName("placa");

                entity.Property(e => e.Saida).HasColumnName("saida");

                entity.Property(e => e.Serie)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("serie");

                entity.Property(e => e.Veiculo)
                    .HasMaxLength(200)
                    .HasColumnName("veiculo");

                entity.HasOne(d => d.IdcfopNavigation)
                    .WithMany(p => p.Nves)
                    .HasForeignKey(d => d.Idcfop)
                    .HasConstraintName("nfe_idcfop_fkey");

                entity.HasOne(d => d.IdfinalidadeNavigation)
                    .WithMany(p => p.Nves)
                    .HasForeignKey(d => d.Idfinalidade)
                    .HasConstraintName("nfe_idfinalidade_fkey");

                entity.HasOne(d => d.IdformadepagamentoNavigation)
                    .WithMany(p => p.Nves)
                    .HasForeignKey(d => d.Idformadepagamento)
                    .HasConstraintName("nfe_idformadepagamento_fkey");

                entity.HasOne(d => d.IdtipoatendimentoNavigation)
                    .WithMany(p => p.Nves)
                    .HasForeignKey(d => d.Idtipoatendimento)
                    .HasConstraintName("nfe_idtipoatendimento_fkey");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Nves)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("nfe_idusuario_fkey");
            });

            modelBuilder.Entity<Nfeentradaxml>(entity =>
            {
                entity.HasKey(e => e.Idnfeentradaxml)
                    .HasName("nfeentradaxml_pkey");

                entity.ToTable("nfeentradaxml");

                entity.Property(e => e.Idnfeentradaxml)
                    .ValueGeneratedNever()
                    .HasColumnName("idnfeentradaxml");

                entity.Property(e => e.Idnfeentrada).HasColumnName("idnfeentrada");

                entity.Property(e => e.Xml).HasColumnName("xml");

                entity.HasOne(d => d.IdnfeentradaNavigation)
                    .WithMany(p => p.Nfeentradaxmls)
                    .HasForeignKey(d => d.Idnfeentrada)
                    .HasConstraintName("nfeentradaxml_idnfeentrada_fkey");
            });

            modelBuilder.Entity<Nfeentradum>(entity =>
            {
                entity.HasKey(e => e.Idnfeentrada)
                    .HasName("nfeentrada_pkey");

                entity.ToTable("nfeentrada");

                entity.Property(e => e.Idnfeentrada)
                    .ValueGeneratedNever()
                    .HasColumnName("idnfeentrada");

                entity.Property(e => e.Autcnpj)
                    .HasMaxLength(14)
                    .HasColumnName("autcnpj");

                entity.Property(e => e.Autcpf)
                    .HasMaxLength(11)
                    .HasColumnName("autcpf");

                entity.Property(e => e.Cdv).HasColumnName("cdv");

                entity.Property(e => e.Chnfe)
                    .HasMaxLength(44)
                    .HasColumnName("chnfe");

                entity.Property(e => e.Cmunfg)
                    .HasMaxLength(7)
                    .HasColumnName("cmunfg");

                entity.Property(e => e.Cnf).HasColumnName("cnf");

                entity.Property(e => e.Cstat).HasColumnName("cstat");

                entity.Property(e => e.Cuf)
                    .HasMaxLength(2)
                    .HasColumnName("cuf");

                entity.Property(e => e.Dataimportacao).HasColumnName("dataimportacao");

                entity.Property(e => e.Dhcont).HasColumnName("dhcont");

                entity.Property(e => e.Dhemi).HasColumnName("dhemi");

                entity.Property(e => e.Dhsaient).HasColumnName("dhsaient");

                entity.Property(e => e.Esp)
                    .HasMaxLength(60)
                    .HasColumnName("esp");

                entity.Property(e => e.Finnfe).HasColumnName("finnfe");

                entity.Property(e => e.Iddest).HasColumnName("iddest");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Idpedidocompra).HasColumnName("idpedidocompra");

                entity.Property(e => e.Idtransportadora).HasColumnName("idtransportadora");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Indfinal).HasColumnName("indfinal");

                entity.Property(e => e.Indpag).HasColumnName("indpag");

                entity.Property(e => e.Indpres).HasColumnName("indpres");

                entity.Property(e => e.Infadfisco)
                    .HasColumnType("ntext")
                    .HasColumnName("infadfisco");

                entity.Property(e => e.Infcpl)
                    .HasColumnType("ntext")
                    .HasColumnName("infcpl");

                entity.Property(e => e.Marca)
                    .HasMaxLength(60)
                    .HasColumnName("marca");

                entity.Property(e => e.Moddoc).HasColumnName("moddoc");

                entity.Property(e => e.Modfrete).HasColumnName("modfrete");

                entity.Property(e => e.Natope)
                    .HasMaxLength(60)
                    .HasColumnName("natope");

                entity.Property(e => e.Nnf).HasColumnName("nnf");

                entity.Property(e => e.Nprot)
                    .HasMaxLength(20)
                    .HasColumnName("nprot");

                entity.Property(e => e.Nvol)
                    .HasMaxLength(60)
                    .HasColumnName("nvol");

                entity.Property(e => e.Pesob)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesob");

                entity.Property(e => e.Pesol)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesol");

                entity.Property(e => e.Placa)
                    .HasMaxLength(8)
                    .HasColumnName("placa");

                entity.Property(e => e.Procemi).HasColumnName("procemi");

                entity.Property(e => e.Qvol)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("qvol");

                entity.Property(e => e.Serie).HasColumnName("serie");

                entity.Property(e => e.Tpamb).HasColumnName("tpamb");

                entity.Property(e => e.Tpemis).HasColumnName("tpemis");

                entity.Property(e => e.Tpimp).HasColumnName("tpimp");

                entity.Property(e => e.Tpnf).HasColumnName("tpnf");

                entity.Property(e => e.Uf)
                    .HasMaxLength(2)
                    .HasColumnName("uf");

                entity.Property(e => e.Vbc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbc");

                entity.Property(e => e.Vbcst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcst");

                entity.Property(e => e.Vcofins)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vcofins");

                entity.Property(e => e.Vdesc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vdesc");

                entity.Property(e => e.Verproc)
                    .HasMaxLength(20)
                    .HasColumnName("verproc");

                entity.Property(e => e.Vfcpufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vfcpufdest");

                entity.Property(e => e.Vfrete)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vfrete");

                entity.Property(e => e.Vicms)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicms");

                entity.Property(e => e.Vicmsufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsufdest");

                entity.Property(e => e.Vicmsufremet)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsufremet");

                entity.Property(e => e.Vipi)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vipi");

                entity.Property(e => e.Vnf)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vnf");

                entity.Property(e => e.Voutro)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("voutro");

                entity.Property(e => e.Vpis)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vpis");

                entity.Property(e => e.Vprod)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vprod");

                entity.Property(e => e.Vseg)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vseg");

                entity.Property(e => e.Vst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vst");

                entity.Property(e => e.Vtottrib)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vtottrib");

                entity.Property(e => e.Xcampo)
                    .HasMaxLength(20)
                    .HasColumnName("xcampo");

                entity.Property(e => e.Xjust)
                    .HasMaxLength(255)
                    .HasColumnName("xjust");

                entity.Property(e => e.Xmotivo)
                    .HasMaxLength(255)
                    .HasColumnName("xmotivo");

                entity.Property(e => e.Xtexto)
                    .HasMaxLength(60)
                    .HasColumnName("xtexto");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Nfeentrada)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("nfeentrada_idfornecedor_fkey");

                entity.HasOne(d => d.IdpedidocompraNavigation)
                    .WithMany(p => p.Nfeentrada)
                    .HasForeignKey(d => d.Idpedidocompra)
                    .HasConstraintName("nfeentrada_idpedidocompra_fkey");

                entity.HasOne(d => d.IdtransportadoraNavigation)
                    .WithMany(p => p.Nfeentrada)
                    .HasForeignKey(d => d.Idtransportadora)
                    .HasConstraintName("nfeentrada_idtransportadora_fkey");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Nfeentrada)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("nfeentrada_idusuario_fkey");
            });

            modelBuilder.Entity<Nfereferenciadamdfe>(entity =>
            {
                entity.HasKey(e => e.Idnfereferenciadamdfe)
                    .HasName("nfereferenciadamdfe_pkey");

                entity.ToTable("nfereferenciadamdfe");

                entity.Property(e => e.Idnfereferenciadamdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idnfereferenciadamdfe");

                entity.Property(e => e.Chavenfe)
                    .HasMaxLength(44)
                    .HasColumnName("chavenfe");

                entity.Property(e => e.Iddocumentofiscalmdfe).HasColumnName("iddocumentofiscalmdfe");

                entity.HasOne(d => d.IddocumentofiscalmdfeNavigation)
                    .WithMany(p => p.Nfereferenciadamdves)
                    .HasForeignKey(d => d.Iddocumentofiscalmdfe)
                    .HasConstraintName("nfereferenciadamdfe_iddocumentofiscalmdfe_fkey");
            });

            modelBuilder.Entity<Origemproduto>(entity =>
            {
                entity.HasKey(e => e.Idorigemproduto)
                    .HasName("origemproduto_pkey");

                entity.ToTable("origemproduto");

                entity.Property(e => e.Idorigemproduto)
                    .ValueGeneratedNever()
                    .HasColumnName("idorigemproduto");

                entity.Property(e => e.Codigo)
                    .HasColumnType("decimal(2, 0)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Pagamentomfe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pagamentomfe");

                entity.Property(e => e.Adquirente)
                    .HasColumnType("ntext")
                    .HasColumnName("adquirente");

                entity.Property(e => e.Autorizacao)
                    .HasColumnType("ntext")
                    .HasColumnName("autorizacao");

                entity.Property(e => e.Bandeira)
                    .HasColumnType("ntext")
                    .HasColumnName("bandeira");

                entity.Property(e => e.Bincartao)
                    .HasColumnType("ntext")
                    .HasColumnName("bincartao");

                entity.Property(e => e.Dataexpiracao)
                    .HasColumnType("ntext")
                    .HasColumnName("dataexpiracao");

                entity.Property(e => e.Datapagamento)
                    .HasColumnType("date")
                    .HasColumnName("datapagamento");

                entity.Property(e => e.Donocartao)
                    .HasColumnType("ntext")
                    .HasColumnName("donocartao");

                entity.Property(e => e.Idlocal).HasColumnName("idlocal");

                entity.Property(e => e.Idpagamento).HasColumnName("idpagamento");

                entity.Property(e => e.Idpagamentomfe).HasColumnName("idpagamentomfe");

                entity.Property(e => e.Idvenda).HasColumnName("idvenda");

                entity.Property(e => e.Mfeenviadodadoscartao)
                    .HasColumnType("ntext")
                    .HasColumnName("mfeenviadodadoscartao");

                entity.Property(e => e.Nsu)
                    .HasColumnType("ntext")
                    .HasColumnName("nsu");

                entity.Property(e => e.Qtdparcelas)
                    .HasColumnType("ntext")
                    .HasColumnName("qtdparcelas");

                entity.Property(e => e.Ultimosquatrodigitos)
                    .HasColumnType("ntext")
                    .HasColumnName("ultimosquatrodigitos");

                entity.Property(e => e.Valorcartao)
                    .HasColumnType("ntext")
                    .HasColumnName("valorcartao");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.Idpais)
                    .HasName("pais_pkey");

                entity.ToTable("pais");

                entity.Property(e => e.Idpais)
                    .ValueGeneratedNever()
                    .HasColumnName("idpais");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Pedidocompra>(entity =>
            {
                entity.HasKey(e => e.Idpedidocompra)
                    .HasName("pedidocompra_pkey");

                entity.ToTable("pedidocompra");

                entity.Property(e => e.Idpedidocompra)
                    .ValueGeneratedNever()
                    .HasColumnName("idpedidocompra");

                entity.Property(e => e.Dataalteracao).HasColumnName("dataalteracao");

                entity.Property(e => e.Datacancelamento).HasColumnName("datacancelamento");

                entity.Property(e => e.Dataemissao).HasColumnName("dataemissao");

                entity.Property(e => e.Dataentrega).HasColumnName("dataentrega");

                entity.Property(e => e.Datafaturamento)
                    .HasColumnType("date")
                    .HasColumnName("datafaturamento");

                entity.Property(e => e.Idcomprador).HasColumnName("idcomprador");

                entity.Property(e => e.Idfluxocaixa).HasColumnName("idfluxocaixa");

                entity.Property(e => e.Idformadepagamento).HasColumnName("idformadepagamento");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Idtipodeoperacao).HasColumnName("idtipodeoperacao");

                entity.Property(e => e.Idtransportadora).HasColumnName("idtransportadora");

                entity.Property(e => e.Idusuariocadastro).HasColumnName("idusuariocadastro");

                entity.Property(e => e.Motivodecancelamento)
                    .HasColumnType("ntext")
                    .HasColumnName("motivodecancelamento");

                entity.Property(e => e.Observacao)
                    .HasColumnType("ntext")
                    .HasColumnName("observacao");

                entity.Property(e => e.Pagamentosdescricao)
                    .HasMaxLength(1000)
                    .HasColumnName("pagamentosdescricao");

                entity.Property(e => e.Quantidadeitens)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("quantidadeitens");

                entity.Property(e => e.Status)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("status");

                entity.Property(e => e.Tipofrete)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipofrete");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdformadepagamentoNavigation)
                    .WithMany(p => p.Pedidocompras)
                    .HasForeignKey(d => d.Idformadepagamento)
                    .HasConstraintName("pedidocompra_idformadepagamento_fkey");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Pedidocompras)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("pedidocompra_idfornecedor_fkey");

                entity.HasOne(d => d.IdtransportadoraNavigation)
                    .WithMany(p => p.Pedidocompras)
                    .HasForeignKey(d => d.Idtransportadora)
                    .HasConstraintName("pedidocompra_idtransportadora_fkey");

                entity.HasOne(d => d.IdusuariocadastroNavigation)
                    .WithMany(p => p.Pedidocompras)
                    .HasForeignKey(d => d.Idusuariocadastro)
                    .HasConstraintName("pedidocompra_idusuariocadastro_fkey");
            });

            modelBuilder.Entity<Percursomdfe>(entity =>
            {
                entity.HasKey(e => e.Idpercursomdfe)
                    .HasName("percursomdfe_pkey");

                entity.ToTable("percursomdfe");

                entity.Property(e => e.Idpercursomdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idpercursomdfe");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.Property(e => e.Idunidadefederativapercurso).HasColumnName("idunidadefederativapercurso");

                entity.Property(e => e.Inicioviagem).HasColumnName("inicioviagem");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Percursomdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("percursomdfe_idmdfe_fkey");

                entity.HasOne(d => d.IdunidadefederativapercursoNavigation)
                    .WithMany(p => p.Percursomdves)
                    .HasForeignKey(d => d.Idunidadefederativapercurso)
                    .HasConstraintName("percursomdfe_idunidadefederativapercurso_fkey");
            });

            modelBuilder.Entity<Perfilacesso>(entity =>
            {
                entity.HasKey(e => e.Idperfilacesso)
                    .HasName("perfilacesso_pkey");

                entity.ToTable("perfilacesso");

                entity.Property(e => e.Idperfilacesso)
                    .ValueGeneratedNever()
                    .HasColumnName("idperfilacesso");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .HasColumnName("descricao");

                entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            });

            modelBuilder.Entity<Perfilacessoitemmenu>(entity =>
            {
                entity.HasKey(e => e.Idperfilacessoitemmenu)
                    .HasName("perfilacessoitemmenu_pkey");

                entity.ToTable("perfilacessoitemmenu");

                entity.Property(e => e.Idperfilacessoitemmenu)
                    .ValueGeneratedNever()
                    .HasColumnName("idperfilacessoitemmenu");

                entity.Property(e => e.Iditemmenu).HasColumnName("iditemmenu");

                entity.Property(e => e.Idperfilacesso).HasColumnName("idperfilacesso");

                entity.HasOne(d => d.IditemmenuNavigation)
                    .WithMany(p => p.Perfilacessoitemmenus)
                    .HasForeignKey(d => d.Iditemmenu)
                    .HasConstraintName("perfilacessoitemmenu_iditemmenu_fkey");

                entity.HasOne(d => d.IdperfilacessoNavigation)
                    .WithMany(p => p.Perfilacessoitemmenus)
                    .HasForeignKey(d => d.Idperfilacesso)
                    .HasConstraintName("perfilacessoitemmenu_idperfilacesso_fkey");
            });

            modelBuilder.Entity<Portarium>(entity =>
            {
                entity.HasKey(e => e.Idportaria)
                    .HasName("portaria_pkey");

                entity.ToTable("portaria");

                entity.Property(e => e.Idportaria)
                    .ValueGeneratedNever()
                    .HasColumnName("idportaria");

                entity.Property(e => e.Descricao)
                    .HasColumnType("ntext")
                    .HasColumnName("descricao");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(250)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Idproduto)
                    .HasName("produto_pkey");

                entity.ToTable("produto");

                entity.Property(e => e.Idproduto)
                    .ValueGeneratedNever()
                    .HasColumnName("idproduto");

                entity.Property(e => e.Alterardescricao)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("alterardescricao");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Cest)
                    .HasMaxLength(150)
                    .HasColumnName("cest");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .HasColumnName("descricao");

                entity.Property(e => e.Ean).HasColumnName("ean");

                entity.Property(e => e.Estoquemaximo)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("estoquemaximo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Estoqueminimo)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("estoqueminimo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Extipi)
                    .HasMaxLength(2)
                    .HasColumnName("extipi");

                entity.Property(e => e.Idalmoxarifadoentrada).HasColumnName("idalmoxarifadoentrada");

                entity.Property(e => e.Idalmoxarifadosaida).HasColumnName("idalmoxarifadosaida");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Idintegracaofiscalnfce).HasColumnName("idintegracaofiscalnfce");

                entity.Property(e => e.Idintegracaofiscalnfe).HasColumnName("idintegracaofiscalnfe");

                entity.Property(e => e.Idmarca).HasColumnName("idmarca");

                entity.Property(e => e.Idncm).HasColumnName("idncm");

                entity.Property(e => e.Idorigemproduto).HasColumnName("idorigemproduto");

                entity.Property(e => e.Idsubcategoria).HasColumnName("idsubcategoria");

                entity.Property(e => e.Idunidadedemedida).HasColumnName("idunidadedemedida");

                entity.Property(e => e.Imagemproduto).HasColumnName("imagemproduto");

                entity.Property(e => e.Imagemprodutolink)
                    .HasMaxLength(150)
                    .HasColumnName("imagemprodutolink");

                entity.Property(e => e.Paravender).HasColumnName("paravender");

                entity.Property(e => e.Saldoestoque)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("saldoestoque")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tipodeproduto).HasColumnName("tipodeproduto");

                entity.Property(e => e.TribAliqcofins)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trib_aliqcofins");

                entity.Property(e => e.TribAliqicmsdif)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trib_aliqicmsdif");

                entity.Property(e => e.TribAliqipi)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trib_aliqipi");

                entity.Property(e => e.TribAliqpis)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trib_aliqpis");

                entity.Property(e => e.TribMva)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trib_mva");

                entity.Property(e => e.TribRedbcicms)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trib_redbcicms");

                entity.Property(e => e.TribRedbcicmsst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("trib_redbcicmsst");

                entity.Property(e => e.Valorcusto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorcusto");

                entity.Property(e => e.Valorvenda)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorvenda");

                entity.Property(e => e.Valorvendaprazo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorvendaprazo");

                entity.Property(e => e.Vendersemsaldo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("vendersemsaldo");

                entity.HasOne(d => d.IdalmoxarifadoentradaNavigation)
                    .WithMany(p => p.ProdutoIdalmoxarifadoentradaNavigations)
                    .HasForeignKey(d => d.Idalmoxarifadoentrada)
                    .HasConstraintName("produto_idalmoxarifadoentrada_fkey");

                entity.HasOne(d => d.IdalmoxarifadosaidaNavigation)
                    .WithMany(p => p.ProdutoIdalmoxarifadosaidaNavigations)
                    .HasForeignKey(d => d.Idalmoxarifadosaida)
                    .HasConstraintName("produto_idalmoxarifadosaida_fkey");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.ProdutoIdcategoriaNavigations)
                    .HasForeignKey(d => d.Idcategoria)
                    .HasConstraintName("produto_idcategoria_fkey");

                entity.HasOne(d => d.IdintegracaofiscalnfceNavigation)
                    .WithMany(p => p.ProdutoIdintegracaofiscalnfceNavigations)
                    .HasForeignKey(d => d.Idintegracaofiscalnfce)
                    .HasConstraintName("produto_idintegracaofiscalnfce_fkey");

                entity.HasOne(d => d.IdintegracaofiscalnfeNavigation)
                    .WithMany(p => p.ProdutoIdintegracaofiscalnfeNavigations)
                    .HasForeignKey(d => d.Idintegracaofiscalnfe)
                    .HasConstraintName("produto_idintegracaofiscalnfe_fkey");

                entity.HasOne(d => d.IdmarcaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.Idmarca)
                    .HasConstraintName("produto_idmarca_fkey");

                entity.HasOne(d => d.IdorigemprodutoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.Idorigemproduto)
                    .HasConstraintName("produto_idorigemproduto_fkey");

                entity.HasOne(d => d.IdsubcategoriaNavigation)
                    .WithMany(p => p.ProdutoIdsubcategoriaNavigations)
                    .HasForeignKey(d => d.Idsubcategoria)
                    .HasConstraintName("produto_idsubcategoria_fkey");

                entity.HasOne(d => d.IdunidadedemedidaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.Idunidadedemedida)
                    .HasConstraintName("produto_idunidadedemedida_fkey");
            });

            modelBuilder.Entity<Produtocomposicao>(entity =>
            {
                entity.HasKey(e => e.Idprodutocomposicao)
                    .HasName("produtocomposicao_pkey");

                entity.ToTable("produtocomposicao");

                entity.Property(e => e.Idprodutocomposicao)
                    .ValueGeneratedNever()
                    .HasColumnName("idprodutocomposicao");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Idprodutocomposto).HasColumnName("idprodutocomposto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("quantidade");
            });

            modelBuilder.Entity<Produtofornecedor>(entity =>
            {
                entity.HasKey(e => e.Idprodutofornecedor)
                    .HasName("produtofornecedor_pkey");

                entity.ToTable("produtofornecedor");

                entity.Property(e => e.Idprodutofornecedor)
                    .ValueGeneratedNever()
                    .HasColumnName("idprodutofornecedor");

                entity.Property(e => e.Cprod)
                    .HasMaxLength(14)
                    .HasColumnName("cprod");

                entity.Property(e => e.Idfornecedor).HasColumnName("idfornecedor");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.HasOne(d => d.IdfornecedorNavigation)
                    .WithMany(p => p.Produtofornecedors)
                    .HasForeignKey(d => d.Idfornecedor)
                    .HasConstraintName("produtofornecedor_idfornecedor_fkey");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Produtofornecedors)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("produtofornecedor_idproduto_fkey");
            });

            modelBuilder.Entity<Produtonfe>(entity =>
            {
                entity.HasKey(e => e.Idprodutonfe)
                    .HasName("produtonfe_pkey");

                entity.ToTable("produtonfe");

                entity.Property(e => e.Idprodutonfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idprodutonfe");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("desconto");

                entity.Property(e => e.Frete)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("frete");

                entity.Property(e => e.Idcfop).HasColumnName("idcfop");

                entity.Property(e => e.Idintegracaofiscal).HasColumnName("idintegracaofiscal");

                entity.Property(e => e.Idnfe).HasColumnName("idnfe");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Idunidadedemedida).HasColumnName("idunidadedemedida");

                entity.Property(e => e.Outrasdespesas)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("outrasdespesas");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.Seguro)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("seguro");

                entity.Property(e => e.Sequencia).HasColumnName("sequencia");

                entity.Property(e => e.Valorunitario)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorunitario");

                entity.HasOne(d => d.IdcfopNavigation)
                    .WithMany(p => p.Produtonves)
                    .HasForeignKey(d => d.Idcfop)
                    .HasConstraintName("produtonfe_idcfop_fkey");

                entity.HasOne(d => d.IdintegracaofiscalNavigation)
                    .WithMany(p => p.Produtonves)
                    .HasForeignKey(d => d.Idintegracaofiscal)
                    .HasConstraintName("produtonfe_idintegracaofiscal_fkey");

                entity.HasOne(d => d.IdnfeNavigation)
                    .WithMany(p => p.Produtonves)
                    .HasForeignKey(d => d.Idnfe)
                    .HasConstraintName("produtonfe_idnfe_fkey");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Produtonves)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("produtonfe_idproduto_fkey");

                entity.HasOne(d => d.IdunidadedemedidaNavigation)
                    .WithMany(p => p.Produtonves)
                    .HasForeignKey(d => d.Idunidadedemedida)
                    .HasConstraintName("produtonfe_idunidadedemedida_fkey");
            });

            modelBuilder.Entity<Produtonfecofin>(entity =>
            {
                entity.HasKey(e => e.Idprodutonfecofins)
                    .HasName("produtonfecofins_pkey");

                entity.ToTable("produtonfecofins");

                entity.Property(e => e.Idprodutonfecofins)
                    .ValueGeneratedNever()
                    .HasColumnName("idprodutonfecofins");

                entity.Property(e => e.Idcstcofins).HasColumnName("idcstcofins");

                entity.Property(e => e.Idprodutonfe).HasColumnName("idprodutonfe");

                entity.Property(e => e.Pcofins)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pcofins");

                entity.Property(e => e.Vbc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbc");

                entity.Property(e => e.Vcofins)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vcofins");

                entity.HasOne(d => d.IdcstcofinsNavigation)
                    .WithMany(p => p.Produtonfecofins)
                    .HasForeignKey(d => d.Idcstcofins)
                    .HasConstraintName("produtonfecofins_idcstcofins_fkey");

                entity.HasOne(d => d.IdprodutonfeNavigation)
                    .WithMany(p => p.Produtonfecofins)
                    .HasForeignKey(d => d.Idprodutonfe)
                    .HasConstraintName("produtonfecofins_idprodutonfe_fkey");
            });

            modelBuilder.Entity<Produtonfeicm>(entity =>
            {
                entity.HasKey(e => e.Idprodutonfeicms)
                    .HasName("produtonfeicms_pkey");

                entity.ToTable("produtonfeicms");

                entity.Property(e => e.Idprodutonfeicms)
                    .ValueGeneratedNever()
                    .HasColumnName("idprodutonfeicms");

                entity.Property(e => e.Idcsticms).HasColumnName("idcsticms");

                entity.Property(e => e.Idorigemproduto).HasColumnName("idorigemproduto");

                entity.Property(e => e.Idprodutonfe).HasColumnName("idprodutonfe");

                entity.Property(e => e.Idunidadefederativast).HasColumnName("idunidadefederativast");

                entity.Property(e => e.Modbc)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("modbc");

                entity.Property(e => e.Modbcst)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("modbcst");

                entity.Property(e => e.Pcredsn)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pcredsn");

                entity.Property(e => e.Pdif)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pdif");

                entity.Property(e => e.Picms)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("picms");

                entity.Property(e => e.Picmsst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("picmsst");

                entity.Property(e => e.Pmvast)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pmvast");

                entity.Property(e => e.Predbc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("predbc");

                entity.Property(e => e.Predbcst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("predbcst");

                entity.Property(e => e.Vbc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbc");

                entity.Property(e => e.Vbcst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcst");

                entity.Property(e => e.Vcredicmssn)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vcredicmssn");

                entity.Property(e => e.Vicms)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicms");

                entity.Property(e => e.Vicmsdif)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsdif");

                entity.Property(e => e.Vicmsst)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsst");

                entity.HasOne(d => d.IdcsticmsNavigation)
                    .WithMany(p => p.Produtonfeicms)
                    .HasForeignKey(d => d.Idcsticms)
                    .HasConstraintName("produtonfeicms_idcsticms_fkey");

                entity.HasOne(d => d.IdprodutonfeNavigation)
                    .WithMany(p => p.Produtonfeicms)
                    .HasForeignKey(d => d.Idprodutonfe)
                    .HasConstraintName("produtonfeicms_idprodutonfe_fkey");

                entity.HasOne(d => d.IdunidadefederativastNavigation)
                    .WithMany(p => p.Produtonfeicms)
                    .HasForeignKey(d => d.Idunidadefederativast)
                    .HasConstraintName("produtonfeicms_idunidadefederativast_fkey");
            });

            modelBuilder.Entity<Produtonfepartilhaicm>(entity =>
            {
                entity.HasKey(e => e.Idprodutonfepartilhaicms)
                    .HasName("produtonfepartilhaicms_pkey");

                entity.ToTable("produtonfepartilhaicms");

                entity.Property(e => e.Idprodutonfepartilhaicms)
                    .ValueGeneratedNever()
                    .HasColumnName("idprodutonfepartilhaicms");

                entity.Property(e => e.Idprodutonfe).HasColumnName("idprodutonfe");

                entity.Property(e => e.Pfcpufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("pfcpufdest");

                entity.Property(e => e.Picmsinter)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("picmsinter");

                entity.Property(e => e.Picmsinterpart)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("picmsinterpart");

                entity.Property(e => e.Picmsufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("picmsufdest");

                entity.Property(e => e.Vbcufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbcufdest");

                entity.Property(e => e.Vfcpufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vfcpufdest");

                entity.Property(e => e.Vicmsufdest)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsufdest");

                entity.Property(e => e.Vicmsufremet)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vicmsufremet");

                entity.HasOne(d => d.IdprodutonfeNavigation)
                    .WithMany(p => p.Produtonfepartilhaicms)
                    .HasForeignKey(d => d.Idprodutonfe)
                    .HasConstraintName("produtonfepartilhaicms_idprodutonfe_fkey");
            });

            modelBuilder.Entity<Produtonfepi>(entity =>
            {
                entity.HasKey(e => e.Idprodutonfepis)
                    .HasName("produtonfepis_pkey");

                entity.ToTable("produtonfepis");

                entity.Property(e => e.Idprodutonfepis)
                    .ValueGeneratedNever()
                    .HasColumnName("idprodutonfepis");

                entity.Property(e => e.Idcstpis).HasColumnName("idcstpis");

                entity.Property(e => e.Idprodutonfe).HasColumnName("idprodutonfe");

                entity.Property(e => e.Ppis)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("ppis");

                entity.Property(e => e.Vbc)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vbc");

                entity.Property(e => e.Vpis)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vpis");

                entity.HasOne(d => d.IdcstpisNavigation)
                    .WithMany(p => p.Produtonfepis)
                    .HasForeignKey(d => d.Idcstpis)
                    .HasConstraintName("produtonfepis_idcstpis_fkey");

                entity.HasOne(d => d.IdprodutonfeNavigation)
                    .WithMany(p => p.Produtonfepis)
                    .HasForeignKey(d => d.Idprodutonfe)
                    .HasConstraintName("produtonfepis_idprodutonfe_fkey");
            });

            modelBuilder.Entity<Proprietarioveiculomdfe>(entity =>
            {
                entity.HasKey(e => e.Idproprietarioveiculomdfe)
                    .HasName("proprietarioveiculomdfe_pkey");

                entity.ToTable("proprietarioveiculomdfe");

                entity.Property(e => e.Idproprietarioveiculomdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idproprietarioveiculomdfe");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Codigoagenciaporto)
                    .HasColumnType("decimal(16, 0)")
                    .HasColumnName("codigoagenciaporto");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Idunidadefederativa).HasColumnName("idunidadefederativa");

                entity.Property(e => e.Inscricaoestadual)
                    .HasColumnType("decimal(14, 0)")
                    .HasColumnName("inscricaoestadual");

                entity.Property(e => e.Nome)
                    .HasMaxLength(60)
                    .HasColumnName("nome");

                entity.Property(e => e.Rntrc)
                    .HasMaxLength(8)
                    .HasColumnName("rntrc");

                entity.Property(e => e.Tipoproprietario)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipoproprietario");

                entity.HasOne(d => d.IdunidadefederativaNavigation)
                    .WithMany(p => p.Proprietarioveiculomdves)
                    .HasForeignKey(d => d.Idunidadefederativa)
                    .HasConstraintName("proprietarioveiculomdfe_idunidadefederativa_fkey");
            });

            modelBuilder.Entity<Requisitante>(entity =>
            {
                entity.HasKey(e => e.Idrequisitante)
                    .HasName("requisitante_pkey");

                entity.ToTable("requisitante");

                entity.Property(e => e.Idrequisitante)
                    .ValueGeneratedNever()
                    .HasColumnName("idrequisitante");

                entity.Property(e => e.Idcentrocusto).HasColumnName("idcentrocusto");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Responsavelsegurocargamdfe>(entity =>
            {
                entity.HasKey(e => e.Idresponsavelsegurocargamdfe)
                    .HasName("responsavelsegurocargamdfe_pkey");

                entity.ToTable("responsavelsegurocargamdfe");

                entity.Property(e => e.Idresponsavelsegurocargamdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idresponsavelsegurocargamdfe");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Responsavelseguro)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("responsavelseguro");
            });

            modelBuilder.Entity<Retiradacaixa>(entity =>
            {
                entity.HasKey(e => e.Idretiradacaixa)
                    .HasName("retiradacaixa_pkey");

                entity.ToTable("retiradacaixa");

                entity.Property(e => e.Idretiradacaixa)
                    .ValueGeneratedNever()
                    .HasColumnName("idretiradacaixa");

                entity.Property(e => e.Dataretirada).HasColumnName("dataretirada");

                entity.Property(e => e.Idfluxocaixa).HasColumnName("idfluxocaixa");

                entity.Property(e => e.Valorretirada)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorretirada");

                entity.HasOne(d => d.IdfluxocaixaNavigation)
                    .WithMany(p => p.Retiradacaixas)
                    .HasForeignKey(d => d.Idfluxocaixa)
                    .HasConstraintName("retiradacaixa_idfluxocaixa_fkey");
            });

            modelBuilder.Entity<Romaneio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("romaneio");

                entity.Property(e => e.Datainclusao)
                    .HasColumnType("date")
                    .HasColumnName("datainclusao");

                entity.Property(e => e.Empresa)
                    .HasMaxLength(150)
                    .HasColumnName("empresa");

                entity.Property(e => e.Idromaneio).HasColumnName("idromaneio");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Motoristaid).HasColumnName("motoristaid");

                entity.Property(e => e.Motoristanome)
                    .HasMaxLength(600)
                    .HasColumnName("motoristanome");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(500)
                    .HasColumnName("observacao");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Totalitens).HasColumnName("totalitens");

                entity.Property(e => e.Transportadoraid).HasColumnName("transportadoraid");

                entity.Property(e => e.Transportadoranome)
                    .HasMaxLength(600)
                    .HasColumnName("transportadoranome");

                entity.Property(e => e.Valortotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valortotal");

                entity.Property(e => e.Veiculodescricao)
                    .HasMaxLength(600)
                    .HasColumnName("veiculodescricao");

                entity.Property(e => e.Veiculoid).HasColumnName("veiculoid");
            });

            modelBuilder.Entity<Romaneiovendum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("romaneiovenda");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(150)
                    .HasColumnName("cliente");

                entity.Property(e => e.Datafaturamento)
                    .HasColumnType("date")
                    .HasColumnName("datafaturamento");

                entity.Property(e => e.Idromaneio).HasColumnName("idromaneio");

                entity.Property(e => e.Idromaneiovenda).HasColumnName("idromaneiovenda");

                entity.Property(e => e.Idvenda).HasColumnName("idvenda");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(500)
                    .HasColumnName("observacao");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Totalitens).HasColumnName("totalitens");

                entity.Property(e => e.Valortotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valortotal");
            });

            modelBuilder.Entity<Saldoestoqueinicial>(entity =>
            {
                entity.HasKey(e => e.Idsaldoestoqueinicial)
                    .HasName("saldoestoqueinicial_pkey");

                entity.ToTable("saldoestoqueinicial");

                entity.Property(e => e.Idsaldoestoqueinicial)
                    .ValueGeneratedNever()
                    .HasColumnName("idsaldoestoqueinicial");

                entity.Property(e => e.Datacadastro)
                    .HasColumnType("date")
                    .HasColumnName("datacadastro");

                entity.Property(e => e.Idalmoxarifado).HasColumnName("idalmoxarifado");

                entity.Property(e => e.Idproduto).HasColumnName("idproduto");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("quantidade");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdalmoxarifadoNavigation)
                    .WithMany(p => p.Saldoestoqueinicials)
                    .HasForeignKey(d => d.Idalmoxarifado)
                    .HasConstraintName("saldoestoqueinicial_idalmoxarifado_fkey");

                entity.HasOne(d => d.IdprodutoNavigation)
                    .WithMany(p => p.Saldoestoqueinicials)
                    .HasForeignKey(d => d.Idproduto)
                    .HasConstraintName("saldoestoqueinicial_idproduto_fkey");
            });

            modelBuilder.Entity<Sangriacaixa>(entity =>
            {
                entity.HasKey(e => e.Idsangriacaixa)
                    .HasName("sangriacaixa_pkey");

                entity.ToTable("sangriacaixa");

                entity.Property(e => e.Idsangriacaixa)
                    .ValueGeneratedNever()
                    .HasColumnName("idsangriacaixa");

                entity.Property(e => e.Datasangria).HasColumnName("datasangria");

                entity.Property(e => e.Idfluxocaixa).HasColumnName("idfluxocaixa");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Idusuariocadastro).HasColumnName("idusuariocadastro");

                entity.Property(e => e.Observacao)
                    .HasColumnType("ntext")
                    .HasColumnName("observacao");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdfluxocaixaNavigation)
                    .WithMany(p => p.Sangriacaixas)
                    .HasForeignKey(d => d.Idfluxocaixa)
                    .HasConstraintName("sangriacaixa_idfluxocaixa_fkey");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.SangriacaixaIdusuarioNavigations)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("sangriacaixa_idusuario_fkey");

                entity.HasOne(d => d.IdusuariocadastroNavigation)
                    .WithMany(p => p.SangriacaixaIdusuariocadastroNavigations)
                    .HasForeignKey(d => d.Idusuariocadastro)
                    .HasConstraintName("sangriacaixa_idusuariocadastro_fkey");
            });

            modelBuilder.Entity<Seguradora>(entity =>
            {
                entity.HasKey(e => e.Idseguradora)
                    .HasName("seguradora_pkey");

                entity.ToTable("seguradora");

                entity.Property(e => e.Idseguradora)
                    .ValueGeneratedNever()
                    .HasColumnName("idseguradora");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Seguradoramdfe>(entity =>
            {
                entity.HasKey(e => e.Idseguradoramdfe)
                    .HasName("seguradoramdfe_pkey");

                entity.ToTable("seguradoramdfe");

                entity.Property(e => e.Idseguradoramdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idseguradoramdfe");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.Property(e => e.Idresponsavelsegurocargamdfe).HasColumnName("idresponsavelsegurocargamdfe");

                entity.Property(e => e.Idseguradora).HasColumnName("idseguradora");

                entity.Property(e => e.Numeroapolice)
                    .HasMaxLength(20)
                    .HasColumnName("numeroapolice");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Seguradoramdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("seguradoramdfe_idmdfe_fkey");

                entity.HasOne(d => d.IdresponsavelsegurocargamdfeNavigation)
                    .WithMany(p => p.Seguradoramdves)
                    .HasForeignKey(d => d.Idresponsavelsegurocargamdfe)
                    .HasConstraintName("seguradoramdfe_idresponsavelsegurocargamdfe_fkey");

                entity.HasOne(d => d.IdseguradoraNavigation)
                    .WithMany(p => p.Seguradoramdves)
                    .HasForeignKey(d => d.Idseguradora)
                    .HasConstraintName("seguradoramdfe_idseguradora_fkey");
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.HasKey(e => e.Idservico)
                    .HasName("servico_pkey");

                entity.ToTable("servico");

                entity.Property(e => e.Idservico)
                    .ValueGeneratedNever()
                    .HasColumnName("idservico");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Idunidadedemedida).HasColumnName("idunidadedemedida");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Suprimentocaixa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("suprimentocaixa");

                entity.Property(e => e.Datasuprimentocaixa).HasColumnName("datasuprimentocaixa");

                entity.Property(e => e.Idfluxocaixa).HasColumnName("idfluxocaixa");

                entity.Property(e => e.Idsuprimentocaixa).HasColumnName("idsuprimentocaixa");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Idusuariocadastro).HasColumnName("idusuariocadastro");

                entity.Property(e => e.Observacao)
                    .HasColumnType("ntext")
                    .HasColumnName("observacao");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("valor");
            });

            modelBuilder.Entity<Talonario>(entity =>
            {
                entity.HasKey(e => e.Idtalonario)
                    .HasName("talonario_pkey");

                entity.ToTable("talonario");

                entity.Property(e => e.Idtalonario)
                    .ValueGeneratedNever()
                    .HasColumnName("idtalonario");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Emissao)
                    .HasColumnType("date")
                    .HasColumnName("emissao");

                entity.Property(e => e.Fim)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("fim");

                entity.Property(e => e.Idcontabancaria).HasColumnName("idcontabancaria");

                entity.Property(e => e.Inicio)
                    .HasColumnType("decimal(11, 0)")
                    .HasColumnName("inicio");

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .HasColumnName("numero");

                entity.Property(e => e.Obs).HasColumnName("obs");

                entity.HasOne(d => d.IdcontabancariaNavigation)
                    .WithMany(p => p.Talonarios)
                    .HasForeignKey(d => d.Idcontabancaria)
                    .HasConstraintName("talonario_idcontabancaria_fkey");
            });

            modelBuilder.Entity<Tipoatendimento>(entity =>
            {
                entity.HasKey(e => e.Idtipoatendimento)
                    .HasName("tipoatendimento_pkey");

                entity.ToTable("tipoatendimento");

                entity.Property(e => e.Idtipoatendimento)
                    .ValueGeneratedNever()
                    .HasColumnName("idtipoatendimento");

                entity.Property(e => e.Codigo)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("codigo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Tipodeoperacao>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tipodeoperacao");

                entity.Property(e => e.Controlarestoque).HasColumnName("controlarestoque");

                entity.Property(e => e.Gerarfinanceiro).HasColumnName("gerarfinanceiro");

                entity.Property(e => e.Idcentrocusto).HasColumnName("idcentrocusto");

                entity.Property(e => e.Idcontabancaria).HasColumnName("idcontabancaria");

                entity.Property(e => e.Idfinalidade).HasColumnName("idfinalidade");

                entity.Property(e => e.Idhistoricofinanceiro).HasColumnName("idhistoricofinanceiro");

                entity.Property(e => e.Idoperacaofiscal).HasColumnName("idoperacaofiscal");

                entity.Property(e => e.Idtipoatendimento).HasColumnName("idtipoatendimento");

                entity.Property(e => e.Idtipodeoperacao).HasColumnName("idtipodeoperacao");

                entity.Property(e => e.Idtransportadora).HasColumnName("idtransportadora");

                entity.Property(e => e.Informacoescomplementares)
                    .HasMaxLength(500)
                    .HasColumnName("informacoescomplementares");

                entity.Property(e => e.Limitecredito).HasColumnName("limitecredito");

                entity.Property(e => e.Modelodocumento).HasColumnName("modelodocumento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .HasColumnName("nome");

                entity.Property(e => e.Permiteestoquenegativo).HasColumnName("permiteestoquenegativo");

                entity.Property(e => e.Serie).HasColumnName("serie");

                entity.Property(e => e.Tipodefrete).HasColumnName("tipodefrete");

                entity.Property(e => e.Tipodemovimento).HasColumnName("tipodemovimento");

                entity.Property(e => e.Tipodemovimento123).HasColumnName("tipodemovimento123");
            });

            modelBuilder.Entity<Tipooperacao>(entity =>
            {
                entity.HasKey(e => e.Idtipooperacao)
                    .HasName("tipooperacao_pkey");

                entity.ToTable("tipooperacao");

                entity.Property(e => e.Idtipooperacao)
                    .ValueGeneratedNever()
                    .HasColumnName("idtipooperacao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Transferenciaestoque>(entity =>
            {
                entity.HasKey(e => e.Idtransferenciaestoque)
                    .HasName("transferenciaestoque_pkey");

                entity.ToTable("transferenciaestoque");

                entity.Property(e => e.Idtransferenciaestoque)
                    .ValueGeneratedNever()
                    .HasColumnName("idtransferenciaestoque");

                entity.Property(e => e.Datatransferencia).HasColumnName("datatransferencia");

                entity.Property(e => e.Observacao)
                    .HasColumnType("ntext")
                    .HasColumnName("observacao");
            });

            modelBuilder.Entity<Transportadora>(entity =>
            {
                entity.HasKey(e => e.Idtransportadora)
                    .HasName("transportadora_pkey");

                entity.ToTable("transportadora");

                entity.Property(e => e.Idtransportadora)
                    .ValueGeneratedNever()
                    .HasColumnName("idtransportadora");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Idendereco).HasColumnName("idendereco");

                entity.Property(e => e.Inscricaoestadual)
                    .HasColumnType("decimal(14, 0)")
                    .HasColumnName("inscricaoestadual");

                entity.Property(e => e.Isento).HasColumnName("isento");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .HasColumnName("nome");

                entity.Property(e => e.Razaosocial)
                    .HasMaxLength(150)
                    .HasColumnName("razaosocial");

                entity.Property(e => e.Tipodocumento).HasColumnName("tipodocumento");
            });

            modelBuilder.Entity<Unidadedemedidum>(entity =>
            {
                entity.HasKey(e => e.Idunidadedemedida)
                    .HasName("unidadedemedida_pkey");

                entity.ToTable("unidadedemedida");

                entity.Property(e => e.Idunidadedemedida)
                    .ValueGeneratedNever()
                    .HasColumnName("idunidadedemedida");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .HasColumnName("descricao");

                entity.Property(e => e.Sigla)
                    .HasMaxLength(4)
                    .HasColumnName("sigla");
            });

            modelBuilder.Entity<Unidadefederativa>(entity =>
            {
                entity.HasKey(e => e.Idunidadefederativa)
                    .HasName("unidadefederativa_pkey");

                entity.ToTable("unidadefederativa");

                entity.Property(e => e.Idunidadefederativa)
                    .ValueGeneratedNever()
                    .HasColumnName("idunidadefederativa");

                entity.Property(e => e.Aliquotainter)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("aliquotainter");

                entity.Property(e => e.Aliquotaintra)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("aliquotaintra");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .HasColumnName("descricao");

                entity.Property(e => e.Fcp)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("fcp");

                entity.Property(e => e.Idpais).HasColumnName("idpais");

                entity.Property(e => e.Sigla)
                    .HasMaxLength(10)
                    .HasColumnName("sigla");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.Unidadefederativas)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("unidadefederativa_idpais_fkey");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("usuario_pkey");

                entity.ToTable("usuario");

                entity.Property(e => e.Idusuario)
                    .ValueGeneratedNever()
                    .HasColumnName("idusuario");

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Descontomaximo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("descontomaximo");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Formadesconto).HasColumnName("formadesconto");

                entity.Property(e => e.Idperfilacesso).HasColumnName("idperfilacesso");

                entity.Property(e => e.Idusuariosupervisor).HasColumnName("idusuariosupervisor");

                entity.Property(e => e.Iscomprador).HasColumnName("iscomprador");

                entity.Property(e => e.Isvendedor).HasColumnName("isvendedor");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .HasColumnName("login");

                entity.Property(e => e.Nome)
                    .HasMaxLength(150)
                    .HasColumnName("nome");

                entity.Property(e => e.Pin)
                    .HasMaxLength(150)
                    .HasColumnName("pin");

                entity.Property(e => e.Root).HasColumnName("root");

                entity.Property(e => e.Senha)
                    .HasMaxLength(150)
                    .HasColumnName("senha");

                entity.Property(e => e.Tipodesconto).HasColumnName("tipodesconto");

                entity.HasOne(d => d.IdperfilacessoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idperfilacesso)
                    .HasConstraintName("usuario_idperfilacesso_fkey");

                entity.HasOne(d => d.IdusuariosupervisorNavigation)
                    .WithMany(p => p.InverseIdusuariosupervisorNavigation)
                    .HasForeignKey(d => d.Idusuariosupervisor)
                    .HasConstraintName("usuario_idusuariosupervisor_fkey");
            });

            modelBuilder.Entity<Valepedagiomdfe>(entity =>
            {
                entity.HasKey(e => e.Idvalepedagiomdfe)
                    .HasName("valepedagiomdfe_pkey");

                entity.ToTable("valepedagiomdfe");

                entity.Property(e => e.Idvalepedagiomdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idvalepedagiomdfe");

                entity.Property(e => e.Cnpjfornecedora)
                    .HasMaxLength(14)
                    .HasColumnName("cnpjfornecedora");

                entity.Property(e => e.Cnpjpagamento)
                    .HasMaxLength(14)
                    .HasColumnName("cnpjpagamento");

                entity.Property(e => e.Cpfpagamento)
                    .HasMaxLength(11)
                    .HasColumnName("cpfpagamento");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.Property(e => e.Numerocompra)
                    .HasMaxLength(20)
                    .HasColumnName("numerocompra");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Valepedagiomdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("valepedagiomdfe_idmdfe_fkey");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.Idveiculo)
                    .HasName("veiculo_pkey");

                entity.ToTable("veiculo");

                entity.Property(e => e.Idveiculo)
                    .ValueGeneratedNever()
                    .HasColumnName("idveiculo");

                entity.Property(e => e.Anofabricacao)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("anofabricacao");

                entity.Property(e => e.Anomodelo)
                    .HasColumnType("decimal(4, 0)")
                    .HasColumnName("anomodelo");

                entity.Property(e => e.Ativo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("ativo");

                entity.Property(e => e.Capacidadeemkg)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("capacidadeemkg");

                entity.Property(e => e.Capacidadeemm3)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("capacidadeemm3");

                entity.Property(e => e.Idmarca).HasColumnName("idmarca");

                entity.Property(e => e.Idunidadefederativa).HasColumnName("idunidadefederativa");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(60)
                    .HasColumnName("modelo");

                entity.Property(e => e.Placa)
                    .HasMaxLength(7)
                    .HasColumnName("placa");

                entity.Property(e => e.Renavam)
                    .HasMaxLength(11)
                    .HasColumnName("renavam");

                entity.Property(e => e.Taraemkg)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("taraemkg");

                entity.Property(e => e.Tipocarroceria)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipocarroceria");

                entity.Property(e => e.Tipopropriedade)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipopropriedade");

                entity.Property(e => e.Tiporodado)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tiporodado");

                entity.Property(e => e.Tipoveiculo)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("tipoveiculo");

                entity.Property(e => e.Veiculoemusomdfe)
                    .HasColumnType("decimal(1, 0)")
                    .HasColumnName("veiculoemusomdfe");

                entity.HasOne(d => d.IdmarcaNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.Idmarca)
                    .HasConstraintName("veiculo_idmarca_fkey");

                entity.HasOne(d => d.IdunidadefederativaNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.Idunidadefederativa)
                    .HasConstraintName("veiculo_idunidadefederativa_fkey");
            });

            modelBuilder.Entity<Veiculotracaomdfe>(entity =>
            {
                entity.HasKey(e => e.Idveiculotracaomdfe)
                    .HasName("veiculotracaomdfe_pkey");

                entity.ToTable("veiculotracaomdfe");

                entity.Property(e => e.Idveiculotracaomdfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idveiculotracaomdfe");

                entity.Property(e => e.Idcondutor).HasColumnName("idcondutor");

                entity.Property(e => e.Idmdfe).HasColumnName("idmdfe");

                entity.Property(e => e.Idproprietarioveiculomdfe).HasColumnName("idproprietarioveiculomdfe");

                entity.Property(e => e.Idveiculo).HasColumnName("idveiculo");

                entity.HasOne(d => d.IdcondutorNavigation)
                    .WithMany(p => p.Veiculotracaomdves)
                    .HasForeignKey(d => d.Idcondutor)
                    .HasConstraintName("veiculotracaomdfe_idcondutor_fkey");

                entity.HasOne(d => d.IdmdfeNavigation)
                    .WithMany(p => p.Veiculotracaomdves)
                    .HasForeignKey(d => d.Idmdfe)
                    .HasConstraintName("veiculotracaomdfe_idmdfe_fkey");

                entity.HasOne(d => d.IdproprietarioveiculomdfeNavigation)
                    .WithMany(p => p.Veiculotracaomdves)
                    .HasForeignKey(d => d.Idproprietarioveiculomdfe)
                    .HasConstraintName("veiculotracaomdfe_idproprietarioveiculomdfe_fkey");

                entity.HasOne(d => d.IdveiculoNavigation)
                    .WithMany(p => p.Veiculotracaomdves)
                    .HasForeignKey(d => d.Idveiculo)
                    .HasConstraintName("veiculotracaomdfe_idveiculo_fkey");
            });

            modelBuilder.Entity<Vendum>(entity =>
            {
                entity.HasKey(e => e.Idvenda)
                    .HasName("venda_pkey");

                entity.ToTable("venda");

                entity.Property(e => e.Idvenda)
                    .ValueGeneratedNever()
                    .HasColumnName("idvenda");

                entity.Property(e => e.Chaveerp)
                    .HasMaxLength(100)
                    .HasColumnName("chaveerp");

                entity.Property(e => e.Datacadastro).HasColumnName("datacadastro");

                entity.Property(e => e.Datafaturamento)
                    .HasColumnType("date")
                    .HasColumnName("datafaturamento");

                entity.Property(e => e.Dinheiro)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("dinheiro");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Idcomanda).HasColumnName("idcomanda");

                entity.Property(e => e.Idcomandautilizada).HasColumnName("idcomandautilizada");

                entity.Property(e => e.Idcomprador).HasColumnName("idcomprador");

                entity.Property(e => e.Idfluxocaixa).HasColumnName("idfluxocaixa");

                entity.Property(e => e.Idformapagamento).HasColumnName("idformapagamento");

                entity.Property(e => e.Idrespostafiscal)
                    .HasMaxLength(150)
                    .HasColumnName("idrespostafiscal");

                entity.Property(e => e.Idromaneio).HasColumnName("idromaneio");

                entity.Property(e => e.Idtipodeoperacao).HasColumnName("idtipodeoperacao");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Idvendedor).HasColumnName("idvendedor");

                entity.Property(e => e.Motivodecancelamento)
                    .HasColumnType("ntext")
                    .HasColumnName("motivodecancelamento");

                entity.Property(e => e.Obra)
                    .HasColumnType("ntext")
                    .HasColumnName("obra");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(1000)
                    .HasColumnName("observacao");

                entity.Property(e => e.Pagamentodescricao)
                    .HasMaxLength(1000)
                    .HasColumnName("pagamentodescricao");

                entity.Property(e => e.Pagamentosdescricao)
                    .HasMaxLength(1000)
                    .HasColumnName("pagamentosdescricao");

                entity.Property(e => e.Quantidadeitens)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("quantidadeitens");

                entity.Property(e => e.Romaneio).HasColumnName("romaneio");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tipodevenda).HasColumnName("tipodevenda");

                entity.Property(e => e.Troco)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("troco");

                entity.Property(e => e.Valoravistaproposto)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("valoravistaproposto");

                entity.Property(e => e.Valortotal)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("valortotal");

                entity.HasOne(d => d.IdcomandaNavigation)
                    .WithMany(p => p.VendumIdcomandaNavigations)
                    .HasForeignKey(d => d.Idcomanda)
                    .HasConstraintName("venda_idcomanda_fkey");

                entity.HasOne(d => d.IdcomandautilizadaNavigation)
                    .WithMany(p => p.VendumIdcomandautilizadaNavigations)
                    .HasForeignKey(d => d.Idcomandautilizada)
                    .HasConstraintName("venda_idcomandautilizada_fkey");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Venda)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("venda_idusuario_fkey");
            });

            modelBuilder.Entity<Volumenfe>(entity =>
            {
                entity.HasKey(e => e.Idvolumenfe)
                    .HasName("volumenfe_pkey");

                entity.ToTable("volumenfe");

                entity.Property(e => e.Idvolumenfe)
                    .ValueGeneratedNever()
                    .HasColumnName("idvolumenfe");

                entity.Property(e => e.Especie)
                    .HasMaxLength(150)
                    .HasColumnName("especie");

                entity.Property(e => e.Idnfe).HasColumnName("idnfe");

                entity.Property(e => e.Marca)
                    .HasMaxLength(150)
                    .HasColumnName("marca");

                entity.Property(e => e.Numero)
                    .HasMaxLength(150)
                    .HasColumnName("numero");

                entity.Property(e => e.Pesobruto)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesobruto");

                entity.Property(e => e.Pesoliquido)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoliquido");

                entity.Property(e => e.Volume)
                    .HasMaxLength(200)
                    .HasColumnName("volume");

                entity.HasOne(d => d.IdnfeNavigation)
                    .WithMany(p => p.Volumenves)
                    .HasForeignKey(d => d.Idnfe)
                    .HasConstraintName("volumenfe_idnfe_fkey");
            });

            modelBuilder.HasSequence("IDBAIXARECEBIMENTO");

            modelBuilder.HasSequence("IDCONFERENCIACAIXAPDV");

            modelBuilder.HasSequence("IDCONTARECEBER");

            modelBuilder.HasSequence("IDDUPLICATANFCE");

            modelBuilder.HasSequence("IDFLUXOCAIXA");

            modelBuilder.HasSequence("IDINVENTARIO");

            modelBuilder.HasSequence("IDITEMINVENTARIO");

            modelBuilder.HasSequence("IDITEMVENDA");

            modelBuilder.HasSequence("IDMAQUINA").StartsAt(12);

            modelBuilder.HasSequence("IDMOVIMENTOESTOQUE");

            modelBuilder.HasSequence("IDSUPRIMENTOCAIXA");

            modelBuilder.HasSequence("IDTIPODEOPERACAO").StartsAt(54);

            modelBuilder.HasSequence("IDVENDA");

            modelBuilder.HasSequence("PDV_99").StartsAt(54);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
