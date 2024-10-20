using PDV.DAO.DB.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Custom;
using PDV.DAO.Enum;
using PDV.DAO.Entidades;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesDuplicataNFe
    {
        public static DataTable GetDuplicatas(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDDUPLICATANFE,
IDNFE,
NUMERODOCUMENTO,
DATAVENCIMENTO,
VALOR,
CHAVEERP,
IDFORMADEPAGAMENTO,
PAGAMENTO FROM DUPLICATANFE WHERE IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        } 

        public static DataTable GetDuplicatasConferencia(decimal IDFluxo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT
                            FP.CODIGO,
                            FP.DESCRICAO AS DESCRICAO
                            FROM DUPLICATANFCE DUP
                            LEFT JOIN FORMADEPAGAMENTO FP ON FP.IDFORMADEPAGAMENTO = DUP.IDFORMADEPAGAMENTO
                            LEFT JOIN VENDA V ON V.IDVENDA = DUP.IDVENDA
                            WHERE V.IDFLUXOCAIXA = @IDFLUXO OR (FP.CODIGO = 1 AND FP.TRANSACAO = @AVISTA)
                            GROUP BY FP.CODIGO,DESCRICAO, FP.IDFORMADEPAGAMENTO";
                oSQL.ParamByName["IDFLUXO"] = IDFluxo;
                oSQL.ParamByName["AVISTA"] = FormaDePagamento.AVista;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }



        public static DataTable GetDuplicatasTudo()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT
                            FP.DESCRICAO AS DESCRICAO,
                            SUM(VALOR) AS VALOR
                            FROM DUPLICATANFCE DUP
                            LEFT JOIN FORMADEPAGAMENTO FP ON FP.IDFORMADEPAGAMENTO = DUP.IDFORMADEPAGAMENTO
                            LEFT JOIN VENDA V ON V.IDVENDA = DUP.IDVENDA
                            GROUP BY DESCRICAO
";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetDuplicatasCompraTudo()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT
                            FP.DESCRICAO AS DESCRICAO,
                            SUM(VALOR) AS VALOR
                            FROM DUPLICATADAC DUP
                            LEFT JOIN FORMADEPAGAMENTO FP ON FP.IDFORMADEPAGAMENTO = DUP.IDFORMADEPAGAMENTO
                            LEFT JOIN PEDIDOCOMPRA V ON V.IDPEDIDOCOMPRA = DUP.IDCOMPRA
                            GROUP BY DESCRICAO
";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetDuplicatasAgrupadaEncerramento(decimal IDFluxo, decimal IDFormaPagamentoCodigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT
                            FP.DESCRICAO AS DESCRICAO,
                            SUM(VALOR) AS VALOR
                            FROM DUPLICATANFCE DUP
                            LEFT JOIN FORMADEPAGAMENTO FP ON FP.IDFORMADEPAGAMENTO = DUP.IDFORMADEPAGAMENTO
                            LEFT JOIN VENDA V ON V.IDVENDA = DUP.IDVENDA
                            WHERE V.IDFLUXOCAIXA = @IDFLUXO AND FP.CODIGO = @IDFORMAPAGAMENTO AND V.STATUS != @CANCELADO
                            GROUP BY DESCRICAO";
                oSQL.ParamByName["IDFLUXO"] = IDFluxo;
                oSQL.ParamByName["IDFORMAPAGAMENTO"] = IDFormaPagamentoCodigo;
                oSQL.ParamByName["CANCELADO"] = StatusPedido.Cancelado;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DuplicataNFCe GetDuplicata(DateTime datavcto, decimal idvenda, decimal valor )
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDDUPLICATANFE,
IDNFE,
NUMERODOCUMENTO,
DATAVENCIMENTO,
VALOR,
CHAVEERP,
IDFORMADEPAGAMENTO,
PAGAMENTO FROM DUPLICATANFE WHERE DATAVENCIMENTO = @DATAVECTO AND VALOR = @VALOR";
                oSQL.ParamByName["DATAVECTO"] = datavcto;
                oSQL.ParamByName["VALOR"] = valor;
                oSQL.Open();
                return EntityUtil<DuplicataNFCe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static void AtualizaConta(decimal idNFCE, DateTime data)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE DUPLICATANFCE SET DATAPAGAMENTO = @DATAPGTO WHERE IDDUPLICATANFCE = @IDNFCE";
                oSQL.ParamByName["DATAPGTO"] = data;
                oSQL.ParamByName["IDDUPLICATANFCE"] = idNFCE;

            }
        }

        public static bool Salvar(DuplicataNFe DuplicataNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO DUPLICATANFE 
                            (IDDUPLICATANFE, IDNFE, NUMERODOCUMENTO, DATAVENCIMENTO, VALOR, IDFORMADEPAGAMENTO) 
                            VALUES 
                            (@IDDUPLICATANFE, @IDNFE, @NUMERODOCUMENTO, @DATAVENCIMENTO, @VALOR, @IDFORMADEPAGAMENTO)";

                oSQL.ParamByName["IDDUPLICATANFE"] = DuplicataNFe.IDDuplicataNFe;
                oSQL.ParamByName["IDNFE"] = DuplicataNFe.IDNFe;
                oSQL.ParamByName["NUMERODOCUMENTO"] = DuplicataNFe.NumeroDocumento;
                oSQL.ParamByName["DATAVENCIMENTO"] = DuplicataNFe.DataVencimento;
                oSQL.ParamByName["VALOR"] = DuplicataNFe.Valor;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = DuplicataNFe.IDFormaDePagamento;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Excluir(decimal IDNDuplicataNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM DUPLICATANFE WHERE IDDUPLICATANFE = @IDDUPLICATANFE";
                oSQL.ParamByName["IDDUPLICATANFE"] = IDNDuplicataNFe;
                return oSQL.ExecSQL() >= 0;
            }
        }

        public static bool ExcluirPorNFe(decimal idNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM DUPLICATANFE WHERE IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = idNFe;
                return oSQL.ExecSQL() >= 0;
            }
        }
    }
}
