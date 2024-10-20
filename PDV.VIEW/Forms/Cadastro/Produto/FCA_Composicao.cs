using DevExpress.XtraRichEdit.Layout;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using System;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Composicao : DevExpress.XtraEditors.XtraForm
    {

        public ProdutoComposicao Composicao { get; set; }

        public FCA_Composicao(decimal idComposicao)
        {
            Composicao = FuncoesProdutoComposicao.GetComposicao(idComposicao);

            InitializeComponent();

            PreencherTela();
        }

        public FCA_Composicao(ProdutoComposicao composicao = null)
        {
            Composicao = composicao ?? new ProdutoComposicao();

            InitializeComponent();

            PreencherTela();
        }

        private void PreencherTela()
        {
            PreencherMateriaPrima();
            PreencherQuantidade();
        }

        private void PreencherQuantidade()
        {
            cmbMateriaPrima.DataSource = FuncoesProduto.GetProdutosPorTipo(Produto.MateriaPrima);
            cmbMateriaPrima.DisplayMember = "descricao";
            cmbMateriaPrima.ValueMember = "idproduto";
            cmbMateriaPrima.SelectedValue = Composicao.IdProduto;
        }

        private void PreencherMateriaPrima()
        {
            spinQuantidade.Value = Composicao.Quantidade;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
                Salvar();
        }

        private void Salvar()
        {
            try
            {
                Validar();
                Composicao.IdProduto = (decimal)cmbMateriaPrima.SelectedValue;
                Composicao.Quantidade = spinQuantidade.Value;
                Close();
            }
            catch (Exception exception)
            {
                var msg = exception.Message;
                MensagemErro(msg);
            }
           
        }

        private void Validar()
        {

            if (cmbMateriaPrima.SelectedValue == null)
                throw new Exception("Escolha um produto");

            if (spinQuantidade.Value <= 0)
                throw new Exception("A quantidade não poder ser menor ou igual a zero");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DialogResult MensagemErro(string msg)
        {
            return MessageBox.Show(msg, "Cadastro de Composição", MessageBoxButtons.OK ,MessageBoxIcon.Error);
        }
    }
}
