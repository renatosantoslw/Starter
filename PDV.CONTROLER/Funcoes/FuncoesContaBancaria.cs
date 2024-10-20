using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesContaBancaria
    {
        public static bool Existe(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTABANCARIA WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static ContaBancaria GetContaBancaria(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTABANCARIA,
IDBANCO,
NOME,
AGENCIA,
CONTA,
DIGITO,
ATIVO,
CAIXA,
DIGITOAGENCIA,
OPERACAO,
CHAVEERP
                               FROM CONTABANCARIA
                             WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.Open();
                return EntityUtil<ContaBancaria>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetContasBancarias(string Nome)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT CONTABANCARIA.IDCONTABANCARIA,
                                     CONTABANCARIA.NOME,
                                     BANCO.NOME AS BANCO,
                                     ISNULL(CONTABANCARIA.AGENCIA, '')+'-'+ISNULL(CAST(CONTABANCARIA.DIGITOAGENCIA AS VARCHAR(10)), '') AS AGENCIA,
                                     ISNULL(CONTABANCARIA.CONTA, '')+'-'+ISNULL(CONTABANCARIA.DIGITO, '') AS CONTA,
                                     CONTABANCARIA.ATIVO,
                                     CONTABANCARIA.CAIXA,
									 CONTABANCARIA.IDBANCO
                                     
                               FROM CONTABANCARIA
                                 LEFT JOIN BANCO ON (CONTABANCARIA.IDBANCO = BANCO.IDBANCO)
                             WHERE UPPER(CONTABANCARIA.NOME) LIKE '%{Nome.ToUpper()}%'";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<ContaBancaria> GetContasBancarias()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CONTABANCARIA.IDCONTABANCARIA,
                                    CONTABANCARIA.NOME
                               FROM CONTABANCARIA
                                 LEFT JOIN BANCO ON (CONTABANCARIA.IDBANCO = BANCO.IDBANCO)";
                oSQL.Open();
                return new DataTableParser<ContaBancaria>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(ContaBancaria Conta, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO 
                                       CONTABANCARIA(IDCONTABANCARIA, IDBANCO, NOME, AGENCIA, CONTA, DIGITO, ATIVO, CAIXA, DIGITOAGENCIA, OPERACAO)
                                     VALUES (@IDCONTABANCARIA, @IDBANCO, @NOME, @AGENCIA, @CONTA, @DIGITO, @ATIVO, @CAIXA, @DIGITOAGENCIA, @OPERACAO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTABANCARIA
                                       SET IDBANCO = @IDBANCO, 
                                           NOME = @NOME, 
                                           AGENCIA = @AGENCIA,
                                           CONTA = @CONTA,
                                           DIGITO = @DIGITO, 
                                           ATIVO = @ATIVO,
                                           CAIXA = @CAIXA,
                                           DIGITOAGENCIA = @DIGITOAGENCIA,
                                           OPERACAO = @OPERACAO
                                     WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
                        break;
                }
                oSQL.ParamByName["IDCONTABANCARIA"] = Conta.IDContaBancaria;
                oSQL.ParamByName["IDBANCO"] = Conta.IDBanco;
                oSQL.ParamByName["NOME"] = Conta.Nome;
                oSQL.ParamByName["AGENCIA"] =Conta.Agencia;
                oSQL.ParamByName["CONTA"] = Conta.Conta;
                oSQL.ParamByName["DIGITO"] =Conta.Digito;
                oSQL.ParamByName["ATIVO"] = Conta.Ativo;
                oSQL.ParamByName["CAIXA"] = Conta.Caixa;
                oSQL.ParamByName["OPERACAO"] = Conta.Operacao;
                oSQL.ParamByName["DIGITOAGENCIA"] = Convert.ToDecimal(Conta.DigitoAgencia);
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONTABANCARIA WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static object GetDefault()
        {
            throw new NotImplementedException();
        }
    }
}
