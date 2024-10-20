using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
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
    public partial class Tabelas : DevExpress.XtraEditors.XtraForm
    {
        public Tabelas()
        {
            InitializeComponent();
            carregardados();
        }

        private void carregardados()
        {
            try
            {
                gridControl1.DataSource = FuncoesTabela.GetTabelas();
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                gridView1.BestFitColumns();
                
                AjustaHeaderTextGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AjustaHeaderTextGrid()
        {
            try
            {
                gridView1.Columns[0].Caption = "ID";
                gridView1.Columns[1].Caption = "NOME";
                gridView1.Columns[2].Caption = "GRUPO";
            }
            catch (Exception)
            {

                
            }
           
           
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(tabelaTextBox.Text))
                {
                    MessageBox.Show("Informe a tabela","Erro");
                    return;
                }
                if (string.IsNullOrEmpty(grupoTextBox.Text))
                {
                    MessageBox.Show("Informe o grupo", "Erro");
                    return;
                }
                Tabela tabelas = new Tabela()
                {
                   
                    Nome = tabelaTextBox.Text,
                    Grupo = grupoTextBox.Text,
                };
                int ID = int.Parse(idTextBox.Text);
                if(ID ==0)
                {
                
                    tabelas.ID = ID = PDV.DAO.DB.Utils.Sequence.GetNextID("TABELA", "ID");
                    FuncoesTabela.Salvar(tabelas,DAO.Enum.TipoOperacao.INSERT);
                }
                else
                {
                    tabelas.ID = decimal.Parse(idTextBox.Text);
                    FuncoesTabela.Salvar(tabelas, DAO.Enum.TipoOperacao.UPDATE);
                }
       
                carregardados();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void limpar()
        {
            idTextBox.Text = "0";
            tabelaTextBox.Text = "";
            grupoTextBox.Text = "";
            tabelaTextBox.Focus();
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(idTextBox.Text))
                {
                    MessageBox.Show("Informe a tabela para excluir", "Erro");
                    return;
                }
                FuncoesTabela.Excluir(decimal.Parse(idTextBox.Text));
                carregardados();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                idTextBox.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString();
                tabelaTextBox.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOME").ToString();
                grupoTextBox.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GRUPO").ToString();
            }
            catch (Exception)
            {

               
            }
           
        }
    }
}
