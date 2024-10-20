using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;

namespace PDV.CONTROLER.FuncoesAndroid
{
    public class FuncoesUsuario
    {
        public static Usuario GetUsuarioPorLoginESenha(string Login, string Senha)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT USUARIO.IDUSUARIO,
                                    USUARIO.LOGIN,
                                    USUARIO.SENHA,
                                    USUARIO.NOME,
                                    USUARIO.EMAIL,
                             
                                    PERFILACESSO.IDPERFILACESSO,
                                    PERFILACESSO.DESCRICAO AS PERFILACESSO
                             
                             FROM USUARIO
                               INNER JOIN PERFILACESSO ON USUARIO.IDPERFILACESSO = PERFILACESSO.IDPERFILACESSO
                             WHERE LOGIN = @LOGIN
                               AND SENHA = @SENHA";
                oSQL.ParamByName["LOGIN"] = Login;
                oSQL.ParamByName["SENHA"] = Senha;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
