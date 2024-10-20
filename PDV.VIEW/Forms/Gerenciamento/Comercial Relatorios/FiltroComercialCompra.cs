using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.QueryModels;
using PDV.REPORTS.Reports.Email_Gestor;
using PDV.UTIL;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento.Comercial_Relatorios
{    
    public partial class FiltroComercialCompra : DevExpress.XtraEditors.XtraForm
    {

        private List<decimal> IdsOperacoes
        {
            get
            {
                var ids = new List<decimal>();
                foreach (var linha in gridView1.GetSelectedRows())
                    ids.Add(Grids.GetValorDec(gridView1, "COD", linha));
                return ids;
            }
        }

        public class FiltrarPorModel
        {
            public FiltrarPorModel(string nomeColunaBanco, string descricao)
            {
                NomeColunaBanco = nomeColunaBanco;
                Descricao = descricao;
            }

            public string NomeColunaBanco { get; set; }

            public string Descricao { get; set; }
        }

        public FiltroComercialCompra()
        {
            InitializeComponent();
            AtualizarOperacoes();
            dateEdit1.DateTime = DateTime.Now;
            dateEdit2.DateTime = DateTime.Now;
            PreecherComboBoxFiltrarPor();
        }

        private void PreecherComboBoxFiltrarPor()
        {
            comboBoxFiltrarPor.DataSource = new List<FiltrarPorModel>
            {
                new FiltrarPorModel("DATAEMISSAO", "Data de cadastro"),
                new FiltrarPorModel("DATAFATURAMENTO", "Data de faturamento")
            };
            comboBoxFiltrarPor.DisplayMember = "Descricao";
            comboBoxFiltrarPor.ValueMember = "NomeColunaBanco";
        }

        private void AtualizarOperacoes()
        {
            try
            {
                var tiposDeOperacao = FuncoesTipoDeOperacao.GetTiposDeOperacaoPorTipoDeMovimento(DAO.Entidades.TipoDeOperacao.Entrada)
                                                            .Select(s => new { COD = s.IDTipoDeOperacao, Nome = s.Nome })
                                                            .OrderBy(x => x.COD).ToList();
                gridControl1.DataSource = tiposDeOperacao;
                gridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                var titulo = "Compras Por Produto Agrupado";

                var rel = new ResumoPorProdutoCompraGenerico(new ResumoPorProdutoGenericoReportModel
                {
                    FiltrarPor = comboBoxFiltrarPor.SelectedValue.ToString(),
                    DataDe = dateEdit1.DateTime.Date,
                    DataAte = dateEdit2.DateTime.Date,
                    Status = comboBoxStatus.Text,
                    Titulo = titulo,
                    IDsOperacaoString = FuncoesUteis.ConverterListParaString(IdsOperacoes)
                });
                using (ReportPrintTool printTool = new ReportPrintTool(rel))
                {
                    printTool.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Validar()
        {
            if (comboBoxFiltrarPor.SelectedValue == null)
                throw new Exception("Preencha o campo 'Filtrar por'");

            if (comboBoxStatus.Text == "")
                throw new Exception("Selecione um status");

            if (IdsOperacoes.Count() == 0)
                throw new Exception("Selecione no mínimo uma operação");
        }

        private void FiltroComercialCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
