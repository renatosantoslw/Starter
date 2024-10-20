using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesProdutoNFePIS
    {
        public static DataTable GetProdutoPIS(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTONFEPIS.* 
                               FROM PRODUTONFEPIS 
                                 INNER JOIN PRODUTONFE ON (PRODUTONFEPIS.IDPRODUTONFE = PRODUTONFE.IDPRODUTONFE)
                             WHERE PRODUTONFE.IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static ProdutoNFePIS GetProdutoPISPorProdutoNFe(decimal IDProdutoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTONFEPIS.* 
                               FROM PRODUTONFEPIS 
                                 INNER JOIN PRODUTONFE ON (PRODUTONFEPIS.IDPRODUTONFE = PRODUTONFE.IDPRODUTONFE)
                             WHERE PRODUTONFE.IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                oSQL.Open();
                return EntityUtil<ProdutoNFePIS>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(ProdutoNFePIS ProdutoNFePis, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO PRODUTONFEPIS (IDPRODUTONFEPIS, IDPRODUTONFE, IDCSTPIS, VBC, PPIS, VPIS)
                                         VALUES (@IDPRODUTONFEPIS, @IDPRODUTONFE, @IDCSTPIS, @VBC, @PPIS, @VPIS)";
                        oSQL.ParamByName["IDPRODUTONFE"] = ProdutoNFePis.IDProdutoNFe;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PRODUTONFEPIS
                                       SET IDCSTPIS = @IDCSTPIS,
                                           VBC = @VBC,
                                           PPIS = @PPIS,
                                           VPIS = @VPIS
                                     WHERE IDPRODUTONFEPIS = @IDPRODUTONFEPIS";
                        break;
                }
                oSQL.ParamByName["IDPRODUTONFEPIS"] = ProdutoNFePis.IDProdutoNFePIS;
                oSQL.ParamByName["IDCSTPIS"] = ProdutoNFePis.IDCstPIS;
                oSQL.ParamByName["VBC"] = ProdutoNFePis.VBc;
                oSQL.ParamByName["PPIS"] = ProdutoNFePis.PPis;
                oSQL.ParamByName["VPIS"] = ProdutoNFePis.VPis;
                return oSQL.ExecSQL() == 1;
            }
        }

        
    }
}
