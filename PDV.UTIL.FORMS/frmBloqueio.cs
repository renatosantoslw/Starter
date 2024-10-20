using System;
using System.Windows.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL.FORMS.Forms;

namespace PDV.UTIL.FORMS
{
    public partial class frmBloqueio : DevExpress.XtraEditors.XtraForm
    {
        private Emitente _Emitente = null;
        public  string DataLocal { get; set; }
        public frmBloqueio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ;// Environment.Exit(1);
            Close();
        }

        public String encriptDataLocal()
        {
            _Emitente =  FuncoesEmitente.GetEmitente();

            CriptografiaSystem crip = new CriptografiaSystem(CryptProvider.DES);
            crip.Key = _Emitente.CNPJ + "Systema";
            var datavalidade = Convert.ToString(crip.Encrypt(DateTime.Now.Date.ToString()));
            return datavalidade;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataLocal = encriptDataLocal();
              // PDVControlador.BeginTransaction();
                FuncoesEmitente.AtualizarChave(chavedeacessotextbox.Text, DataLocal);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO:   "+ex.Message);
               // PDVControlador.Rollback();
              //  throw;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    bool ativou = await ControllerLicense.VerificarBloqueiLicença();
                    if(ativou)
                    {
                        Emitente emitente = FuncoesEmitente.GetEmitente();
                        MessageBox.Show($"Licença atualiza com sucesso! A data de validade está programada para o dia { Convert.ToDateTime(DueLicence.Crypto.Decrypt(emitente.chaveerp))}", "Sucesso",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Você está sem internet no momento não é possivél liberar sua licença de forma automática em nosso servidor", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
