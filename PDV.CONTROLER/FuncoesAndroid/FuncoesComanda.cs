using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.PDV;
using System.Collections.Generic;

namespace PDV.CONTROLER.FuncoesAndroid
{
    public class FuncoesComanda
    {
        public static List<Comanda> GetComandas()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COMANDA.IDCOMANDA,
                                    COMANDA.CODIGO,
                                    COMANDA.DESCRICAO,
                                    COALESCE(CLIENTE.CPF, CLIENTE.CNPJ) AS CPF,
                                    CASE WHEN VENDA.IDVENDA IS NULL THEN 0 ELSE 1 END AS STATUS,
                                    COALESCE(VENDA.IDVENDA, -1) AS IDVENDA
                               FROM COMANDA
                             LEFT JOIN VENDA ON (COMANDA.IDCOMANDA = VENDA.IDCOMANDA
                                             AND VENDA.IDCOMANDAUTILIZADA IS NULL
                                             AND VENDA.IDVENDA NOT IN (SELECT IDVENDA 
                                                                         FROM DUPLICATANFCE
                                                                        WHERE VENDA.IDVENDA = DUPLICATANFCE.IDVENDA))
                             LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                             ORDER BY COMANDA.DESCRICAO, COMANDA.CODIGO";
                oSQL.Open();
                return new DataTableParser<Comanda>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ItemVenda> GetProdutosComandaPorComanda(decimal IDComanda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMVENDA, 
                                    PRODUTO.IDPRODUTO, 
                                    PRODUTO.CODIGO AS CODIGOITEM,
                                    PRODUTO.DESCRICAO AS DESCRICAOITEM,
                                    VENDA.IDVENDA, 
                                    QUANTIDADE, 
                                    DESCONTOPORCENTAGEM, 
                                    DESCONTOVALOR,
                                    VALORUNITARIOITEM,
                                    VALORUNITARIOITEM * QUANTIDADE AS VALORTOTALITEM,
                                    MARCA.DESCRICAO AS MARCA
                               FROM ITEMVENDA
                                INNER JOIN VENDA ON VENDA.IDVENDA = ITEMVENDA.IDVENDA
                                INNER JOIN PRODUTO ON ITEMVENDA.IDPRODUTO = PRODUTO.IDPRODUTO
                                 LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                              WHERE VENDA.IDCOMANDA = @IDCOMANDA
                                AND VENDA.IDVENDA NOT IN (SELECT IDVENDA FROM DUPLICATANFCE)";
                oSQL.ParamByName["IDCOMANDA"] = IDComanda;
                oSQL.Open();
                return new DataTableParser<ItemVenda>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
