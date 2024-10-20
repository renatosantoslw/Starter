using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Servicos;
using NFe.Utils;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.EVENTONFE.Classes;
using PDV.CONTROLLER.EVENTONFE.Enum;
using PDV.CONTROLLER.EVENTONFE.Util;
using PDV.DAO.Entidades;
using System;
using System.Text;

namespace PDV.CONTROLLER.EVENTONFE.Eventos
{
    public class EventoCancelamento
    {
        public static RetornoEvento Cancelar(ConfiguracaoServico CfgServico, int TipoDocumento, decimal IDEventoNFe, decimal IDMovimentoFiscal, string Protocolo, string Chave, string Justificativa, string CNPJ)
        {
            try
            {
                CfgServico.ModeloDocumento = (ModeloDocumento)TipoDocumento;
                var retornoCancelamento = new ServicosNFe(CfgServico).RecepcaoEventoCancelamento(1, FuncoesEventoNFe.GetProxSeqEvento(IDMovimentoFiscal, (int)TipoEvento.CANCELAMENTO), Protocolo, Chave, EventoUtil.RemoverAcentos(Justificativa), CNPJ);

                if (!FuncoesMovimentoFiscal.AtualizarMovimento(new MovimentoFiscal()
                {
                    IDMovimentoFiscal = IDMovimentoFiscal,
                    Cancelada = retornoCancelamento.Retorno.retEvento[0].infEvento.cStat == 101 || retornoCancelamento.Retorno.retEvento[0].infEvento.cStat == 135 ? 1 : 0,
                    cStat = retornoCancelamento.Retorno.retEvento[0].infEvento.cStat,
                    xMotivo = retornoCancelamento.Retorno.retEvento[0].infEvento.xEvento
                }))
                    throw new Exception("Não foi possível atualizar o Movimento Fiscal.");

                if (!FuncoesEventoNFe.Salvar(new EventoNFe
                {
                    IDEventoNFe = IDEventoNFe,
                    DHRecebimento = retornoCancelamento.ProcEventosNFe[0].retEvento.infEvento.dhRegEvento,
                    IDMovimentoFiscal = IDMovimentoFiscal,
                    NProt = retornoCancelamento.ProcEventosNFe[0].retEvento.infEvento.nProt,
                    NSeqEvento = retornoCancelamento.ProcEventosNFe[0].retEvento.infEvento.nSeqEvento.ToString(),
                    XCorrecao = retornoCancelamento.ProcEventosNFe[0].evento.infEvento.detEvento.xCorrecao,
                    DescEvento = retornoCancelamento.ProcEventosNFe[0].evento.infEvento.detEvento.descEvento,
                    XML = Encoding.Default.GetBytes(FuncoesXml.ClasseParaXmlString(retornoCancelamento.ProcEventosNFe[0])),
                    XMotivo = retornoCancelamento.ProcEventosNFe[0].evento.infEvento.detEvento.xJust,
                    CSTAT = retornoCancelamento.Retorno.retEvento[0].infEvento.cStat,
                    TipoEvento = (int)TipoEvento.CANCELAMENTO
                }))
                    throw new Exception("Não foi possível vincular o Evento de Cancelamento da NF-e.");


                if(retornoCancelamento.Retorno.retEvento[0].infEvento.cStat == 135)
                {

                }

                return new RetornoEvento
                {
                    Ok = retornoCancelamento.Retorno.retEvento[0].infEvento.cStat == 101 || retornoCancelamento.Retorno.retEvento[0].infEvento.cStat == 135,
                    xMotivo = retornoCancelamento.Retorno.retEvento[0].infEvento.xMotivo
                };
            }
            catch (Exception Ex)
            {
                return new RetornoEvento
                {
                    Ok = false,
                    xMotivo = Ex.Message
                };
            }
        }
    }
}