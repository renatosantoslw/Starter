using PDV.CONTROLER.Funcoes;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_BandeiraCartao : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE BANDEIRA DO CARTÃO DE CRÉDITO/DÉBITO";

        public FCO_BandeiraCartao()
        {
            InitializeComponent();            
        }

        private void AtualizaBandeiras(string Codigo, string Descricao)
        {
            gridControl1.DataSource = FuncoesBandeiraCartao.GetBandeiras(Codigo, Descricao);
            FormatarGrid();
        }

        private void FormatarGrid()
        {
            Grids.FormatGrid(ref gridView1);
        }

        private void FCO_BandeiraCartao_Load(object sender, EventArgs e)
        {
            AtualizaBandeiras("", "");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = btnRemover.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaBandeiras("","");
        }

        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FCA_BandeiraCartao t = new FCA_BandeiraCartao(new DAO.Entidades.BandeiraCartao());
            t.ShowDialog(this);
            AtualizaBandeiras("", "");
            DesabilitarBotoes();
        }

        private void editarCategoriaMetroButton4_Click(object sender, EventArgs e)
        {
            Editar();
        }
        private void Editar()
        {
            try
            {
                decimal IDBandeira = Grids.GetValorDec(gridView1, "IDBANDEIRACARTAO");
                FCA_BandeiraCartao t = new FCA_BandeiraCartao(FuncoesBandeiraCartao.GetBandeira(IDBandeira));
                t.ShowDialog(this);
                AtualizaBandeiras("", "");
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                DesabilitarBotoes();
            }
        }

        private void DesabilitarBotoes()
        {
            btnEditar.Enabled = btnRemover.Enabled = false;
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Banderia selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    decimal IDBandeira = Grids.GetValorDec(gridView1, "IDBANDEIRACARTAO");
                    try
                    {
                        if (!FuncoesBandeiraCartao.Remover(IDBandeira))
                            throw new Exception("Não foi possível remover a Bandeira.");
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    AtualizaBandeiras("", "");
                }
                catch (Exception EX)
                {
                    MessageBox.Show(this, EX.Message, NOME_TELA);
                }

            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }
    }
}
