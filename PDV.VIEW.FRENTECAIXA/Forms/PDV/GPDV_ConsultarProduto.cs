using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.UTIL;
using System.Configuration;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

namespace PDV.VIEW.FRENTECAIXA.Forms.PDV
{
    public partial class GPDV_ConsultarProduto : DevExpress.XtraEditors.XtraForm
    {
        string RxString;
        string sPeso;

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        private GPDV_PainelInicial TELAPDV = null;
        public GPDV_ConsultarProduto()
        {
            InitializeComponent();
            string sAux = ConfigurationManager.AppSettings["UsaBalanca"];
           abriConexaoBanlanca(sAux);
            //   serialPort1.Open();
        }

        private void abriConexaoBanlanca(string sAux)
        {
            if (sAux == "S")
            {
                Saida_Tela.Visible = true;
                label1.Visible = true;
                serialPort1.PortName = ConfigurationManager.AppSettings["PortaSerial"];  //"COM6";
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.DtrEnable = true;
                serialPort1.StopBits = StopBits.One;
                serialPort1.NewLine = "05H"; //vbCr
                serialPort1.ReadTimeout = 500;
                serialPort1.WriteTimeout = 500;
                try
                {
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Open();
                    }
                }
                catch (Exception ex)
                {
                    ovTXT_StatusConsulta.Visible = true;
                    ovTXT_StatusConsulta.Text = "Falha de comunicação com a balança, verifique as conexões.";
                }
            }
            else
            {
                Saida_Tela.Visible = false;
                label1.Visible = false;
            }
        }

        public void ConsultaProduto(string descricao, GPDV_PainelInicial TelaPDV)
        {
            TELAPDV = TelaPDV;
            ovTXT_CodigoBarrasProduto.Text = descricao;
          //  SendKeys.Send("+{ENTER}");
            // ovTXT_CodigoBarrasProduto_KeyUp(ovTXT_CodigoBarrasProduto, Keys.Enter);
            AtualizaProdutos(descricao);
        }

