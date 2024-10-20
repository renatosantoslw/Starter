using System.Data;
using PDV.CONTROLER.FuncoesRelatorios;

namespace PDV.REPORTS.Reports.ProdutosPorFornecedor
{
    public partial class ProdutosPorFornecedor : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal IDFORNECEDOR, IDMARCA, IDCATEGORIA, IDSUBCATEGORIA;

        public ProdutosPorFornecedor(string UsuarioEmissao,
            string Fornecedor,
            string Marca,
            string Categoria,
            string SubCategoria,
            decimal IDFornecedor,
            decimal IDMarca,
            decimal IDCategoria,
            decimal IDSubcategoria)
        {
            InitializeComponent();

            IDFORNECEDOR = IDFornecedor;
            IDMARCA = IDMarca;
            IDCATEGORIA = IDCategoria;
            IDSUBCATEGORIA = IDSubcategoria;

            ovTXT_Fornecedor.Text = Fornecedor;
            ovTXT_Marca.Text = Marca;
            ovTXT_Categoria.Text = Categoria;
            ovTXT_SubCategoria.Text = SubCategoria;

            ovSR_Cabecalho.ReportSource = new Cabecalho(UsuarioEmissao);
        }

        private void ProdutosPorFornecedor_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GroupFornecedorCategoria.GroupFields.Add(new DevExpress.XtraReports.UI.GroupField("idfornecedor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending));
            DataTable dt = FuncoesProdutosPorFornecedor.GetProdutosPorFornecedor(IDFORNECEDOR, IDMARCA, IDCATEGORIA, IDSUBCATEGORIA);
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }
    }
}
