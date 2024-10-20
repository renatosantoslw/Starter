using NFe.Servicos;
using NFe.Utils.NFe;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_ConsultarNFe : Form
    {
        public decimal IDMovimentoFiscal;
        public string CStat { get; set; }
        public GER_ConsultarNFe(string chave, decimal idmovimento)
        {
            InitializeComponent();
            var servicoNFe = new ServicosNFe(Contexto.CONFIG_NFe.CfgServico);
            var retornoConsulta = servicoNFe.NfeConsultaProtocolo(chave.Replace("NFe", "").Trim());

            

            //String ResultadoTexto = $" Chave {retornoConsulta.Retorno.chNFe}"
            IDMovimentoFiscal = idmovimento;
            CStat = retornoConsulta.Retorno.cStat.ToString().ToUpper();
            ambienteTextBox.Text = retornoConsulta.Retorno.tpAmb.ToString().ToUpper();
            chaveTextBox.Text = retornoConsulta.Retorno.chNFe.ToString().ToUpper();
            protocoloTextBox.Text = retornoConsulta.Retorno.protNFe== null ? "" : retornoConsulta.Retorno.protNFe.infProt.nProt.ToString();
            statusTextBox.Text =retornoConsulta.Retorno.xMotivo.ToUpper();
            UFtextBox.Text = retornoConsulta.Retorno.cUF.ToString().ToUpper();
            
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void simpleButtonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var nfe = new NFe.Classes.NFe().CarregarDeXmlString(FuncoesMovimentoFiscal.GetXMLRetorno(IDMovimentoFiscal));

                var servicoNFe = new ServicosNFe(Contexto.CONFIG_NFe.CfgServico);
                var retornoConsulta = servicoNFe.NfeConsultaProtocolo(nfe.infNFe.Id.ToString().Replace("NFe", "").Trim());
                var nfeProc = new NFe.Classes.nfeProc()
                {
                    NFe = nfe,
                    protNFe = retornoConsulta.Retorno.protNFe,
                    versao = retornoConsulta.Retorno.versao
                };
                MovimentoFiscal movimento = FuncoesMovimentoFiscal.GetMovimento(IDMovimentoFiscal);
                movimento.XMLEnvio = Encoding.Default.GetBytes(nfeProc.ObterXmlString());
                movimento.XMLRetorno = Encoding.Default.GetBytes(nfeProc.ObterXmlString());
                FuncoesMovimentoFiscal.AtualizarMovimentoPorID(movimento);
                FuncoesMovimentoFiscal.AtualizarStatusNFe(IDMovimentoFiscal, CStat, statusTextBox.Text, protocoloTextBox.Text);
                MessageBox.Show("Atualizada com sucesso", "NFe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void GER_ConsultarNFe_Load(object sender, EventArgs e)
        {

        }
    }
}
