using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesCliente
    {
        public static bool ExisteCliente(decimal IDCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static DataTable GetClientes(string Nome_RazaoSocial, string CPF_CNPJ, string InscricaoEstadual)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Nome_RazaoSocial))
                    Filtros.Add(string.Format("(UPPER(RAZAOSOCIAL) LIKE UPPER('%{0}%') OR UPPER(NOME) LIKE UPPER('%{0}%'))", Nome_RazaoSocial));

                if (!string.IsNullOrEmpty(CPF_CNPJ))
                    Filtros.Add(string.Format("(CNPJ LIKE UPPER('%{0}%') OR CPF LIKE UPPER('%{0}%'))", CPF_CNPJ));

                if (!string.IsNullOrEmpty(InscricaoEstadual))
                    Filtros.Add(string.Format("(INSCRICAOESTADUAL::VARCHAR LIKE UPPER('%{0}%'))", InscricaoEstadual));

                //Filtros.Add("(IDVENDEDOR IN (SELECT IDUSUARIO FROM USUARIO WHERE ISVENDEDOR = 1))");

                oSQL.SQL = string.Format(@"SELECT IDCLIENTE,
                                             CASE WHEN CLI.TIPODOCUMENTO = 0 THEN CLI.RAZAOSOCIAL ELSE CLI.NOME END AS DESCRICAO,
                                             CASE WHEN CLI.TIPODOCUMENTO = 0 THEN CLI.CNPJ ELSE CLI.CPF END AS NUMERODOCUMENTO,
                                             CLI.INSCRICAOESTADUAL AS INSCRICAOESTADUAL,
                                             CAST(CASE WHEN CLI.TIPODOCUMENTO = 0 THEN 'JURIDICA' ELSE 'FISICA' END AS VARCHAR(10)) AS TIPO,
                                             VEN.NOME AS VENDEDOR ,
                                             CLI.IDVENDEDOR AS CODVENDEDOR,
                                             CONT.TELEFONE AS TELEFONE,
                                             CONT.CELULAR AS CELULAR,
                                             CONT.EMAIL AS EMAIL,
                                             ENDE.LOGRADOURO AS LOGRADOURO,
                                             ENDE.NUMERO AS NUMERO, 
                                             ENDE.CEP AS CEP,
                                             ENDE.BAIRRO AS BAIRRO, 
                                             MUN.DESCRICAO AS CIDADE,
                                             UF.SIGLA AS UF,
                                             CLI.ATIVO AS ATIVO,
                                             CLI.LIMITEDECREDITO AS LIMITEDECREDITO
                                            FROM CLIENTE CLI {0}
                                            LEFT JOIN USUARIO VEN ON VEN.IDUSUARIO = CLI.IDVENDEDOR AND VEN.ISVENDEDOR = 1
                                            LEFT JOIN ENDERECO ENDE ON ENDE.IDENDERECO = CLI.IDENDERECO 
                                            LEFT JOIN MUNICIPIO MUN ON MUN.IDMUNICIPIO = ENDE.IDMUNICIPIO
                                            LEFT JOIN UNIDADEFEDERATIVA UF ON UF.IDUNIDADEFEDERATIVA = ENDE.IDUNIDADEFEDERATIVA
                                            LEFT JOIN CONTATO CONT ON CONT.IDCONTATO = CLI.IDCONTATO
                                           ORDER BY CLI.RAZAOSOCIAL, CLI.NOME", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();

                return oSQL.dtDados;
            }
        }

        public static DataRow GetClientePorTipoEDocumento(decimal TipoDocumento, string Documento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT CLIENTE.IDCLIENTE,
                                    COALESCE(CLIENTE.NOME, RAZAOSOCIAL) AS NOME,
                                    COALESCE(CPF, CNPJ) AS DOCUMENTO,
                                    CONTATO.EMAIL
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                              WHERE TIPODOCUMENTO = @TIPODOCUMENTO
                                AND COALESCE(CPF, CNPJ) = @DOCUMENTO";
                oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                oSQL.ParamByName["DOCUMENTO"] = Documento;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados.Rows[0];
            }
        }

        public static Cliente GetClientePorCPF(string CPF)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CLIENTE.*
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                              WHERE CPF = @CPF";
                oSQL.ParamByName["CPF"] = CPF;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Cliente GetClientePorCNPJ(string CNPJ)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CLIENTE.*
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                              WHERE CNPJ = @CNPJ";
                oSQL.ParamByName["CNPJ"] = CNPJ;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Cliente GetClientePorNome(string Nome)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CLIENTE.*
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                              WHERE NOME = @NOME";
                oSQL.ParamByName["NOME"] = Nome;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<Cliente> GetClienteObjeto()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CLIENTE.*
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO) WHERE ATIVO = 1 AND IDENDERECO IS NOT NULL " ;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataTable(oSQL.dtDados);
            }
        }
        public static List<Cliente> GetClienteObjeto(int conexao)
        {
            using (SQLQuery oSQL = new SQLQuery(conexao))
            {
                oSQL.SQL = @"SELECT CLIENTE.*
                               FROM CLIENTE
                                 LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO) WHERE ATIVO = 1 AND IDENDERECO IS NOT NULL ";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataTable(oSQL.dtDados);
            }
        }


        public static Cliente GetCliente(decimal? IDCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCLIENTE,
                                    TIPODOCUMENTO,
                                    CNPJ,
                                    CPF,
                                    RAZAOSOCIAL,
                                    INSCRICAOESTADUAL,
                                    INSCRICAOMUNICIPAL,
                                    IDENDERECO,
                                    IDCONTATO,
                                    NOME,
                                    NOMEFANTASIA,
                                    CONSUMIDORFINAL,
                                    ESTRANGEIRO,
                                    DOCESTRANGEIRO,
                                    TIPOCONTRIBUINTE,
                                    IDVENDEDOR,
                                    LIMITEDECREDITO
                             FROM CLIENTE
                             WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static Cliente GetClienteIdCpfCnpj(string idCpfCnpj)
        {
            decimal idCliente = idCpfCnpj.Contains("-") ? -1 : Convert.ToDecimal(idCpfCnpj);

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCLIENTE,
                                    TIPODOCUMENTO,
                                    CNPJ,
                                    CPF,
                                    RAZAOSOCIAL,
                                    INSCRICAOESTADUAL,
                                    INSCRICAOMUNICIPAL,
                                    IDENDERECO,
                                    IDCONTATO,
                                    NOME,
                                    NOMEFANTASIA,
                                    CONSUMIDORFINAL,
                                    ESTRANGEIRO,
                                    DOCESTRANGEIRO,
                                    TIPOCONTRIBUINTE,
                                    IDVENDEDOR
                             FROM CLIENTE
                             WHERE IDCLIENTE = @IDCLIENTE OR
                                   CPF = @CPF OR
                                   CNPJ = @CNPJ";
                oSQL.ParamByName["IDCLIENTE"] = Convert.ToDecimal(idCpfCnpj);
                oSQL.ParamByName["CPF"] = idCpfCnpj;
                oSQL.ParamByName["CNPJ"] = idCpfCnpj;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static bool Salvar(Cliente _Cliente, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CLIENTE (IDCLIENTE, NOME, TIPODOCUMENTO, CNPJ, 
                                        CPF, RAZAOSOCIAL, INSCRICAOESTADUAL, INSCRICAOMUNICIPAL, 
                                        IDENDERECO, IDCONTATO, NOMEFANTASIA, ATIVO, TIPOCONTRIBUINTE, 
                                        CONSUMIDORFINAL, IDVendedor, LIMITEDECREDITO)
                                      VALUES (@IDCLIENTE, @NOME, @TIPODOCUMENTO, @CNPJ, 
                                        @CPF, @RAZAOSOCIAL, @INSCRICAOESTADUAL, @INSCRICAOMUNICIPAL, 
                                        @IDENDERECO, @IDCONTATO, @NOMEFANTASIA, @ATIVO, @TIPOCONTRIBUINTE, 
                                        @CONSUMIDORFINAL, @IDVendedor, @LIMITEDECREDITO)";

                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CLIENTE
                                       SET TIPODOCUMENTO = @TIPODOCUMENTO,
                                           CNPJ = @CNPJ,
                                           CPF = @CPF,
                                           RAZAOSOCIAL = @RAZAOSOCIAL,
                                           INSCRICAOESTADUAL = @INSCRICAOESTADUAL,
                                           INSCRICAOMUNICIPAL = @INSCRICAOMUNICIPAL,
                                           IDENDERECO = @IDENDERECO,
                                           IDCONTATO = @IDCONTATO,
                                           NOME = @NOME,
                                           NOMEFANTASIA = @NOMEFANTASIA,
                                           ATIVO = @ATIVO,
                                           TIPOCONTRIBUINTE = @TIPOCONTRIBUINTE,
                                           CONSUMIDORFINAL = @CONSUMIDORFINAL,
                                           IDVendedor = @IDVendedor,
                                           LIMITEDECREDITO = @LIMITEDECREDITO
                                       WHERE IDCLIENTE = @IDCLIENTE";
                        break;
                }
                oSQL.ParamByName["IDCLIENTE"] = _Cliente.IDCliente;
                oSQL.ParamByName["TIPODOCUMENTO"] = _Cliente.TipoDocumento;
                oSQL.ParamByName["CNPJ"] = _Cliente.CNPJ;
                oSQL.ParamByName["CPF"] = _Cliente.CPF;
                oSQL.ParamByName["RAZAOSOCIAL"] = _Cliente.RazaoSocial;
                oSQL.ParamByName["INSCRICAOESTADUAL"] = _Cliente.InscricaoEstadual;
                oSQL.ParamByName["INSCRICAOMUNICIPAL"] = _Cliente.InscricaoMunicipal;
                oSQL.ParamByName["NOME"] = _Cliente.Nome;
                oSQL.ParamByName["NOMEFANTASIA"] = _Cliente.NomeFantasia;
                oSQL.ParamByName["ATIVO"] = _Cliente.Ativo;
                oSQL.ParamByName["TIPOCONTRIBUINTE"] = _Cliente.TipoContribuinte;
                oSQL.ParamByName["CONSUMIDORFINAL"] = _Cliente.ConsumidorFinal;
                oSQL.ParamByName["IDVendedor"] = _Cliente.IDVendedor;
                oSQL.ParamByName["LIMITEDECREDITO"] = _Cliente.LimiteDeCredito;

                oSQL.ParamByName["IDENDERECO"] = DBNull.Value;
                if (_Cliente.IDEndereco.HasValue)
                    oSQL.ParamByName["IDENDERECO"] = _Cliente.IDEndereco.Value;

                oSQL.ParamByName["IDCONTATO"] = DBNull.Value;
                if (_Cliente.IDContato.HasValue)
                    oSQL.ParamByName["IDCONTATO"] = _Cliente.IDContato.Value;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                decimal? IDEndereco = null;
                decimal? IDContato = null;

                oSQL.SQL = "SELECT IDENDERECO FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    IDEndereco = !string.IsNullOrEmpty(oSQL.dtDados.Rows[0]["IDENDERECO"].ToString()) ? Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDENDERECO"]) : 0;

                oSQL.ClearAll();
                oSQL.SQL = "SELECT IDCONTATO FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    IDContato = Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDCONTATO"]);

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM CLIENTE WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                if (oSQL.ExecSQL() != 1)
                    throw new Exception();

                if (IDEndereco.HasValue && IDEndereco.Value !=0)
                {
                    oSQL.ClearAll();
                    oSQL.SQL = "DELETE FROM ENDERECO WHERE IDENDERECO = @IDENDERECO";
                    oSQL.ParamByName["IDENDERECO"] = IDEndereco.Value;
                    if (oSQL.ExecSQL() != 1)
                        throw new Exception();
                }

                if (IDContato.HasValue)
                {
                    oSQL.ClearAll();
                    oSQL.SQL = "DELETE FROM CONTATO WHERE IDCONTATO = @IDCONTATO";
                    oSQL.ParamByName["IDCONTATO"] = IDContato.Value;
                    if (oSQL.ExecSQL() != 1)
                        throw new Exception();
                }
                return true;
            }
        }

        public static bool SalvarAtualizarClienteNFCe(string nome, decimal IDCliente, string EmailCliente, string CPFCNPJ, decimal TipoDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (!ExisteCliente(IDCliente))
                {
                    decimal _IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                    oSQL.SQL = "INSERT INTO CONTATO (IDCONTATO, EMAIL) VALUES (@IDCONTATO, @EMAIL)";
                    oSQL.ParamByName["EMAIL"] = EmailCliente;
                    oSQL.ParamByName["IDCONTATO"] = _IDContato;
                    oSQL.ExecSQL();

                    oSQL.ClearAll();

                    oSQL.SQL = @"INSERT INTO CLIENTE (IDCLIENTE, CPF, CNPJ, NOME, RAZAOSOCIAL, TIPODOCUMENTO, IDCONTATO, ATIVO, CONSUMIDORFINAL)
                                          VALUES (@IDCLIENTE, @CPF, @CNPJ, @NOME, @RAZAOSOCIAL, @TIPODOCUMENTO, @IDCONTATO, @ATIVO, @CONSUMIDORFINAL)";
                    oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                    oSQL.ParamByName["CPF"] = TipoDocumento == 0 ? string.Empty : CPFCNPJ;
                    oSQL.ParamByName["CNPJ"] = TipoDocumento == 0 ? CPFCNPJ : string.Empty;
                    oSQL.ParamByName["NOME"] = nome;
                    oSQL.ParamByName["RAZAOSOCIAL"] = TipoDocumento == 0 ? nome : string.Empty;
                    oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                    oSQL.ParamByName["IDCONTATO"] = _IDContato;
                    oSQL.ParamByName["CONSUMIDORFINAL"] = 1;
                    oSQL.ParamByName["ATIVO"] = 1;
                    return oSQL.ExecSQL() == 1;
                }
                else
                {
                    return true;
                    //Cliente _Cliente = GetCliente(IDCliente);
                    //oSQL.SQL = @"UPDATE CONTATO SET EMAIL = @EMAIL WHERE IDCONTATO = @IDCONTATO";
                    //oSQL.ParamByName["IDCONTATO"] = _Cliente.IDContato.Value;
                    //oSQL.ParamByName["EMAIL"] = EmailCliente;
                    //return oSQL.ExecSQL() == 1;
                }
            }
        }

        public static bool SalvarAtualizarClientePedido(decimal IDCliente, string EmailCliente, string CPFCNPJ, decimal TipoDocumento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (!ExisteCliente(IDCliente))
                {
                    decimal _IDContato = Sequence.GetNextID("CONTATO", "IDCONTATO");
                    oSQL.SQL = "INSERT INTO CONTATO (IDCONTATO, EMAIL) VALUES (@IDCONTATO, @EMAIL)";
                    oSQL.ParamByName["EMAIL"] = EmailCliente;
                    oSQL.ParamByName["IDCONTATO"] = _IDContato;
                    oSQL.ExecSQL();

                    oSQL.ClearAll();

                    oSQL.SQL = @"INSERT INTO CLIENTE (IDCLIENTE, CPF, CNPJ, NOME, RAZAOSOCIAL, TIPODOCUMENTO, IDCONTATO, ATIVO)
                                          VALUES (@IDCLIENTE, @CPF, @CNPJ, @NOME, @RAZAOSOCIAL, @TIPODOCUMENTO, @IDCONTATO, @ATIVO)";
                    oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                    oSQL.ParamByName["CPF"] = TipoDocumento == 0 ? string.Empty : CPFCNPJ;
                    oSQL.ParamByName["CNPJ"] = TipoDocumento == 0 ? CPFCNPJ : string.Empty;
                    oSQL.ParamByName["NOME"] = TipoDocumento == 0 ? string.Empty : CPFCNPJ;
                    oSQL.ParamByName["RAZAOSOCIAL"] = TipoDocumento == 0 ? CPFCNPJ : string.Empty;
                    oSQL.ParamByName["TIPODOCUMENTO"] = TipoDocumento;
                    oSQL.ParamByName["IDCONTATO"] = _IDContato;
                    oSQL.ParamByName["ATIVO"] = 1;
                    return oSQL.ExecSQL() == 1;
                }
                else
                {
                    Cliente _Cliente = FuncoesCliente.GetCliente(IDCliente);
                    oSQL.SQL = @"UPDATE CONTATO SET EMAIL = @EMAIL WHERE IDCONTATO = @IDCONTATO";
                    oSQL.ParamByName["IDCONTATO"] = _Cliente.IDContato.Value;
                    oSQL.ParamByName["EMAIL"] = EmailCliente;
                    return oSQL.ExecSQL() == 1;
                }
            }
        }

        public static DataTable GetClientesNFe(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT COALESCE(CLIENTE.NOME, CLIENTE.NOMEFANTASIA) AS NOME,
                                                  COALESCE(CLIENTE.CPF, CLIENTE.CNPJ) AS DOCUMENTO,
                                                  CLIENTE.IDCLIENTE,
                                                  ENDERECO.IDENDERECO,
                                                  UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                                  MUNICIPIO.IDMUNICIPIO,
                                                  CONTATO.IDCONTATO
                                           FROM CLIENTE
                                              INNER JOIN ENDERECO ON (CLIENTE.IDENDERECO = ENDERECO.IDENDERECO)
                                              INNER JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                                              INNER JOIN MUNICIPIO ON (MUNICIPIO.IDMUNICIPIO = ENDERECO.IDMUNICIPIO)
                                               LEFT JOIN CONTATO ON (CLIENTE.IDCONTATO = CONTATO.IDCONTATO)
                                           WHERE UPPER(COALESCE(CLIENTE.NOME, CLIENTE.NOMEFANTASIA)) LIKE UPPER('%{0}%')", Descricao.ToUpper());
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

    }
}
