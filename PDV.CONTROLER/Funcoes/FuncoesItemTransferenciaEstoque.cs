using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Transferencia;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesItemTransferenciaEstoque
    {
        public static bool Salvar(ItemTransferenciaEstoque Item, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO ITEMTRANSFERENCIAESTOQUE(
                                               IDITEMTRANSFERENCIAESTOQUE, IDTRANSFERENCIAESTOQUE, IDPRODUTO, 
                                               IDALMOXARIFADOENTRADA, IDALMOXARIFADOSAIDA, QUANTIDADE)
                                       VALUES (@IDITEMTRANSFERENCIAESTOQUE, @IDTRANSFERENCIAESTOQUE, @IDPRODUTO, 
                                               @IDALMOXARIFADOENTRADA, @IDALMOXARIFADOSAIDA, @QUANTIDADE)";
                        oSQL.ParamByName["IDTRANSFERENCIAESTOQUE"] = Item.IDTransferenciaEstoque;
                        oSQL.ParamByName["IDPRODUTO"] = Item.IDProduto;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE ITEMTRANSFERENCIAESTOQUE
                                      SET IDALMOXARIFADOENTRADA = @IDALMOXARIFADOENTRADA,
                                          IDALMOXARIFADOSAIDA = @IDALMOXARIFADOSAIDA,
                                          QUANTIDADE = @QUANTIDADE
                                    WHERE IDITEMTRANSFERENCIAESTOQUE = @IDITEMTRANSFERENCIAESTOQUE";
                        break;
                }
                oSQL.ParamByName["IDITEMTRANSFERENCIAESTOQUE"] = Item.IDItemTransferenciaEstoque;
                oSQL.ParamByName["IDALMOXARIFADOENTRADA"] = Item.IDAlmoxarifadoEntrada;
                oSQL.ParamByName["IDALMOXARIFADOSAIDA"] = Item.IDAlmoxarifadoSaida;
                oSQL.ParamByName["QUANTIDADE"] = Item.Quantidade;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDItemTransferenciaEstoque)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ITEMTRANSFERENCIAESTOQUE WHERE IDITEMTRANSFERENCIAESTOQUE = @IDITEMTRANSFERENCIAESTOQUE";
                oSQL.ParamByName["IDITEMTRANSFERENCIAESTOQUE"] = IDItemTransferenciaEstoque;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM ITEMTRANSFERENCIAESTOQUE WHERE IDITEMTRANSFERENCIAESTOQUE = @IDITEMTRANSFERENCIAESTOQUE";
                oSQL.ParamByName["IDITEMTRANSFERENCIAESTOQUE"] = IDItemTransferenciaEstoque;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static ItemTransferenciaEstoque GetItem(decimal IDItemTransferenciaEstoque)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMTRANSFERENCIAESTOQUE,
