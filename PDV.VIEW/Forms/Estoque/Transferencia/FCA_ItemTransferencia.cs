using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Entidades.Estoque.Transferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Estoque.Transferencia
{
    public partial class FCA_ItemTransferencia : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "ITEM DA TRANSFERÊNCIA";

        public ItemTransferenciaEstoque Item = null;

        private List<Almoxarifado> AlmoxEntrada = null;
        private List<Almoxarifado> AlmoxSaida = null;
        public DataTable ITENS = null;
        public DataTable dtItem = null;

        public bool Salvou = false;

        public FCA_ItemTransferencia(ItemTransferenciaEstoque _Item, DataTable _dtItem)
        {
            InitializeComponent();
            Item = _Item;
            dtItem = _dtItem;
            AlmoxEntrada = FuncoesAlmoxarifado.GetAlmoxarifados();
            AlmoxSaida = FuncoesAlmoxarifado.GetAlmoxarifados();

            ovCMB_AlmoxEntrada.DataSource = AlmoxEntrada;
            ovCMB_AlmoxEntrada.DisplayMember = "descricao";
            ovCMB_AlmoxEntrada.ValueMember = "idalmoxarifado";

            ovCMB_AlmoxSaida.DataSource = AlmoxSaida;
            ovCMB_AlmoxSaida.DisplayMember = "descricao";
            ovCMB_AlmoxSaida.ValueMember = "idalmoxarifado";

            PreencherTela();
        }

        private void PreencherTela()
        {
            ovCMB_AlmoxEntrada.SelectedItem = AlmoxEntrada.Where(o => o.IDAlmoxarifado == Item.IDAlmoxarifadoEntrada).FirstOrDefault();
            ovCMB_AlmoxSaida.SelectedItem = AlmoxSaida.Where(o => o.IDAlmoxarifado == Item.IDAlmoxarifadoSaida).FirstOrDefault();

            if (Item.IDItemTransferenciaEstoque == -1)
                ITENS = FuncoesItemTransferenciaEstoque.GetProdutosComSaldoEmAlmoxarifado(Item.IDAlmoxarifadoEntrada);
            else
            {
                ITENS = dtItem;
                ovCMB_AlmoxEntrada.Enabled = false;
                ovCMB_AlmoxSaida.Enabled = false;
            }

            ovGRD_Itens.DataSource = ITENS;
            AjustaHeaderTextGrid();
        }

        private void AjustaHeaderTextGrid()
        {
            ovGRD_Itens.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Itens.Width;
            foreach (DataGridViewColumn column in ovGRD_Itens.Columns)
            {
                switch (column.Name)
                {
                    case "codigo":
                        column.DisplayIndex = 1;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.10);
                        column.HeaderText = "CÓDIGO";
                        column.ReadOnly = true;
                        break;
                    case "ean":
                        column.DisplayIndex = 2;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.20);
                        column.HeaderText = "EAN";
                        column.ReadOnly = true;
                        break;
                    case "produto":
                        column.DisplayIndex = 3;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.25);
                        column.HeaderText = "PRODUTO";
                        column.ReadOnly = true;
                        break;
                    case "saldo":
                        column.DisplayIndex = 4;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "SALDO";
                        column.ReadOnly = true;
                        break;
                    case "quantidade":
                        column.DisplayIndex = 5;
                        column.FillWeight = Convert.ToInt32(WidthGrid * 0.15);
                        column.HeaderText = "QUANTIDADE";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ovCMB_AlmoxEntrada.SelectedItem == null)
                    throw new Exception("Selecione o Almoxarifado de Origem.");

                if (ovCMB_AlmoxSaida.SelectedItem == null)
                    throw new Exception("Selecione o Almoxarifado de Destino.");

                if (ITENS.AsEnumerable().Sum(o => Convert.ToDecimal(o["QUANTIDADE"])) == 0)
                    throw new Exception("Nenhum ITEM encontrado com quantidade maior que zero.");

                if ((ovCMB_AlmoxSaida.SelectedItem as Almoxarifado).IDAlmoxarifado == (ovCMB_AlmoxEntrada.SelectedItem as Almoxarifado).IDAlmoxarifado)
                    throw new Exception("O Almoxarifado de ORIGEM não pode ser igual o Almoxarifado de DESTINO.");

                foreach (DataRow dr in ITENS.Rows)
                    if (Convert.ToDecimal(dr["QUANTIDADE"]) > Convert.ToDecimal(dr["SALDO"]))
                        throw new Exception("A QUANTIDADE de Transferência não pode ser maior que o SALDO.");

                Item.IDAlmoxarifadoEntrada = (ovCMB_AlmoxEntrada.SelectedItem as Almoxarifado).IDAlmoxarifado;
                Item.IDAlmoxarifadoSaida = (ovCMB_AlmoxSaida.SelectedItem as Almoxarifado).IDAlmoxarifado;

                Salvou = true;
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void ovCMB_AlmoxEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal IDAlmoxarifado = -1;
            if (ovCMB_AlmoxEntrada.SelectedItem != null)
                IDAlmoxarifado = (ovCMB_AlmoxEntrada.SelectedItem as Almoxarifado).IDAlmoxarifado;

            ITENS = FuncoesItemTransferenciaEstoque.GetProdutosComSaldoEmAlmoxarifado(IDAlmoxarifado);
            ovGRD_Itens.DataSource = ITENS;
            AjustaHeaderTextGrid();
        }

        private void ovGRD_Itens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (ovGRD_Itens.Columns[e.ColumnIndex].Name)
            {
                case "saldo":
                case "quantidade":
                    e.Value = Convert.ToDecimal(e.Value).ToString("n4");
                    break;
            }
        }
    }
}
