using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils.Excecoes;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.NFE.Configuracao;
using System;
using System.Collections.Generic;

namespace PDV.CONTROLLER.NFE.Manifestacao
{
    public class ManifestarDestinatario : IConfigNFe
    {
        public ManifestarDestinatario() { }

        public RetornoRecepcaoEvento Manifestar(int NumeroSequencial, string Chave, NFeTipoEvento Tipo, string Justificativa)
        {
            
            return new ServicosNFe(CONFIG_NFe.CfgServico).RecepcaoEventoManifestacaoDestinatario(1, NumeroSequencial, Chave, Tipo, FuncoesEmitente.GetEmitente().CNPJ);
        }

        public RetornoNfeDistDFeInt DownloadNFe(string Chave)
        {
            try { return new ServicosNFeNew(CONFIG_NFe.CfgServico).NfeDistDFeInteresse(CONFIG_NFe.CfgServico.cUF.ToString(), FuncoesEmitente.GetEmitente().CNPJ, chNFE: Chave); }
            catch (ComunicacaoException ex) { throw ex; }
            catch (ValidacaoSchemaException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }
    }
}