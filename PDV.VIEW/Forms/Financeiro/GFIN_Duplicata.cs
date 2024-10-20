using Boleto2Net;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using PDV.UTIL.Components.Custom;
using PDV.VIEW.App_Context;
using PDV.VIEW.BOLETO.Classes;
using PDV.VIEW.Forms.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Financeiro
{
    public partial class GFIN_Duplicata : DevExpress.XtraEditors.XtraForm
    {
        private List<ContaCobranca> CONTAS = null;
        private DataTable Dados = null;
        private string NOME_TELA = "DUPLICATAS";
        private DataGridViewCheckBoxColumnHeaderCell CheckAllColumn;

        public List<decimal> IdsContasReceber
        {
            get
            {
                var ids = new List<decimal>();
                foreach (var i in gridView1.GetSelectedRows())
                    ids.Add(Grids.GetValorDec(gridView1, "IDCONTARECEBER", i));
                return ids;
            }
        }

        public List<decimal> IdsContasRecCobranca
        {
            get
            {
                var ids = new List<decimal>();

                foreach (var i in gridView1.GetSelectedRows())
                {
                    try
                    {
                        ids.Add(Grids.GetValorDec(gridView1, "IDCONTARECCOBRANCA", i));
                    }
                    catch (FormatException)
                    {
                    }
                }

                return ids;
            }
        }

        public GFIN_Duplicata()
        {
            InitializeComponent();

            CONTAS = FuncoesContaCobranca.GetContasCobranca();
            ovCMB_ContaCobranca.DataSource = CONTAS;
            ovCMB_ContaCobranca.DisplayMember = "descricao";
            ovCMB_ContaCobranca.ValueMember = "idcontacobranca";
            ovCMB_ContaCobranca.SelectedItem = CONTAS.FirstOrDefault();
            LimparTela();
            Size = new Size(Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.85), Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.85));
        }

        private void LimparTela()
        {
            ovTXT_Cliente.Text = string.Empty;
            ovTXT_EmissaoFim.Value = DateTime.Now;
            ovTXT_EmissaoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_VencimentoInicio.Value = DateTime.Now.AddMonths(-1);
            ovTXT_VencimentoFim.Value = DateTime.Now;
            ovCKB_Cancelado.Checked = false;
            ovCKB_EmRemessa.Checked = false;
            ovCKB_Impresso.Checked = false;
            ovCKB_NaoGerado.Checked = false;
        }

        private void GFIN_Duplicata_Load(object sender, System.EventArgs e)
        {
            Carregar();
        }

        private void Carregar()
        {
            decimal IDFormaPagamento = 0;
            try
            {
                IDFormaPagamento = (ovCMB_ContaCobranca.SelectedItem as ContaCobranca).IDFormaDePagamento;
            }
            catch (NullReferenceException)
            {
                return;
            }
            List<decimal> ArrayStatus = new List<decimal>();

            if (ovCKB_NaoGerado.Checked)
                ArrayStatus.Add(0);

            if (ovCKB_Impresso.Checked)
                ArrayStatus.Add(1);

            if (ovCKB_Cancelado.Checked)
                ArrayStatus.Add(2);

            if (ovCKB_EmRemessa.Checked)
                ArrayStatus.Add(3);

            if (ArrayStatus.Count == 0)
            {
                ArrayStatus.Add(0);
                ArrayStatus.Add(1);
                ArrayStatus.Add(2);
                ArrayStatus.Add(3);
            }

            Dados = FuncoesContaRecCobranca
                .GetDuplicatas(ovTXT_Cliente.Text, (ovCMB_ContaCobranca.SelectedItem as ContaCobranca).IDContaBancaria, ovTXT_EmissaoInicio.Value, ovTXT_EmissaoFim.Value, ovTXT_VencimentoInicio.Value, ovTXT_VencimentoFim.Value, IDFormaPagamento, ArrayStatus.ToArray());
            gridControl1.DataSource = Dados;
            AjustaHeader();

        }

        private void AjustaHeader()
        {
            Grids.FormatGrid(ref gridView1, "ID CONTA RECEBER");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            GerarBoletos();
        }

        private void GerarBoletos(bool primeiraVia = true)
        {
            try
            {
                PDVControlador.BeginTransaction();
                Cursor.Current = Cursors.WaitCursor;
                if (!primeiraVia && IdsContasRecCobranca.Count() == 0)
                    throw new Exception("Selecione no mínimo uma duplicata cuja primeira via já tenha sido gerada");


                ValidarGerarBoleto();
                SaveFileDialog SaveFile = new SaveFileDialog();
                SaveFile.Filter = "PDF|*.pdf";
                SaveFile.Title = "Duplicatas";
                SaveFile.FileName = "Boleto";
                var dialogResult = SaveFile.ShowDialog(this);
                SaveFile.ShowHelp = false;

                if (dialogResult == DialogResult.OK)
                {
                    if (primeiraVia)
                        GerarBoletosPrimeiraVia(SaveFile);
                    else
                        GerarBoletosSegundaVia(SaveFile);
                }
                Carregar();
                Cursor.Current = Cursors.Default;
                PDVControlador.Commit();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                Cursor.Current = Cursors.Default;
                Alert(Ex.Message);

            }
        }

        public void Alert(string msg)
        {
            MessageBox.Show(msg, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GerarBoletosPrimeiraVia(SaveFileDialog SaveFile)
        {
            var abrirArquivos = IdsContasReceber.Count() < 4;
            var comBoleto = new List<string>();
            foreach (var id in IdsContasReceber)
            {
                if (FuncoesContaReceber.PossuiBoletoGerado(id))
                {
                    if (!comBoleto.Contains(id.ToString()))
                        comBoleto.Add(id.ToString());
                    continue;
                }
                ContaReceber ContaRec = FuncoesContaReceber.GetContaReceber(id);
                if (!FuncoesContaReceber.AtualizaContaBancaria(ContaRec.IDContaReceber, (ovCMB_ContaCobranca.SelectedItem as ContaCobranca).IDContaBancaria))
                    throw new Exception("Não foi Possível Atualizar a Conta Bancária do Conta a Receber.");

                var Titulos = new List<ContaReceber> { ContaRec };

                List<BoletoBancario> Boletos = BoletoUtil.GerarBoleto(Titulos, FuncoesContaCobranca.GetContaCobranca((ovCMB_ContaCobranca.SelectedItem as ContaCobranca).IDContaCobranca));
                byte[] ArrBoletos = BoletoUtil.GeraLayoutPDF(Boletos);
                var cliente = FuncoesCliente.GetCliente(ContaRec.IDCliente);

                var nomeCliente = cliente._DESCRICAO;

                var fileName = $"{SaveFile.FileName.Replace(".pdf", "")} {nomeCliente} (Conta num. {id}).pdf";


                File.WriteAllBytes(fileName, ArrBoletos);
                if (abrirArquivos)
                    System.Diagnostics.Process.Start(fileName);

            }
            if (comBoleto.Count() > 0)
                Alert("As seguintes duplicatas já possuem boleto gerado " + string.Join(", ", comBoleto));
        }

        private void GerarBoletosSegundaVia(SaveFileDialog SaveFile)
        {
            var abrirArquivos = IdsContasRecCobranca.Count() < 4;
            foreach (var id in IdsContasRecCobranca)
            {
                var contaRecCobranca = FuncoesContaRecCobranca.GetContaRecCobranca(id);


                var Titulos = new List<ContaRecCobranca> { contaRecCobranca };

                var contaCobranca = FuncoesContaCobranca.GetContaCobranca((ovCMB_ContaCobranca.SelectedItem as ContaCobranca).IDContaCobranca);
                List<BoletoBancario> Boletos = BoletoUtil.ImprimirGerado(Titulos, contaCobranca);
                byte[] ArrBoletos = BoletoUtil.GeraLayoutPDF(Boletos);

                var contaReceber = FuncoesContaReceber.GetContaReceber(contaRecCobranca.IDContaReceber);
                var cliente = FuncoesCliente.GetCliente(contaReceber.IDCliente);
                var nomeCliente = cliente._DESCRICAO;

                var fileName = $"{SaveFile.FileName.Replace(".pdf", "")} {nomeCliente} (Conta num. {id}).pdf";
                File.WriteAllBytes(fileName, ArrBoletos);
                if (abrirArquivos)
                    System.Diagnostics.Process.Start(fileName);

            }
        }

        private void ValidarGerarBoleto()
        {
            if (ovCMB_ContaCobranca.SelectedItem == null)
                throw new Exception("Selecione a Conta Cobrança.");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            GerarBoletos(false);
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            // Cancelar Duplicatas
            try
            {
                PDVControlador.BeginTransaction();

                var lQuerySelecionados = Dados.AsEnumerable().Where(o => Convert.ToBoolean(o["SELECIONADO"]) &&
                                                                         o["IDCONTARECCOBRANCA"] != DBNull.Value &&
                                                                         Convert.ToDecimal(o["STATUS"]) != (int)StatusDuplicata.IMPRESSO);

                if (lQuerySelecionados != null && lQuerySelecionados.Count() > 0)
                {
                    foreach (DataRow dr in lQuerySelecionados.CopyToDataTable().Rows)
                        if (!FuncoesContaRecCobranca.UpdateStatus(Convert.ToDecimal(dr["IDCONTARECCOBRANCA"]), (int)StatusDuplicata.CANCELADO, DateTime.Now))
                            throw new Exception("Não foi possível Cancelar a Duplicata.");
                }
                else
                    throw new Exception("Selecione ao menos um Título para Cancelar a Duplicata.");

                Carregar();
                PDVControlador.Commit();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            // Gerar Remessa.
            try
            {
                PDVControlador.BeginTransaction();

                if (ovCMB_ContaCobranca.SelectedItem == null)
                    throw new Exception("Selecione a Conta Cobrança.");

                //var lQuerySelecionados = Dados.AsEnumerable().Where(o => Convert.ToBoolean(o["SELECIONADO"]) &&
                //                                                         o["IDCONTARECCOBRANCA"] != DBNull.Value &&
                //                                                         Convert.ToDecimal(o["STATUS"]) == (int)StatusDuplicata.IMPRESSO);

                //if (lQuerySelecionados != null && lQuerySelecionados.Count() > 0)
                decimal ID = decimal.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDCONTARECCOBRANCA").ToString());
                List<decimal> ids = new List<decimal>();
                ids.Add(ID);

                BoletoUtil.GerarArquivoRemessa(ids, (ovCMB_ContaCobranca.SelectedItem as ContaCobranca));
                //else
                //    throw new Exception("Selecione ao menos um Título para Gerar o Arquivo de Remessa.");

                Carregar();
                PDVControlador.Commit();
                MessageBox.Show(this, "Remessa gerada com sucesso.", NOME_TELA);
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            // Importar Remessa.
            // Implementar Rotina...
            try
            {
                PDVControlador.BeginTransaction();

                if (ovCMB_ContaCobranca.SelectedItem == null)
                    throw new Exception("Selecione a Conta Cobrança.");

                BoletoUtil.ImportarRemessa((ovCMB_ContaCobranca.SelectedItem as ContaCobranca));
                PDVControlador.Commit();

                MessageBox.Show(this, "Arquivo Importado com Sucesso.", NOME_TELA);
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                if (!Ex.Message.Equals("ARQUIVONAOIMPORTADO"))
                    MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Carregar();
        }

        private void ovGRD_Lancamentos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                for (int i = 0; i < gridView1.RowCount; i++)
                    ((DataGridViewCheckBoxCell)(sender as DataGridView).Rows[i].Cells["SELECIONADO"]).Value = CheckAllColumn.CheckAll;
        }

    }
}
