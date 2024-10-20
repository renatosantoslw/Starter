using ACBr.Net.Core.Extensions;
using MetroFramework;
using MetroFramework.Forms;
using PDV.DAO.Entidades.PDV;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.FRENTECAIXA.Forms
{
    public partial class GPDV_CancelarItem : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CANCELAR ITEM";

        public BindingList<ItemVenda> ItensVenda { get; set; }
        public IEnumerable<decimal> IdsSelecionados 
        { 
            get
            {
                var ids = new List<decimal>();
                foreach (var i in gridView1.GetSelectedRows())
                    ids.Add(Grids.GetValorDec(gridView1, "IDItemVenda", i));

                return ids;
            }
        }

        public GPDV_CancelarItem(BindingList<ItemVenda> itensVenda)
        {
            InitializeComponent();
            gridControl1.DataSource = ItensVenda = itensVenda;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Alt | Keys.F4):
                    if (MessageBox.Show(this, "Deseja Sair?", NOME_TELA, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return true;
                    break;
                case Keys.Escape:
                    Close();
                    break;                
            }
            return base.ProcessDialogKey(keyData);
        }
        

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CancelarItens();
        }

        private void CancelarItens()
        {            
            if (Confirm("Deseja cancelar o(s) item(ns) selecionado(s)") == DialogResult.Yes)
            {
                foreach (var id in IdsSelecionados)
                {
                    var item = ItensVenda.Where(i => i.IDItemVenda == id).FirstOrDefault();
                    if (item != null)
                        ItensVenda.Remove(item);                   
                }
                Close();
            }
        }

        private DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                case Keys.Enter:
                case Keys.Delete:
                    CancelarItens();
                    break;
            }
        }
    }
}
