using Boleto2Net;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.VIEW.BOLETO.Classes;
using System;
using System.Collections.Generic;

namespace PDV.VIEW.BOLETO.Boletos
{
    public class BoletoBradesco
    {
        public static List<BoletoBancario> GerarBoletoBradesco(List<ContaReceber> _Titulos, ContaCobranca _Conta)
        {
            BoletoBancario _BoletoBancario = null;
            List<BoletoBancario> _Boletos = new List<BoletoBancario>();
            foreach (ContaReceber Titulo in _Titulos)
            {
                if (!Titulo.IDCliente.HasValue)
                    continue;

                DAO.Entidades.Financeiro.ContaBancaria _ContaBancaria = FuncoesContaBancaria.GetContaBancaria(_Conta.IDContaBancaria);
                DAO.Entidades.Financeiro.Banco _Banco = FuncoesBanco.GetBanco(_ContaBancaria.IDContaBancaria);

                decimal NossoNumero = FuncoesContaCobranca.GetNossoNumero(_Conta.IDContaCobranca);

                _BoletoBancario = new BoletoBancario
                {
                    MostrarCodigoCarteira = true,
                    MostrarEnderecoCedente = true
                };

                IBanco _BancoBoleto = Boleto2Net.Banco.Instancia(Convert.ToInt32(_Banco.CodBacen));
                _BancoBoleto.Cedente = BoletoUtil.GetCedente(_Conta, _ContaBancaria, _Banco);

                Boleto _Boleto = new Boleto(_BancoBoleto);
                _Boleto.Banco.Cedente = BoletoUtil.GetCedente(_Conta, _ContaBancaria, _Banco);
                _Boleto.Sacado = BoletoUtil.GetSacado(Titulo.IDCliente.Value);
                _Boleto.NumeroDocumento = $"BRADESCO{NossoNumero}_{Titulo.IDContaReceber}";
                _Boleto.Aceite = _Conta.Aceite == 1 ? "S" : "N";
                _Boleto.Carteira = _Conta.Carteira;
                _Boleto.VariacaoCarteira = _Conta.VariacaoCarteira;
                _Boleto.DataEmissao = DateTime.Now;
                _Boleto.DataProcessamento = DateTime.Now;
                _Boleto.DataVencimento = Titulo.Vencimento;
                _Boleto.EspecieDocumento = BoletoUtil.ToEnum(_Conta.EspecieDoc, true, TipoEspecieDocumento.OU);
                _Boleto.EspecieMoeda = _Conta.Especie;
                _Boleto.ValorTitulo = Titulo.Saldo + _Conta.Taxa.Value;
                _Boleto.ValorTarifas = _Conta.Taxa.Value;
                _Boleto.NossoNumero = NossoNumero.ToString().PadLeft(11, '0');
                _Boleto.TipoCarteira = TipoCarteira.CarteiraCobrancaSimples;
                _Boleto.ValorMulta = _Conta.ValorMulta;
                _Boleto.PercentualJurosDia = _Conta.PercentualJuros;
                _Boleto.MensagemInstrucoesCaixa = _Conta.Instrucoes;
                _Boleto.NumeroControleParticipante = "CHAVEPRIMARIA=" + Titulo.IDContaReceber;
                _Boleto.ValidarDados();
                _BoletoBancario.Boleto = _Boleto;
                _Boletos.Add(_BoletoBancario);

                if (!FuncoesContaCobranca.UpdateNossoNumero(_Conta.IDContaCobranca, NossoNumero + 1))
                    throw new Exception("Não foi possível atualizar o Nosso Número em Conta Cobrança");

                if (!FuncoesContaRecCobranca.Salvar(new ContaRecCobranca()
                {
                    IDContasRecobranca = Sequence.GetNextID("CONTARECCOBRANCA", "IDCONTARECCOBRANCA"),
                    IDContaCobranca = _Conta.IDContaCobranca,
                    IDContaReceber = Titulo.IDContaReceber,
                    Emissao = _Boleto.DataEmissao,
                    NossoNumero = _Boleto.NossoNumero,
                    NumeroControleParticipante = _Boleto.NumeroControleParticipante,
                    NumeroDocumento = _Boleto.NumeroDocumento,
                    Status = (int)StatusDuplicata.IMPRESSO,
                    Valor = _Boleto.ValorTitulo,
                    Vencimento = _Boleto.DataVencimento
                }, DAO.Enum.TipoOperacao.INSERT))
                    throw new Exception("Não foi possível salvar a Conta Recebimento de Cobrança.");
            }
            return _Boletos;
        }

