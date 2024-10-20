using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_Usuario : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE USUÁRIO";

        public FCO_Usuario()
        {
            InitializeComponent();
            AtualizaUsuarios("", "");
        }

        private void AtualizaUsuarios(string Login, string Nome)
        {
            gridControl1.DataSource = FuncoesUsuario.GetUsuarios(Nome, Login);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }


        private void ovBTN_Pesquisar_Click(object sender, EventArgs e)
        {
            AtualizaUsuarios("", "");
        }

        private void ovBTN_Novo_Click(object sender, EventArgs e)
        {
            FCA_Usuario t = new FCA_Usuario(new Usuario());
            t.ShowDialog(this);
            AtualizaUsuarios("", "");
            editarusuariometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void ovBTN_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal IDUsuario = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDUSUARIO").ToString()));
                FCA_Usuario t = new FCA_Usuario(FuncoesUsuario.GetUsuario(IDUsuario));
                t.ShowDialog(this);
                AtualizaUsuarios("", "");
            }
            catch (Exception)
            {

            }

            finally
            {
                editarusuariometroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
           
            
        }

        private void ovBTN_Excluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover o Usuário selecionado?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            { 
                decimal IDUsuario = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDUSUARIO").ToString()));
                try
                {
                    if (!FuncoesUsuario.Remover(IDUsuario))
                        throw new Exception("Não foi possível remover o Usuário.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaUsuarios("", "");
            }
            editarusuariometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void FCO_Usuario_Load(object sender, EventArgs e)
        {
            AtualizaUsuarios("", "");
        }

       

        private void gridControl1_Click(object sender, EventArgs e)
        {
            editarusuariometroButton4.Enabled = true;
            metroButton3.Enabled = true;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                decimal IDUsuario = decimal.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDUSUARIO").ToString()));
                FCA_Usuario t = new FCA_Usuario(FuncoesUsuario.GetUsuario(IDUsuario));
                t.ShowDialog(this);
                AtualizaUsuarios("", "");
                editarusuariometroButton4.Enabled = false;
                metroButton3.Enabled = false;
            }
            catch (Exception)
            {

                
            }

        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            editarusuariometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaUsuarios("","");
            editarusuariometroButton4.Enabled = false;
            metroButton3.Enabled = false;
        }
    }
}
