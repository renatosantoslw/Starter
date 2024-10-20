using MetroFramework;
using MetroFramework.Forms;
using ModelAndroidApp.ModelAndroid;
using Newtonsoft.Json;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class FCONFIG_ConsultaStatusWS : DevExpress.XtraEditors.XtraForm
    {
        public FCONFIG_ConsultaStatusWS()
        {
            InitializeComponent();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ovBTN_Cancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void TrataRetorno(RetornoBasico retornoBasico)
        {
            RetornoDados(retornoBasico.Retorno, RtbRetornoCompletoStr);
        }

        internal void RetornoDados<T>(T objeto, Label TextBox) where T : class
        {
            TextBox.Text = string.Empty;

            foreach (var atributos in LerPropriedades(objeto))
            {
                TextBox.Text += (atributos.Key + " = " + atributos.Value + "\r");
            }
        }

        public static Dictionary<string, object> LerPropriedades<T>(T objeto) where T : class
        {
            //A função pode ser melhorada para trazer recursivamente as proprieades dos objetos filhos
            var dicionario = new Dictionary<string, object>();

            foreach (var attributo in objeto.GetType().GetProperties())
            {
                var value = attributo.GetValue(objeto, null);
                dicionario.Add(attributo.Name, value);
            }

            return dicionario;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            RtbRetornoCompletoStr.Text = "Procesando...";
            Consultar();
        }

        private void Consultar()
        {
            try
            {
                #region Status do serviço


                var servicoNFe = new ServicosNFe(Contexto.CONFIG_NFe.CfgServico);
                var retornoStatus = servicoNFe.NfeStatusServico();

                TrataRetorno(retornoStatus);

                RtbRetornoCompletoStr.ForeColor = System.Drawing.Color.Green;

                #endregion
            }
            catch (Exception ex)
            {
                RtbRetornoCompletoStr.ForeColor = System.Drawing.Color.Red;
                RtbRetornoCompletoStr.Text = ex.Message;
            }
        }

        private void FCONFIG_ConsultaStatusWS_Load(object sender, EventArgs e)
        {
            try
            {
                ServicosNFe servicos = new ServicosNFe(Contexto.CONFIG_NFCe.CfgServico);
                Consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível fazer a consulta do status sa Sefaz. Verifique as configurações e tente novamente!", "CONSULTA STATUS SEFAZ");
                Close();
            }
        }

        private void FCONFIG_ConsultaStatusWS_Shown(object sender, EventArgs e)
        {
            Consultar();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Emitente _emitente = FuncoesEmitente.GetEmitente();
                var jsonEmitente = JsonConvert.SerializeObject(_emitente);
                var jsonServico = JsonConvert.SerializeObject(Contexto.CONFIG_NFe.CfgServico);

                ContextAppAndroid contexto = new ContextAppAndroid();
                contexto.Database.ExecuteSqlCommand("Delete From BaseApps");
                contexto.Database.ExecuteSqlCommand($"Insert into BaseApps (Servico , Emitente) values ('{jsonServico}','{jsonEmitente}')");
                MessageBox.Show(this,"API  FISCAL ATUALIZADA COM SUCESSO", "SUCESSO");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERRO AO ATUALIZAR API");
            }
        }
    }
}
