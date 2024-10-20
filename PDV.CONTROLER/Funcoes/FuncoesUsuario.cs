using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;
using System;
using System.Linq.Expressions;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesUsuario
    {
        public static Usuario GetUsuarioRoot(string Login, string Senha)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT U.* 
                               FROM USUARIO U
                              WHERE LOGIN = @LOGIN 
                               AND SENHA = @SENHA 
                               AND COALESCE(ROOT, 0) = 1";
                oSQL.ParamByName["LOGIN"] = Login;
                oSQL.ParamByName["SENHA"] = Senha;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Usuario GetUsuarioSupervisor(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT US.IDUSUARIO,
                                    US.NOME,
                                    US.LOGIN,
                                    US.SENHA,
                                    US.EMAIL,
                                    US.ATIVO,
                                    US.PIN
                             FROM USUARIO
                                 INNER JOIN USUARIO US ON (USUARIO.IDUSUARIOSUPERVISOR = US.IDUSUARIO)
                             WHERE USUARIO.IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static void AlterarSenha(string email, string senha, decimal IDUsuario)
        {
            try
            {
                using (SQLQuery oSQL = new SQLQuery())
                {
                    oSQL.SQL = @"UPDATE USUARIO SET SENHA =@SENHA WHERE IDUSUARIO = @IDUSUARIO";

                    oSQL.ParamByName["SENHA"] = senha;
                    oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                    var d = oSQL.ExecSQL();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

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
                               AND SENHA = @SENHA
                               AND COALESCE(USUARIO.ATIVO, 0) = 1";
                oSQL.ParamByName["LOGIN"] = Login;
                oSQL.ParamByName["SENHA"] = Senha;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM USUARIO WHERE IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool ExisteLogin(decimal IDUsuario, string Login)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM USUARIO WHERE LOGIN = @LOGIN AND IDUSUARIO <> @IDUSUARIO";
                oSQL.ParamByName["LOGIN"] = Login;
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static DataTable GetUsuarios(string Nome, string Login)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome))
                    Filtros.Add(string.Format("(UPPER(NOME) LIKE UPPER('%{0}%'))", Nome));

                if (!string.IsNullOrEmpty(Login))
                    Filtros.Add(string.Format("(UPPER(LOGIN) LIKE UPPER('%{0}%'))", Login));

                oSQL.SQL = string.Format(@"SELECT IDUSUARIO, 
                                                  LOGIN, 
                                                  NOME, 
                                                  ATIVO, 
                                                  CASE 
                                                   WHEN ISVENDEDOR = 0 THEN 'NÃO' 
                                                   WHEN ISVENDEDOR = 1 THEN 'SIM' 
                                                  END AS VENDEDOR,
                                                  CASE 
                                                   WHEN ISCOMPRADOR = 0 THEN 'NÃO' 
                                                   WHEN ISCOMPRADOR = 1 THEN 'SIM' 
                                                  END AS COMPRADOR
                                                  FROM USUARIO WHERE 
                                                  COALESCE(ROOT, 0) = 0 {0} ORDER BY NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Usuario> GetUsuarios()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUSUARIO,
IDUSUARIOSUPERVISOR,
IDPERFILACESSO,
NOME,
LOGIN,
SENHA,
EMAIL,
ATIVO,
ROOT,
PIN,
CHAVEERP,
TIPODESCONTO,
FORMADESCONTO,
ISVENDEDOR,
ISCOMPRADOR,
DESCONTOMAXIMO FROM USUARIO WHERE ATIVO = 1 ORDER BY NOME";
                oSQL.Open();
                return new DataTableParser<Usuario>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<Usuario> GetUsuarios(int conexao)
        {
            using (SQLQuery oSQL = new SQLQuery(conexao))
            {
                oSQL.SQL = @"SELECT IDUSUARIO,
IDUSUARIOSUPERVISOR,
IDPERFILACESSO,
NOME,
LOGIN,
SENHA,
EMAIL,
ATIVO,
ROOT,
PIN,
CHAVEERP,
TIPODESCONTO,
FORMADESCONTO,
ISVENDEDOR,
ISCOMPRADOR,
DESCONTOMAXIMO FROM USUARIO WHERE ATIVO = 1 ORDER BY NOME";
                oSQL.Open();
                return new DataTableParser<Usuario>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<Usuario> GetUsuariosVendedores()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUSUARIO,
IDUSUARIOSUPERVISOR,
IDPERFILACESSO,
NOME,
LOGIN,
SENHA,
EMAIL,
ATIVO,
ROOT,
PIN,
CHAVEERP,
TIPODESCONTO,
FORMADESCONTO,
ISVENDEDOR,
ISCOMPRADOR,
DESCONTOMAXIMO FROM USUARIO WHERE ATIVO = 1 AND ISVENDEDOR = 1 ORDER BY NOME";
                oSQL.Open();
                return new DataTableParser<Usuario>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static List<Usuario> GetUsuariosCompradores()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDUSUARIO,
IDUSUARIOSUPERVISOR,
IDPERFILACESSO,
NOME,
LOGIN,
SENHA,
EMAIL,
ATIVO,
ROOT,
PIN,
CHAVEERP,
TIPODESCONTO,
FORMADESCONTO,
ISVENDEDOR,
ISCOMPRADOR,
DESCONTOMAXIMO FROM USUARIO WHERE ATIVO = 1 AND ISCOMPRADOR = 1 ORDER BY NOME";
                oSQL.Open();
                return new DataTableParser<Usuario>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static Usuario GetUsuario(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT USUARIO.IDUSUARIO,
                                    USUARIO.NOME,
                                    USUARIO.LOGIN,
                                    USUARIO.SENHA,
                                    USUARIO.EMAIL,
                                    USUARIO.ATIVO,
                                    USUARIO.ISVENDEDOR,
                                    USUARIO.ISCOMPRADOR,
                                    PERFILACESSO.IDPERFILACESSO,
                                    PERFILACESSO.DESCRICAO AS PERFILACESSO,
                                    USUARIO.IDUSUARIOSUPERVISOR,
                                    USUARIO.PIN, 
                                    USUARIO.TIPODESCONTO, 
                                    USUARIO.FORMADESCONTO,
                                    USUARIO.DESCONTOMAXIMO
                               FROM USUARIO 
                                  INNER JOIN PERFILACESSO ON (USUARIO.IDPERFILACESSO = PERFILACESSO.IDPERFILACESSO)
                             WHERE IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static Usuario GetUsuario(string nome)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 * FROM USUARIO
                             WHERE NOME = @NOME /*LIMIT 1*/";
                oSQL.ParamByName["NOME"] = nome;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Usuario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static bool Remover(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM USUARIO WHERE IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Salvar(Usuario User, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO USUARIO (IDUSUARIO, NOME, LOGIN, SENHA, EMAIL, ATIVO, IDPERFILACESSO, IDUSUARIOSUPERVISOR, PIN, TIPODESCONTO, FORMADESCONTO, ISVENDEDOR, ISCOMPRADOR, DESCONTOMAXIMO) 
                                                 VALUES  (@IDUSUARIO, @NOME, @LOGIN, @SENHA, @EMAIL, @ATIVO, @IDPERFILACESSO, @IDUSUARIOSUPERVISOR, @PIN,@TIPODESCONTO, @FORMADESCONTO, @ISVENDEDOR , @ISCOMPRADOR, @DESCONTOMAXIMO)";

                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE USUARIO
                                        SET NOME = @NOME,
                                            LOGIN = @LOGIN,
                                            SENHA = @SENHA,
                                            EMAIL = @EMAIL,
                                            ATIVO = @ATIVO,
                                            IDPERFILACESSO = @IDPERFILACESSO,
                                            IDUSUARIOSUPERVISOR = @IDUSUARIOSUPERVISOR,
                                            PIN = @PIN, 
                                            TIPODESCONTO = @TIPODESCONTO, 
                                            FORMADESCONTO = @FORMADESCONTO,
                                            ISVENDEDOR = @ISVENDEDOR,
                                            ISCOMPRADOR = @ISCOMPRADOR,
                                            DESCONTOMAXIMO = @DESCONTOMAXIMO
                                     WHERE IDUSUARIO = @IDUSUARIO";
                        break;
                }
                oSQL.ParamByName["NOME"] = User.Nome;
                oSQL.ParamByName["SENHA"] = User.Senha;
                oSQL.ParamByName["EMAIL"] = User.Email;
                oSQL.ParamByName["ATIVO"] = User.Ativo;
                oSQL.ParamByName["IDUSUARIO"] = User.IDUsuario;
                oSQL.ParamByName["IDPERFILACESSO"] = User.IDPerfilAcesso;
                oSQL.ParamByName["IDUSUARIOSUPERVISOR"] = User.IDUsuarioSupervisor;
                oSQL.ParamByName["TIPODESCONTO"] = User.TipoDesconto;
                oSQL.ParamByName["FORMADESCONTO"] = User.FormaDesconto;
                oSQL.ParamByName["PIN"] = User.Pin;
                oSQL.ParamByName["ISVENDEDOR"] = User.IsVendedor;
                oSQL.ParamByName["ISCOMPRADOR"] = User.IsComprador;
                oSQL.ParamByName["DESCONTOMAXIMO"] = User.DescontoMaximo;
                oSQL.ParamByName["LOGIN"] = User.Login;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool AutenticarUsuarioSupervisor(string Login, string Pin)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM USUARIO WHERE LOGIN = @LOGIN AND PIN = @PIN";
                oSQL.ParamByName["LOGIN"] = Login;
                oSQL.ParamByName["PIN"] = Pin;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        private static void Download(string caminho)
        {
            var request = (System.Net.FtpWebRequest)System.Net.WebRequest.Create("ftp://localhost/" + caminho);
            request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = new System.Net.NetworkCredential("anonymous", "contato@andrealveslima.com.br");
            var response = (System.Net.FtpWebResponse)request.GetResponse();

            var responseStream = response.GetResponseStream();
            using (var memoryStream = new System.IO.MemoryStream())
            {
                responseStream.CopyTo(memoryStream);
                var conteudoArquivo = memoryStream.ToArray();
                System.IO.File.WriteAllBytes(caminho, conteudoArquivo);
            }

            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
            response.Close();
        }
        public static void VerififcarAtualizacao()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string ftpurl = "ftp://servidor:21/atualizadordue/";
                string user = "admin";
                string pass = "123";
                //string caminho = "setup.exe";
                string caminho = "setup.exe";

                var request = (System.Net.FtpWebRequest)System.Net.WebRequest.Create(ftpurl + caminho);
                request.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;

                request.Credentials = new System.Net.NetworkCredential(user, pass);
                var response = (System.Net.FtpWebResponse)request.GetResponse();

                var responseStream = response.GetResponseStream();
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    responseStream.CopyTo(memoryStream);
                    var conteudoArquivo = memoryStream.ToArray();
                    System.IO.File.WriteAllBytes(caminho, conteudoArquivo);

                   var caminhoCorrente = AppDomain.CurrentDomain.BaseDirectory.ToString();
                 System.Diagnostics.Process.Start(caminhoCorrente +"\\"+ caminho);
                }

                Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
                response.Close();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
