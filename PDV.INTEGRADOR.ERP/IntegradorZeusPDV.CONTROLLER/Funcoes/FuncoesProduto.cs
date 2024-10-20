using IntegradorZeusPDV.DB;
using IntegradorZeusPDV.DB.DB.Controller;
using IntegradorZeusPDV.DB.DB.Utils;
using IntegradorZeusPDV.MODEL.ClassesPDV;
using System.Data;

namespace IntegradorZeusPDV.CONTROLLER.Funcoes
{
    public class FuncoesProduto
    {
        public static bool Salvar(Produto Pro)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (!Existe(Pro.ChaveERP))
                {
                    oSQL.SQL = @"INSERT INTO PRODUTO 
                                    (IDPRODUTO, DESCRICAO, CODIGO,  EAN, VALORVENDA, VALORVENDAPRAZO, ATIVO, CHAVEERP, IDUnidadeDeMedida, IDOrigemProduto, IDIntegracaoFiscalNFCe, Trib_MVA, 
                                    Trib_RedBCICMS, Trib_RedBCICMSST, Trib_AliqCOFINS, Trib_AliqICMSDif, Trib_AliqIPI, Trib_AliqPIS, VENDERSEMSALDO)
                                  VALUES 
                                    (@IDPRODUTO, @DESCRICAO, @CODIGO, @EAN, @VALORVENDA, @VALORVENDAPRAZO, @ATIVO, @CHAVEERP, @IDUNIDADEDEMEDIDA, @IDORIGEMPRODUTO, @IDINTEGRACAOFISCALNFCE, @TRIB_MVA,
                                    @TRIB_REDBCICMS, @TRIB_REDBICMSST, @TRIB_ALIQCOFINS, @TRIB_ALIQICMSDIF, @TRIB_ALIQIPI, @TRIB_ALIQPIS, @VENDERSEMSALDO)";
                    oSQL.ParamByName["IDPRODUTO"] = Sequence.GetNextID("PRODUTO", "IDPRODUTO");
                    oSQL.ParamByName["DESCRICAO"] = Pro.Descricao;
                    oSQL.ParamByName["CODIGO"] = Pro.EAN;
                    oSQL.ParamByName["EAN"] = Pro.EAN;
                    oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = Pro.IDUnidadeDeMedida;
                    oSQL.ParamByName["IDOrigemProduto"] = Pro.IDOrigemProduto;
                    oSQL.ParamByName["IDIntegracaoFiscalNFCe"] = Pro.IDIntegracaoFiscalNFCe;
                    oSQL.ParamByName["Trib_MVA"] = Pro.Trib_MVA;
                    oSQL.ParamByName["Trib_RedBCICMS"] = Pro.Trib_RedBCICMS;
                    oSQL.ParamByName["TRIB_REDBICMSST"] = Pro.Trib_RedBCICMSST;
                    oSQL.ParamByName["TRIB_ALIQCOFINS"] = Pro.Trib_AliqCOFINS;
                    oSQL.ParamByName["TRIB_ALIQICMSDIF"] = Pro.Trib_AliqICMSDif;
                    oSQL.ParamByName["TRIB_ALIQIPI"] = Pro.Trib_AliqIPI;
                    oSQL.ParamByName["TRIB_ALIQPIS"] = Pro.Trib_AliqPIS;
                    oSQL.ParamByName["VENDERSEMSALDO"] = 1;


                    //   oSQL.ParamByName["IDNCM"] = Pro.IDNCM;
                }
                else
                {
                    oSQL.SQL = @"UPDATE PRODUTO 
                                    SET DESCRICAO = @DESCRICAO,
                                        VALORVENDA = @VALORVENDA,
                                        VALORVENDAPRAZO = @VALORVENDAPRAZO,
                                        IDNCM = @IDNCM,
                                        ATIVO = @ATIVO,
                                        EAN = @EAN
                                 WHERE CHAVEERP = @CHAVEERP";
                }
                oSQL.ParamByName["DESCRICAO"] = Pro.Descricao;
                oSQL.ParamByName["VALORVENDA"] = Pro.ValorVenda;
                oSQL.ParamByName["VALORVENDAPRAZO"] = Pro.ValorVendaPrazo;
                oSQL.ParamByName["IDNCM"] = Pro.IDNCM;
                oSQL.ParamByName["ATIVO"] = Pro.Ativo;
                oSQL.ParamByName["CHAVEERP"] = Pro.ChaveERP;
                oSQL.ParamByName["EAN"] = Pro.EAN;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static Produto GetProduto(decimal IDProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT P.* FROM PRODUTO P WHERE P.IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Produto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(string ChaveERP)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM PRODUTO WHERE CHAVEERP = @CHAVEERP";
                oSQL.ParamByName["CHAVEERP"] = ChaveERP;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static DataTable NCM(string codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNCM,
IDUNIDADEFEDERATIVA,
CODIGO,
EX,
TIPO,
DESCRICAO,
NACIONALFEDERAL,
IMPORTADOSFEDERAL,
ESTADUAL,
MUNICIPAL,
VIGENCIAINICIO,
VIGENCIAFIM,
CHAVE,
VERSAO,
FONTE FROM NCM WHERE CODIGO = @NCM";
                oSQL.ParamByName["NCM"] = codigo;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
