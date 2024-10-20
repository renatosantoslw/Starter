using DFe.Utils;
using MDFe.Classes.Retorno;
using MDFe.Damdfe.Base;
using MDFe.Damdfe.Fast;
using MDFe.Utils.Configuracoes;
using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.CONTROLLER.MDFE.Configuracao;
using PDV.CONTROLLER.MDFE.Eventos;
using PDV.CONTROLLER.MDFE.Util;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.MDFe;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using PDV.VIEW.Forms.Vendas.Manifesto;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Gerenciamento
{
    public partial class GER_Manifesto : DevExpress.XtraEditors.XtraForm
    {
        public string NOME_TELA = "GERENCIAMENTO DE MANIFESTO DE DOCUMENTO FISCAL";
        private DataTable DADOS = null;
        public GER_Manifesto()
        {
            InitializeComponent();
            ovTXT_InicioVigencia.Value = DateTime.Now.AddDays(-30);
            ConfigMDFe.PreencheConfiguracao(Contexto.CaminhoSchemasMDFe);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CarregarMovimentos();
        }

        private void CarregarMovimentos()
        {

            decimal Transmitida = ovCKB_Transmitida.Checked ? 1 : 0;
            decimal Cancelada = ovCKB_Cancelada.Checked ? 1 : 0;
            decimal Encerrada = ovCKB_Encerrada.Checked ? 1 : 0;
            decimal Rejeitada = ovCKB_Rejeitada.Checked ? 1 : 0;
            decimal EmDigitacao = ovCKB_Digitalizada.Checked ? 1 : 0;

            if ((Transmitida + Cancelada + Encerrada + Rejeitada + EmDigitacao) == 0)
            {
                Transmitida = 1;
                Cancelada = 1;
                Encerrada = 1;
                Rejeitada = 1;
                EmDigitacao = 1;
            }

            DADOS = FuncoesMovimentoFiscalMDFe.GetMovimentos(ovTXT_InicioVigencia.Value, ovTXT_DataFim.Value, Transmitida, Cancelada, Encerrada, Rejeitada, EmDigitacao, (int)MDFeConfiguracao.VersaoWebService.TipoAmbiente);

            gridControl1.DataSource = DADOS;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.BestFitColumns();
            AjustaGridHeader();
        }

        private void AjustaGridHeader()
        {
            //DataGridViewCellStyle style = new DataGridViewCellStyle();
            //style.Font = new Font("Open Sans", 9, FontStyle.Bold);
            //style.Alignment = DataGridViewContentAlignment.TopLeft;
            //int WidthGrid = WidthGrid = ovGRD_Notas.Width;
            //foreach (DataGridViewColumn column in ovGRD_Notas.Columns)
            //{
            //    switch (column.Name)
            //    {
            //        case "nmdf":
            //            column.DisplayIndex = 1;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.08);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.08);
            //            column.HeaderText = "NÚMERO";
            //            column.HeaderCell.Style = style;
            //            break;
            //        case "serie":
            //            column.DisplayIndex = 2;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.08);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.08);
            //            column.HeaderText = "SÉRIE";
            //            column.HeaderCell.Style = style;
            //            break;
            //        case "datacadastro":
            //            column.DisplayIndex = 3;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //            column.HeaderText = "CADASTRO";
            //            column.HeaderCell.Style = style;
            //            break;
            //        case "chave":
            //            column.DisplayIndex = 4;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //            column.HeaderText = "CHAVE";
            //            column.HeaderCell.Style = style;
            //            break;
            //        case "recebimento":
            //            column.DisplayIndex = 5;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //            column.HeaderText = "RECEBIMENTO";
            //            column.HeaderCell.Style = style;
            //            break;
            //        case "veiculo":
            //            column.DisplayIndex = 6;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.15);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.15);
            //            column.HeaderText = "VEICULO";
            //            column.HeaderCell.Style = style;
            //            break;
            //        case "status":
            //            column.DisplayIndex = 7;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.10);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.10);
            //            column.HeaderText = "STATUS";
            //            column.HeaderCell.Style = style;
            //            break;
            //        case "motivo":
            //            column.DisplayIndex = 8;
            //            column.MinimumWidth = Convert.ToInt32(WidthGrid * 0.29);
            //            column.Width = Convert.ToInt32(WidthGrid * 0.29);
            //            column.HeaderText = "RETORNO SEFAZ";
            //            column.HeaderCell.Style = style;
            //            break;
            //        default:
            //            column.Visible = false;
            //            column.DisplayIndex = 0;
            //            break;
            //    }
            //}
            gridView1.Columns[0].Caption = "NÚMERO";
            gridView1.Columns[1].Caption = "SÉRIE";
            gridView1.Columns[2].Caption = "CADASTRO";
            gridView1.Columns[3].Caption = "CHAVE";
            gridView1.Columns[4].Caption = "RECEBIMENTO";
            gridView1.Columns[5].Caption = "VEÍCULO";
            gridView1.Columns[6].Caption = "STATUS";
            gridView1.Columns[7].Caption = "RETORNO SEFAZ";
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[13].Visible = false;

        }

        private void GER_Manifesto_Load(object sender, EventArgs e)
        {
            CarregarMovimentos();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            try
            {
                var Cstat = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CSTAT");
                var idmdfe = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMDFE");
                if (Cstat != DBNull.Value)
                    if (Convert.ToDecimal(Cstat) == 100)
                    {
                        MessageBox.Show(this, "MDF-E está Autorizada e não pode ser Editada.", NOME_TELA);
                        return;
                    }
                if (idmdfe != null)
                {
                    ManifestoDocumentoFiscalEletronico Mani = FuncoesMDFe.GetMDFe(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMDFE").ToString()));
                    ManifestoDFE FormMDFe = new ManifestoDFE(Mani, Mani.NMDF);
                    FormMDFe.ShowDialog(this);
                    CarregarMovimentos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            try
            {
                var idmdfe = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMDFE");
                if (idmdfe != null)
                {
                    MovimentoFiscalMDFe Movimento = FuncoesMovimentoFiscalMDFe.GetMovimento(decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE").ToString()));
                    if (Movimento.CSTAT != 100)
                    {
                        MessageBox.Show(this, "MDF-E não está Autorizada e não pode ser impresso.", NOME_TELA);
                        return;
                    }

                    Imprimir(Movimento.XmlRetorno,
                        Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CANCELADA").ToString()) == 1,
                        Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ENCERRADA").ToString()) == 1);
                }
            }
            catch (Exception ex)
            {

                //throw;
            }

        }

        private void Imprimir(byte[] XMLEnvio, bool Cancelado, bool Encerrado)
        {
            bool ExibirCaixaDialogo = ConfigMDFe.IsExibirCaixaDialogo();
            string NomeImpressora = ConfigMDFe.GetNomeImpressora();

            DamdfeFrMDFe Danfe = new DamdfeFrMDFe(proc: FuncoesXml.XmlStringParaClasse<MDFeProcMDFe>(Encoding.UTF8.GetString(XMLEnvio)),
                config: new ConfiguracaoDamdfe()
                {
                    Logomarca = FuncoesEmitente.GetEmitente().Logomarca,
                    DocumentoEncerrado = Encerrado,
                    DocumentoCancelado = Cancelado,
                    Desenvolvedor = "Sistemas",
                    QuebrarLinhasObservacao = true
                });

            if (!string.IsNullOrEmpty(NomeImpressora))
                Danfe.Imprimir(ExibirCaixaDialogo, NomeImpressora);
            else
                Danfe.Visualizar(ExibirCaixaDialogo);
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            decimal? IDMovimentoFiscalMDFe = null;
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE") != DBNull.Value)
                IDMovimentoFiscalMDFe = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE").ToString());
            if (IDMovimentoFiscalMDFe.HasValue)
            {

                if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CSTAT").ToString()) == 100)
                {
                    MessageBox.Show(this, "MDF-E está Autorizada e não pode ser Enviada.", NOME_TELA);
                    return;
                }

                if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CANCELADA").ToString()) == 1)
                {
                    MessageBox.Show(this, "MDF-E está Cancelada e não pode ser Enviada.", NOME_TELA);
                    return;
                }

                if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ENCERRADA").ToString()) == 1)
                {
                    MessageBox.Show(this, "MDF-E está Encerrada e não pode ser Enviada.", NOME_TELA);
                    return;
                }
            }

            try
            {
                PDVControlador.BeginTransaction();
                RetornoTransmissaoMDFe Retorno = EventosMDFe.TransmitirMDFe(FuncoesMDFe.GetMDFe(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMDFE").ToString())), IDMovimentoFiscalMDFe, Contexto.CaminhoSchemasMDFe);
                PDVControlador.Commit();
                CarregarMovimentos();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            try
            {
                decimal? IDMovimentoFiscalMDFe = null;
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE") != null)
                    IDMovimentoFiscalMDFe = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE").ToString());

                if (IDMovimentoFiscalMDFe.HasValue)
                {
                    if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CSTAT").ToString()) != 100)
                    {
                        MessageBox.Show(this, "MDF-E não está Autorizada e não pode ser Enviada.", NOME_TELA);
                        return;
                    }

                    if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CANCELADA").ToString()) == 1)
                    {
                        MessageBox.Show(this, "MDF-E está Cancelada e não pode ser Enviada.", NOME_TELA);
                        return;
                    }

                    if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ENCERRADA").ToString()) == 1)
                    {
                        MessageBox.Show(this, "MDF-E está Encerrada e não pode ser Enviada.", NOME_TELA);
                        return;
                    }
                }

                PDVControlador.BeginTransaction();

                if (!IDMovimentoFiscalMDFe.HasValue)
                    throw new Exception("MDF-E está em digitação e não pode ser cancelada.");

                RetornoTransmissaoMDFe Retorno = EventosMDFe.CancelarMDFe(IDMovimentoFiscalMDFe.Value);
                PDVControlador.Commit();

                if (Retorno.isAutorizada)
                    MessageBox.Show(this, Retorno.Motivo, NOME_TELA);
                CarregarMovimentos();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            // Encerrar..
            try
            {
                var idmdfe = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE");
                if (idmdfe != null)
                {
                    decimal? IDMovimentoFiscalMDFe = null;
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE") != DBNull.Value)
                        IDMovimentoFiscalMDFe = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE").ToString());

                    if (IDMovimentoFiscalMDFe.HasValue)
                    {
                        if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CANCELADA").ToString()) == 1)
                        {
                            MessageBox.Show(this, "MDF-E está Cancelada e não pode ser Enviada.", NOME_TELA);
                            return;
                        }

                        if (Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ENCERRADA").ToString()) == 1)
                        {
                            MessageBox.Show(this, "MDF-E está Encerrada e não pode ser Enviada.", NOME_TELA);
                            return;
                        }
                    }

                    PDVControlador.BeginTransaction();
                    if (!IDMovimentoFiscalMDFe.HasValue)
                        throw new Exception("MDF-E está em digitação e não pode ser cancelada.");

                    RetornoTransmissaoMDFe Retorno = EventosMDFe.EncerrarMDFe(IDMovimentoFiscalMDFe.Value);
                    PDVControlador.Commit();

                    if (Retorno.isAutorizada)
                        MessageBox.Show(this, Retorno.Motivo, NOME_TELA);
                    CarregarMovimentos();
                }
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // Enviar Por E-mail..
            var idmovimentofiscal = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE");
            if (idmovimentofiscal != null)
            {
                if (idmovimentofiscal != null)
                {
                    decimal? IDMovimentoFiscalMDFe = null;
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE") != DBNull.Value)
                        IDMovimentoFiscalMDFe = Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMOVIMENTOFISCALMDFE").ToString());

                    if (IDMovimentoFiscalMDFe.HasValue)
                    {
                        Emitente Emit = FuncoesEmitente.GetEmitente();
                        new GER_EnviarMDFeEmail(Encoding.UTF8.GetString(FuncoesMovimentoFiscalMDFe.GetMovimento(IDMovimentoFiscalMDFe.Value).XmlRetorno)).ShowDialog(this);
                    }
                }
            }
        }

        private void ovGRD_Notas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var Cstat = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CSTAT");
            if (Cstat != DBNull.Value)
                if (Convert.ToDecimal(Cstat) == 100)
                {
                    MessageBox.Show(this, "MDF-E está Autorizada e não pode ser Editada.", NOME_TELA);
                    return;
                }

            ManifestoDocumentoFiscalEletronico Mani = FuncoesMDFe.GetMDFe(Convert.ToDecimal(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDMDFE").ToString()));
            ManifestoDFE FormMDFe = new ManifestoDFE(Mani, Mani.NMDF);
            FormMDFe.ShowDialog(this);
            CarregarMovimentos();
        }

        private void novoMetroButton_Click(object sender, EventArgs e)
        {
            Emitente emitente = FuncoesEmitente.GetEmitente();
            if (emitente == null)
            {
                MessageBox.Show(this, "Emitente não cadastrado!", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                new ManifestoDFE().ShowDialog(this);
            }
            CarregarMovimentos();
        }
    }
}
