using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using PDV.CONTROLER.FuncoesRelatorios;
using PDV.DAO.Entidades;
using PDV.CONTROLER.Funcoes;
using System.IO;

namespace PDV.REPORTS.Reports.Modelo2
{
    public partial class Modelo2DuasVias : DevExpress.XtraReports.UI.XtraReport
    {
        int subreportRowsCount = 4;
        int Itens = 0;
        decimal _IDVENDA = 0;
        public Modelo2DuasVias(decimal IDVENDA)
        {
            _IDVENDA = IDVENDA;
            InitializeComponent();
            Emitente Emit = FuncoesEmitente.GetEmitente();
            Endereco End = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            UnidadeFederativa UnFed = FuncoesUF.GetUnidadeFederativa(End.IDUnidadeFederativa.Value);
            Municipio Mun = FuncoesMunicipio.GetMunicipio(End.IDMunicipio.Value);
            using (var ms = new MemoryStream(Emit.Logomarca))
            {
                xrPictureBox1.Image = Image.FromStream(ms);
                xrPictureBox2.Image = Image.FromStream(ms);
            }
            empresaXrLabel.Text = Emit.RazaoSocial;
            cnpjxrLabel.Text = Emit.CNPJ;
            enderecoxrLabel.Text = $"{End.Logradouro}, {End.Numero}, {End.Bairro} , {Mun.Descricao} - {UnFed.Sigla}";
            telefoneEmpresaXrLabel.Text = End.Telefone;

            Empresa2.Text = Emit.RazaoSocial; ;
            endereco2.Text = $"{End.Logradouro}, {End.Numero}, {End.Bairro} , {Mun.Descricao} - {UnFed.Sigla}";
            Telefone2.Text = End.Telefone;
            documento2.Text = Emit.CNPJ;


            DataTable dt = FuncoesPedidoVendaTermica.GetDAV(IDVENDA);
            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
            Itens = dt.Rows.Count;

            for (int i = 0; i < Itens; i++)
                dt.Rows[i]["observacao"] = dt.Rows[i]["observacao"]
                    .ToString()
                    .Replace("{%", "");


            xrSubreport2.ReportSource = new SubRelatorioModelo2(_IDVENDA);
            xrSubreport1.ReportSource = new SubRelatorioModelo2(_IDVENDA);

        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int i = Convert.ToInt32(this.GetCurrentColumnValue("calculatedField1"));
            XtraReport report = ((XRSubreport)sender).ReportSource;
            int minIndex = i * subreportRowsCount + 1;
            report.FilterString = "[codigoProduto]<" + (minIndex + subreportRowsCount).ToString() + "AND [codigoProduto]>= " + minIndex.ToString();

        }

        private void calculatedField1_GetValue(object sender, GetValueEventArgs e)
        {
            try
            {
                e.Value = ((Itens) / subreportRowsCount);
            }
            catch (Exception)
            {

               
            }
            
        }

        private void impressaoDavC_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
            
        }
    }
}
