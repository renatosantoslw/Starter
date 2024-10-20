using IntegradorZeusPDV.DB;
using IntegradorZeusPDV.DB.DB.Controller;
using IntegradorZeusPDV.MODEL.ClassesPDV;
using System.Data;

namespace IntegradorZeusPDV.CONTROLLER.Funcoes
{
    public class FuncoesUsuario
    {
        public static bool Salvar(Usuario User)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {

                oSQL.SQL = @"INSERT INTO USUARIO (IDUSUARIO, NOME, LOGIN, SENHA, EMAIL, ATIVO, IDPERFILACESSO, IDUSUARIOSUPERVISOR, PIN) 
                                            VALUES  (@IDUSUARIO, @NOME, @LOGIN, @SENHA, @EMAIL, @ATIVO, @IDPERFILACESSO, @IDUSUARIOSUPERVISOR, @PIN)";
                oSQL.ParamByName["LOGIN"] = User.Login;
                oSQL.ParamByName["NOME"] = User.Nome;
                oSQL.ParamByName["SENHA"] = User.Senha;
                oSQL.ParamByName["EMAIL"] = User.Email;
                oSQL.ParamByName["ATIVO"] = User.Ativo;
                oSQL.ParamByName["IDUSUARIO"] = User.IDUsuario;
                oSQL.ParamByName["IDPERFILACESSO"] = User.IDPerfilAcesso;
                oSQL.ParamByName["IDUSUARIOSUPERVISOR"] = User.IDUsuarioSupervisor;
                oSQL.ParamByName["PIN"] = User.Pin;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static DataTable GetUsuario(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT USUARIO.IDUSUARIO,
                                    USUARIO.NOME,
                                    USUARIO.LOGIN,
                                    USUARIO.SENHA,
                                    USUARIO.EMAIL,
                                    USUARIO.ATIVO,

                                    PERFILACESSO.IDPERFILACESSO,
                                    PERFILACESSO.DESCRICAO AS PERFILACESSO,
                                    USUARIO.IDUSUARIOSUPERVISOR,
                                    USUARIO.PIN
                               FROM USUARIO 
                                  INNER JOIN PERFILACESSO ON (USUARIO.IDPERFILACESSO = PERFILACESSO.IDPERFILACESSO)
                             WHERE IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados;
            }
        }


    }
}
