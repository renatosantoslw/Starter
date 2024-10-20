using MetroFramework;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using PDV.UTIL.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.UTIL.FORMS.Forms.Caixa
{
    public partial class AberturaCaixa : Form
    {
        private DateTime DataAberturaCaixa;
        private string NOME_TELA = "ABERTURA DE CAIXA";
        private FluxoCaixa FLUXO = null;
        private Usuario Logado = null;
        public PDV.DAO.Entidades.Caixa Caixa;
        public AberturaCaixa(Usuario User)
        {
            InitializeComponent();
            
            carregarCombobox();
            Logado = User;
            ovTXT_Usuario.Text = string.Format("{0} ({1})", Logado.Nome, Logado.Login);
            DataAberturaCaixa = DateTime.Now;
            ovTXT_DataHora.Text = DataAberturaCaixa.ToString();

            ovTXT_Valor.GotFocus += OvTXT_Valor_GotFocus;

            FLUXO = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Logado.IDUsuario);
            if (FLUXO != null)
            {
                ovTXT_DataHora.Text = FLUXO.DataAberturaCaixa.ToString();
                ovTXT_Valor.Text = FLUXO.ValorCaixa.ToString();

                ovTXT_DataHora.Enabled = false;
                ovTXT_Valor.Enabled = false;
            }
        }

        private void carregarCombobox()
        {
            caixaComboBox.DataSource = FuncoesCaixa.GetTodosCaixasAtivo();
            caixaComboBox.DisplayMember = "numerocaixa";
            caixaComboBox.ValueMember = "idcaixa";
            caixaComboBox.SelectedItem = null;
        }

        private void OvTXT_Valor_GotFocus(object sender, EventArgs e)
        {
            ovTXT_Valor.Select(0, ovTXT_Valor.Text.Length);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.Enter:
                    AbrirCaixa();
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AbrirCaixa();
        }

        private void AbrirCaixa()
        {
            if (FLUXO != null)
            {
                Close();
                return;
            }

            try
            {
                if(caixaComboBox.Text == String.Empty)
                {
                    throw new Exception("Informe o Caixa.");
                }
                Caixa = FuncoesCaixa.GetCaixa(decimal.Parse(caixaComboBox.SelectedValue.ToString()));

                if (!FuncoesFluxoCaixa.AbrirCaixa(Convert.ToDecimal(ovTXT_Valor.Text), DataAberturaCaixa, Logado.IDUsuario,int.Parse(caixaComboBox.SelectedValue.ToString())))
                    throw new Exception("Ocorreu um problema ao inicializar esse caixa procure o administrador do sistema.");
                printDocument1.Print();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Não foi possível Abrir o Caixa. Detalhes: " + ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ovTXT_Valor_MouseClick(object sender, MouseEventArgs e)
        {
            ovTXT_Valor.Select(0, ovTXT_Valor.Text.Length);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Pen myPen = new Pen(Brushes.Black);
                Font myFont1 = new Font("Arial", 8);
                Font myFont2 = new Font("Arial", 7);
                Font myFont3 = new Font("Arial Black", 8);
                Font myFont4 = new Font("Arial", 8, FontStyle.Bold);
                Font myFont5 = new Font("Arial", 10, FontStyle.Bold);

                DateTime dataCupom = DateTime.Now;
                //O NOME DA EMPRESA QUE VAI SAIR NO CABEÇAALHO

                string menu = "COMPROVANTE DE ABERTURA DE CAIXA";
                string nao_fiscal = "*** NÃO É DOCUMENTO FISCAL ***";

                //string nome_emp = "Nome da Empresa";
                //string rua_emp = "Rua da Empresa";
                //string cidade_emp = "Cidade da Empresa";
                //string cnpj_emp = "Cnpj da Empresa";

                #region Carregar Logo Tipo Imagem
                //Image imagem = Image.FromFile(Application.StartupPath + @"\Logo.PNG");
                //int largura = imagem.Width / 5;
                //int altura = imagem.Height / 5;

                //e.Graphics.DrawImage(imagem,
                //    new Rectangle(95, 15, largura, altura),
                //    new Rectangle(10, 0, imagem.Width, imagem.Height), GraphicsUnit.Pixel);

                #endregion

                //*******************************************************************

                Brush cor = new SolidBrush(Color.Black);
                PointF ponto = new PointF(100, 100);
                RectangleF rect = new RectangleF(0, 85, 280, 15);
                Rectangle rect1 = new Rectangle(0, 85, 280, 15);
                StringFormat formato = new StringFormat();
                formato.Alignment = StringAlignment.Center;

                e.Graphics.DrawRectangle(new Pen(Color.White), rect1);
                e.Graphics.DrawString(menu, myFont4, cor, rect, formato);
               Pen lapis = new Pen(Color.Black);
                Point pont1 = new Point(0, 155);
                Point pont2 = new Point(280, 155);
                e.Graphics.DrawLine(lapis, pont1, pont2);

                //*******************************************************************
                PointF ponto5 = new PointF(100, 100);
                RectangleF rect10 = new RectangleF(0, 158, 280, 15);
                Rectangle rect11 = new Rectangle(0, 158, 280, 15);


                e.Graphics.DrawRectangle(new Pen(Color.White), rect11);
                e.Graphics.DrawString(nao_fiscal, myFont1, cor, rect10, formato);
                //*******************************************************************

                Point pont3 = new Point(0, 173);
                Point pont4 = new Point(280, 173);
                e.Graphics.DrawLine(lapis, pont3, pont4);

                //*******************************************************************
                e.Graphics.DrawString("Caixa:", myFont4, Brushes.Black, 5, 175);
                e.Graphics.DrawString("01", myFont1, Brushes.Black, 64, 175);
                e.Graphics.DrawString("Hora:" + DateTime.Now.ToString("HH:mm:ss"), myFont1, Brushes.Black, 180, 175);

                e.Graphics.DrawString("Data Abertura                               Valor inicial", myFont4, Brushes.Black, 5, 188);

                RectangleF rect13 = new RectangleF(0, 201, 80, 15);
                Rectangle rect14 = new Rectangle(0, 201, 80, 15);
                e.Graphics.DrawRectangle(new Pen(Color.White), rect14);
                e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), myFont1, cor, rect13, formato);


                //RectangleF rect15 = new RectangleF(90, 201, 90, 15);
                //Rectangle rect16 = new Rectangle(90, 201, 90, 15);
                //e.Graphics.DrawRectangle(new Pen(Color.White), rect16);
                //e.Graphics.DrawString("01-01-2010", myFont1, cor, rect15, formato);



                RectangleF rect17 = new RectangleF(180, 201, 70, 15);
                Rectangle rect18 = new Rectangle(180, 201, 70, 15);
                e.Graphics.DrawRectangle(new Pen(Color.White), rect18);
                e.Graphics.DrawString(ovTXT_Valor.Text, myFont4, cor, rect17, formato);

                e.Graphics.DrawString("Caixa (Operador):", myFont4, Brushes.Black, 5, 216);
                e.Graphics.DrawString(ovTXT_Usuario.Text, myFont1, Brushes.Black, 5, 229);
                //e.Graphics.DrawString("Nome do Clinete", myFont1, Brushes.Black, 5, 242);

                //e.Graphics.DrawString("Caixa:", myFont4, Brushes.Black, 5, 257);
                //e.Graphics.DrawString("Nome do Caixa", myFont1, Brushes.Black, 43, 257);


                Point pont6 = new Point(0, 272);
                Point pont7 = new Point(280, 272);
                e.Graphics.DrawLine(lapis, pont6, pont7);

                Point pont8 = new Point(0, 287);
                Point pont9 = new Point(280, 287);
                e.Graphics.DrawLine(lapis, pont8, pont9);

                int seqAberturaM = int.Parse(DateTime.Now.Month.ToString());
                int seqAberturaD = int.Parse(DateTime.Now.Day.ToString());
                int seqAberturaA = int.Parse(DateTime.Now.Year.ToString());
              //  String Seq = global.NumeroCaixa + seqAberturaD.ToString() + seqAberturaM.ToString() + seqAberturaA.ToString().Replace("20", "");
                //e.Graphics.DrawString(">>> Abertura " + Seq + " <<<", myFont1, Brushes.Black, 78, 273);

                e.Graphics.DrawString("Assinatura do operador(a) : ___________________________________", myFont4, Brushes.Black, 5, 290);
                e.Graphics.DrawString("Confirmo os valores incluídos na abertura de caixa.", myFont2, Brushes.Black, 5, 300);
                e.Graphics.DrawString("Tenha um otimo dia de trabalho!!!", myFont4, Brushes.Black, 5, 315);
                e.HasMorePages = false;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro na Impressão. Detalhes: " + erro.Message);
            }
        }

        private void AberturaCaixa_Load(object sender, EventArgs e)
        {

        }

        private void abrirCaixaButton_Click(object sender, EventArgs e)
        {
            AbrirCaixa();
        }

        private void ovTXT_Valor_TextChanged(object sender, EventArgs e)
        {
            Moedas.FormatarMoedas(ref ovTXT_Valor);
        }

        private void contadorMoedasButton_Click(object sender, EventArgs e)
        {
            frmContadorMoedas frm = new frmContadorMoedas();
            frm.ShowDialog();
            if (frm.Valornicial == null)
            {
                ovTXT_Valor.Text = "";
                ovTXT_Valor.Focus();
            }
            else
            {
                ovTXT_Valor.Text = frm.Valornicial.ToString();
                ovTXT_Valor.Focus();
            }
            frm = null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AbrirCaixa();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
