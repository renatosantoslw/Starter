using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Configuracoes
{
    public partial class ModeloImpressaoDav : XtraForm
    {
        public Emitente Emitente { get; set; }

        private readonly string sectionName = "Conexao_PDV";
        private readonly string key = "modelo_impressao_dav";
        public ModeloImpressaoDav()
        {
            InitializeComponent();
            Emitente = FuncoesEmitente.GetEmitente();
            comboModelo.SelectedIndex = Convert.ToInt32(Emitente.ModeloImpressaoDAV);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Salvar(object sender, EventArgs e)
        {
            
            try
            {
                Validar();
                SalvarConfiguracoes();
                Close();
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }            
        }

        private void SalvarConfiguracoes()
        {
            Emitente.ModeloImpressaoDAV = comboModelo.SelectedIndex;
            FuncoesEmitente.SalvarEmitente(Emitente, TipoOperacao.UPDATE);
        }

        private void Validar()
        {
            if (comboModelo.SelectedIndex == -1)
                throw new Exception("Escolha um modelo");
        }

        private void Alert(string msg)
        {
            MessageBox.Show(this, msg, Text.ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
