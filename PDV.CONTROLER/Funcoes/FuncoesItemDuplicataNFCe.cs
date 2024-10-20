using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.PDV;
using System.Collections.Generic;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesItemDuplicataNFCe
    {
        public static bool SalvarDuplicataNFCe(DuplicataNFCe Duplicata)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                          
               oSQL.SQL = @"INSERT INTO DUPLICATANFCE(IDDUPLICATANFCE, IDVENDA, IDFORMADEPAGAMENTO, DATAVENCIMENTO, VALOR, CONTROLE, PAGAMENTO, TROCO)
                        VALUES (@IDDUPLICATANFCE, @IDVENDA, @IDFORMADEPAGAMENTO, @DATAVENCIMENTO, @VALOR,@CONTROLE, @PAGAMENTO, @TROCO)";           

               
                oSQL.ParamByName["IDDUPLICATANFCE"] = Duplicata.IDDuplicataNFCe;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Duplicata.IDFormaDePagamento;
                oSQL.ParamByName["IDVENDA"] = Duplicata.IDVenda;
                oSQL.ParamByName["DATAVENCIMENTO"] = Duplicata.DataVencimento;
                oSQL.ParamByName["VALOR"] = Duplicata.Valor;
                oSQL.ParamByName["CONTROLE"] = Duplicata.Controle;
                oSQL.ParamByName["PAGAMENTO"] = Duplicata.Pagamento;
                oSQL.ParamByName["TROCO"] = Duplicata.Troco;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<DuplicataNFCe> GetPagamentosPorVenda(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DUPLICATANFCE.IDDUPLICATANFCE,
                                    DUPLICATANFCE.IDFORMADEPAGAMENTO,
                                    DUPLICATANFCE.IDVENDA,
                                    DUPLICATANFCE.VALOR,
                                    DUPLICATANFCE.DATAVENCIMENTO,
                                    DUPLICATANFCE.PAGAMENTO,
                                    DUPLICATANFCE.TROCO,
                                    FP.IDFORMADEPAGAMENTO,
                                    FP.DESCRICAO AS FORMADEPAGAMENTO
                               FROM DUPLICATANFCE
                                 INNER JOIN FORMADEPAGAMENTO FP ON (DUPLICATANFCE.IDFORMADEPAGAMENTO = FP.IDFORMADEPAGAMENTO)
                             WHERE DUPLICATANFCE.IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return new DataTableParser<DuplicataNFCe>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool ExistePagamentoNaVenda(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM DUPLICATANFCE WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static List<DuplicataNFCe> GetPagamentosPorVendaParaCarne(decimal IDVenda, decimal IDFormaDePagamento)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DUPLICATANFCE.IDDUPLICATANFCE,
                                    DUPLICATANFCE.IDFORMADEPAGAMENTO,
                                    DUPLICATANFCE.IDVENDA,
                                    DUPLICATANFCE.VALOR,
                                    DUPLICATANFCE.DATAVENCIMENTO,
                                    DUPLICATANFCE.TROCO,
                                    FP.IDFORMADEPAGAMENTO,
                                    FP.DESCRICAO AS FORMADEPAGAMENTO
                               FROM DUPLICATANFCE
                                 INNER JOIN FORMADEPAGAMENTO FP ON (DUPLICATANFCE.IDFORMADEPAGAMENTO = FP.IDFORMADEPAGAMENTO)
                             WHERE DUPLICATANFCE.IDVENDA = @IDVENDA
                               AND FP.IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = IDFormaDePagamento;
                oSQL.Open();
                return new DataTableParser<DuplicataNFCe>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static bool ExcluirPorVenda(decimal idVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM DUPLICATANFCE WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = idVenda;
                oSQL.Open();
                return oSQL.ExecSQL() >= 1;
            }
        }
    }
}
