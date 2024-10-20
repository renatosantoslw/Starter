using DevExpress.XtraEditors;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Custom;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PDV.UTIL.FORMS.Forms.Caixa
{
    public partial class ManutencaoCaixa : DevExpress.XtraEditors.XtraForm
    {
        private FluxoCaixa Fluxo { get; set; } = null;

        private string NOME_TELA = "Manutenção Caixa";

        private Usuario Logado = null;
        DataTable fluxos = null;
        DataTable sangrias = null;
        DataTable suprimentos = null;

        public ManutencaoCaixa(Usuario User)
        {
            InitializeComponent();
            Logado = User;
            Fluxo = FuncoesFluxoCaixa.GetFluxoCaixaAbertoUsuario(Logado.IDUsuario);
            fluxos = FuncoesFluxoCaixa.GetDataTableFluxoCaixaAbertoUsuario(Logado.IDUsuario);
            grdFluxo.DataSource = fluxos;
            GetSangrias();
            grdSangria.DataSource = sangrias;
            GetSuprimentos();
            grdSuprimento.DataSource = suprimentos;
            GridHeader();
        }

        private void GridHeader()
        {
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "Valor";
            gridView1.Columns[2].Caption = "Data";
            gridView1.Columns[2].OptionsColumn.AllowEdit = false;
            gridView1.Columns[3].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[5].Visible = false;

            gridView2.Columns[0].Visible = false;
            gridView2.Columns[1].Visible = false;
            gridView2.Columns[2].Visible = false;
            gridView2.Columns[3].Visible = false;
            gridView2.Columns[4].Caption = "Data";
            gridView2.Columns[4].OptionsColumn.AllowEdit = false;
            gridView2.Columns[5].Caption = "Valor";
            gridView2.Columns[6].Caption = "Observação";

            gridView3.Columns[0].Visible = false;
            gridView3.Columns[1].Visible = false;
            gridView3.Columns[2].Visible = false;
            gridView3.Columns[3].Visible = false;
            gridView3.Columns[4].Caption = "Data";
            gridView3.Columns[4].OptionsColumn.AllowEdit = false;
            gridView3.Columns[5].Caption = "Valor";
            gridView3.Columns[6].Caption = "Observação";
        }

        private void GetSangrias()
        {
            sangrias = FuncoesSangriaCaixa.GetSangriasPorFluxoDeCaixa(Fluxo.IDFluxoCaixa);
        }

        private void GetSuprimentos()
        {
            suprimentos = FuncoesSuprimentoCaixa.GetSuprimentoPorFluxoDeCaixa(Fluxo.IDFluxoCaixa);
        }

        private void Alert(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            foreach(DataRow dr in fluxos.Rows)
            {
                FuncoesFluxoCaixa.Salvar(new DataTableParser<FluxoCaixa>().ParseDataRow(dr), DAO.Enum.TipoOperacao.UPDATE);
            }
            foreach(DataRow dr in suprimentos.Rows)
            {   
                SuprimentoCaixa suprimento = new DataTableParser<SuprimentoCaixa>().ParseDataRow(dr);
                FuncoesSuprimentoCaixa.Update(suprimento);
            }
            foreach(DataRow dr in sangrias.Rows)
            {
                FuncoesSangriaCaixa.Update(new DataTableParser<SangriaCaixa>().ParseDataRow(dr));
            }
            Close();
        }

    }
}