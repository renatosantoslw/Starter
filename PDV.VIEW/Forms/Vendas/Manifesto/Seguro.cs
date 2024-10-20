using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Entidades.MDFe.Tipos;
using PDV.UTIL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Vendas.Manifesto
{
    public partial class Seguro : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "SEGURO MDF-E";

        public bool Salvou = false;
        public DataRow drSeguradora = null;
        public DataTable Averbacoes = null;

        private List<Seguradora> Seguradoras = null;
        private List<TipoResponsavelSeguro> Responsaveis = null;

        public Seguro(DataRow _drSeguradora, DataTable _Averbacoes)
        {
            InitializeComponent();
            metroTabControl2.SelectedTab = metroTabPage5;

            drSeguradora = _drSeguradora;
            Averbacoes = _Averbacoes;

            Seguradoras = FuncoesSeguradora.GetSeguradorasAtivas();
            ovCMB_Seguradora.DataSource = Seguradoras;
            ovCMB_Seguradora.ValueMember = "idseguradora";
            ovCMB_Seguradora.DisplayMember = "descricaoformatada";

            Responsaveis = TipoResponsavelSeguro.GetTipos();
            ovCMB_Responsavel.DataSource = Responsaveis;
            ovCMB_Responsavel.ValueMember = "idresponsavelseguro";
            ovCMB_Responsavel.DisplayMember = "descricao";

            AplicaMascaraContratante();
        }

        private void PreencherTela()
        {
            ovCMB_Responsavel.SelectedItem = null;
            if (drSeguradora["RESPONSAVELSEGURO"] != DBNull.Value)
                ovCMB_Responsavel.SelectedItem = Responsaveis.Where(o => o.IDResponsavelSeguro == Convert.ToDecimal(drSeguradora["RESPONSAVELSEGURO"])).FirstOrDefault();

            if (drSeguradora["CPF"] != DBNull.Value)
            {
                ovCKB_ContratanteFisica.Checked = true;
                ovTXT_CNPJCPFResponsavel.Text = drSeguradora["CPF"].ToString();
            }
            else if (drSeguradora["CNPJ"] != DBNull.Value)
            {
                ovCKB_ContratanteJuridica.Checked = true;
                ovTXT_CNPJCPFResponsavel.Text = drSeguradora["CNPJ"].ToString();
            }

            ovCMB_Seguradora.SelectedItem = null;
            if (drSeguradora["IDSEGURADORA"] != DBNull.Value)
                ovCMB_Seguradora.SelectedItem = Seguradoras.Where(o => o.IDSeguradora == Convert.ToDecimal(drSeguradora["IDSEGURADORA"])).FirstOrDefault();

            ovTXT_NumeroApolice.Text = drSeguradora["NUMEROAPOLICE"].ToString();
            CarregaAverbacoes();
        }

        private void CarregaAverbacoes()
        {
            ovGRD_Averbacoes.DataSource = Averbacoes;
            AjustaGridAverbacoes();
        }

        private void AjustaGridAverbacoes()
        {
            ovGRD_Averbacoes.RowHeadersVisible = false;
            int WidthGrid = ovGRD_Averbacoes.Width;

            foreach (DataGridViewColumn column in ovGRD_Averbacoes.Columns)
            {
                switch (column.Name)
                {
                    case "numeroaverbacao":
                        column.DisplayIndex = 1;
                        column.FillWeight = WidthGrid;
                        column.HeaderText = "NÚMERO AVERBAÇÃO";
                        break;
                    default:
                        column.DisplayIndex = 0;
                        column.Visible = false;
                        break;
                }
            }
        }

        private void ovCKB_ContratanteFisica_CheckedChanged(object sender, EventArgs e)
        {
            AplicaMascaraContratante();
        }

        private void ovCKB_ContratanteJuridica_CheckedChanged(object sender, EventArgs e)
        {
            AplicaMascaraContratante();
        }

        private void AplicaMascaraContratante()
        {
            if (ovCKB_ContratanteFisica.Checked)
                ovTXT_CNPJCPFResponsavel.Mask = "###,###,###-##";
            else
                ovTXT_CNPJCPFResponsavel.Mask = "##,###,###/####-##";
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            // Adicionar Averbações
            if (string.IsNullOrEmpty(ovTXT_Averbacao.Text))
            {
                MessageBox.Show(this, "Informe o Número da Averbação.", NOME_TELA);
                return;
            }

            DataRow drAverbacao = Averbacoes.NewRow();
            drAverbacao["IDAVERBACAOSEGURADORAMDFE"] = Sequence.GetNextID("AVERBACAOSEGURADORAMDFE", "IDAVERBACAOSEGURADORAMDFE");
            drAverbacao["IDSEGURADORAMDFE"] = drSeguradora["IDSEGURADORAMDFE"];
            drAverbacao["NUMEROAVERBACAO"] = ovTXT_Averbacao.Text;
            Averbacoes.Rows.Add(drAverbacao);
            ovTXT_Averbacao.Text = string.Empty;
            CarregaAverbacoes();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            // Remover Averbação
            Averbacoes.DefaultView.RowFilter = "[IDAVERBACAOSEGURADORAMDFE] = " + Convert.ToDecimal(ZeusUtil.GetValueFieldDataRowView((ovGRD_Averbacoes.CurrentRow.DataBoundItem as DataRowView), "IDAVERBACAOSEGURADORAMDFE"));
            Averbacoes.DefaultView[0].Delete();
            Averbacoes.DefaultView.RowFilter = string.Empty;
            ovTXT_Averbacao.Text = string.Empty;
            CarregaAverbacoes();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Salvou = false;
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDados();

                drSeguradora["NUMEROAPOLICE"] = ovTXT_NumeroApolice.Text;
                drSeguradora["RESPONSAVEL"] = ZeusUtil.SomenteNumeros(ovTXT_CNPJCPFResponsavel.Text);
                drSeguradora["IDSEGURADORA"] = (ovCMB_Seguradora.SelectedItem as Seguradora).IDSeguradora;
                drSeguradora["SEGURADORA"] = (ovCMB_Seguradora.SelectedItem as Seguradora).Descricao;
                drSeguradora["RESPONSAVELSEGURO"] = (ovCMB_Responsavel.SelectedItem as TipoResponsavelSeguro).IDResponsavelSeguro;

                drSeguradora["CPF"] = DBNull.Value;
                if (ovCKB_ContratanteFisica.Checked)
                    drSeguradora["CPF"] = ZeusUtil.SomenteNumeros(ovTXT_CNPJCPFResponsavel.Text);

                drSeguradora["CNPJ"] = DBNull.Value;
                if (ovCKB_ContratanteJuridica.Checked)
                    drSeguradora["CNPJ"] = ZeusUtil.SomenteNumeros(ovTXT_CNPJCPFResponsavel.Text);

                Salvou = true;
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, NOME_TELA);
            }
        }

        private void ValidarDados()
        {
            if (ovCMB_Responsavel.SelectedItem == null)
                throw new Exception("Selecione o Responsável.");

            if ((ovCMB_Responsavel.SelectedItem as TipoResponsavelSeguro).IDResponsavelSeguro == 2)
            {
                if (string.IsNullOrEmpty(ZeusUtil.SomenteNumeros(ovTXT_CNPJCPFResponsavel.Text)))
                    throw new Exception("Informe o CPF/CNPJ.");
            }

            if (ovCMB_Seguradora.SelectedItem == null)
                throw new Exception("Selecione a Seguradora.");
        }

        private void ovCMB_Responsavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ovCMB_Responsavel.SelectedItem != null && (ovCMB_Responsavel.SelectedItem as TipoResponsavelSeguro).IDResponsavelSeguro == 1)
            {
                ovCKB_ContratanteFisica.Enabled = false;
                ovCKB_ContratanteJuridica.Enabled = false;

                ovTXT_CNPJCPFResponsavel.Enabled = false;
                ovTXT_CNPJCPFResponsavel.ReadOnly = true;

                ovCKB_ContratanteJuridica.Checked = true;
                ovTXT_CNPJCPFResponsavel.Text = FuncoesEmitente.GetEmitente().CNPJ;
            }
            else
            {
                ovCKB_ContratanteFisica.Checked = true;
                ovCKB_ContratanteFisica.Enabled = true;

                ovCKB_ContratanteJuridica.Enabled = true;

                ovTXT_CNPJCPFResponsavel.Text = string.Empty;
                ovTXT_CNPJCPFResponsavel.Enabled = true;
                ovTXT_CNPJCPFResponsavel.ReadOnly = false;
            }
        }

        private void Seguro_Load(object sender, EventArgs e)
        {
            PreencherTela();
        }
    }
}
