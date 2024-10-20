using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesProdutoNFeICMS
    {

        public static DataTable GetProdutoICMS(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTONFEICMS.*
                              FROM PRODUTONFEICMS 
                                INNER JOIN PRODUTONFE ON (PRODUTONFE.IDPRODUTONFE = PRODUTONFEICMS.IDPRODUTONFE)
                             WHERE PRODUTONFE.IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static ProdutoNFeICMS GetProdutoICMSPorProdutoNFe(decimal IDProdutoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTONFEICMS.*
                              FROM PRODUTONFEICMS 
                                INNER JOIN PRODUTONFE ON (PRODUTONFE.IDPRODUTONFE = PRODUTONFEICMS.IDPRODUTONFE)
                             WHERE PRODUTONFE.IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                oSQL.Open();
                return EntityUtil<ProdutoNFeICMS>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(ProdutoNFeICMS ProdutoNFeIcms, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO PRODUTONFEICMS(
                                                 IDPRODUTONFEICMS, IDORIGEMPRODUTO, IDCSTICMS, IDUNIDADEFEDERATIVAST, 
                                                 IDPRODUTONFE, MODBC, PREDBC, VBC, PICMS, VICMS, MODBCST, PMVAST, 
                                                 PREDBCST, VBCST, PICMSST, VICMSST, PCREDSN, VCREDICMSSN, PDIF, 
                                                 VICMSDIF)
                                         VALUES (@IDPRODUTONFEICMS, @IDORIGEMPRODUTO, @IDCSTICMS, @IDUNIDADEFEDERATIVAST, 
                                                 @IDPRODUTONFE, @MODBC, @PREDBC, @VBC, @PICMS, @VICMS, @MODBCST, @PMVAST, 
                                                 @PREDBCST, @VBCST, @PICMSST, @VICMSST, @PCREDSN, @VCREDICMSSN, @PDIF, 
                                                 @VICMSDIF)";
                        oSQL.ParamByName["IDPRODUTONFE"] = ProdutoNFeIcms.IDProdutoNFe;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PRODUTONFEICMS
                                       SET IDORIGEMPRODUTO = @IDORIGEMPRODUTO,
                                           IDCSTICMS = @IDCSTICMS,
                                           IDUNIDADEFEDERATIVAST = @IDUNIDADEFEDERATIVAST, 
                                           MODBC = @MODBC,
                                           PREDBC = @PREDBC,
                                           VBC = @VBC,
                                           PICMS = @PICMS,
                                           VICMS = @VICMS,
                                           MODBCST = @MODBCST, 
                                           PMVAST = @PMVAST,
                                           PREDBCST = @PREDBCST,
                                           VBCST = @VBCST,
                                           PICMSST = @PICMSST,
                                           VICMSST = @VICMSST,
                                           PCREDSN = @PCREDSN, 
                                           VCREDICMSSN = @VCREDICMSSN,
                                           PDIF = @PDIF,
                                           VICMSDIF = @VICMSDIF
                                     WHERE IDPRODUTONFEICMS = @IDPRODUTONFEICMS";
                        break;
                }
                oSQL.ParamByName["IDORIGEMPRODUTO"] = ProdutoNFeIcms.IDOrigemProduto;
                oSQL.ParamByName["IDCSTICMS"] = ProdutoNFeIcms.IDCstICMS;
                oSQL.ParamByName["IDUNIDADEFEDERATIVAST"] = ProdutoNFeIcms.IDUnidadeFederativaST;
                oSQL.ParamByName["MODBC"] = ProdutoNFeIcms.ModBC;
                oSQL.ParamByName["PREDBC"] = ProdutoNFeIcms.PRedBC;
                oSQL.ParamByName["VBC"] = ProdutoNFeIcms.VBc;
                oSQL.ParamByName["PICMS"] = ProdutoNFeIcms.PIcms;
                oSQL.ParamByName["VICMS"] = ProdutoNFeIcms.VIcms;
                oSQL.ParamByName["MODBCST"] = ProdutoNFeIcms.ModBCST;
                oSQL.ParamByName["PMVAST"] = ProdutoNFeIcms.PMVAST;
                oSQL.ParamByName["PREDBCST"] = ProdutoNFeIcms.PRedBcST;
                oSQL.ParamByName["VBCST"] = ProdutoNFeIcms.VBcST;
                oSQL.ParamByName["PICMSST"] = ProdutoNFeIcms.PIcmsST;
                oSQL.ParamByName["VICMSST"] = ProdutoNFeIcms.VIcmsST;
                oSQL.ParamByName["PCREDSN"] = ProdutoNFeIcms.PCredSN;
                oSQL.ParamByName["VCREDICMSSN"] = ProdutoNFeIcms.VCredIcmsSN;
                oSQL.ParamByName["PDIF"] = ProdutoNFeIcms.PDif;
                oSQL.ParamByName["VICMSDIF"] = ProdutoNFeIcms.VIcmsDif;
                oSQL.ParamByName["IDPRODUTONFEICMS"] = ProdutoNFeIcms.IDProdutoNFeICMS;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
