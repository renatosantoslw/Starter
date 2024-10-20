using DFe.Utils;
using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos.Retorno;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.NFE.Manifestacao;
using PDV.DAO.DB.Utils;
using PDV.VIEW.App_Context;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada
{
    public partial class FEST_IdentificacaoChave : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "IDENTIFICAÇÃO DA CHAVE DA NF-E";
        public FEST_IdentificacaoChave()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ovTXT_Chave.Text) || ovTXT_Chave.Text.Replace(" ", string.Empty).Length != 44)
                {
                    MessageBox.Show(this, "Chave Inválida.", NOME_TELA);
                    return;
                }

                /*
                 * Manifestação do Destinatário sempre vai ser feito uma vez. Caso já tenha sido feito, no banco vai salvar o Motivo como Duplicidade de Numero de Evento,
                 * Caso não exista, vai fazer a manifestação como Ciencia da Emissão, vai salvar o retorno e sempre vai usar ele.
                 */
                PDVControlador.BeginTransaction();
                ManifestarDestinatario Manif = new ManifestarDestinatario { CaminhoSolution = Contexto.CaminhoSolution };
                decimal? IDManifesto = null;

                DAO.Entidades.DownloadNFeEntrada.ManifestacaoDestinatario ManifestoEncontrado = FuncoesManifestacaoDestinatario.GetManifestoPorChave(ovTXT_Chave.Text.Replace(" ", string.Empty));
                //if (ManifestoEncontrado == null)
                //{
                //    //Aqui só para fazer a manifestação
                //    RetornoRecepcaoEvento RetornoManif = Manif.Manifestar(1, ovTXT_Chave.Text.Replace(" ", string.Empty), NFeTipoEvento.TeMdCienciaDaEmissao, string.Empty); ;
                //    if (RetornoManif.ProcEventosNFe[0].retEvento.infEvento.cStat != 135)
                //        throw new Exception(RetornoManif.ProcEventosNFe[0].retEvento.infEvento.xMotivo);

                //    IDManifesto = Sequence.GetNextID("MANIFESTACAODESTINATARIO", "IDMANIFESTACAODESTINATARIO");
                //    if (!FuncoesManifestacaoDestinatario.Salvar(new DAO.Entidades.DownloadNFeEntrada.ManifestacaoDestinatario
                //    {
                //        ChaveNFe = ovTXT_Chave.Text.Replace(" ", string.Empty),
                //        Cstat = RetornoManif.ProcEventosNFe[0].retEvento.infEvento.cStat,
                //        IDManifestacaoDestinatario = IDManifesto.Value,
                //        Motivo = RetornoManif.ProcEventosNFe[0].retEvento.infEvento.xMotivo,
                //        NumeroEvento = 1,
                //        Orgao = (int)RetornoManif.ProcEventosNFe[0].retEvento.infEvento.cOrgao,
                //        TipoAmbiente = (int)RetornoManif.ProcEventosNFe[0].retEvento.infEvento.tpAmb,
                //        TipoManifestacao = (decimal)NFeTipoEvento.TeMdCienciaDaEmissao//(int)NFe.Classes.Servicos.Tipos.TipoEventoManifestacaoDestinatario.TeMdCienciaDaEmissao
                //    }))
                //        throw new Exception("Não foi possível salvar a Manifestação do Destinatário.");
                //}

                RetornoNfeDistDFeInt RetornoDownload = Manif.DownloadNFe(ovTXT_Chave.Text.Replace(" ", string.Empty));
                if (RetornoDownload.Retorno.cStat != 138)
                    throw new Exception(RetornoDownload.Retorno.xMotivo);

                if (!FuncoesDownloadNFe.Salvar(new DAO.Entidades.DownloadNFeEntrada.DownloadNFe
                {
                    Cstat = RetornoDownload.Retorno.cStat,
                    DhResp = RetornoDownload.Retorno.dhResp,
                    IDDownloadNFe = Sequence.GetNextID("DOWNLOADNFE", "IDDOWNLOADNFE"),
                    IDManifestacaoDestinatario = ManifestoEncontrado != null ? ManifestoEncontrado.IDManifestacaoDestinatario : IDManifesto,
                    MaxNsu = RetornoDownload.Retorno.maxNSU,
                    Motivo = RetornoDownload.Retorno.xMotivo,
                    TpAmb = RetornoDownload.Retorno.tpAmb,
                    UltNSu = RetornoDownload.Retorno.ultNSU,
                    Xml = RetornoDownload.Retorno.loteDistDFeInt.First().XmlNfe
                }))
                    throw new Exception("Não foi possível salvar a Manifestação do Destinatário.");

                PDVControlador.Commit();
                // Abrir tela da NFe
                TratarRetorno(RetornoDownload);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
                if (PDVControlador.CONTROLADOR.InTransaction(Contexto.IDCONEXAO_PRIMARIA))
                    PDVControlador.Rollback();
            }
        }

        private void TratarRetorno(RetornoNfeDistDFeInt Retorno)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Retorno.RetornoCompletoStr);
            XmlNodeList nodeList = doc.GetElementsByTagName("docZip");

            string Retorno_XML = string.Empty;

            foreach (XmlNode node in nodeList)
                Retorno_XML = node.InnerText;

            NFe.Classes.NFe ArquivoXML = FuncoesXml.XmlStringParaClasse<NFe.Classes.NFe>(FuncoesXml.ObterNodeDeStringXml("NFe", Descompactar_Msg(Retorno_XML)));
            new FEST_ImportacaoNFeNOVO(ArquivoXML).ShowDialog(this);
            Close();
        }

        public static string Descompactar_Msg(string text)
        {
            byte[] bytes = Convert.FromBase64String(text);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    byte[] bytesAux = new byte[4096];
                    int cnt;

                    while ((cnt = gs.Read(bytesAux, 0, bytesAux.Length)) != 0)
                    {
                        mso.Write(bytesAux, 0, cnt);
                    }
                }
                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
    }
}
