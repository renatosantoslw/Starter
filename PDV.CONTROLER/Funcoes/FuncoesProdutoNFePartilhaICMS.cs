using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesProdutoNFePartilhaICMS
    {
        public static bool Salvar(ProdutoNFePartilhaICMS Prod, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO PRODUTONFEPARTILHAICMS(
                                                 IDPRODUTONFEPARTILHAICMS, IDPRODUTONFE, VBCUFDEST, PFCPUFDEST, 
                                                 PICMSUFDEST, PICMSINTER, PICMSINTERPART, VFCPUFDEST, VICMSUFDEST, 
                                                 VICMSUFREMET)
                                         VALUES (@IDPRODUTONFEPARTILHAICMS, @IDPRODUTONFE, @VBCUFDEST, @PFCPUFDEST, 
                                                 @PICMSUFDEST, @PICMSINTER, @PICMSINTERPART, @VFCPUFDEST, @VICMSUFDEST, 
                                                 @VICMSUFREMET)";
                        oSQL.ParamByName["IDPRODUTONFE"] = Prod.IDProdutoNFe;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PRODUTONFEPARTILHAICMS
                                        SET VBCUFDEST = @VBCUFDEST, 
                                            PFCPUFDEST = @PFCPUFDEST,
                                            PICMSUFDEST = @PICMSUFDEST,
                                            PICMSINTER = @PICMSINTER,
                                            PICMSINTERPART = @PICMSINTERPART,
                                            VFCPUFDEST = @VFCPUFDEST,
                                            VICMSUFDEST = @VICMSUFDEST,
                                            VICMSUFREMET = @VICMSUFREMET
                                      WHERE IDPRODUTONFEPARTILHAICMS = @IDPRODUTONFEPARTILHAICMS";
                        break;
                }
                oSQL.ParamByName["VBCUFDEST"] = Prod.VBcUFDest;
                oSQL.ParamByName["PFCPUFDEST"] = Prod.PFcpUFDest;
                oSQL.ParamByName["PICMSUFDEST"] = Prod.PIcmsUFDest;
                oSQL.ParamByName["PICMSINTER"] = Prod.PIcmsInter;
                oSQL.ParamByName["PICMSINTERPART"] = Prod.PIcmsInterPart;
                oSQL.ParamByName["VFCPUFDEST"] = Prod.VFcpUFDest;
                oSQL.ParamByName["VICMSUFDEST"] = Prod.VIcmsUFDest;
                oSQL.ParamByName["VICMSUFREMET"] = Prod.VIcmsUFRemet;
                oSQL.ParamByName["IDPRODUTONFEPARTILHAICMS"] = Prod.IDProdutoNFePartilhaICMS;
                return oSQL.ExecSQL() == 1;
            }
        }
        
        public static DataTable GetPartilhas(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTONFEPARTILHAICMS.*
                               FROM PRODUTONFEPARTILHAICMS
                                 INNER JOIN PRODUTONFE ON (PRODUTONFEPARTILHAICMS.IDPRODUTONFE = PRODUTONFE.IDPRODUTONFE)
                             WHERE PRODUTONFE.IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static ProdutoNFePartilhaICMS GetPartilhasPorProdutoNFe(decimal IDProdutoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT PRODUTONFEPARTILHAICMS.*
                               FROM PRODUTONFEPARTILHAICMS
                                 INNER JOIN PRODUTONFE ON (PRODUTONFEPARTILHAICMS.IDPRODUTONFE = PRODUTONFE.IDPRODUTONFE)
                             WHERE PRODUTONFE.IDPRODUTONFE = @IDPRODUTONFE";
                oSQL.ParamByName["IDPRODUTONFE"] = IDProdutoNFe;
                oSQL.Open();
                return EntityUtil<ProdutoNFePartilhaICMS>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
