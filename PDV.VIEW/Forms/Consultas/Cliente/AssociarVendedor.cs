using DevExpress.Utils.MVVM;
using DevExpress.XtraPrinting;
using MetroFramework;
using MetroFramework.Forms;
using ModelAndroidApp.ModelAndroid;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Cadastro;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Consultas
{
    public partial class AssociarVendedorForm : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "ASSOCIAÇÃO DE VENDEDOR";

        public List<decimal> IdsClientes { get; set; }

        public decimal IdVendedor
        {
            get
            {
                return (comboBox1.SelectedItem as Usuario).IDUsuario;
            }
        }

        public AssociarVendedorForm(List<decimal> idsClientes)
        {
            InitializeComponent();

            IdsClientes = idsClientes;

            PreencherVendedores();
        }

        private void PreencherVendedores()
        {
            comboBox1.DataSource = FuncoesUsuario.GetUsuariosVendedores();
            comboBox1.ValueMember = "idusuario";
            comboBox1.DisplayMember = "nome";
        }

        public DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void selecionarSimpleButton_Click(object sender, EventArgs e)
        {
            var msg = "Atenção! Este usuário se tornará vendedor de todos os clientes selecionados. Você confirma essa ação?";

            if (Confirm(msg) == DialogResult.Yes)
            {
                try
                {
                    PDVControlador.BeginTransaction();

                    foreach (var id in IdsClientes)
                    {
                        var cliente = FuncoesCliente.GetCliente(id);
                        cliente.IDVendedor = Convert.ToInt32(IdVendedor);

                        if (!FuncoesCliente.Salvar(cliente, DAO.Enum.TipoOperacao.UPDATE))
                            throw new Exception($"Não foi possível salvar o cliente {id}");
                    }


                    PDVControlador.Commit();
                }
                catch (Exception exception)
                {
                    Alert(exception.Message);
                    PDVControlador.Rollback();
                }
                Close();
            }
        }

        private void Alert(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
