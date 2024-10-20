using DevExpress.Data;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using System;
using System.Data;

namespace PDV.REPORTS.Reports.PedidoDeCompra
{
    public partial class ReportPedidoCompra : DevExpress.XtraReports.UI.XtraReport
    {
        private Usuario UsuarioEmissao = null;
        private decimal IDPedidoCompra = -1;

        public ReportPedidoCompra(Usuario _UsuarioEmissao, decimal _IDPedidoCompra)
        {
            InitializeComponent();
            UsuarioEmissao = _UsuarioEmissao;
            IDPedidoCompra = _IDPedidoCompra;

            ovTXT_NumeroPedido.Text = "Nº " + IDPedidoCompra.ToString();
            CarregarEmitente();
        }

        private void CarregarEmitente()
        {
            Emitente Emit = FuncoesEmitente.GetEmitente();
            Endereco End = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            UnidadeFederativa UnFed = FuncoesUF.GetUnidadeFederativa(End.IDUnidadeFederativa.Value);
            Municipio Mun = FuncoesMunicipio.GetMunicipio(End.IDMunicipio.Value);

            ovTXT_NomeEmpresa.Text = Emit.NomeFantasia;
            ovTXT_CNPJ.Text = Emit.CNPJ;
            ovTXT_InscricaoEstadual.Text = Emit.InscricaoEstadual;
            ovTXT_Endereco.Text = $"{End.Logradouro}, {End.Numero}, {End.Bairro}";
            ovTXT_Fone.Text = End.Telefone;
            ovTXT_Cidade.Text = Mun.Descricao;
            ovTXT_UF.Text = UnFed.Sigla;
            ovTXT_CEP.Text = End.Cep?.ToString();
        }

        private void ReportPedidoCompra_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ovSR_Cabecalho.ReportSource = new Cabecalho(UsuarioEmissao.Nome);
            DataTable dt = CONTROLER.FuncoesRelatorios.FuncoesPedidoCompra.GetPedidoCompraComItens(IDPedidoCompra);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var total = dt.Rows[i]["total"].ToString();
                if (total == "")
                {
                    var rows = dt.Rows;

                    var qtd = Convert.ToDecimal(rows[i]["quantidade"]);
                    var valor = Convert.ToDecimal(rows[i]["valorunitario"]);
                    var desconto = Convert.ToDecimal(rows[i]["desconto"]);
                    dt.Rows[i]["total"] = qtd * (valor - desconto);
                }
            }

            dt.TableName = "DADOS";
            ovDS_Dados.Tables.Clear();
            ovDS_Dados.Tables.Add(dt);
        }
    }
}