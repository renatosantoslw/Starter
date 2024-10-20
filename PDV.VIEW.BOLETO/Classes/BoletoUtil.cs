using Boleto2Net;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.BOLETO.Boletos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.BOLETO.Classes
{
    public class BoletoUtil
    {
        public static byte[] GeraLayoutPDF(List<BoletoBancario> Boletos)
        {
            var _Html = new StringBuilder();
            foreach (BoletoBancario _BoletoBancario in Boletos)
            {
                using (BoletoBancario ImprimeBoleto = new BoletoBancario
                {
                    Boleto = _BoletoBancario.Boleto,
                    OcultarInstrucoes = false,
                    MostrarComprovanteEntrega = true,
                    MostrarEnderecoCedente = true
                })
                {
                    _Html.Append("<div style=\"page-break-after: always;\">");
                    _Html.Append(ImprimeBoleto.MontaHtml());
                    _Html.Append("<div><p style=\"text-align:right;font-size: 12px;font-family: 'Arial';\"><b>Desenvolvido Por</b>: DUE ERP -  Software</p></div>");
                    _Html.Append("</div>");
                }
            }
            return new NReco.PdfGenerator.HtmlToPdfConverter().GeneratePdf(_Html.ToString());
        }

        public static List<BoletoBancario> GerarBoleto(List<ContaReceber> _Titulos, ContaCobranca _Conta)
        {
            switch (ToEnum(FuncoesBanco.GetBanco(_Conta.IDContaBancaria).CodBacen.ToString(), true, Bancos.BancoDoBrasil))
            {
                case Bancos.BancoDoBrasil:
                    return BoletoBB.GerarBoletoBB(_Titulos, _Conta);
                case Bancos.Bradesco:
                    return BoletoBradesco.GerarBoletoBradesco(_Titulos, _Conta);
                case Bancos.Caixa:
                    return BoletoCaixa.GerarBoletoCaixa(_Titulos, _Conta);
                case Bancos.Itau:
                    return BoletoItau.GerarBoletoItau(_Titulos, _Conta);
                default:

                    return null;
            }
        }

        public static List<BoletoBancario> ImprimirGerado(List<ContaRecCobranca> _ContasRecebimento, ContaCobranca _Conta)
        {
            switch (ToEnum(FuncoesBanco.GetBanco(_Conta.IDContaBancaria).CodBacen.ToString(), true, Bancos.BancoDoBrasil))
            {
                case Bancos.BancoDoBrasil:
                    return BoletoBB.Imprimir(_ContasRecebimento, _Conta);
                case Bancos.Bradesco:
                    return BoletoBradesco.Imprimir(_ContasRecebimento, _Conta);
                case Bancos.Caixa:
                    return BoletoCaixa.Imprimir(_ContasRecebimento, _Conta);
                case Bancos.Itau:
                    return BoletoItau.Imprimir(_ContasRecebimento, _Conta);
                default:
                    return null;
            }
        }

        public static Cedente GetCedente(ContaCobranca _ContaCobranca, DAO.Entidades.Financeiro.ContaBancaria _Conta, DAO.Entidades.Financeiro.Banco _Banco)
        {
            Emitente Emit = FuncoesEmitente.GetEmitente();
            DAO.Entidades.Endereco EndEmitente = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            UnidadeFederativa UF = FuncoesUF.GetUnidadeFederativa(EndEmitente.IDUnidadeFederativa.Value);
            Municipio Mun = FuncoesMunicipio.GetMunicipio(EndEmitente.IDMunicipio.Value);

            return new Cedente()
            {
                MostrarCNPJnoBoleto = true,
                Nome = Emit.RazaoSocial,
                CPFCNPJ = Emit.CNPJ,
                Endereco = new Boleto2Net.Endereco()
                {
                    LogradouroEndereco = EndEmitente.Logradouro,
                    Bairro = EndEmitente.Bairro,
                    CEP = EndEmitente.Cep,
                    Cidade = Mun.Descricao,
                    LogradouroNumero = EndEmitente.Numero.ToString(),
                    UF = UF.Sigla
                },
                Codigo = _ContaCobranca.Cedente,
                //CodigoTransmissao = string.Empty,
                ContaBancaria = new Boleto2Net.ContaBancaria()
                {
                    Agencia = _Conta.Agencia,
                    DigitoAgencia = _Conta.DigitoAgencia,
                    Conta = _Conta.Conta,
                    DigitoConta = _Conta.Digito,
                    OperacaoConta = _Conta.Operacao,
                    LocalPagamento = _ContaCobranca.LocalPagto,
                    TipoDocumento = TipoDocumento.Tradicional,
                    TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples,
                    TipoFormaCadastramento = _ContaCobranca.Registro == 1 ? TipoFormaCadastramento.ComRegistro : TipoFormaCadastramento.SemRegistro,
                    CodigoBancoCorrespondente = Convert.ToInt32(_Banco.CodBacen),
                    TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa,
                    CarteiraPadrao = _ContaCobranca.Carteira,
                    VariacaoCarteiraPadrao = _ContaCobranca.VariacaoCarteira
                }
            };
        }

        public static Sacado GetSacado(decimal _IDCliente)
        {
            Cliente _Cliente = FuncoesCliente.GetCliente(_IDCliente);
            DAO.Entidades.Endereco EndEmitente = null;
            UnidadeFederativa UF = null;
            Municipio Mun = null;
            if (_Cliente.IDEndereco.HasValue)
            {
                EndEmitente = FuncoesEndereco.GetEndereco(_Cliente.IDEndereco.Value);
                UF = FuncoesUF.GetUnidadeFederativa(EndEmitente.IDUnidadeFederativa.Value);
                Mun = FuncoesMunicipio.GetMunicipio(EndEmitente.IDMunicipio.Value);
            }

            return new Sacado()
            {
                CPFCNPJ = _Cliente._CPF_CNPJ,
                Nome = _Cliente._DESCRICAO,
                Endereco = new Boleto2Net.Endereco()
                {
                    LogradouroEndereco = EndEmitente.Logradouro,
                    Bairro = EndEmitente.Bairro,
                    CEP = EndEmitente.Cep,
                    Cidade = Mun.Descricao,
                    LogradouroNumero = EndEmitente.Numero.ToString(),
                    UF = UF.Sigla
                }
            };
        }

        public static T ToEnum<T>(string value, bool ignoreCase, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            if (Enum.TryParse(value, ignoreCase, out T result))
                return result;

            return defaultValue;
        }

        public static void ImportarRemessa(ContaCobranca Conta)
        {
            try
            {
                DAO.Entidades.Financeiro.Banco _Banco = FuncoesBanco.GetBanco(Conta.IDContaBancaria);
                IBanco _BancoBoleto = Boleto2Net.Banco.Instancia(Convert.ToInt32(_Banco.CodBacen));
                _BancoBoleto.Cedente = GetCedente(Conta, FuncoesContaBancaria.GetContaBancaria(Conta.IDContaBancaria), _Banco);

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = "";
                openFileDialog.Title = "Selecione um arquivo de retorno";
                openFileDialog.Filter = "Arquivos de Retorno (*.ret;*.crt)|*.ret;*.crt|Todos Arquivos (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ArquivoRetorno _ArquivoRetorno = new ArquivoRetorno(_BancoBoleto, Conta.CNAB == 0 ? TipoArquivo.CNAB240 : TipoArquivo.CNAB400);
                    _ArquivoRetorno.LerArquivoRetorno(openFileDialog.OpenFile());

                    foreach (Boleto Bol in _ArquivoRetorno.Boletos)
                    {
                        /* Lançando a Baixa. */

                    }
                }
                else
                    throw new Exception("ARQUIVONAOIMPORTADO");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GerarArquivoRemessa(List<decimal> IDSContaRecCobranca, ContaCobranca ContaCob)
        {
            DAO.Entidades.Financeiro.Banco _Banco = FuncoesBanco.GetBanco(ContaCob.IDContaBancaria);
            ContaCob = FuncoesContaCobranca.GetContaCobranca(ContaCob.IDContaCobranca);

            ArquivoRemessa ArqRemessa = new ArquivoRemessa(Boleto2Net.Banco.Instancia(Convert.ToInt32(_Banco.CodBacen)), ContaCob.CNAB == 0 ? TipoArquivo.CNAB240 : TipoArquivo.CNAB400, Convert.ToInt32(ContaCob.NumeroRemessa));
            ArqRemessa.Banco.Cedente = GetCedente(ContaCob, FuncoesContaBancaria.GetContaBancaria(ContaCob.IDContaBancaria), _Banco);

            List<ContaRecCobranca> ContasRecCobranca = new List<ContaRecCobranca>();
            foreach (decimal IDContaRecCobranca in IDSContaRecCobranca)
            {
                ContasRecCobranca.Add(FuncoesContaRecCobranca.GetContaRecCobranca(IDContaRecCobranca));
                if (!FuncoesContaRecCobranca.UpdateStatus(IDContaRecCobranca, (int)StatusDuplicata.REMESSA, null))
                    throw new Exception("Não foi possível gerar a remessa.");
            }

            Boleto2Net.Boletos _Boletos = new Boleto2Net.Boletos();
            foreach (BoletoBancario Bc in ImprimirGerado(ContasRecCobranca, ContaCob))
                _Boletos.Add(Bc.Boleto);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Remessa(.rem)|*.rem";
            saveFileDialog.Title = "Salvar Arquivo de Remessa";
            saveFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                ArqRemessa.GerarArquivoRemessa(_Boletos, saveFileDialog.OpenFile());
            else
                throw new Exception("NAOSELECIONOUARQUIVO");
        }
    }
}
