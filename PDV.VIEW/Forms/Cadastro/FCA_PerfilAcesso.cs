using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using System.Windows.Forms;
using System;
using PDV.VIEW.App_Context;
using PDV.DAO.DB.Utils;
using MetroFramework.Forms;
using MetroFramework;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using PDV.UTIL.Components.Custom;
using System.Drawing;

namespace PDV.VIEW.Forms.Cadastro
{
    public partial class FCA_PerfilAcesso : DevExpress.XtraEditors.XtraForm
    {
        private string NOME_TELA = "CADASTRO DE PERFIL DE ACESSO";
        private PerfilAcesso Perfil = null;

        public FCA_PerfilAcesso(PerfilAcesso _Perfil)
        {
            InitializeComponent();
            Perfil = _Perfil;
            PreencherTela();
        }

        private void CarregarItens(bool Banco)
        {
            ovTV_Itens.Nodes.Clear();

            DataTable Modulos = FuncoesPerfilAcesso.GetModulos();
            foreach (DataRow dr in Modulos.Rows)
            {
                ovTV_Itens.Nodes.Add(dr["IDITEMMENU"].ToString(), dr["DESCRICAO"].ToString());
                MontarTreeView(Convert.ToDecimal(dr["IDITEMMENU"]));
            }
        }

        private void MontarTreeView(decimal IDItemMenuSuperior)
        {
            TreeNode NodeEncontrado = ovTV_Itens.Nodes.Find(IDItemMenuSuperior.ToString(), true).First();
            DataTable dt = FuncoesPerfilAcesso.GetItensPorItemMenuSuperior(IDItemMenuSuperior);
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    NodeEncontrado.Nodes.Add(dr["IDITEMMENU"].ToString(), dr["DESCRICAO"].ToString());
                    MontarTreeView(Convert.ToDecimal(dr["IDITEMMENU"]));
                }

            CarregarPermissoes();
        }

