using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.PDV;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesDuplicataDAC
    {
        public static bool SalvarDuplicataDAC(DuplicataDAC Duplicata)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO DUPLICATADAC (IDDUPLICATADAC, IDFORMADEPAGAMENTO, IDCOMPRA, DATAVENCIMENTO, VALOR, PAGAMENTO)
	                                VALUES (@IDDUPLICATADAC, @IDFORMADEPAGAMENTO, @IDCOMPRA, @DATAVENCIMENTO, @VALOR, @PAGAMENTO)";
                oSQL.ParamByName["IDDUPLICATADAC"] = Duplicata.IDDuplicataDAC;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Duplicata.IDFormaDePagamento;
                oSQL.ParamByName["IDCOMPRA"] = Duplicata.IDCompra;
                oSQL.ParamByName["DATAVENCIMENTO"] = Duplicata.DataVencimento;
                oSQL.ParamByName["VALOR"] = Duplicata.Valor;
                oSQL.ParamByName["PAGAMENTO"] = Duplicata.Pagamento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<DuplicataDAC> GetPagamentosPorCompra(decimal IDCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DUPLICATADAC.IDDUPLICATADAC,
                                    DUPLICATADAC.IDFORMADEPAGAMENTO,
                                    DUPLICATADAC.IDCOMPRA,
                                    DUPLICATADAC.VALOR,
                                    DUPLICATADAC.DATAVENCIMENTO,
                                    DUPLICATADAC.PAGAMENTO,
                                    FP.IDFORMADEPAGAMENTO,
                                    FP.DESCRICAO AS FORMADEPAGAMENTO
                               FROM DUPLICATADAC
                                 INNER JOIN FORMADEPAGAMENTO FP ON (DUPLICATADAC.IDFORMADEPAGAMENTO = FP.IDFORMADEPAGAMENTO)
                             WHERE DUPLICATADAC.IDCOMPRA = @IDCOMPRA";
                oSQL.ParamByName["IDCOMPRA"] = IDCompra;
                oSQL.Open();
                return new DataTableParser<DuplicataDAC>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool ExcluirPorPedidoCompra(decimal idPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM DUPLICATADAC WHERE IDCOMPRA = @IDCOMPRA";
                oSQL.ParamByName["IDCOMPRA"] = idPedidoCompra;
                oSQL.Open();
                return oSQL.ExecSQL() >= 1;
            }
        }
    }
}
