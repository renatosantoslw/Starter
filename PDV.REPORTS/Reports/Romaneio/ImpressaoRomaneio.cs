using System.Drawing;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using System.Data;
using System.IO;

namespace PDV.REPORTS.Reports.Romaneio
{
    public partial class ImpressaoRomaneio : DevExpress.XtraReports.UI.XtraReport
    {
        public ImpressaoRomaneio(decimal IDRomaneio)
        {
            InitializeComponent();
            //Cabeçalho
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
            //Romaneio
            PDV.DAO.Entidades.Romaneio romaneio = FuncoesRomaneio.GetRomaneioPorID(IDRomaneio);
            xrLabel31.Text = "Romaneio de Entrega Número  " + romaneio.IDRomaneio.ToString();
            motoristaXrLabel.Text = romaneio.MotoristaNome;
            transportadoraXrLabel.Text = romaneio.TransportadoraNome;
            veiculoXrLabel.Text = romaneio.VeiculoDescricao;

            //Detalhes
            DataTable dt = FuncoesRomaneio.GetRomaneiosVendas(IDRomaneio);
            dt.TableName = "objectDataSource1";
            objectDataSource1.DataSource = dt;
        }

    }
}
