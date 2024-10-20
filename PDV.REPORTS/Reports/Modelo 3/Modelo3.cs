using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Data.Browsing.Design;
using DevExpress.ExpressApp;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLER.FuncoesRelatorios;
using PDV.DAO.Entidades;
using PDV.UTIL.Components;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using static System.Convert;
namespace PDV.REPORTS.Reports.Modelo_3
{ 
    public partial class Modelo3 : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable dt = new DataTable();
        public decimal IdVenda { get; set; }

        public Modelo3(decimal idVenda)
        {

            InitializeComponent();
            IdVenda = idVenda;

            Emitente Emit = FuncoesEmitente.GetEmitente();
            Endereco End = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            UnidadeFederativa UnFed = FuncoesUF.GetUnidadeFederativa(End.IDUnidadeFederativa.Value);
            Municipio Mun = FuncoesMunicipio.GetMunicipio(End.IDMunicipio.Value);
            using (var ms = new MemoryStream(Emit.Logomarca))
                xrPictureBox1.Image = Image.FromStream(ms);

            dt = FuncoesPedidoVendaTermica.GetDAVProdutoAcabadoSomente(idVenda);

            GerarColunaTotal();

            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;

        }


        private void GerarColunaTotal()
        {
            AdicionarColunaTotal();

            for (int i = 0; i < dt.Rows.Count; i++)
                CalcularTotais(dt.Rows[i]);
        }

        private void CalcularTotais(DataRow dataRow)
        {            
            var quantidade = ToDecimal(dataRow["quantidade"]);
            var area = ToDecimal(dataRow["area"]);
            var preco = ToDecimal(dataRow["valor"]);
            var desconto = ToDecimal(dataRow["desconto"]);
            var total  = ItemVendaUtil.GetTotalItem(quantidade, preco, desconto, area != 0 ? area : 1);
            dataRow["total"] = total;

            if (dataRow["valoravistaproposto"].GetType() != typeof(DBNull))
            {
                if (ToDecimal(dataRow["valoravistaproposto"]) == 0)
                    labelValorAVista.Visible = textoValorAVista.Visible = false;
            }
            else
            {
                labelValorAVista.Visible = textoValorAVista.Visible = false;
            }              
        }

        private void AdicionarColunaTotal()
        {
            dt.Columns.Add(new DataColumn("total", typeof(decimal)));
        }
    }
}
