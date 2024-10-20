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
    public class EventoCartaCorrecao
    {
        public static RetornoEvento Enviar(ConfiguracaoServico CfgServico, int IDEventoNFe, decimal IDMovimentoFiscal, string Chave, string Descricao, string CNPJ)
        {
            try
            {
                var retornoCartaCorrecao = new ServicosNFe(CfgServico).RecepcaoEventoCartaCorrecao(1, FuncoesEventoNFe.GetProxSeqEvento(IDMovimentoFiscal, (int)TipoEvento.CARTACORRECAO), Chave, EventoUtil.RemoverAcentos(Descricao), CNPJ);

                if (!FuncoesEventoNFe.Salvar(new EventoNFe
                {
                    IDEventoNFe = IDEventoNFe,
                    DHRecebimento = retornoCartaCorrecao.ProcEventosNFe[0].retEvento.infEvento.dhRegEvento,
                    IDMovimentoFiscal = IDMovimentoFiscal,
                    NProt = retornoCartaCorrecao.ProcEventosNFe[0].retEvento.infEvento.nProt,
                    NSeqEvento = retornoCartaCorrecao.ProcEventosNFe[0].retEvento.infEvento.nSeqEvento.ToString(),
                    XCorrecao = retornoCartaCorrecao.ProcEventosNFe[0].evento.infEvento.detEvento.xCorrecao,
                    DescEvento = retornoCartaCorrecao.ProcEventosNFe[0].evento.infEvento.detEvento.descEvento,
                    XML = Encoding.Default.GetBytes(FuncoesXml.ClasseParaXmlString(retornoCartaCorrecao.ProcEventosNFe[0])),
                    XMotivo = retornoCartaCorrecao.Retorno.retEvento[0].infEvento.xMotivo,
                    CSTAT = retornoCartaCorrecao.Retorno.retEvento[0].infEvento.cStat,
                    TipoEvento = (int)TipoEvento.CARTACORRECAO
                }))
                    throw new Exception("Não foi possível vincular o Evento da Carta de Correção.");

                return new RetornoEvento { Ok = true, xMotivo = retornoCartaCorrecao.Retorno.retEvento[0].infEvento.xMotivo };
            }
            catch (Exception Ex)
            {
                return new RetornoEvento { Ok = false, xMotivo = Ex.Message };
            }
        }
    }
}
