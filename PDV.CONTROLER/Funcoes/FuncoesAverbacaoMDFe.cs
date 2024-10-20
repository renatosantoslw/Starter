using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesAverbacaoMDFe
    {
        public static DataTable GetAverbacoes(decimal IDSeguradoraMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDAVERBACAOSEGURADORAMDFE,
IDSEGURADORAMDFE,
NUMEROAVERBACAO FROM AVERBACAOSEGURADORAMDFE WHERE IDSEGURADORAMDFE = @IDSEGURADORAMDFE";
                oSQL.ParamByName["IDSEGURADORAMDFE"] = IDSeguradoraMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(AverbacaoSeguradoraMDFe Averbacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO AVERBACAOSEGURADORAMDFE (IDAVERBACAOSEGURADORAMDFE, IDSEGURADORAMDFE, NUMEROAVERBACAO)
                             VALUES (@IDAVERBACAOSEGURADORAMDFE, @IDSEGURADORAMDFE, @NUMEROAVERBACAO)";
                oSQL.ParamByName["IDAVERBACAOSEGURADORAMDFE"] = Averbacao.IDAverbacaoSeguradoraMDFe;
                oSQL.ParamByName["IDSEGURADORAMDFE"] = Averbacao.IDSeguradoraMDFe;
                oSQL.ParamByName["NUMEROAVERBACAO"] = Averbacao.NumeroAverbacao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDAverbacaoSeguradoraMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM AVERBACAOSEGURADORAMDFE WHERE IDAVERBACAOSEGURADORAMDFE = @IDAVERBACAOSEGURADORAMDFE";
                oSQL.ParamByName["IDAVERBACAOSEGURADORAMDFE"] = IDAverbacaoSeguradoraMDFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return true;

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM AVERBACAOSEGURADORAMDFE WHERE IDAVERBACAOSEGURADORAMDFE = @IDAVERBACAOSEGURADORAMDFE";
                oSQL.ParamByName["IDAVERBACAOSEGURADORAMDFE"] = IDAverbacaoSeguradoraMDFe;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
