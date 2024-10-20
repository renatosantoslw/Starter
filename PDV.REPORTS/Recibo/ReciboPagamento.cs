using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PDV.DAO.Entidades;
using PDV.CONTROLER.Funcoes;
using System.Data;
using System.IO;

namespace PDV.REPORTS.Recibo
{
    public partial class ReciboPagamento : DevExpress.XtraReports.UI.XtraReport
    {
        public ReciboPagamento(PDV.DAO.Entidades.Recibo recibo)
        {
            InitializeComponent();

            Emitente Emit = FuncoesEmitente.GetEmitente();
            Endereco End = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            UnidadeFederativa UnFed = FuncoesUF.GetUnidadeFederativa(End.IDUnidadeFederativa.Value);
            Municipio Mun = FuncoesMunicipio.GetMunicipio(End.IDMunicipio.Value);
            using (var ms = new MemoryStream(Emit.Logomarca))
                xrPictureBox1.Image = Image.FromStream(ms);

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("Pessoa");
            dt.Columns.Add("PessoaEndereco");
            dt.Columns.Add("Referente");
            dt.Columns.Add("Valor");
            dt.Columns.Add("Importacia");
            dt.Columns.Add("Emitente");
            dt.Columns.Add("EmitenteEndereco");
            dt.Columns.Add("EmitenteDocumento");
            dt.Columns.Add("Data");
            dr = dt.NewRow();

            dr["Pessoa"] = recibo.Pessoa;
            dr["PessoaEndereco"] = recibo.PessoaEndereco;
            dr["Referente"] = recibo.Referente;
            dr["Valor"] = recibo.Valor.ToString("c2");
            dr["Importacia"] = recibo.Importancia;
            dr["Emitente"] = recibo.Emitente;
            dr["EmitenteEndereco"] = recibo.EmitenteEndereco;
            dr["EmitenteDocumento"] = recibo.EmitenteDocumento;
            dr["Data"] = recibo.Data;
            dt.Rows.Add(dr);
             dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
        }

    }
}
