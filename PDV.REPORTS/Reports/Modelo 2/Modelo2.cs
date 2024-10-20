using PDV.CONTROLER.Funcoes;
using PDV.CONTROLER.FuncoesRelatorios;
using PDV.DAO.Entidades;
using System.Data;
using System.Drawing;
using System.IO;
namespace PDV.REPORTS.Reports.Modelo_2
{ 
    public partial class Modelo2 : DevExpress.XtraReports.UI.XtraReport
    {
        public Modelo2(decimal IdVenda)
        {
            InitializeComponent();
            Emitente Emit = FuncoesEmitente.GetEmitente();
            Endereco End = FuncoesEndereco.GetEndereco(Emit.IDEndereco);
            UnidadeFederativa UnFed = FuncoesUF.GetUnidadeFederativa(End.IDUnidadeFederativa.Value);
            Municipio Mun = FuncoesMunicipio.GetMunicipio(End.IDMunicipio.Value);
            using (var ms = new MemoryStream(Emit.Logomarca))
                xrPictureBox1.Image = Image.FromStream(ms);
            empresaXrLabel.Text = Emit.RazaoSocial;
            cnpjxrLabel.Text = Emit.CNPJ;
            enderecoxrLabel.Text = $"{End.Logradouro}, {End.Numero}, {End.Bairro} , {Mun.Descricao} - {UnFed.Sigla}";
            telefoneEmpresaXrLabel.Text = End.Telefone;
            DataTable dt = FuncoesPedidoVendaTermica.GetDAV(IdVenda);
            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i]["observacao"] = dt.Rows[i]["observacao"]
                    .ToString()
                    .Replace("{%", "");

            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
            
        }

    }
}
