using DFe.Utils;
using MetroFramework;
using MetroFramework.Forms;
using NFe.Classes.Servicos.Recepcao;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.EVENTONFE.Classes;
using PDV.CONTROLLER.EVENTONFE.Eventos;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_CartaCorrecao : Form
    {
        private string NOME_TELA = "CARTA DE CORREÇÃO";
        private MovimentoFiscal Movimento;
        private retEnviNFe retEnvi = null;

        public GER_CartaCorrecao(decimal IDMovimento)
        {
            InitializeComponent();
            Movimento = FuncoesMovimentoFiscal.GetMovimento(IDMovimento);
            //retEnvi = FuncoesXml.XmlStringParaClasse<retEnviNFe>(Encoding.UTF8.GetString(Movimento.XMLRetorno));
            ovTXT_Chave.Text = Movimento.Chave.Replace("NFe", string.Empty);
            ovTXT_Protocolo.Text = Movimento.Protocolo;//retEnvi.protNFe.infProt.nProt;
        }

        private void ovBTN_Enviar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(ovTXT_Justificativa.Text))
            {
                MessageBox.Show(this, "Preencha a Descrição da Correção.", NOME_TELA);
                return;
            }

            try
            {
                int IDEventoNFe = Sequence.GetNextID("EVENTONFE", "IDEVENTONFE");
                RetornoEvento Retorno = EventoCartaCorrecao.Enviar(Contexto.CONFIG_NFe.CfgServico,
                                                                   IDEventoNFe,
                                                                   Movimento.IDMovimentoFiscal,
                                                                   Movimento.Chave.Replace("NFe", string.Empty),
                                                                   ovTXT_Descricao.Text,
                                                                   string.IsNullOrEmpty(Contexto.CONFIG_NFe.Emitente.CNPJ) ? Contexto.CONFIG_NFe.Emitente.CPF : Contexto.CONFIG_NFe.Emitente.CNPJ);
                if (!Retorno.Ok)
                    throw new Exception(Retorno.xMotivo);

                MessageBox.Show(this, Retorno.xMotivo, NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

    }
}
