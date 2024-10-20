using System;
using System.Data;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesSangriaCaixa
    {
        public static bool Salvar(SangriaCaixa Sangria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO SANGRIACAIXA 
                               (IDSANGRIACAIXA, IDUSUARIO, IDUSUARIOCADASTRO, IDFLUXOCAIXA, DATASANGRIA, VALOR, OBSERVACAO)
                             VALUES
                               (@IDSANGRIACAIXA, @IDUSUARIO, @IDUSUARIOCADASTRO, @IDFLUXOCAIXA, @DATASANGRIA, @VALOR, @OBSERVACAO)";
                oSQL.ParamByName["IDSANGRIACAIXA"] = Sangria.IDSangriaCaixa;
                oSQL.ParamByName["IDUSUARIO"] = Sangria.IDUsuario;
                oSQL.ParamByName["IDUSUARIOCADASTRO"] = Sangria.IDUsuarioCadastro;
                oSQL.ParamByName["IDFLUXOCAIXA"] = Sangria.IDFluxoCaixa;
                oSQL.ParamByName["DATASANGRIA"] = Sangria.DataSangria;
                oSQL.ParamByName["VALOR"] = Sangria.Valor;
                oSQL.ParamByName["OBSERVACAO"] = Sangria.Observacao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetSangriasPorFluxoDeCaixa(decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDSANGRIACAIXA,
                            IDUSUARIOCADASTRO,
                            IDUSUARIO,
                            IDFLUXOCAIXA,
                            DATASANGRIA,
                            VALOR,
                            OBSERVACAO FROM SANGRIACAIXA WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Update(SangriaCaixa sangria)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE SANGRIACAIXA SET
                                            VALOR = @VALOR, 
                                            OBSERVACAO = @OBSERVACAO
                                    WHERE IDSANGRIACAIXA  = @ID";

                oSQL.ParamByName["VALOR"] = sangria.Valor;
                oSQL.ParamByName["OBSERVACAO"] = sangria.Observacao;
                oSQL.ParamByName["ID"] = sangria.IDSangriaCaixa;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}