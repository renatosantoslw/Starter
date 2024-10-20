using MetroFramework;
using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Entidades.MDFe.Tipos;
using PDV.DAO.Enum;
using PDV.UTIL;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Cadastro.MDFe
{
    public partial class FCA_Veiculo : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE VEÍCULO";
        private List<TipoRodado> Rodados;
        private List<TipoCarroceria> Carrocerias;
        private List<UnidadeFederativa> Unidades;
        private Veiculo _Veiculo;
        private List<Marca> Marcas;
        public static readonly decimal[] idsMenuItem = { 46 };

        public FCA_Veiculo(Veiculo veiculo)
        {
            InitializeComponent();
            _Veiculo = veiculo;

            Unidades = FuncoesUF.GetUnidadesFederativa(1058);
            ovCMB_UF.DisplayMember = "sigla";
            ovCMB_UF.ValueMember = "idunidadefederativa";
            ovCMB_UF.DataSource = Unidades;
            ovCMB_UF.SelectedItem = null;

            Rodados = TipoRodado.GetTipos();
            ovCMB_TipoRodado.DataSource = Rodados;
            ovCMB_TipoRodado.DisplayMember = "descricao";
            ovCMB_TipoRodado.ValueMember = "idtiporodado";
            ovCMB_TipoRodado.SelectedItem = null;

            Carrocerias = TipoCarroceria.GetTipos();
            ovCMB_TipoCarroceria.DataSource = Carrocerias;
            ovCMB_TipoCarroceria.DisplayMember = "descricao";
            ovCMB_TipoCarroceria.ValueMember = "idtipocarroceria";
            ovCMB_TipoCarroceria.SelectedItem = null;

            Marcas = FuncoesMarca.GetMarcasDeVeiculo();
            ovCMB_Marca.DataSource = Marcas;
            ovCMB_Marca.DisplayMember = "descricao";
            ovCMB_Marca.ValueMember = "idmarca";
            ovCMB_Marca.SelectedItem = null;

            ovDEC_Tara.AplicaAlteracoes();
            ovDEC_Capkg.AplicaAlteracoes();
            ovDEC_Capm3.AplicaAlteracoes();
            PreencherTela();
        }

        private void PreencherTela()
        {
            ovTXT_Placa.Text = _Veiculo.Placa;
            ovCMB_UF.SelectedItem = Unidades.Where(o => o.IDUnidadeFederativa == _Veiculo.IDUnidadefederativa).FirstOrDefault();
            ovTXT_Modelo.Text = _Veiculo.Modelo;
            ovDEC_Tara.Value = _Veiculo.TaraEmKG;
            ovDEC_Capkg.Value = _Veiculo.TaraEmKG;
            ovDEC_Capm3.Value = _Veiculo.CapacidadeEmM3;
            ovTXT_AnoFab.Text = _Veiculo.AnoFabricacao.ToString();
            ovTXT_AnoMod.Text = _Veiculo.AnoModelo.ToString();
            ovTXT_Renavam.Text = _Veiculo.Renavam;
            ovCMB_Marca.SelectedItem = Marcas.Where(o => o.IDMarca == _Veiculo.IDMarca).FirstOrDefault();
            ovCMB_TipoRodado.SelectedItem = Rodados.Where(o => o.IDTipoRodado == _Veiculo.TipoRodado).FirstOrDefault();
            ovCMB_TipoCarroceria.SelectedItem = Carrocerias.Where(o => o.IDTipoCarroceria == _Veiculo.TipoCarroceria).FirstOrDefault();
            ovCKB_Ativo.Checked = _Veiculo.Ativo == 1;
            ovCMB_Disponível.Checked = _Veiculo.VeiculoEmUsoMDFe == 0;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Placa.Text))
                    throw new Exception("Informe a Placa.");

                if (string.IsNullOrEmpty(ovDEC_Tara.Value.ToString()))
                    throw new Exception("Informe a Tara(kg).");

                if (ovCMB_UF.SelectedItem == null)
                    throw new Exception("Selecione a UF.");

                if (ovCMB_TipoCarroceria.SelectedItem == null)
                    throw new Exception("Selecione o tipo de carroceria.");

                if (ovCMB_TipoRodado.SelectedItem == null)
                    throw new Exception("Selecione o tipo rodado.");

                _Veiculo.Placa = ovTXT_Placa.Text;
                _Veiculo.Modelo = ovTXT_Modelo.Text;
                _Veiculo.TaraEmKG = ovDEC_Tara.Value;
                _Veiculo.TaraEmKG = ovDEC_Capkg.Value;
                _Veiculo.CapacidadeEmM3 = ovDEC_Capm3.Value;
                _Veiculo.AnoFabricacao = Convert.ToInt32(ovTXT_AnoFab.Text);
                _Veiculo.AnoModelo = Convert.ToInt32(ovTXT_AnoMod.Text);
                _Veiculo.Renavam = ovTXT_Renavam.Text;

                _Veiculo.IDMarca = null;
                if ((ovCMB_Marca.SelectedItem as Marca) != null)
                    _Veiculo.IDMarca = (ovCMB_Marca.SelectedItem as Marca).IDMarca;

                _Veiculo.TipoRodado = (ovCMB_TipoRodado.SelectedItem as TipoRodado).IDTipoRodado;
                _Veiculo.TipoCarroceria = (ovCMB_TipoCarroceria.SelectedItem as TipoCarroceria).IDTipoCarroceria;
                _Veiculo.IDUnidadefederativa = (ovCMB_UF.SelectedItem as UnidadeFederativa).IDUnidadeFederativa;

                _Veiculo.Ativo = ovCKB_Ativo.Checked ? 1 : 0;

                TipoOperacao Op = TipoOperacao.UPDATE;
                if (!FuncoesVeiculoMDFe.Existe(_Veiculo.IDVeiculo))
                {
                    _Veiculo.IDVeiculo = Sequence.GetNextID("VEICULO", "IDVEICULO");
                    Op = TipoOperacao.INSERT;
                }

                if (!FuncoesVeiculoMDFe.Salvar(_Veiculo, Op))
                    throw new Exception("Não foi possível salvar o Veículo.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Veículo salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_Veiculo_KeyDown(object sender, KeyEventArgs e)
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