        public static List<BoletoBancario> Imprimir(List<ContaRecCobranca> _ContasRecebimentoCobranca, ContaCobranca _Conta)
        {
            BoletoBancario _BoletoBancario = null;
            List<BoletoBancario> _Boletos = new List<BoletoBancario>();
            foreach (ContaRecCobranca ContaRecebimento in _ContasRecebimentoCobranca)
            {
                ContaReceber _ContaReceber = FuncoesContaReceber.GetContaReceber(ContaRecebimento.IDContaReceber);
                if (!_ContaReceber.IDCliente.HasValue)
                    continue;

                DAO.Entidades.Financeiro.ContaBancaria _ContaBancaria = FuncoesContaBancaria.GetContaBancaria(_Conta.IDContaBancaria);
                DAO.Entidades.Financeiro.Banco _Banco = FuncoesBanco.GetBanco(_ContaBancaria.IDContaBancaria);

                decimal NossoNumero = FuncoesContaCobranca.GetNossoNumero(_Conta.IDContaCobranca);

                _BoletoBancario = new BoletoBancario
                {
                    MostrarCodigoCarteira = true,
                    MostrarEnderecoCedente = true
                };

                IBanco _BancoBoleto = Boleto2Net.Banco.Instancia(Convert.ToInt32(_Banco.CodBacen));
                _BancoBoleto.Cedente = BoletoUtil.GetCedente(_Conta, _ContaBancaria, _Banco);

                Boleto _Boleto = new Boleto(_BancoBoleto);
                _Boleto.Banco.Cedente = BoletoUtil.GetCedente(_Conta, _ContaBancaria, _Banco);
                _Boleto.Sacado = BoletoUtil.GetSacado(_ContaReceber.IDCliente.Value);
                _Boleto.NumeroDocumento = $"BRADESCO{NossoNumero}_{_ContaReceber.IDContaReceber}";
                _Boleto.Aceite = _Conta.Aceite == 1 ? "S" : "N";
                _Boleto.Carteira = _Conta.Carteira;
                _Boleto.VariacaoCarteira = _Conta.VariacaoCarteira;
                _Boleto.DataEmissao = ContaRecebimento.Emissao;
                _Boleto.DataProcessamento = ContaRecebimento.Emissao;
                _Boleto.DataVencimento = ContaRecebimento.Vencimento;
                _Boleto.EspecieDocumento = BoletoUtil.ToEnum(_Conta.EspecieDoc, true, TipoEspecieDocumento.OU);
                _Boleto.EspecieMoeda = _Conta.Especie;
                _Boleto.ValorTitulo = ContaRecebimento.Valor;
                _Boleto.ValorTarifas = _Conta.Taxa.Value;
                _Boleto.NossoNumero = NossoNumero.ToString().PadLeft(11, '0');
                _Boleto.TipoCarteira = TipoCarteira.CarteiraCobrancaSimples;
                _Boleto.ValorMulta = _Conta.ValorMulta;
                _Boleto.PercentualJurosDia = _Conta.PercentualJuros;
                _Boleto.MensagemInstrucoesCaixa = _Conta.Instrucoes;
                _Boleto.NumeroControleParticipante = "CHAVEPRIMARIA=" + _ContaReceber.IDContaReceber;
                _Boleto.ValidarDados();
                _BoletoBancario.Boleto = _Boleto;
                _Boletos.Add(_BoletoBancario);
            }
            return _Boletos;
        }
    }
}
