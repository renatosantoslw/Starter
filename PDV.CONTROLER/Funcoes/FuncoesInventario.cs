using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.InventarioEstoque;
using PDV.DAO.Enum;
using System;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesInventario
    {

        public static bool Salvar(Inventario Invent, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO INVENTARIO (IDINVENTARIO, DATAINVENTARIO) VALUES (@IDINVENTARIO, @DATAINVENTARIO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE INVENTARIO SET DATAINVENTARIO = @DATAINVENTARIO WHERE IDINVENTARIO = @IDINVENTARIO";
                        break;
                }
                oSQL.ParamByName["IDINVENTARIO"] = Invent.IDInventario;
                oSQL.ParamByName["DATAINVENTARIO"] = Invent.DataInventario;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool SalvarItemInventario(ItemInventario Item, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO ITEMINVENTARIO
                                       (IDITEMINVENTARIO, IDINVENTARIO, IDPRODUTO, IDALMOXARIFADO, QUANTIDADE)
                                     VALUES
                                       (@IDITEMINVENTARIO, @IDINVENTARIO, @IDPRODUTO, @IDALMOXARIFADO, @QUANTIDADE)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE ITEMINVENTARIO
                                        SET IDPRODUTO = @IDPRODUTO, 
                                            IDALMOXARIFADO = @IDALMOXARIFADO,
                                            QUANTIDADE = @QUANTIDADE
                                     WHERE IDITEMINVENTARIO = @IDITEMINVENTARIO";
                        break;
                }
                oSQL.ParamByName["IDITEMINVENTARIO"] = Item.IDItemInventario;
                oSQL.ParamByName["IDINVENTARIO"] = Item.IDInventario;
                oSQL.ParamByName["IDPRODUTO"] = Item.IDProduto;
                oSQL.ParamByName["IDALMOXARIFADO"] = Item.IDAlmoxarifado;
                oSQL.ParamByName["QUANTIDADE"] = Item.Quantidade;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool RemoverInventario(decimal IDInventario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM ITEMINVENTARIO WHERE IDINVENTARIO = @IDINVENTARIO";
                oSQL.ParamByName["IDINVENTARIO"] = IDInventario;
                oSQL.ExecSQL();

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM INVENTARIO WHERE IDINVENTARIO = @IDINVENTARIO";
                oSQL.ParamByName["IDINVENTARIO"] = IDInventario;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool RemoverItemInventario(decimal IDItemInventario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM ITEMINVENTARIO WHERE IDITEMINVENTARIO = @IDITEMINVENTARIO";
                oSQL.ParamByName["IDITEMINVENTARIO"] = IDItemInventario;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static ItemInventario GetItemInventario(decimal IDItemInventario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMINVENTARIO,
IDINVENTARIO,
IDPRODUTO,
IDALMOXARIFADO,
QUANTIDADE FROM ITEMINVENTARIO WHERE IDITEMINVENTARIO = @IDITEMINVENTARIO";
                oSQL.ParamByName["IDITEMINVENTARIO"] = IDItemInventario;
                oSQL.Open();
                return EntityUtil<ItemInventario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Inventario GetInventario(decimal IDInventario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDITEMINVENTARIO,
IDINVENTARIO,
IDPRODUTO,
IDALMOXARIFADO,
QUANTIDADE FROM ITEMINVENTARIO WHERE IDINVENTARIO = @IDINVENTARIO";
                oSQL.ParamByName["IDINVENTARIO"] = IDInventario;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Inventario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


        public static DataTable GetItensDoInventario(decimal IDInventario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ALMOXARIFADO.DESCRICAO AS ALMOXARIFADO,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    ITEMINVENTARIO.QUANTIDADE,

                                    ALMOXARIFADO.IDALMOXARIFADO,
                                    PRODUTO.IDPRODUTO,
                                    ITEMINVENTARIO.IDITEMINVENTARIO
                               FROM ITEMINVENTARIO
                                 INNER JOIN ALMOXARIFADO ON (ITEMINVENTARIO.IDALMOXARIFADO = ALMOXARIFADO.IDALMOXARIFADO)
                                 INNER JOIN PRODUTO ON (ITEMINVENTARIO.IDPRODUTO = PRODUTO.IDPRODUTO)
                             WHERE ITEMINVENTARIO.IDINVENTARIO = @IDINVENTARIO";
                oSQL.ParamByName["IDINVENTARIO"] = IDInventario;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetInventarios(DateTime DataInicial, DateTime DataFinal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                
                 oSQL.SQL = "select IDINVENTARIO, DATAINVENTARIO from inventario WHERE DATAINVENTARIO BETWEEN @DATAINICIAL AND @DATAFINAL";
                oSQL.ParamByName["DATAINICIAL"] = DataInicial;
                oSQL.ParamByName["DATAFINAL"] = DataFinal;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
