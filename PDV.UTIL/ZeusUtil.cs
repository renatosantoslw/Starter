using ConrollerLicença;
using DFe.Classes.Flags;
using NFe.Classes.Informacoes.Pagamento;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Estoque.PedidoDeCompra;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace PDV.UTIL
{
    public partial class ZeusUtil
    {
        public static double Arredondar(double Valor, int Dec)
        {
            double Valor1 = 0;
            double Numero1 = 0;
            double Numero2 = 0;
            double Numero3 = 0;

            Valor1 = Math.Exp(Math.Log(10) * (Dec + 1));
            Valor1 = Math.Round(Valor1, 6);
            Numero1 = Convert.ToDouble(Valor * Valor1);
            Numero2 = (Numero1 / 10);
            Numero3 = Math.Round(Numero2);
            return (Numero3 / (Math.Exp(Math.Log(10) * Dec)));
        }

        public static string SomenteNumeros(string Value)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(Value, "");
            return resultString;
        }

        public static object GetValueFieldDataRowView(DataRowView DataRow, string FieldName)
        {
            try
            {
                return DataRow[FieldName];
            }
            catch (Exception)
            {
                return null;

            }

        }

        public static string EnviarEmail(Email email, string NomeUsuario)
        {
            try
            {
                if (string.IsNullOrEmpty(email.Mensagem))
                    throw new Exception("O corpo da mensagem não foi informado!");

                if (string.IsNullOrEmpty(email.UsarSSL))
                    email.UsarSSL = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_SSL).Valor);

                if (string.IsNullOrEmpty(email.UsarTLS))
                    email.UsarTLS = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_TLS).Valor);

                if (string.IsNullOrEmpty(email.ServidorEmail))
                    email.ServidorEmail = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_SMTP).Valor);

                if (string.IsNullOrEmpty(email.Porta))
                    email.Porta = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_SMTP_PORT).Valor);

                if (string.IsNullOrEmpty(email.Usuario))
                    email.Usuario = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_USUARIO).Valor);

                if (string.IsNullOrEmpty(email.Senha))
                    email.Senha = DAO.DB.Utils.Criptografia.DecodificaSenha(Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_SENHA).Valor));

                if (string.IsNullOrEmpty(email.EmailRemetente))
                {
                    email.EmailRemetente = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_REMETENTE).Valor);
                    if (string.IsNullOrEmpty(email.EmailRemetente))
                        throw new Exception("Não há configuração de Remetente nas configurações do sistema.");
                }

                if (string.IsNullOrEmpty(email.NomeRemetente))
                    email.NomeRemetente = Encoding.UTF8.GetString(FuncoesConfiguracao.GetConfiguracao(Email.EMAIL_NOME_REMETENTE).Valor);

                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential basicCredential = new NetworkCredential(email.Usuario, email.Senha);

                smtpClient.EnableSsl = !email.UsarSSL.Equals("0");
                smtpClient.Host = email.ServidorEmail;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                smtpClient.Port = Convert.ToInt32(email.Porta);

                smtpClient.Timeout = string.IsNullOrEmpty(email.TimeOut) ? 100000 : Convert.ToInt32(email.TimeOut);

                MailAddress fromAddress = new MailAddress(email.EmailRemetente, email.NomeRemetente);
                MailMessage vMessage = new MailMessage();
                vMessage.From = fromAddress;
                vMessage.IsBodyHtml = true;
                vMessage.Subject = email.Assunto;
                foreach (string destinatario in email.EmailDestinatario)
                {
                    if (string.IsNullOrEmpty(destinatario.Trim()))
                        continue;
                    vMessage.To.Add(destinatario);
                }

                if (vMessage.To.Count == 0)
                    throw new Exception("Não foi informado um Destinatário para a mensagem!");

                string cor = "#f04e41";

                string fonte = "Arial, sans-serif !important";

                string style = string.Format(@"<style>
                            * {{ font-family:{0}; }} 
                            .box {{ width:640px; margin:0 auto; border:1px solid #ccc; padding:15px 15px 0 15px; display:block; }} 
                            .box h3 {{ margin:0; font-weight:bold; font-size:14px; }} 
                            .content {{ margin-bottom:50px; }} 
                            .content h4 {{ color:{1}; font-size:14px; font-weight:bold; }} 
                            .content p {{ color:#222; font-size:12px; }} 
                            .content label {{ font-size:11px; }} 
                            .content strong {{ color:{1}; }} 
                            .content small {{ font-size:10px; }} 
                            .footer {{ width:105%; margin-left:-15px; margin-right:-15px; margin-bottom:-15px; background-color:{1}; }} 
                            .footer p {{ color:#fff; font-size:12px; text-align:center; padding:5px; }} 
                        </style>", fonte, cor);

                email.Mensagem = email.Mensagem.Replace("\n", "<br />");

                string body = string.Format(@"{0}
                                              <div class='box'>
                                                  <div class='header'><h3>Data: {1}</h3></div>
                                                  <div class='header'><h3>Remetente: {3}</h3></div>
                                                  <div class='content'>{2}</div>
                                                  <div class='footer'><p>Esta é uma mensagem automática e não precisa ser respondida.</p></div>
                                              </div>",
                                            style,
                                            DateTime.Now.ToString(),
                                            email.Mensagem, NomeUsuario);

                vMessage.Body = body;

                /*********
                 * Anexos
                 *********/
                if (email.Anexos != null)
                    for (int i = 0; i < email.Anexos.Count; i++)
                    {
                        Stream stream = new MemoryStream(email.Anexos[i]);
                        stream.Position = 0;
                        if (i == 0)
                        {
                            vMessage.Attachments.Add(new Attachment(stream, email.Mensagem.Equals("NFCe") ? "NFCe.zip" : email.Mensagem.Equals("NFe") ? "NFe.zip" : "notafiscal.xml", MediaTypeNames.Application.Octet));
                        }
                        else
                        {
                            vMessage.Attachments.Add(new Attachment(stream, "danfe.pdf", MediaTypeNames.Application.Octet));
                        }
                    }

                smtpClient.Send(vMessage);
                return "OK";
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                if (ex.InnerException != null)
                    erro += " " + ex.InnerException.Message;
                erro += ".";

                return "ERRO|" + erro;
            }
        }

        public static DataTable GetChanges(DataTable dt, TipoOperacao to)
        {
            if (dt == null)
                return null;

            switch (to)
            {
                case TipoOperacao.INSERT:
                    return dt.GetChanges(DataRowState.Added);
                case TipoOperacao.UPDATE:
                    return dt.GetChanges(DataRowState.Modified);
                case TipoOperacao.DELETE:
                    using (DataTable dtDel = dt.GetChanges(DataRowState.Deleted))
                    {
                        if (dtDel == null)
                            return null;
                        dtDel.RejectChanges();
                        return dtDel;
                    }
                default:
                    return null;
            }
        }

        public static decimal GetProximoCodigo(string Tabela, string Campo)
        {
            return FuncoesProduto.GetProximoCodigo(Tabela, Campo) + 1;
        }

        public static void LembrarSenha(string Usuario, string Senha)
        {
            if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_LOGIN_USUARIO_LEMBRAR, Encoding.Default.GetBytes(Usuario)))
                throw new Exception("Não foi possível salvar a configuração de lembrar Login/Senha.");

            if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_LOGIN_SENHA_LEMBRAR, Encoding.Default.GetBytes(Senha)))
                throw new Exception("Não foi possível salvar a configuração de lembrar Login/Senha.");
        }

        public static bool GerarFinanceiro(decimal IDMovimentoFiscal, ModeloDocumento ModelDoc, Usuario usuario)
        {
            try
            {
                switch (ModelDoc)
                {
                    case ModeloDocumento.NFe:
                        return GerarFinanceiroNFe(IDMovimentoFiscal, usuario);
                    case ModeloDocumento.NFCe:
                        return GerarFinanceiroNFCe(IDMovimentoFiscal, usuario);
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private static bool GerarFinanceiroNFe(decimal IDMovimentoFiscal, Usuario usuario)
        {

            MovimentoFiscal Movimento = FuncoesMovimentoFiscal.GetMovimento(IDMovimentoFiscal);
            DAO.Entidades.NFe.NFe _NFe = FuncoesNFe.GetNFe(Movimento.IDNFe.Value);

            DataTable DUPLICATAS = FuncoesDuplicataNFe.GetDuplicatas(Movimento.IDNFe.Value);
            Venda venda = FuncoesVenda.GetVenda((decimal)Movimento.IDVenda);
            TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(venda.IDTipoDeOperacao);

            /* Geração do Financeiro... */
            foreach (DataRow dr in DUPLICATAS.Rows)
            {
                DuplicataNFe Duplicata = EntityUtil<DuplicataNFe>.ParseDataRow(dr);
                decimal IDContaReceber = Sequence.GetNextID("CONTARECEBER", "IDCONTARECEBER");
                FormaDePagamento FormaPag = FuncoesFormaDePagamento.GetFormaDePagamento(Convert.ToDecimal(dr["idformadepagamento"]));
                if (!FuncoesContaReceber.Salvar(new ContaReceber()
                {
                    IDContaReceber = IDContaReceber,
                    Emissao = _NFe.Emissao,
                    Fluxo = _NFe.Emissao,
                    IDCliente = _NFe.IDCliente,
                    IDContaBancaria = IsFormaPagamentoBoleto(FormaPag.Codigo.ToString()) ? (decimal?)tipoDeOperacao.IDContaBancaria : null,
                    IDHistoricoFinanceiro = tipoDeOperacao.IDHistoricoFinanceiro,
                    IDCentroCusto = tipoDeOperacao.IdCentroCusto,
                    Juros = 0,
                    Multa = 0,
                    Origem = "NFE",
                    Parcela = Convert.ToDecimal(Duplicata.NumeroDocumento),
                    Saldo = IsTituloBaixado(FormaPag.Codigo.ToString()) && FormaPag.Transacao == FormaDePagamento.AVista ? 0 : Duplicata.Valor,
                    Desconto = 0,
                    Valor = Duplicata.Valor,
                    ValorTotal = Duplicata.Valor,
                    ComplmHisFin = "NFE" + IDMovimentoFiscal,
                    Titulo = IDContaReceber.ToString(),
                    Situacao = IsTituloBaixado(FormaPag.Codigo.ToString()) && FormaPag.Transacao == FormaDePagamento.AVista ? 3 : 1,
                    IDFormaDePagamento = FormaPag.IDFormaDePagamento,
                    Vencimento = Duplicata.DataVencimento,
                    IDMovimentoFiscal = IDMovimentoFiscal,
                    IDUsuario = usuario.IDUsuario
                }, TipoOperacao.INSERT))
                    throw new Exception("Não foi possível lançar título a receber.");

                /* Salvar as Baixas do Conta a Receber */
                if (IsTituloBaixado(FormaPag.Codigo.ToString()) && FormaPag.Transacao == FormaDePagamento.AVista)
                {
                    decimal IDBaixaRecebimento = Sequence.GetNextID("BAIXARECEBIMENTO", "IDBAIXARECEBIMENTO");
                    if (!FuncoesBaixaRecebimento.Salvar(new BaixaRecebimento()
                    {
                        IDBaixaRecebimento = IDBaixaRecebimento,
                        Baixa = Duplicata.DataVencimento,
                        ComplmHisFin = "NFE" + IDMovimentoFiscal,
                        Desconto = 0,
                        Juros = 0,
                        Multa = 0,
                        Valor = Duplicata.Valor,
                        IDHistoricoFinanceiro = tipoDeOperacao.IDHistoricoFinanceiro,
                        IDFormaDePagamento = FormaPag.IDFormaDePagamento,
                        IDContaBancaria = tipoDeOperacao.IDContaBancaria,
                        IDContaReceber = IDContaReceber,
                        DataConciliacao = null
                    }, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível lançar as baixas do título.");

                    if (!FuncoesMovimentoBancario.Salvar(new MovimentoBancario()
                    {
                        IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO"),
                        IDContaBancaria = tipoDeOperacao.IDContaBancaria,
                        IDNatureza = null,
                        Historico = FuncoesHistoricoFinanceiro.GetHistoricoFinanceiro(tipoDeOperacao.IDHistoricoFinanceiro).Descricao,
                        Conciliacao = null,
                        Sequencia = Convert.ToDecimal(Duplicata.NumeroDocumento),
                        DataMovimento = _NFe.Emissao,
                        Documento = $"{IDContaReceber}_{IDBaixaRecebimento}T",
                        Tipo = 1,
                        Valor = Duplicata.Valor,
                    }, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Movimento Bancário.");
                }
            }
            return true;
        }

        private static bool GerarFinanceiroNFCe(decimal IDMovimentoFiscal, Usuario usuario)
        {


            MovimentoFiscal Movimento = FuncoesMovimentoFiscal.GetMovimento(IDMovimentoFiscal);
            DAO.Entidades.PDV.Venda _Venda = FuncoesVenda.GetVenda(Movimento.IDVenda.Value);
            List<DuplicataNFCe> PAGAMENTOS = FuncoesItemDuplicataNFCe.GetPagamentosPorVenda(Movimento.IDVenda.Value);
            ContaCobranca ContaCobranca = null;// FuncoesContaCobranca.GetContaCobranca(IDContaCobranca.Value);
            TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(_Venda.IDTipoDeOperacao);

            /* Geração do Financeiro... */
            decimal NumeroParcela = 0;
            foreach (DuplicataNFCe ItemPagamento in PAGAMENTOS)
            {
                NumeroParcela++;
                decimal IDContaReceber = Sequence.GetNextID("CONTARECEBER", "IDCONTARECEBER");
                FormaDePagamento FormaPag = FuncoesFormaDePagamento.GetFormaDePagamento(ItemPagamento.IDFormaDePagamento);

                if (!FuncoesContaReceber.Salvar(new ContaReceber()
                {
                    IDContaReceber = IDContaReceber,
                    Emissao = _Venda.DataCadastro,
                    Fluxo = _Venda.DataCadastro,
                    IDCliente = _Venda.IDCliente,
                    IDContaBancaria = IsFormaPagamentoBoleto(FormaPag.Codigo.ToString()) ? (decimal?)ContaCobranca.IDContaBancaria : null,
                    IDHistoricoFinanceiro = tipoDeOperacao.IDHistoricoFinanceiro,
                    IDCentroCusto = tipoDeOperacao.IdCentroCusto,
                    Juros = 0,
                    Multa = 0,
                    Origem = "NFCE",
                    Parcela = NumeroParcela,
                    Saldo = IsTituloBaixado(FormaPag.Codigo.ToString()) && FormaPag.Transacao == FormaDePagamento.AVista ? 0 : ItemPagamento.Valor,
                    Desconto = 0,
                    Valor = ItemPagamento.Valor,
                    ValorTotal = ItemPagamento.Valor,
                    ComplmHisFin = "NFCE" + IDMovimentoFiscal,
                    Titulo = IDContaReceber.ToString(),
                    Situacao = IsTituloBaixado(FormaPag.Codigo.ToString()) && FormaPag.Transacao == FormaDePagamento.AVista ? 3 : 1,
                    IDFormaDePagamento = ItemPagamento.IDFormaDePagamento,
                    Vencimento = IsTituloBaixado(FormaPag.Codigo.ToString()) && FormaPag.Transacao == FormaDePagamento.AVista ? _Venda.DataCadastro : ItemPagamento.DataVencimento,
                    IDMovimentoFiscal = IDMovimentoFiscal,
                    IDUsuario = usuario.IDUsuario
                }, TipoOperacao.INSERT))
                    throw new Exception("Não foi possível lançar título a receber.");

                /* Salvar as Baixas do Conta a Receber */
                if (IsTituloBaixado(FormaPag.Codigo.ToString()) && FormaPag.Transacao == FormaDePagamento.AVista)
                {
                    decimal IDBaixaRecebimento = Sequence.GetNextID("BAIXARECEBIMENTO", "IDBAIXARECEBIMENTO");
                    if (!FuncoesBaixaRecebimento.Salvar(new BaixaRecebimento()
                    {
                        IDBaixaRecebimento = IDBaixaRecebimento,
                        Baixa = _Venda.DataCadastro,
                        ComplmHisFin = "NFCE" + IDMovimentoFiscal,
                        Desconto = 0,
                        Juros = 0,
                        Multa = 0,
                        Valor = ItemPagamento.Valor,
                        IDHistoricoFinanceiro = tipoDeOperacao.IDHistoricoFinanceiro,
                        IDFormaDePagamento = ItemPagamento.IDFormaDePagamento,
                        IDContaBancaria = tipoDeOperacao.IDContaBancaria,
                        IDContaReceber = IDContaReceber,
                        DataConciliacao = null
                    }, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível lançar as baixas do título.");

                    if (!FuncoesMovimentoBancario.Salvar(new MovimentoBancario()
                    {
                        IDMovimentoBancario = Sequence.GetNextID("MOVIMENTOBANCARIO", "IDMOVIMENTOBANCARIO"),
                        IDContaBancaria = tipoDeOperacao.IDContaBancaria,
                        IDNatureza = null,
                        Historico = FuncoesHistoricoFinanceiro.GetHistoricoFinanceiro(tipoDeOperacao.IDHistoricoFinanceiro).Descricao,
                        Conciliacao = null,
                        Sequencia = NumeroParcela,
                        DataMovimento = _Venda.DataCadastro,
                        Documento = $"{IDContaReceber}_{IDBaixaRecebimento}T",
                        Tipo = 1,
                        Valor = ItemPagamento.Valor,
                    }, TipoOperacao.INSERT))
                        throw new Exception("Não foi possível salvar o Movimento Bancário.");

                }
            }
            return true;
        }

        public static bool GerarFinanceiroNFeEntrada(PedidoCompra compra, DataTable Duplicatas, decimal IDFornecedor, decimal IDNFeEntrada)
        {
            /* Geração do Financeiro... */
            foreach (DataRow dr in Duplicatas.Rows)
            {
                DuplicataNFe Duplicata = EntityUtil<DuplicataNFe>.ParseDataRow(dr);
                decimal IDContaPagar = Sequence.GetNextID("CONTAPAGAR", "IDCONTAPAGAR");
                TipoDeOperacao tipoDeOperacao = FuncoesTipoDeOperacao.GetTipoDeOperacao(compra.IDTipoDeOperacao);

                if (!FuncoesContaPagar.Salvar(new ContaPagar()
                {
                    IDContaPagar = IDContaPagar,
                    Emissao = DateTime.Now,
                    Fluxo = DateTime.Now,
                    IDFornecedor = IDFornecedor,
                    IDContaBancaria = tipoDeOperacao.IDContaBancaria,
                    IDHistoricoFinanceiro = tipoDeOperacao.IDHistoricoFinanceiro,
                    IDCentroCusto = tipoDeOperacao.IdCentroCusto,
                    Juros = 0,
                    Multa = 0,
                    Origem = "IMPORTACAO",
                    Parcela = Convert.ToDecimal(Duplicata.NumeroDocumento),
                    Saldo = Duplicata.Valor,
                    Desconto = 0,
                    Valor = Duplicata.Valor,
                    ValorTotal = Duplicata.Valor,
                    ComplmHisFin = "IMPORTACAO" + IDNFeEntrada,
                    Titulo = IDContaPagar.ToString(),
                    Situacao = 1,
                    IDFormaDePagamento = Convert.ToDecimal(dr["IDFORMADEPAGAMENTO"]),
                    Vencimento = Duplicata.DataVencimento,
                    IDNFeEntrada = IDNFeEntrada
                }, TipoOperacao.INSERT))
                    throw new Exception("Não foi possível lançar título a pagar.");
            }
            return true;
        }

        private static bool IsTituloBaixado(string CodigoFormaDePagamento)
        {
            return (FormaPagamento)Enum.Parse(typeof(FormaPagamento), CodigoFormaDePagamento) == FormaPagamento.fpDinheiro
                || (FormaPagamento)Enum.Parse(typeof(FormaPagamento), CodigoFormaDePagamento) == FormaPagamento.fpCartaoDebito;
        }

        private static bool IsFormaPagamentoBoleto(string CodigoFormaDePagamento)
        {
            return (FormaPagamento)Enum.Parse(typeof(FormaPagamento), CodigoFormaDePagamento) == FormaPagamento.fpOutro;
        }



    }
}