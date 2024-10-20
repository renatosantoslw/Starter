using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.VIEW.App_Context;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_Servico : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE SERVIÇO";

        public Servico Servico { get; set; }

        public decimal IDServico 
        { 
            get => Convert.ToDecimal(textEditID.EditValue);
            set => textEditID.EditValue = value;
        }

        public string Descricao
        {
            get => textEditDescricao.EditValue.ToString();
            set => textEditDescricao.EditValue = value;
        }

        public decimal IDCategoria
        {
            get => Convert.ToDecimal(gridLookUpEditCategoria.EditValue);
            set => gridLookUpEditCategoria.EditValue = value;
        }

        public decimal IDUnidadeDeMedida
        {
            get => Convert.ToDecimal(gridLookUpEditUnidadeDeMedida.EditValue);
            set => gridLookUpEditUnidadeDeMedida.EditValue = value;
        }

        public decimal Valor
        {
            get => Convert.ToDecimal(spinEditValor.EditValue);
            set => spinEditValor.EditValue = value;
        }

        public FCA_Servico(Servico servico)
        {
            Inicializar(servico);
        }

        public FCA_Servico(decimal idServico)
        {
            var servico = FuncoesServico.GetServico(idServico);
            Inicializar(servico);
        }

        private void Inicializar(Servico servico)
        {
            InitializeComponent();
            Servico = servico;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            PreencherGridLookUps();
            IDServico = Servico.IDServico;
            IDCategoria = Servico.IDCategoria;
            IDUnidadeDeMedida = Servico.IDUnidadeDeMedida;
            Descricao = Servico.Descricao;
            Valor = Servico.Valor;
        }

        private void PreencherGridLookUps()
        {
            gridLookUpEditCategoria.Properties.DataSource = FuncoesCategoria
                .GetCategorias()
                .OrderBy(u => u.Descricao)
                .Select(c => new { c.IDCategoria, c.Descricao })
                .ToList();
            gridLookUpEditCategoria.Properties.ValueMember = "IDCategoria";
            gridLookUpEditCategoria.Properties.DisplayMember = "Descricao";

            gridLookUpEditUnidadeDeMedida.Properties.DataSource = FuncoesUnidadeMedida
                .GetUnidadesMedida()
                .OrderBy(u => u.Descricao)
                .Select(u => new { u.IDUnidadeDeMedida, u.Descricao })
                .ToList();
            gridLookUpEditUnidadeDeMedida.Properties.ValueMember = "IDUnidadeDeMedida";
            gridLookUpEditUnidadeDeMedida.Properties.DisplayMember = "Descricao";

        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            try
            {
                PDVControlador.BeginTransaction();
                PopularAtributos();
                FuncoesServico.Salvar(Servico);
                PDVControlador.Commit();
                Alert("Serviço salvo com sucesso");
                Close();
            }
            catch (Exception exception)
            {
                PDVControlador.Rollback();
                Alert(exception.Message);
            }
        }

        private void PopularAtributos()
        {
            Servico.IDServico = IDServico;
            Servico.IDCategoria = IDCategoria;
            Servico.IDUnidadeDeMedida = IDUnidadeDeMedida;
            Servico.Descricao = Descricao;
            Servico.Valor = Valor;
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void Alert(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}