using PDV.CONTROLER.Funcoes;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class FCO_FormaDePagamento : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CONSULTA DE FORMA DE PAGAMENTO";
        public FCO_FormaDePagamento()
        {
            InitializeComponent();
            AtualizaFormasPagamento("", "");
        }

        private void AtualizaFormasPagamento(string Codigo, string Descricao)
        {
            gridControl1.DataSource = FuncoesFormaDePagamento.GetFormasDePagamento(Codigo, Descricao);
            FormatarGrid();
        }

        private void FormatarGrid()
        {

            Grids.FormatColumnType(ref gridView1, new List<string>() 
            { 
                "idbandeiracartao",
                "idformadepagamento1",
                "idbandeiracartao1",
                "codigo1",
                "descricao1",
                "ativo1",
                "identificacao1",
                "tef1",
                "transacao",
                "usa_calendario_comercial",
                "qtd_parcelas",
                "dias_intervalo",
                "fator_dup_sem_entrada",
                "fator_dup_com_entrada",
                "fator_cheq_com_entrada",
                "fator_cheq_sem_entrada",
                "periodicidade",
                "pdv",
                "idbandeiracartao2",
                "codigo2",
                "descricao2"
            }, GridFormats.VisibleFalse);

            Grids.FormatGrid(ref gridView1);
        }
        private void ovBTN_Novo_Click(object sender, System.EventArgs e)
        {
            FCA_FormaDePagamento t = new FCA_FormaDePagamento(new DAO.Entidades.FormaDePagamento());
            t.ShowDialog(this);
            AtualizaFormasPagamento("", "");
            DesabilitarBotoes();
        }

        private void ovBTN_Editar_Click(object sender, System.EventArgs e)
        {
            Editar();
        }

        private void ovBTN_Excluir_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(this, "Deseja remover a Forma de Pagamento selecionada?", NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                decimal IDFormaDePagamento = Grids.GetValorDec(gridView1, "IDFORMADEPAGAMENTO");
                try
                {
                    if (!FuncoesFormaDePagamento.Remover(IDFormaDePagamento))
                        throw new Exception("Não foi possível remover a Forma de Pagamento.");
                }
                catch (Exception Ex)
                {
                   MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AtualizaFormasPagamento("", "");
            }
            DesabilitarBotoes();
        }

        private void FCO_FormaDePagamento_Load(object sender, EventArgs e)
        {
            AtualizaFormasPagamento("", "");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            ovBTN_Editar_Click(sender,e);
            DesabilitarBotoes();
        }


        private void imprimriMetroButton_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
            DesabilitarBotoes();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Editar();            
        }
        private void Editar()
        {
            try
            {
                decimal IDFormaDePagamento = Grids.GetValorDec(gridView1, "IDFORMADEPAGAMENTO");
                FCA_FormaDePagamento t = new FCA_FormaDePagamento(FuncoesFormaDePagamento.GetFormaDePagamento(IDFormaDePagamento));
                t.ShowDialog(this);
                AtualizaFormasPagamento("", "");

            }
            catch (NullReferenceException)
            {

            }
            finally
            {

            }
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnRemover.Enabled = true;
        }

        private void atualizarMetroButton_Click(object sender, EventArgs e)
        {
            AtualizaFormasPagamento("", "");
            DesabilitarBotoes();
        }

        private void DesabilitarBotoes()
        {
            btnEditar.Enabled = btnRemover.Enabled = false;
        }
    }
}
