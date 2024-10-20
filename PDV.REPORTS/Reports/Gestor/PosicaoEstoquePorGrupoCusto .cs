using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PDV.DAO.Entidades;
using PDV.CONTROLER.Funcoes;
using System.IO;
using System.Data;

namespace PDV.REPORTS.Reports.Email_Gestor
{
    public partial class PosicaoEstoquePorGrupoCusto : DevExpress.XtraReports.UI.XtraReport
    {
        public PosicaoEstoquePorGrupoCusto()
        {
            InitializeComponent();
            Emitente Emit = FuncoesEmitente.GetEmitente();
            Endereco End = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            UnidadeFederativa UnFed = FuncoesUF.GetUnidadeFederativa(End.IDUnidadeFederativa.Value);
            Municipio Mun = FuncoesMunicipio.GetMunicipio(End.IDMunicipio.Value);
            using (var ms = new MemoryStream(Emit.Logomarca))
                xrPictureBox1.Image = Image.FromStream(ms);

            DataTable dt = FuncoesProduto.GetPosicaoEstoque();
            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
        }

    }
}
