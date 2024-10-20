using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesProdutoNFeCOFINS
    {
        public static DataTable GetProdutoCOFINS(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTONFECOFINS.* 
                               FROM PRODUTONFECOFINS
                                 INNER JOIN PRODUTONFE ON (PRODUTONFECOFINS.IDPRODUTONFE = PRODUTONFE.IDPRODUTONFE)
                             WHERE PRODUTONFE.IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static ProdutoNFeCOFINS GetProdutoCOFINSPorProdutoNFe(decimal IDProdutoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTONFECOFINS.* 
                               FROM PRODUTONFECOFINS
                                 INNER JOIN PRODUTONFE ON (PRODUTONFECOFINS.IDPRODUTONFE = PRODUTONFE.IDPRODUTONFE)
                             WHERE PRODUTONFE.IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                oSQL.Open();
                return EntityUtil<ProdutoNFeCOFINS>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(ProdutoNFeCOFINS ProdutoNFeCOFINS, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO PRODUTONFECOFINS (IDPRODUTONFECOFINS, IDPRODUTONFE, IDCSTCOFINS, VBC, PCOFINS, VCOFINS)
                                         VALUES (@IDPRODUTONFECOFINS, @IDPRODUTONFE, @IDCSTCOFINS, @VBC, @PCOFINS, @VCOFINS)";
                        oSQL.ParamByName["IDPRODUTONFE"] = ProdutoNFeCOFINS.IDProdutoNFe;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PRODUTONFECOFINS
                                       SET IDCSTCOFINS = @IDCSTCOFINS,
                                           VBC = @VBC,
                                           PCOFINS = @PCOFINS,
                                           VCOFINS = @VCOFINS
                                     WHERE IDPRODUTONFECOFINS = @IDPRODUTONFECOFINS";
                        break;
                }
                oSQL.ParamByName["IDPRODUTONFECOFINS"] = ProdutoNFeCOFINS.IDProdutoNFeCOFINS;
                oSQL.ParamByName["IDCSTCOFINS"] = ProdutoNFeCOFINS.IDCstCOFINS;
                oSQL.ParamByName["VBC"] = ProdutoNFeCOFINS.VBc;
                oSQL.ParamByName["PCOFINS"] = ProdutoNFeCOFINS.PCOFINS;
                oSQL.ParamByName["VCOFINS"] = ProdutoNFeCOFINS.VCOFINS;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
