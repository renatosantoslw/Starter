using FontAwesome.Sharp;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using PDV.VIEW.App_Context;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.Suprimentos
{
    public partial class FCA_Almoxarifado : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE ALMOXARIFADO";
        private Almoxarifado Almoxarifado = null;
        public FCA_Almoxarifado(Almoxarifado _Almoxarifado)
        {
            InitializeComponent();
            Almoxarifado = _Almoxarifado;
            PreencherTela();





            //icones
          
            Bitmap bitmapSalvar = IconChar.Save.ToBitmap(Color.SteelBlue, 32);
            Bitmap bitmapCancelar = IconChar.WindowClose.ToBitmap(Color.Firebrick, 32);

         
            metroButton3.ImageOptions.Image = bitmapSalvar;
            metroButton4.ImageOptions.Image = bitmapCancelar;
        
        }

        private void PreencherTela()
        {
            ovTXT_Descricao.Text = Almoxarifado.Descricao;
            
            switch(Convert.ToInt32(Almoxarifado.Tipo))
            {
                case 1:
                    ovCKB_Estoque.Checked = true;
                    break;
                case 2:
                    ovCKB_Producao.Checked = true;
                    break;
                case 3:
                    ovCKB_Quarentena.Checked = true;
                    break;
            }
        }

        private void metroButton4_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void metroButton3_Click(object sender, System.EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text))
                    throw new Exception("Informe o Nome.");

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesAlmoxarifado.Existe(Almoxarifado.IDAlmoxarifado))
                {
                    Almoxarifado.IDAlmoxarifado = Sequence.GetNextID("ALMOXARIFADO", "IDALMOXARIFADO");
                    Op = TipoOperacao.INSERT;
                }

                Almoxarifado.Descricao = ovTXT_Descricao.Text;
                Almoxarifado.Tipo = GetTipo();

                if (!FuncoesAlmoxarifado.Salvar(Almoxarifado, Op))
                    throw new Exception("Não foi possível salvar o Almoxarifado.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Almoxarifado salvo com sucesso.", NOME_TELA);
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
                PDVControlador.Rollback();
            }
        }

        private decimal GetTipo()
        {
            if (ovCKB_Estoque.Checked) return 1;
            if (ovCKB_Producao.Checked) return 2;
            if (ovCKB_Quarentena.Checked) return 3;
            return 0;
        }

        private void FCA_Almoxarifado_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}
