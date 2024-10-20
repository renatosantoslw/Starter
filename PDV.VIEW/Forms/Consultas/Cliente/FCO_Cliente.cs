using DevExpress.XtraPrinting;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Drawing;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Cliente : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE CLIENTES";
        public Cliente Cliente { get; set; }

        public List<decimal> IdsSelecionados
        {
            get
            {
                var ids = new List<decimal>();
                foreach (var linha in gridView1.GetSelectedRows())
                    ids.Add(Grids.GetValorDec(gridView1, "IDCLIENTE", linha));
                
                return ids;
            }
        }

        public FCO_Cliente(bool PDV = false)
        {
            InitializeComponent();
            Cliente = new Cliente();
            AtualizaClientes(null,null, null);
            selecionarSimpleButton.Visible = PDV;



            //icones
            Bitmap bitmapNovo = IconChar.PlusSquare.ToBitmap(Color.DarkGreen, 24);
            Bitmap bitmapAssociarVendedor = IconChar.UserTie.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapEditar = IconChar.PenSquare.ToBitmap(Color.DarkOrange, 24);
            Bitmap bitmapRemover = IconChar.MinusSquare.ToBitmap(Color.Firebrick, 24);
            Bitmap bitmapAtualizar = IconChar.SyncAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapMovimento = IconChar.ExchangeAlt.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapImprimir = IconChar.Print.ToBitmap(Color.SteelBlue, 24);
            Bitmap bitmapBuscarProdutoNuvem = IconChar.CloudDownloadAlt.ToBitmap(Color.SteelBlue, 24);


            metroButton5.ImageOptions.Image = bitmapNovo;
            btnAssociarVendedor.ImageOptions.Image = bitmapAssociarVendedor;
            editarMetroButton.ImageOptions.Image = bitmapEditar;
            excluircliente.ImageOptions.Image = bitmapRemover;//remover
            atualizarMetroButton.ImageOptions.Image = bitmapAtualizar;
            imprimriMetroButton.ImageOptions.Image = bitmapImprimir;
           



        }

        private void AtualizaClientes(string Nome_RazaoSocial, string CPF_CNPJ, string InscricaoEstadual)
        {
         
            gridControl1.DataSource = FuncoesCliente.GetClientes(Nome_RazaoSocial, CPF_CNPJ, InscricaoEstadual);   
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            Grids.FormatColumnType(ref gridView1, new List<string>() 
            {

          
                "CODVENDEDOR",
                "LOGRADOURO",
                "NUMERO",
                "CEP",
                "EMAIL"
            }, GridFormats.VisibleFalse);

            Grids.FormatGrid(ref gridView1);
        }

        private void ovBTN_Novo_Click(object sender, System.EventArgs e)
        {
            FCA_Cliente t = new FCA_Cliente(new DAO.Entidades.Cliente());
            t.ShowDialog(this);
            AtualizaClientes("", "", "");
            editarMetroButton.Enabled = false;
            excluircliente.Enabled = false;
        }
      
        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o cliente selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    decimal IDCliente = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCLIENTE").ToString());
                    if (!FuncoesCliente.Remover(IDCliente))
                    {
                        MessageBox.Show(this, "Não foi possível remover o cliente.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    AtualizaClientes(null, null, null);
                    editarMetroButton.Enabled = false;
                }
                catch (Exception EX)
                {
                    MessageBox.Show(this, EX.Message, NOME_TELA);
                }
               
            }
            editarMetroButton.Enabled = false;
            excluircliente.Enabled = false;
        }


        private void FCO_Cliente_Load(object sender, EventArgs e)
        {
           
        }
     
        private void gridView1_Click(object sender, EventArgs e)
        {
            editarMetroButton.Enabled = true;
            excluircliente.Enabled = true;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                decimal IDCliente = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCLIENTE").ToString());
                FCA_Cliente t = new FCA_Cliente(FuncoesCliente.GetCliente(IDCliente));
                t.ShowDialog(this);
                AtualizaClientes(null, null, null);
                editarMetroButton.Enabled = false;
            }
            catch (Exception)
            {
            }            
        }
        public decimal IDCliente { get; set; }
        private void editarMetroButton_Click(object sender, EventArgs e)
        {

            try
            {
            
                IDCliente = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCLIENTE").ToString()));
                FCA_Cliente t = new FCA_Cliente(FuncoesCliente.GetCliente(IDCliente));
                t.ShowDialog(this);
                AtualizaClientes(null, null, null);
            }
            catch (NullReferenceException)
            {
;
            }
            finally
            {
                editarMetroButton.Enabled = false;
                excluircliente.Enabled = false;
            }
            
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarMetroButton.Enabled = true;
            excluircliente.Enabled = true;
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            editarMetroButton.Enabled = false;
            excluircliente.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaClientes("","","");
            editarMetroButton.Enabled = false;
            excluircliente.Enabled = false;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            editarMetroButton.Enabled = false;
            excluircliente.Enabled = false;
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase printingSystemBase = e.PrintingSystem as PrintingSystemBase;
            printingSystemBase.PageSettings.Landscape = true;
            printingSystemBase.PageSettings.LeftMargin =
            printingSystemBase.PageSettings.RightMargin =
            printingSystemBase.PageSettings.TopMargin =
            printingSystemBase.PageSettings.BottomMargin = 5;
        }

        private void selecionarSimpleButton_Click(object sender, EventArgs e)
        {
            IDCliente = Grids.GetValorDec(gridView1, "IDCLIENTE");
            Cliente = FuncoesCliente.GetCliente(IDCliente);
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new AssociarVendedorForm(IdsSelecionados).ShowDialog();
            AtualizaClientes("", "", "");
        }

        private void btnAssociarVendedor_Click(object sender, EventArgs e)
        {
            new AssociarVendedorForm(IdsSelecionados).ShowDialog();
            AtualizaClientes("", "", "");
        }
    }
}
