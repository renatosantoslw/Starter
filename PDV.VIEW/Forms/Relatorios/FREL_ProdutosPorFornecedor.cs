using MetroFramework.Forms;
using PDV.CONTROLER.Funcoes;
using PDV.DAO.Entidades;
using PDV.REPORTS.Reports.ProdutosPorFornecedor;
using PDV.VIEW.App_Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PDV.VIEW.Forms.Relatorios
{
    public partial class FREL_ProdutosPorFornecedor : DevExpress.XtraEditors.XtraForm
    {
        List<Fornecedor> Fornecedores = FuncoesFornecedor.GetFornecedores();
        List<Marca> Marcas = FuncoesMarca.GetMarcas();
        List<Categoria> Categorias = FuncoesCategoria.GetCategorias();
        List<Categoria> SubCategorias = FuncoesCategoria.GetCategorias();

        public FREL_ProdutosPorFornecedor()
        {
            InitializeComponent();

            ovCMB_Fornecedor.DataSource = Fornecedores;
            ovCMB_Fornecedor.DisplayMember = "descricao";
            ovCMB_Fornecedor.ValueMember = "idfornecedor";
            ovCMB_Fornecedor.SelectedItem = null;

            ovCMB_Marca.DataSource = Marcas;
            ovCMB_Marca.DisplayMember = "descricao";
            ovCMB_Marca.ValueMember = "idmarca";
            ovCMB_Marca.SelectedItem = null;

            ovCMB_Categoria.DataSource = Categorias;
            ovCMB_Categoria.DisplayMember = "idcategoria";
            ovCMB_Categoria.ValueMember = "descricao";
            ovCMB_Categoria.SelectedItem = null;

            ovCMB_SubCategoria.DataSource = SubCategorias;
            ovCMB_SubCategoria.DisplayMember = "idcategoria";
            ovCMB_SubCategoria.ValueMember = "descricao";
            ovCMB_SubCategoria.SelectedItem = null;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            Fornecedor _Fornecedor = ovCMB_Fornecedor.SelectedItem as Fornecedor;
            Categoria _Categoria = ovCMB_Categoria.SelectedItem as Categoria;
            Marca _Marca = ovCMB_Marca.SelectedItem as Marca;
            Categoria _SubCategoria = ovCMB_SubCategoria.SelectedItem as Categoria;


            ProdutosPorFornecedor RelatorioProdutosPorFornecedor = new ProdutosPorFornecedor(string.Format("{0} - ({1})", Contexto.USUARIOLOGADO.Nome, Contexto.USUARIOLOGADO.Login),
                                                                                             _Fornecedor == null ? "<Todos>" : _Fornecedor.Descricao,
                                                                                             _Marca == null ? "<Todas>" : _Marca.CodigoDescricao,
                                                                                             _Categoria == null ? "<Todas>" : _Categoria.Descricao,
                                                                                             _SubCategoria == null ? "<Todas>" : _SubCategoria.Descricao,
                                                                                             _Fornecedor == null ? -1 : _Fornecedor.IDFornecedor,
                                                                                             _Marca == null ? -1 : _Marca.IDMarca,
                                                                                             _Categoria == null ? -1 : _Categoria.IDCategoria,
                                                                                             _SubCategoria == null ? -1 : _SubCategoria.IDCategoria);

            Stream STRel = new MemoryStream();
            RelatorioProdutosPorFornecedor.ExportToPdf(STRel);
            new FREL_Preview(STRel).ShowDialog(this);

            //SaveFileDialog SaveFile = new SaveFileDialog();
            //SaveFile.Filter = "RTF|*.rtf|PDF|*.pdf|XLS|*.xls|XLSX|*.xlsx";
            //SaveFile.Title = "Salvar Relatório De Produtos Por Fornecedor";
            //SaveFile.ShowDialog(this);
            //SaveFile.ShowHelp = false;
            //if (string.IsNullOrEmpty(SaveFile.FileName))
            //    return;

            //switch (SaveFile.FilterIndex)
            //{
            //    case 1:
            //        RelatorioProdutosPorFornecedor.ExportToRtf(SaveFile.FileName);
            //        break;
            //    case 2:
            //        RelatorioProdutosPorFornecedor.ExportToPdf(SaveFile.FileName);
            //        break;
            //    case 3:
            //        RelatorioProdutosPorFornecedor.ExportToXls(SaveFile.FileName);
            //        break;
            //    case 4:
            //        RelatorioProdutosPorFornecedor.ExportToXlsx(SaveFile.FileName);
            //        break;
            //}
        }
    }
}
