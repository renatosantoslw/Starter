using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesContato
    {
        public static bool ExisteContato(decimal IDContato)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTATO WHERE IDCONTATO = @IDCONTATO";
                oSQL.ParamByName["IDCONTATO"] = IDContato;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Contato GetContato(decimal IDContato)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTATO,
                                    EMAIL,
                                    EMAILALTERNATIVO,
                                    TELEFONE,
                                    CELULAR
                              FROM CONTATO
                                WHERE IDCONTATO = @IDCONTATO";
                oSQL.ParamByName["IDCONTATO"] = IDContato;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Contato>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Salvar(Contato _Contato, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                      CONTATO (IDCONTATO, EMAIL, EMAILALTERNATIVO, TELEFONE, CELULAR)
                                      VALUES (@IDCONTATO, @EMAIL, @EMAILALTERNATIVO, @TELEFONE, @CELULAR)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTATO
                                       SET EMAIL = @EMAIL,
                                           EMAILALTERNATIVO = @EMAILALTERNATIVO,
                                           TELEFONE = @TELEFONE,
                                           CELULAR = @CELULAR
                                       WHERE IDCONTATO = @IDCONTATO";
                        break;
                }
                oSQL.ParamByName["IDCONTATO"] = _Contato.IDContato;
                oSQL.ParamByName["EMAIL"] = _Contato.Email;
                oSQL.ParamByName["EMAILALTERNATIVO"] = _Contato.EmailAlternativo;
                oSQL.ParamByName["TELEFONE"] = _Contato.Telefone;
                oSQL.ParamByName["CELULAR"] = _Contato.Celular;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
