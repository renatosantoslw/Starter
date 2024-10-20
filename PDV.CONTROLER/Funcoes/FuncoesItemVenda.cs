using System;
using System.Collections.Generic;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Custom;
using System.Linq;
using PDV.DAO.GridViewModels;
using PDV.DAO.QueryModels;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using PDV.DAO.QueryModels;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesItemVenda
    {
        public static bool RemoverItensDaVenda(List<ItemVenda> ItensVenda, decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<ItemVenda> ItensExistenteNaVenda = GetItensVenda(IDVenda);
                foreach (ItemVenda Item in ItensVenda)
                {
                    if (ItensExistenteNaVenda.Where(o => o.IDItemVenda == Item.IDItemVenda).FirstOrDefault() == null)
                    {
                        if (!RemoverItemVenda(Item.IDItemVenda))
                            throw new Exception("Não é possível remover os Itens da Venda.");
                    }
                }


                oSQL.SQL = "DELETE FROM ITEMVENDA WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                return oSQL.ExecSQL() >= 0;
            }
        }


        public static bool SalvarItemVenda(ItemVenda Item)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (ExisteItem(Item.IDItemVenda))
                    return true;

                oSQL.SQL = @"INSERT INTO ITEMVENDA(
                                         IDITEMVENDA, IDPRODUTO, IDVENDA, QUANTIDADE, DESCONTOPORCENTAGEM, 
                                          DESCONTOVALOR, VALORUNITARIOITEM, IDUSUARIO, DESCRICAO, ALTURA, LARGURA, AREA,
                                          SUBTOTAL)
                                 VALUES (@IDITEMVENDA, @IDPRODUTO, @IDVENDA, @QUANTIDADE, @DESCONTOPORCENTAGEM, 
                                        @DESCONTOVALOR, @VALORUNITARIOITEM, @IDUSUARIO, @DESCRICAO, @ALTURA, @LARGURA, @AREA,
                                        @SUBTOTAL)";
                oSQL.ParamByName["IDITEMVENDA"] = Item.IDItemVenda;
                oSQL.ParamByName["IDPRODUTO"] = Item.IDProduto;
                oSQL.ParamByName["IDVENDA"] = Item.IDVenda;
                oSQL.ParamByName["QUANTIDADE"] = Item.Quantidade;
                oSQL.ParamByName["DESCONTOPORCENTAGEM"] = Item.DescontoPorcentagem;
                oSQL.ParamByName["DESCONTOVALOR"] = Item.DescontoValor;
                oSQL.ParamByName["VALORUNITARIOITEM"] = Item.ValorUnitarioItem;
                oSQL.ParamByName["IDUSUARIO"] = Item.IDUsuario;
                oSQL.ParamByName["DESCRICAO"] = Item.DescricaoItem;
                oSQL.ParamByName["ALTURA"] = Item.Altura;
                oSQL.ParamByName["LARGURA"] = Item.Largura;
                oSQL.ParamByName["AREA"] = Item.Area;
                oSQL.ParamByName["SUBTOTAL"] = Item.Subtotal;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool UpdateDescontoItens(ItemVenda Item)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE ITEMVENDA 
                               SET DESCONTOPORCENTAGEM = @DESCONTOPORCENTAGEM,
                                   DESCONTOVALOR = @DESCONTOVALOR
                               WHERE IDITEMVENDA = @IDITEMVENDA";
                oSQL.ParamByName["IDITEMVENDA"] = Item.IDItemVenda;
                oSQL.ParamByName["DESCONTOPORCENTAGEM"] = Item.DescontoPorcentagem;
                oSQL.ParamByName["DESCONTOVALOR"] = Item.DescontoValor;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<MovimentoDeEstoquePorVendaGridViewModel> GetMovimentoPorVenda(MovimentoDeEstoquePorVendaQueryModel pesquisa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
	                            VENDA.IDVENDA AS IDVENDA,
                                PRODUTO.EAN,
	                            UPPER(PRODUTO.DESCRICAO) AS PRODUTO,	
	                            VENDA.DATAFATURAMENTO AS DATAFATURAMENTO,
	                            UPPER(TIPODEOPERACAO.NOME) AS OPERACAO,
	                            UPPER(MARCA.DESCRICAO) AS GRUPO,
	                            SUM(ITEMVENDA.QUANTIDADE) AS QUANTIDADE	
                            FROM ITEMVENDA
                            JOIN VENDA ON  (ITEMVENDA.IDVENDA = VENDA.IDVENDA)
                            JOIN PRODUTO ON (ITEMVENDA.IDPRODUTO = PRODUTO.IDPRODUTO)
                            JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                            JOIN TIPODEOPERACAO ON (VENDA.IDTIPODEOPERACAO = TIPODEOPERACAO.IDTIPODEOPERACAO)
                            WHERE TIPODEOPERACAO.TIPODEMOVIMENTO = @TIPODEMOVIMENTO
                            AND VENDA.STATUS = @FATURADO
                            AND (VENDA.DATAFATURAMENTO BETWEEN @DATADE AND @DATAATE)
                            AND (UPPER(PRODUTO.DESCRICAO) LIKE @PESQUISA OR PRODUTO.EAN LIKE @PESQUISA)                            
                            GROUP BY PRODUTO.DESCRICAO, PRODUTO.EAN, VENDA.IDVENDA, VENDA.DATAFATURAMENTO, TIPODEOPERACAO.NOME, MARCA.DESCRICAO
                            ORDER BY DATAFATURAMENTO DESC";
                oSQL.ParamByName["DATADE"] = pesquisa.DataDe;
                oSQL.ParamByName["DATAATE"] = pesquisa.DataAte;
                oSQL.ParamByName["PESQUISA"] = $"%{pesquisa.Pesquisa}%".ToUpper();
                oSQL.ParamByName["TIPODEMOVIMENTO"] = TipoDeOperacao.Saida;
                oSQL.ParamByName["FATURADO"] = StatusPedido.Faturado;
                oSQL.Open();
                return new DataTableParser<MovimentoDeEstoquePorVendaGridViewModel>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ItemVenda> GetItens(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMVENDA, 
                                    ITEMVENDA.IDPRODUTO,
                                    IDVENDA,
                                    QUANTIDADE, 
                                    DESCONTOPORCENTAGEM, 
                                    DESCONTOVALOR,
                                    VALORUNITARIOITEM,
                                    ALTURA,
                                    LARGURA,
                                    AREA,
                                    SUBTOTAL
                               FROM ITEMVENDA
                                JOIN PRODUTO ON (PRODUTO.IDPRODUTO = ITEMVENDA.IDPRODUTO)
                              WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return new DataTableParser<ItemVenda>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ItemVenda> GetItensVenda(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMVENDA, 
                                    PRODUTO.IDPRODUTO, 
                                    PRODUTO.CODIGO AS CODIGOITEM,
                                    PRODUTO.DESCRICAO AS DESCRICAOITEM,
                                    IDVENDA, 
                                    ITEMVENDA.IDUSUARIO,
                                    QUANTIDADE, 
                                    DESCONTOPORCENTAGEM,
                                    DESCONTOVALOR,
                                    VALORUNITARIOITEM,
                                    ALTURA,
                                    LARGURA,
                                    AREA,
                                   SUBTOTAL
                                    FROM ITEMVENDA
                                    JOIN PRODUTO ON (PRODUTO.IDPRODUTO = ITEMVENDA.IDPRODUTO)
                                    WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return new DataTableParser<ItemVenda>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool RemoverItemVenda(decimal IDItemVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM ITEMVENDA WHERE IDITEMVENDA = @IDITEMVENDA";
                oSQL.ParamByName["IDITEMVENDA"] = IDItemVenda;
                return oSQL.ExecSQL() >= 0;
            }
        }

        public static bool ExisteItem(decimal IDItemVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ITEMVENDA WHERE IDITEMVENDA = @IDITEMVENDA";
                oSQL.ParamByName["IDITEMVENDA"] = IDItemVenda;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static ItemVenda GetItemVenda(decimal IDItemVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMVENDA,
IDUSUARIO,
IDPRODUTO,
IDVENDA,
QUANTIDADE,
DESCONTOPORCENTAGEM,
DESCONTOVALOR,
VALORUNITARIOITEM,
DESCRICAO,
ALTURA,
LARGURA,
AREA,
SUBTOTAL,
IMPRESSOFICHA FROM ITEMVENDA WHERE IDITEMVENDA = @IDITEMVENDA";
                oSQL.ParamByName["IDITEMVENDA"] = IDItemVenda;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<ItemVenda>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
