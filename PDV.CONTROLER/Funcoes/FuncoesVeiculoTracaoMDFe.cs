using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesVeiculoTracaoMDFe
    {
        public static bool Salvar(VeiculoTracaoMDFe VeiculoTracao, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch(Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO VEICULOTRACAOMDFE(
                                              IDVEICULOTRACAOMDFE, IDPROPRIETARIOVEICULOMDFE, IDCONDUTOR, IDVEICULO, 
                                              IDMDFE)
                                      VALUES (@IDVEICULOTRACAOMDFE, @IDPROPRIETARIOVEICULOMDFE, @IDCONDUTOR, @IDVEICULO, 
                                              @IDMDFE)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE VEICULOTRACAOMDFE 
                                        SET IDPROPRIETARIOVEICULOMDFE = @IDPROPRIETARIOVEICULOMDFE, 
                                            IDCONDUTOR = @IDCONDUTOR,
                                            IDVEICULO = @IDVEICULO, 
                                            IDMDFE = @IDMDFE
                                     WHERE IDVEICULOTRACAOMDFE = @IDVEICULOTRACAOMDFE";
                        break;
                }                
                oSQL.ParamByName["IDVEICULOTRACAOMDFE"] = VeiculoTracao.IDVeiculoTracaoMDFe;
                oSQL.ParamByName["IDPROPRIETARIOVEICULOMDFE"] = VeiculoTracao.IDProprietarioVeiculoMDFe;
                oSQL.ParamByName["IDCONDUTOR"] = VeiculoTracao.IDCondutor;
                oSQL.ParamByName["IDVEICULO"] = VeiculoTracao.IDVeiculo;
                oSQL.ParamByName["IDMDFE"] = VeiculoTracao.IDMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDVeiculoTracaoMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM VEICULOTRACAOMDFE WHERE IDVEICULOTRACAOMDFE = @IDVEICULOTRACAOMDFE";
                oSQL.ParamByName["IDVEICULOTRACAOMDFE"] = IDVeiculoTracaoMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM VEICULOTRACAOMDFE WHERE IDVEICULOTRACAOMDFE = @IDVEICULOTRACAOMDFE";
                oSQL.ParamByName["IDVEICULOTRACAOMDFE"] = IDVeiculoTracaoMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
