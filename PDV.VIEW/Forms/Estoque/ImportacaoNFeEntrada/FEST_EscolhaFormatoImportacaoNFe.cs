using DFe.Utils;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Estoque.ImportacaoNFeEntrada
{
    public partial class FEST_EscolhaFormatoImportacaoNFe : DevExpress.XtraEditors.XtraForm
    {
        public FEST_EscolhaFormatoImportacaoNFe()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Baixar NFe
            new FEST_IdentificacaoChave().ShowDialog(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CarregarXML();
        }

        private void CarregarXML()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Arquivo .XML|*.xml";
            openFileDialog1.Title = "Selecione o Arquivo XML da NF-e";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Chamar a Tela de Importação do XML da NFe
                    NFe.Classes.NFe ArquivoXML = FuncoesXml.XmlStringParaClasse<NFe.Classes.NFe>(FuncoesXml.ObterNodeDeArquivoXml("NFe", openFileDialog1.FileName));
                   
                    //new metroButton5(ArquivoXML).ShowDialog();
                    new FEST_ImportacaoNFeNOVO(ArquivoXML).ShowDialog();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "FORMATO DE IMPORTAÇÃO");
                }
            }
        }
    }
}
