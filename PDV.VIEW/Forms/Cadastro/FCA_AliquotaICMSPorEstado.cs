using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_AliquotaICMSPorEstado : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE ALÍQUOTA DE ICMS POR ESTADO";
        private DataTable UNIDADES = null;
        public FCA_AliquotaICMSPorEstado()
        {
            InitializeComponent();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();


                foreach (DataRow dr in UNIDADES.Rows)
                    if (!FuncoesUF.Salvar(EntityUtil<UnidadeFederativa>.ParseDataRow(dr), TipoOperacao.UPDATE))
                        throw new Exception("Não foi possível salvar as Alíquotas.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Alíquotas salvas com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Unidades.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Unidades.Width;
            foreach (DataGridViewColumn column in ovGRD_Unidades.Columns)
            {
                switch (column.Name)
                {
                    case "sigla":
                        column.DisplayIndex = 1;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
                        column.Width = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "UF";
                        column.ReadOnly = true;
                        break;
                    case "aliquotainter":
                        column.DisplayIndex = 2;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.29);
                        column.Width = Convert.ToInt32(WidthGrid * 0.29);
                        column.HeaderText = "% ICMS INTERESTADUAL";
                        break;
                    case "aliquotaintra":
                        column.DisplayIndex = 3;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.29);
                        column.Width = Convert.ToInt32(WidthGrid * 0.29);
                        column.HeaderText = "% ICMS INTERNA";
                        break;
                    case "fcp":
                        column.DisplayIndex = 4;
                        column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.29);
                        column.Width = Convert.ToInt32(WidthGrid * 0.29);
                        column.HeaderText = "% FCP";
                        break;
                    default:
                        column.Visible = false;
                        break;
                }
            }
        }

        private void FCA_AliquotaICMSPorEstado_Load(object sender, EventArgs e)
        {
            UNIDADES = FuncoesUF.GetUnidadesFederativaComAliquotasICMS();
            ovGRD_Unidades.DataSource = UNIDADES;
            AjustaHeaderTextGrid();
        }

        private void FCA_AliquotaICMSPorEstado_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
