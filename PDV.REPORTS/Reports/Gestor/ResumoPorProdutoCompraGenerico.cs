using System;
using System.Drawing;
using PDV.DAO.Entidades;
using PDV.CONTROLER.Funcoes;
using System.IO;
using System.Data;
using PDV.DAO.QueryModels;

namespace PDV.REPORTS.Reports.Email_Gestor
{
    public partial class ResumoPorProdutoCompraGenerico : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dt = null;
        //Tipo
        //1-Entrada 
        //2-Saída
        public ResumoPorProdutoCompraGenerico(ResumoPorProdutoGenericoReportModel reportModel)
        {
            InitializeComponent();
            Emitente Emit = FuncoesEmitente.GetEmitente();
            Endereco End = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            UnidadeFederativa UnFed = FuncoesUF.GetUnidadeFederativa(End.IDUnidadeFederativa.Value);
            Municipio Mun = FuncoesMunicipio.GetMunicipio(End.IDMunicipio.Value);
            using (var ms = new MemoryStream(Emit.Logomarca))
                xrPictureBox1.Image = Image.FromStream(ms);
            
            dt = FuncoesPedidoCompra
                    .GetComprasPorProduto(reportModel);
            
            CalcularPercentualAplicado();
            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
            tituloLabel.Text = reportModel.Titulo;
            dataPeriodo.Text =
                $"Período de {reportModel.DataDe.ToString("dd/MM/yyyy")} até {reportModel.DataAte.ToString("dd/MM/yyyy")} ";


        }

        private void CalcularPercentualAplicado()
        {
            dt.Columns.Add(new DataColumn("PERCENTUAL", typeof(string)));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var precoCusto = Convert.ToDecimal(dt.Rows[i]["PRECOCUSTO"]);
                var precoVenda = Convert.ToDecimal(dt.Rows[i]["PRECOVENDA"]);
                if (precoCusto == 0)
                    dt.Rows[i]["PERCENTUAL"] = 100 + "%";
                else
                    dt.Rows[i]["PERCENTUAL"] = Math.Round(precoVenda / precoCusto * 100 - 100, 2) + "%";
            }
        }
    }
}
