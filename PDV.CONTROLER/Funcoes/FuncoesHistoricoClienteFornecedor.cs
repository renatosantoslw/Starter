using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Estoque.Suprimentos;
using PDV.DAO.Enum;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesHistoricoClienteFornecedor
    {
        public static bool Salvar(HistoricoClienteFornecedor Historico, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch(Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO HISTORICOCLIENTEFORNECEDOR
                                       (IDHISTORICOCLIENTEFORNECEDOR, IDFORNECEDOR, IDCLIENTE, DATAHISTORICO, ASSUNTO, OBSERVACAO)
                                     VALUES
                                       (@IDHISTORICOCLIENTEFORNECEDOR, @IDFORNECEDOR, @IDCLIENTE, @DATAHISTORICO, @ASSUNTO, @OBSERVACAO)";
                        oSQL.ParamByName["IDFORNECEDOR"] = Historico.IDFornecedor;
                        oSQL.ParamByName["IDCLIENTE"] = Historico.IDCliente;
                        oSQL.ParamByName["DATAHISTORICO"] = Historico.DataHistorico;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE HISTORICOCLIENTEFORNECEDOR
                                       SET ASSUNTO = @ASSUNTO,
                                           OBSERVACAO = @OBSERVACAO
                                     WHERE IDHISTORICOCLIENTEFORNECEDOR = @IDHISTORICOCLIENTEFORNECEDOR";
                        break;
                }
                oSQL.ParamByName["IDHISTORICOCLIENTEFORNECEDOR"] = Historico.IDHistoricoClienteFornecedor;
                oSQL.ParamByName["ASSUNTO"] = Historico.Assunto;
                oSQL.ParamByName["OBSERVACAO"] = Historico.Observacao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDHistoricoClienteFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM HISTORICOCLIENTEFORNECEDOR WHERE IDHISTORICOCLIENTEFORNECEDOR = @IDHISTORICOCLIENTEFORNECEDOR";
                oSQL.ParamByName["IDHISTORICOCLIENTEFORNECEDOR"] = IDHistoricoClienteFornecedor;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetHistorico(decimal IDCliente, decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDHISTORICOCLIENTEFORNECEDOR,
IDFORNECEDOR,
IDCLIENTE,
DATAHISTORICO,
ASSUNTO,
OBSERVACAO
                              FROM HISTORICOCLIENTEFORNECEDOR  
                             WHERE (IDCLIENTE = @IDCLIENTE OR @IDCLIENTE = -1)
                               AND (IDFORNECEDOR = @IDFORNECEDOR OR @IDFORNECEDOR = -1)";
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}