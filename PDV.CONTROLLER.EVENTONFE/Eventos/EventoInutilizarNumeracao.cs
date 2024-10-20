using DFe.Classes.Flags;
using NFe.Servicos;
using NFe.Utils;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.EVENTONFE.Classes;
using PDV.CONTROLLER.EVENTONFE.Util;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using System;
using System.Text;

namespace PDV.CONTROLLER.EVENTONFE.Eventos
{
    public class EventoInutilizarNumeracao
    {
        public static RetornoEvento Enviar(ConfiguracaoServico CfgServico, string CNPJ, int Ano, ModeloDocumento Modelo, int Serie, int NumeroInicial, int NumeroFinal, string xJust)
        {
            try
            {
                var ServicoNFe = new ServicosNFe(CfgServico);
                var Retorno = ServicoNFe.NfeInutilizacao(CNPJ, Ano, Modelo, Serie, NumeroInicial, NumeroFinal, EventoUtil.RemoverAcentos(xJust));

                if (!FuncoesEventoNFe.Salvar(new EventoNFe
                {
                    IDEventoNFe = Sequence.GetNextID("IDEVENTONFE"),
                    DHRecebimento = Retorno.Retorno.infInut.dhRecbto ?? DateTime.Now,
                    IDMovimentoFiscal = null,
                    NProt = Retorno.Retorno.infInut.nProt,
                    DescEvento = "Inutilização de Numeração",
                    XML = Encoding.Default.GetBytes(Retorno.RetornoStr),
                    XMotivo = Retorno.Retorno.infInut.xMotivo,
                    CSTAT = Retorno.Retorno.infInut.cStat,
                    XCorrecao = EventoUtil.RemoverAcentos(xJust),
                    Inutilizacao_NNFIni = Retorno.Retorno.infInut.nNFIni,
                    Inutilizacao_NNFFIN = Retorno.Retorno.infInut.nNFFin,
                    Inutilizacao_Serie = Retorno.Retorno.infInut.serie,
                }))
                    throw new Exception("Não foi possível vincular o Evento de Cancelamento da NF-e.");

                return new RetornoEvento { Ok = true, xMotivo = Retorno.Retorno.infInut.xMotivo };
            }
            catch (Exception Ex)
            {
                return new RetornoEvento { Ok = false, xMotivo = Ex.Message };
            }
        }
    }
}
