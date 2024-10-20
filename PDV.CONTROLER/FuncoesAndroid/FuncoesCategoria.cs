using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System.Collections.Generic;

namespace PDV.CONTROLER.FuncoesAndroid
{
    public class FuncoesCategoria
    {
        public static List<Categoria> GetCategoriasComSubCategorias()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT CATEGORIA.IDCATEGORIA AS IDCATEGORIA,
                                    CATEGORIA.DESCRICAO,
                                    
                                    ARRAY_TO_STRING(ARRAY(SELECT SUBCATEGORIA.DESCRICAO 
                                                            FROM PRODUTO
                                                             LEFT JOIN CATEGORIA SUBCATEGORIA ON PRODUTO.IDSUBCATEGORIA = SUBCATEGORIA.IDCATEGORIA
                                                           WHERE PRODUTO.IDCATEGORIA = CATEGORIA.IDCATEGORIA
                                                          ), ', ') AS SUBCATEGORIAS
                               FROM PRODUTO
                                 INNER JOIN CATEGORIA ON (PRODUTO.IDCATEGORIA = CATEGORIA.IDCATEGORIA)
                                 LEFT JOIN CATEGORIA SUBCATEGORIA ON (PRODUTO.IDSUBCATEGORIA = SUBCATEGORIA.IDCATEGORIA)";
                oSQL.Open();
                return new DataTableParser<Categoria>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}