using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesContatoClienteFornecedor
    {
        public static bool Salvar(ContatoClienteFornecedor Contato, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch(Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONTATOCLIENTEFORNECEDOR
                                        (IDCONTATOCLIENTEFORNECEDOR, IDFORNECEDOR, IDCLIENTE, NOME, CARGO, EMAIL, TELEFONE1, TELEFONE2, SEXO)
                                     VALUES
                                        (@IDCONTATOCLIENTEFORNECEDOR, @IDFORNECEDOR, @IDCLIENTE, @NOME, @CARGO, @EMAIL, @TELEFONE1, @TELEFONE2, @SEXO)";
                        oSQL.ParamByName["IDFORNECEDOR"] = Contato.IDFornecedor;
                        oSQL.ParamByName["IDCLIENTE"] = Contato.IDCliente;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTATOCLIENTEFORNECEDOR
                                      SET NOME = @NOME,
                                          CARGO = @CARGO,
                                          EMAIL = @EMAIL,
                                          TELEFONE1 = @TELEFONE1,
                                          TELEFONE2 = @TELEFONE2,
                                          SEXO = @SEXO
                                     WHERE IDCONTATOCLIENTEFORNECEDOR = @IDCONTATOCLIENTEFORNECEDOR";
                        break;
                }
                oSQL.ParamByName["IDCONTATOCLIENTEFORNECEDOR"] = Contato.IDContatoClienteFornecedor;
                
                oSQL.ParamByName["NOME"] = Contato.Nome;
                oSQL.ParamByName["CARGO"] = Contato.Cargo;
                oSQL.ParamByName["EMAIL"] = Contato.Email;
                oSQL.ParamByName["TELEFONE1"] = Contato.Telefone1;
                oSQL.ParamByName["TELEFONE2"] = Contato.Telefone2;
                oSQL.ParamByName["SEXO"] = Contato.Sexo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static ContatoClienteFornecedor GetContato(decimal IDCliente, decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTATOCLIENTEFORNECEDOR,
IDFORNECEDOR,
IDCLIENTE,
NOME,
CARGO,
EMAIL,
TELEFONE1,
TELEFONE2,
SEXO,
DATANASCIMENTO 
                              FROM CONTATOCLIENTEFORNECEDOR
                             WHERE (@IDCLIENTE = -1 OR IDCLIENTE = @IDCLIENTE)
                               AND (@IDFORNECEDOR = -1 OR IDFORNECEDOR = @IDFORNECEDOR)";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                return EntityUtil<ContatoClienteFornecedor>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Existe(decimal IDContatoClienteFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTATOCLIENTEFORNECEDOR,
IDFORNECEDOR,
IDCLIENTE,
NOME,
CARGO,
EMAIL,
TELEFONE1,
TELEFONE2,
SEXO,
DATANASCIMENTO FROM CONTATOCLIENTEFORNECEDOR WHERE IDCONTATOCLIENTEFORNECEDOR = @IDCONTATOCLIENTEFORNECEDOR";
                oSQL.ParamByName["IDCONTATOCLIENTEFORNECEDOR"] = IDContatoClienteFornecedor;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Remover(decimal IDContatoClienteFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (!Existe(IDContatoClienteFornecedor))
                    return true;

                oSQL.SQL = "DELETE FROM CONTATOCLIENTEFORNECEDOR WHERE IDCONTATOCLIENTEFORNECEDOR = @IDCONTATOCLIENTEFORNECEDOR";
                oSQL.ParamByName["IDCONTATOCLIENTEFORNECEDOR"] = IDContatoClienteFornecedor;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetContatos(decimal IDCliente, decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTATOCLIENTEFORNECEDOR,
                                    IDFORNECEDOR,
                                    IDCLIENTE,
                                    NOME,
                                    CARGO,
                                    EMAIL,
                                    TELEFONE1,
                                    TELEFONE2,
                                    SEXO
                               FROM CONTATOCLIENTEFORNECEDOR
                             WHERE (@IDCLIENTE = -1 OR IDCLIENTE = @IDCLIENTE)
                               AND (@IDFORNECEDOR = -1 OR IDFORNECEDOR = @IDFORNECEDOR)";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
