using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;

namespace PDV.CONTROLER.FuncoesRetaguarda
{
    public class FuncoesEmitente
    {
        public static Emitente GetEmitente()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDEMITENTE, 
                                    IDENDERECO, 
                                    CNPJ, 
                                    RAZAOSOCIAL, 
                                    NOMEFANTASIA, 
                                    EMAIL, 
                                    CODIGOREGIMETRIBUTARIO,
                                    CERTIFICADO, 
                                    CSC, 
                                    IDCSC, 
                                    CNAE, 
                                    INSCRICAOMUNICIPAL, 
                                    INSCRICAOESTADUAL, 
                                    LOGOMARCA,
                                    NOMECERTIFICADO,
                                    NOMELOGOMARCA,
                                    SENHACERTIFICADO
                               FROM EMITENTE";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Emitente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