        private void AtualizaProdutos(string Descricao)
        {
            DataTable tabela = FuncoesProduto.GetProdutosPorDescricao(Descricao, false, true);
            ovGRD_Produtos.DataSource = tabela;
            AjustaHeaderTextGrid();
            if (tabela.Rows.Count >0)
            {
                DataRow dRow = tabela.Rows[0];
                ovTXT_DescricaoProduto.Text = dRow["DESCRICAO"].ToString();
                ovTXT_Marca.Text = dRow["MARCA"].ToString();
                ovTXT_UnidadeMedida.Text = dRow["UNIDADEDEMEDIDA"].ToString();
                ovTXT_CodigoBarras.Text = dRow["CODIGODEBARRAS"].ToString();
                ovTXT_ValorUnitario.Text = dRow["PRECOVENDA"].ToString();

                ovGRD_Produtos.Rows[0].Selected = true;
            }
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Produtos.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Produtos.Width;

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font("Open Sans", 9, FontStyle.Regular);
            style.Alignment = DataGridViewContentAlignment.TopLeft;
            style.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in ovGRD_Produtos.Columns)
            {
                switch (column.Name)
                {
                    case "codigodebarras":
                        column.DisplayIndex = 6;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.25);
                        column.Width = Convert.ToInt32(WidthGrid * 0.25);
                        column.HeaderText = "CÓDIGO DE BARRAS";
                        break;
                    case "descricao":
                        column.DisplayIndex = 7;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.35);
                        column.Width = Convert.ToInt32(WidthGrid * 0.35);
                        column.HeaderText = "NOME";
                        break;
                    case "unidadedemedida":
                        column.DisplayIndex = 8;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.35);
                        column.Width = Convert.ToInt32(WidthGrid * 0.35);
                        column.HeaderText = "UNIDADE";
                        break;
                    case "marca":
                        column.DisplayIndex = 9;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.20);
                        column.Width = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "MARCA";
                        break;
                    case "precovenda":
                        column.DisplayIndex = 5;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.20);
                        column.Width = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "PREÇO";

                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
           
        }
        private void ovTXT_CodigoBarrasProduto_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    AtualizaProdutos(ovTXT_CodigoBarrasProduto.Text);

                    //DataRow drProduto = FuncoesProduto.GetProdutoPorCodigoPDV(ovTXT_CodigoBarrasProduto.Text.Trim());
                    //if (drProduto != null)
                    //{
                    //    if (!FuncoesProduto.ExisteTributoVigenteProduto(Convert.ToDecimal(drProduto["IDPRODUTO"])))
                    //    {
                    //        ovTXT_StatusConsulta.Text = string.Format("* O produto \"{0}\" não possui tributação vigênte. Verifique o cadastro do IBPT e tente novamente.", drProduto["PRODUTO"].ToString());
                    //        return;
                    //    }

                    //    ovTXT_DescricaoProduto.Text = drProduto["PRODUTO"].ToString();
                    //    ovTXT_Marca.Text = string.IsNullOrEmpty(drProduto["MARCA"].ToString()) ? "<Não Informado>" : drProduto["MARCA"].ToString();
                    //    ovTXT_ValorUnitario.Text = Convert.ToDecimal(drProduto["PRECOVENDA"]).ToString("n2");
                    //    ovTXT_UnidadeMedida.Text = drProduto["UNIDADEDEMEDIDA"].ToString();
                    //    ovTXT_StatusConsulta.Text = string.Empty;
                    //}
                    //else
                    //{
                    //    ovTXT_DescricaoProduto.Text = string.Empty;
                    //    ovTXT_Marca.Text = string.Empty;
                    //    ovTXT_ValorUnitario.Text = string.Empty;
                    //    ovTXT_UnidadeMedida.Text = string.Empty;

                    //    ovTXT_StatusConsulta.Text = "* Produto não encontrado. Verifique e tente novamente!";
                    //}
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void ovGRD_Produtos_CurrentCellChanged(object sender, EventArgs e)
        {


            //     ovTXT_DescricaoProduto.Text = ovGRD_Produtos.SelectedRows[1].ToString();
            //ovTXT_Marca.Text = string.IsNullOrEmpty(drProduto["MARCA"].ToString()) ? "<Não Informado>" : drProduto["MARCA"].ToString();
            //ovTXT_ValorUnitario.Text = Convert.ToDecimal(drProduto["PRECOVENDA"]).ToString("n2");
            //ovTXT_UnidadeMedida.Text = drProduto["UNIDADEDEMEDIDA"].ToString();
            //ovTXT_StatusConsulta.Text = string.Empty;
            //MyDataGrid.SelectedItem.Cells[1]
        }

        private void ovGRD_Produtos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            // if (ovGRD_Produtos.CurrentRow == null)



            ovTXT_DescricaoProduto.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "DESCRICAO").ToString();
            ovTXT_Marca.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "MARCA").ToString();
            ovTXT_UnidadeMedida.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "UNIDADEDEMEDIDA").ToString();
            ovTXT_CodigoBarras.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "CODIGODEBARRAS").ToString();
            ovTXT_ValorUnitario.Text = ZeusUtil.GetValueFieldDataRowView((ovGRD_Produtos.CurrentRow.DataBoundItem as System.Data.DataRowView), "PRECOVENDA").ToString();
            //  = ovGRD_Produtos.Rows[1].Cells[3].Value.ToString();// row.Cells[1].Value;
            //ovTXT_Peso.Focus();
        }

        private void ovGRD_Produtos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (ovGRD_Produtos.Columns[e.ColumnIndex].Name)
            {
                case "ValorUnitarioItem":
                case "ValorTotalItem":
                    e.Value = Convert.ToDecimal(e.Value).ToString("n2");
                    break;
            }
        }
        private void DisplayText(object sender, EventArgs e)
        {
            // string svalor = string.Format("{0:0.000}", sPeso.TrimStart(new char[] { '0' }));
            try
            {
                string sAux = sPeso;
                sAux = (Decimal.Parse(sPeso)).ToString();
                sAux = (Decimal.Parse(sPeso) / 100).ToString("f3");
                sAux = (Decimal.Parse(sPeso) / 1000).ToString("f3");
                Saida_Tela.Text = (Decimal.Parse(sPeso) / 1000).ToString("f3");
                sPeso = "";
                RxString = "";
            }
            catch(Exception ex)
            {
                sPeso = "00000";
                RxString = "00000";
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            buscarPeso();

        }

        private void buscarPeso()
        {
            try
            {
                abriConexaoBanlanca("S");
                 //  byte[] DadosPeso = new byte[6];
                 RxString = serialPort1.ReadExisting();
                //     DadosPeso = Encoding.ASCII.GetBytes(RxString);
                //        char[] chars = new char[DadosPeso.Length / sizeof(char)];
                //       System.Buffer.BlockCopy(DadosPeso, 0, chars, 0, DadosPeso.Length);

                //RxString = serialPort1.ReadTo("0");
                RxString = RxString.Replace("\u0002", "");
                sPeso = RxString.Substring(0, 6);
                string sTotal = RxString.Substring(7, 6);
                string sKg = RxString.Substring(13, 6);
                //	RxString = RxString.Replace("00.","0.");
                //	RxString = RxString.Replace(".",",");
                // int index = 6;
                //    int iAux = int.Parse(RxString.Substring(0, index));
                //  RxString = iAux.ToString();

                this.Invoke(new EventHandler(DisplayText));
            }
            catch (Exception ex)
            {
                sPeso = "Erro: pressione imprimir na balança";
                //   this.Invoke(new EventHandler(DisplayText));
            }
        }

        private void ovTXT_Peso_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!serialPort1.IsOpen) return;

            // If the port is Open, declare a char[] array with one element.
            char[] buff = new char[1];

            // Load element 0 with the key character.

            buff[0] = e.KeyChar;

            // Send the one character buffer.
            serialPort1.Write(buff, 0, 1);

            // Set the KeyPress event as handled so the character won't
            // display locally. If you want it to display, omit the next line.
            e.Handled = true;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F10:
                    metroButton1_Click(metroButton1, null);
                    break;

            }
            return base.ProcessDialogKey(keyData);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            TELAPDV.AtualizaQtde(Saida_Tela.Text, ovTXT_CodigoBarras.Text);
            if (serialPort1.IsOpen)
                serialPort1.Close();
            ovTXT_StatusConsulta.Visible = false;
            ovTXT_StatusConsulta.Text = "";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscarPeso();
        }
    }
}
