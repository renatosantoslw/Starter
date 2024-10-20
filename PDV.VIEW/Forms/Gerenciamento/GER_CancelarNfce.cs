using DFe.Utils;
using MetroFramework;
using NFe.Classes.Servicos.Recepcao;
using NFe.Classes.Servicos.Recepcao.Retorno;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.EVENTONFE.Classes;
using PDV.CONTROLLER.EVENTONFE.Eventos;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_CancelarNfce : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "Cancelar NFC-E/NF-E";
        private decimal IDMOVIMENTOFISCAL;
        private string NFE;
        private decimal TipoDocumento = 55;


        public GER_CancelarNfce(decimal IDMovimentoFiscal, decimal TDocumento)
        {
            InitializeComponent();
            IDMOVIMENTOFISCAL = IDMovimentoFiscal;
            MovimentoFiscal movimento = FuncoesMovimentoFiscal.GetMovimento(IDMOVIMENTOFISCAL);
            ovTXT_Protocolo.Text = movimento.Protocolo;
            ovTXT_Chave.Text = movimento.Chave;
            TipoDocumento = movimento.TipoDocumento;
        }
        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            try
            {
                if (ovTXT_Justificativa.Text.Length > 15)
                {
                    PDVControlador.BeginTransaction();

                    if (string.IsNullOrEmpty(ovTXT_Justificativa.Text.Trim()))
                        throw new Exception("A justificativa deve ser informada.");

                    int IDEventoNFe = Sequence.GetNextID("EVENTONFE", "IDEVENTONFE");
                    RetornoEvento Retorno = EventoCancelamento.Cancelar(TipoDocumento == 65 ? Contexto.CONFIG_NFCe.CfgServico : Contexto.CONFIG_NFe.CfgServico,
                                                                        Convert.ToInt32(TipoDocumento),
                                                                        IDEventoNFe,
                                                                        IDMOVIMENTOFISCAL,
                                                                        ovTXT_Protocolo.Text,
                                                                        ovTXT_Chave.Text.Replace("NFe", ""),
                                                                        ovTXT_Justificativa.Text,
                                                                        ZeusUtil.SomenteNumeros(Contexto.CONFIG_NFe.Emitente.CNPJ));
                    if (!Retorno.Ok)
                        throw new Exception(Retorno.xMotivo);

                    PDVControlador.Commit();
                    MessageBox.Show(this, Retorno.xMotivo, NOME_TELA);
                    Close();
                }
                else
                {
                    MessageBox.Show(this, "O motivo deve ter 15 caracteres.", NOME_TELA);
                }
            }
            catch (Exception ex)
            {
                if (PDVControlador.CONTROLADOR.InTransaction(Contexto.IDCONEXAO_PRIMARIA))
                    PDVControlador.Rollback();

                if (!string.IsNullOrEmpty(ex.Message))
                    MessageBox.Show(this, ex.Message, NOME_TELA, MessageBoxButtons.OK);
            }
        }
    }
}
