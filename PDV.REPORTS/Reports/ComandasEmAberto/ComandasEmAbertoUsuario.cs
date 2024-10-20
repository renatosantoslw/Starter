using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PDV.CONTROLER.FuncoesRelatorios;
using System.Data;

namespace PDV.REPORTS.Reports.ComandasEmAberto
{
    public partial class ComandasEmAbertoUsuario : DevExpress.XtraReports.UI.XtraReport
    {
        public ComandasEmAbertoUsuario(decimal IDUsuario, decimal IDFluxoCaixa, string Usuario, string UsuarioEmissao)
        {
            InitializeComponent();

            ovSR_Cabecalho.ReportSource = new Cabecalho(UsuarioEmissao);
            ovTXT_Usuario.Text = Usuario;

            DataTable dt = FuncoesComandaEmAberto.GetDados_ComandasEmAberto(IDUsuario, IDFluxoCaixa);
            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }
    }
}
