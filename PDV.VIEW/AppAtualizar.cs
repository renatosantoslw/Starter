using PDV.VIEW.Forms.Configuracoes;
using PDV.VIEW.Tarefas_do_Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.VIEW
{
    public partial class AppAtualizar : DevExpress.XtraEditors.XtraForm
    {
        public AppAtualizar()
        {
            InitializeComponent();
        }

        private void simpleButtonAppForçaVendas_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(this, "Confirma Atualizar dados do aplicativo?", "Sincronização", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                    Tarefas.AtualizarAPP();
                    System.Windows.Forms.Cursor.Current = Cursors.Default;
                    MessageBox.Show("Atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
    }
}
