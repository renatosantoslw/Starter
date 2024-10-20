using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesTalonario
    {
        public static bool Existe(decimal IDTALONARIO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM TALONARIO WHERE IDTALONARIO = @IDTALONARIO";
                oSQL.ParamByName["IDTALONARIO"] = IDTALONARIO;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Talonario GetTalonario(decimal IDTalonario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDTALONARIO,
IDCONTABANCARIA,
NUMERO,
EMISSAO,
INICIO,
FIM,
ATIVO,
OBS FROM TALONARIO WHERE IDTALONARIO = @IDTALONARIO";
                oSQL.ParamByName["IDTALONARIO"] = IDTalonario;
                oSQL.Open();
                return EntityUtil<Talonario>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<Talonario> GetTalonarios(decimal IDContaBancaria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 'Número: '+TALONARIO.NUMERO+' Inicio: '+TALONARIO.INICIO+' Fim: '+TALONARIO.FIM AS DESCRICAO,
                                    TALONARIO.IDTALONARIO
                                FROM TALONARIO
                             WHERE TALONARIO.IDCONTABANCARIA = @IDCONTABANCARIA
                               AND TALONARIO.ATIVO = 1";
                oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
                oSQL.Open();
                return new DataTableParser<Talonario>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static DataTable GetTalonarios(string Numero, string Conta)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT CONTABANCARIA.CONTA,
                                     TALONARIO.NUMERO, 
                                     TALONARIO.INICIO, 
                                     TALONARIO.FIM, 
                                     TALONARIO.ATIVO,
                                     TALONARIO.IDTALONARIO,
                                     TALONARIO.EMISSAO
                                FROM TALONARIO
                                  INNER JOIN CONTABANCARIA ON (TALONARIO.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                                WHERE UPPER(TALONARIO.NUMERO::VARCHAR) LIKE '%{Numero.ToUpper()}%'
                                   OR UPPER(CONTABANCARIA.NOME) LIKE '%{Conta.ToUpper()}%'";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(Talonario Talonario, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO TALONARIO(IDTALONARIO, IDCONTABANCARIA, NUMERO, EMISSAO, INICIO, FIM, ATIVO, OBS)
                                       VALUES (@IDTALONARIO, @IDCONTABANCARIA, @NUMERO, @EMISSAO, @INICIO, @FIM, @ATIVO, @OBS)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE TALONARIO
                                       SET  IDTALONARIO       = @IDTALONARIO, 
                                            IDCONTABANCARIA   = @IDCONTABANCARIA, 
                                            NUMERO            = @NUMERO, 
                                            EMISSAO           = @EMISSAO, 
                                            INICIO            = @INICIO,
                                            FIM               = @FIM, 
                                            ATIVO             = @ATIVO, 
                                            OBS               = @OBS
                                     WHERE IDTALONARIO        = @IDTALONARIO";
                        break;
                }
                oSQL.ParamByName["IDTALONARIO"] = Talonario.IDTalonario;
                oSQL.ParamByName["IDCONTABANCARIA"] = Talonario.IDContaBancaria;
                oSQL.ParamByName["NUMERO"] = Talonario.Numero;
                oSQL.ParamByName["EMISSAO"] = Talonario.Emissao;
                oSQL.ParamByName["INICIO"] = Talonario.Inicio;
                oSQL.ParamByName["FIM"] = Talonario.Fim;
                oSQL.ParamByName["ATIVO"] = Talonario.Ativo;
                oSQL.ParamByName["OBS"] = Talonario.Obs;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDTALONARIO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM TALONARIO WHERE IDTALONARIO = @IDTALONARIO";
                oSQL.ParamByName["IDTALONARIO"] = IDTALONARIO;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