        private void CarregarPermissoes()
        {
            DataTable dt = FuncoesPerfilAcesso.GetItensMenuPorPerfil(Perfil.IDPerfilAcesso);
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode NodeEncontrado = ovTV_Itens.Nodes.Find(dr["IDITEMMENU"].ToString(), true).FirstOrDefault();
                if (NodeEncontrado != null)
                    NodeEncontrado.Checked = true;
            }
        }

        private void PreencherTela()
        {
            ovTXT_Descricao.Text = Perfil.Descricao;
            ovCKB_Ativo.Checked = Perfil.Ativo == 1;
            ovCKB_Admin.Checked = Perfil.IsAdmin == 1;

            /* Fazer a Árvore dos Itens de Menu */
            CarregarItens(true);

        }

        private List<TreeNode> GetSelecionados(bool Selecionado)
        {
            return ovTV_Itens.Nodes.Descendants().Where(n => n.Checked == Selecionado).ToList();
        }

        private void ovBTN_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ovBTN_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                PDVControlador.BeginTransaction();

                if (string.IsNullOrEmpty(ovTXT_Descricao.Text.Trim()))
                    throw new Exception("Informe a Descrição.");

                Perfil.Descricao = ovTXT_Descricao.Text;
                Perfil.Ativo = ovCKB_Ativo.Checked ? 1 : 0;
                Perfil.IsAdmin = ovCKB_Admin.Checked ? 1 : 0;

                DAO.Enum.TipoOperacao Op = DAO.Enum.TipoOperacao.UPDATE;
                if (!FuncoesPerfilAcesso.Existe(Perfil.IDPerfilAcesso))
                {
                    Perfil.IDPerfilAcesso = Sequence.GetNextID("PERFILACESSO", "IDPERFILACESSO");
                    Op = DAO.Enum.TipoOperacao.INSERT;
                }

                if (!FuncoesPerfilAcesso.Salvar(Perfil, Op))
                    throw new Exception("Não foi possível salvar o Perfil de Acesso.");

                foreach (TreeNode Node in GetSelecionados(false))
                    if (!FuncoesPerfilAcesso.RemoverPerfilAcessoItemMenu(Perfil.IDPerfilAcesso, Convert.ToDecimal(Node.Name)))
                        throw new Exception("Não foi possível salvar os Itens de Menu.");

                foreach (TreeNode Node in GetSelecionados(true))
                    if (!FuncoesPerfilAcesso.SalvarPerfilAcessoItemMenu(Sequence.GetNextID("PERFILACESSOITEMMENU", "IDPERFILACESSOITEMMENU"), Perfil.IDPerfilAcesso, Convert.ToDecimal(Node.Name)))
                        throw new Exception("Não foi possível salvar os Itens de Menu.");

                PDVControlador.Commit();
                MessageBox.Show(this, "Perfil de Acesso salvo com sucesso.", NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception Ex)
            {
                PDVControlador.Rollback();
                MessageBox.Show(this, Ex.Message, NOME_TELA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FCA_PerfilAcesso_Load(object sender, EventArgs e)
        {
            metroTabControl1.SelectedTab = metroTabControl1.TabPages[0];
        }

        private void CheckNodes(TreeNode Node)
        {
            if (Node.Nodes.Count > 0)
                foreach (TreeNode n in Node.Nodes)
                {
                    n.Checked = Node.Checked;
                    CheckNodes(n);
                }
        }

        private void ovTV_Itens_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var hitTest = e.Node.TreeView.HitTest(e.Location);
            if (hitTest.Location == TreeViewHitTestLocations.Label)
                e.Node.Checked = !e.Node.Checked;

            if (hitTest.Location != TreeViewHitTestLocations.Label && hitTest.Location != TreeViewHitTestLocations.StateImage)
                return;

            CheckNodes(e.Node);

            // Se todos os filhos estiver checkado, o Pai também deve estar Checkado.
            if (e.Node.Parent != null)
            {
                var QuantidadeDeFilhos = e.Node.Parent.Nodes.Descendants().Count();
                var QuantidadeDeFilhosChecados = e.Node.Parent.Nodes.Descendants().Where(n => n.Checked).Count();

                if (QuantidadeDeFilhos == QuantidadeDeFilhosChecados)
                {
                    e.Node.Parent.Checked = true;
                    CheckNodesParent(e.Node.Parent, true);
                }
                else if (QuantidadeDeFilhosChecados == 0)
                {
                    e.Node.Parent.Checked = false;
                    if (GetMasterParent(e.Node.Parent).Nodes.Descendants().Where(n => n.Checked).Count() == 0)
                        CheckNodesParent(e.Node.Parent, false);
                }
                else
                {
                    e.Node.Parent.Checked = true;
                    CheckNodesParent(e.Node.Parent, true);
                }
            }
        }

        private void CheckNodesParent(TreeNode Node, bool Check)
        {
            if (Node.Parent != null)
            {
                Node.Parent.Checked = Check;
                CheckNodesParent(Node.Parent, Check);
            }
        }

        private TreeNode GetMasterParent(TreeNode Node)
        {
            if (Node.Parent == null)
                return Node;

            if (Node.Parent.Nodes.Descendants().Where(n => n.Checked).Count() == 0)
                Node.Parent.Checked = false;

            return GetMasterParent(Node.Parent);
        }

        private void ovTV_Itens_AfterCheck(object sender, TreeViewEventArgs e)
        {
            e.Node.ForeColor = e.Node.Checked ? Color.DarkGreen : Color.Black;            
        }

        private void FCA_PerfilAcesso_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in ovTV_Itens.Nodes)
                MarcarNode(node);
        }

        private static void MarcarNode(TreeNode node)
        {
            node.Checked = true;
            foreach (TreeNode _node in node.Nodes)
                MarcarNode(_node);
        }
    }
}