IDTRANSFERENCIAESTOQUE,
IDPRODUTO,
IDALMOXARIFADOENTRADA,
IDALMOXARIFADOSAIDA,
QUANTIDADE FROM ITEMTRANSFERENCIAESTOQUE WHERE IDITEMTRANSFERENCIAESTOQUE = @IDITEMTRANSFERENCIAESTOQUE";
                oSQL.ParamByName["IDITEMTRANSFERENCIAESTOQUE"] = IDItemTransferenciaEstoque;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<ItemTransferenciaEstoque>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetItensPorTransferencia(decimal IDTransferenciaEstoque)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(PRODUTO.EAN, '<Não Informado>') as CODIGOPRODUTO,
                                    ITEMTRANSFERENCIAESTOQUE.QUANTIDADE,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    
                                    AE.DESCRICAO AS ALMOXARIFADOENTRADA,
                                    ASS.DESCRICAO AS ALMOXARIFADOSAIDA,
                             
                                    ITEMTRANSFERENCIAESTOQUE.IDALMOXARIFADOENTRADA,
                                    ITEMTRANSFERENCIAESTOQUE.IDALMOXARIFADOSAIDA,
                                    ITEMTRANSFERENCIAESTOQUE.IDITEMTRANSFERENCIAESTOQUE,
                                    PRODUTO.IDPRODUTO
                                    
                               FROM ITEMTRANSFERENCIAESTOQUE
                                INNER JOIN PRODUTO ON (ITEMTRANSFERENCIAESTOQUE.IDPRODUTO = PRODUTO.IDPRODUTO)
                                INNER JOIN ALMOXARIFADO AE ON (ITEMTRANSFERENCIAESTOQUE.IDALMOXARIFADOENTRADA = AE.IDALMOXARIFADO)
                                INNER JOIN ALMOXARIFADO ASS ON (ITEMTRANSFERENCIAESTOQUE.IDALMOXARIFADOSAIDA = ASS.IDALMOXARIFADO)
                             WHERE ITEMTRANSFERENCIAESTOQUE.IDTRANSFERENCIAESTOQUE = @IDTRANSFERENCIAESTOQUE";
                oSQL.ParamByName["IDTRANSFERENCIAESTOQUE"] = IDTransferenciaEstoque;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetProdutosComSaldoEmAlmoxarifado(decimal IDAlmoxarifado)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT PRODUTO.CODIGO,
                                     COALESCE(PRODUTO.EAN, '<Não Informado>') AS EAN,
                                     PRODUTO.DESCRICAO AS PRODUTO,
                                     MOVIMENTOESTOQUE.SALDOALMOXARIFADO AS SALDO,
                                     CAST(0 AS NUMERIC(15,4)) AS QUANTIDADE,
                                    ALMOXARIFADO.DESCRICAO AS ALMOXARIFADOENTRADA,
                                    ALMOXARIFADO.IDALMOXARIFADO,
                                    MOVIMENTOESTOQUE.IDPRODUTO       
                               FROM MOVIMENTOESTOQUE
                               INNER JOIN (SELECT MAX(IDMOVIMENTOESTOQUE) AS IDMOV,
                               IDALMOXARIFADO
                               FROM MOVIMENTOESTOQUE
                               GROUP BY IDALMOXARIFADO) MOV ON MOVIMENTOESTOQUE.IDALMOXARIFADO = MOV.IDALMOXARIFADO
                               AND MOVIMENTOESTOQUE.IDMOVIMENTOESTOQUE = MOV.IDMOV
                               INNER JOIN PRODUTO ON (MOVIMENTOESTOQUE.IDPRODUTO = PRODUTO.IDPRODUTO)
                               INNER JOIN ALMOXARIFADO ON (MOVIMENTOESTOQUE.IDALMOXARIFADO = ALMOXARIFADO.IDALMOXARIFADO)
                               WHERE MOVIMENTOESTOQUE.SALDOALMOXARIFADO > 0
                                AND ALMOXARIFADO.IDALMOXARIFADO = @IDALMOXARIFADO";
                oSQL.ParamByName["IDALMOXARIFADO"] = IDAlmoxarifado;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataRow GetProdutosComSaldoEmAlmoxarifado(decimal IDAlmoxarifado, decimal IDProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT PRODUTO.CODIGO,
                                COALESCE(PRODUTO.EAN, '<Não Informado>') AS EAN,
                                PRODUTO.DESCRICAO AS PRODUTO,
                                MOVIMENTOESTOQUE.SALDOALMOXARIFADO AS SALDO,
                                CAST(0 AS NUMERIC(15,4)) AS QUANTIDADE,
                                ALMOXARIFADO.DESCRICAO AS ALMOXARIFADOENTRADA,
                                ALMOXARIFADO.IDALMOXARIFADO,
                                MOVIMENTOESTOQUE.IDPRODUTO       
                                FROM MOVIMENTOESTOQUE
                                INNER JOIN (SELECT IDMOVIMENTOESTOQUE AS IDMOV,
                                IDALMOXARIFADO AS IDALMOXARIFADO
                                FROM MOVIMENTOESTOQUE
                                GROUP BY IDMOVIMENTOESTOQUE,IDALMOXARIFADO) MOV ON MOVIMENTOESTOQUE.IDALMOXARIFADO = MOV.IDALMOXARIFADO
                                AND MOVIMENTOESTOQUE.IDMOVIMENTOESTOQUE = MOV.IDMOV
                                INNER JOIN PRODUTO ON (MOVIMENTOESTOQUE.IDPRODUTO = PRODUTO.IDPRODUTO)
                                INNER JOIN ALMOXARIFADO ON (MOVIMENTOESTOQUE.IDALMOXARIFADO = ALMOXARIFADO.IDALMOXARIFADO)
                                WHERE MOVIMENTOESTOQUE.SALDOALMOXARIFADO > 0
                                AND PRODUTO.IDPRODUTO = @IDPRODUTO
                                AND ALMOXARIFADO.IDALMOXARIFADO = @IDALMOXARIFADO
                                ORDER BY MOVIMENTOESTOQUE.IDMOVIMENTOESTOQUE DESC";
                //SELECT CORRIGIDO POR RENATO
                oSQL.ParamByName["IDALMOXARIFADO"] = IDAlmoxarifado;
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return oSQL.dtDados.Rows[0];
            }
        }
    }
}