using DevExpress.XtraReports.UI;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.REPORTS.Recibo;
using PDV.UTIL.Components;
using PDV.UTIL.FORMS.Forms.Seletores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Financeiro
{
    public partial class ReciboAvulsoForm : DevExpress.XtraEditors.XtraForm
    {
        public ReciboAvulsoForm()
        {
            InitializeComponent();

            Emitente emitente = FuncoesEmitente.GetEmitente();
            emitenteTextBox1.Text = emitente.RazaoSocial;
            documentoEmitenteTextBox.Text = emitente.CNPJ;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SEL_Cliente SeletorCliente = new SEL_Cliente();
            SeletorCliente.ShowDialog(this);

            if (SeletorCliente.DRCliente == null)
                return;

            DataRow DrSelecionada = SeletorCliente.DRCliente;
            Cliente CLIENTE = FuncoesCliente.GetCliente(Convert.ToDecimal(DrSelecionada["IDCLIENTE"]));
            Endereco endereco = FuncoesEndereco.GetEndereco(CLIENTE.IDEndereco.Value);
            codClienteTextBox.Text = CLIENTE.IDCliente.ToString();
            nomeClienteTextBox.Text = CLIENTE.TipoDocumento == 0 ? CLIENTE.NomeFantasia : CLIENTE.Nome;
            documentoClienteTextBox.Text = CLIENTE.TipoDocumento == 0 ? CLIENTE.CNPJ : CLIENTE.CPF;
            enderecoClienteTextBox.Text = $"{endereco.Logradouro} ,{endereco.Numero}, {endereco.Bairro} , {endereco.Municipio}, {endereco.UnidadeFederativa}";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(valorTextBox.Text))
            {
                MessageBox.Show("Informe o valor","Erro");
                return;
            }
            Recibo recibo = new Recibo();
            recibo.Pessoa = nomeClienteTextBox.Text;
            recibo.PessoaEndereco = enderecoClienteTextBox.Text;
            recibo.Referente = referenteTextBox.Text;
            recibo.Valor = decimal.Parse(valorTextBox.Text);
            recibo.Importancia = ClsExtenso.Extenso_Valor(recibo.Valor);
            recibo.Emitente = emitenteTextBox1.Text;
            recibo.EmitenteDocumento = documentoEmitenteTextBox.Text;
            recibo.Data = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            ReciboPagamento rel = new ReciboPagamento(recibo);
            using (ReportPrintTool printTool = new ReportPrintTool(rel))
            {
                printTool.ShowPreviewDialog();
            }

        }

        private void valorTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            DecimalMoeda.Moeda(ref valorTextBox);
        }
    }
}
