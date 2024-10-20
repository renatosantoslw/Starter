using PDV.DAO.Entidades;
using PDV.DAO.DB.Controller;
using System.Collections.Generic;
using PDV.DAO.Custom;
using PDV.DAO.GridViewModels;
using PDV.DAO.DB.Utils;

namespace PDV.CONTROLER.Funcoes
{
    public static class FuncoesServico
    {
        public static bool Salvar(Servico servico)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (servico.IDServico == 0)
                {
                    oSQL.SQL = @"INSERT INTO SERVICO 
                            (IDSERVICO, DESCRICAO, IDCATEGORIA, IDUNIDADEDEMEDIDA, VALOR)
                            VALUES
                            (@IDSERVICO, @DESCRICAO, @IDCATEGORIA, @IDUNIDADEDEMEDIDA, @VALOR)";
                    oSQL.ParamByName["IDSERVICO"] = Sequence.GetNextID("SERVICO", "IDSERVICO");
                }
                else
                {
                    oSQL.SQL = @"UPDATE SERVICO SET
                                DESCRICAO = @DESCRICAO,
                                IDCATEGORIA = @IDCATEGORIA,
                                IDUNIDADEDEMEDIDA = @IDUNIDADEDEMEDIDA,
                                VALOR = @VALOR
                                WHERE IDSERVICO = @IDSERVICO";
                    oSQL.ParamByName["IDSERVICO"] = servico.IDServico;
                }

                
                oSQL.ParamByName["DESCRICAO"] = servico.Descricao;
                oSQL.ParamByName["IDCATEGORIA"] = servico.IDCategoria;
                oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = servico.IDUnidadeDeMedida;
                oSQL.ParamByName["VALOR"] = servico.Valor;

                return oSQL.ExecSQL() == 0;
            }
        }

        public static List<Servico> GetServicos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDSERVICO,
DESCRICAO,
IDCATEGORIA,
IDUNIDADEDEMEDIDA,
VALOR FROM SERVICO";
                oSQL.Open();
                return new DataTableParser<Servico>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<ServicoGridViewModel> GetServicosGridView()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                                SERVICO.IDSERVICO, 
                                SERVICO.DESCRICAO, 
                                CA.DESCRICAO AS CATEGORIA,
                                UN.DESCRICAO AS UNIDADEDEMEDIDA,
                                SERVICO.VALOR
                            FROM SERVICO
                            JOIN CATEGORIA CA ON CA.IDCATEGORIA = SERVICO.IDCATEGORIA
                            JOIN UNIDADEDEMEDIDA UN ON UN.IDUNIDADEDEMEDIDA = SERVICO.IDUNIDADEDEMEDIDA";
                oSQL.Open();
                return new DataTableParser<ServicoGridViewModel>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static Servico GetServico(decimal idServico)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDSERVICO,
DESCRICAO,
IDCATEGORIA,
IDUNIDADEDEMEDIDA,
VALOR FROM SERVICO WHERE IDSERVICO = @IDSERVICO";
                oSQL.ParamByName["IDSERVICO"] = idServico;
                oSQL.Open();
                return new DataTableParser<Servico>().ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Remover(decimal idServico)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM SERVICO WHERE IDSERVICO = @IDSERVICO";
                oSQL.ParamByName["IDSERVICO"] = idServico;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
