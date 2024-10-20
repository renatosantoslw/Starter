using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;
using System;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesPagamentoMFe
    {

        public static PagamentoMFe GetPagementoMFe(decimal IDPagamentoMFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPAGAMENTOMFE,
	                        		IDVENDA,
	                        		ADQUIRENTE,
                                    AUTORIZACAO,
                                    BANDEIRA,
                                    BINCARTAO,
                                    DATAEXPIRACAO,
                                    DONOCARTAO,
                                    NSU,
                                    QTDPARCELAS,
                                    ULTIMOSQUATRODIGITO,
                                    VALORCARTAO,
                                    MFEENVIADODADOSCARTAO
                               FROM PAGAMENTOMFE                                   
                             WHERE IDPAGAMENTOMFE = @IDPAGAMENTOMFE";
                oSQL.ParamByName["IDPAGAMENTOMFE"] = IDPagamentoMFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<PagamentoMFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool Remover(decimal IDPagamentoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"DELETE FROM PAGAMENTONFE WHERE IDPAGAMENTONFE = @IDPAGAMENTONFE";
                oSQL.ParamByName["IDPAGAMENTONFE"] = IDPagamentoNFe;
                return oSQL.ExecSQL() == 1;
            }
        }
        public static bool Existe(decimal IDPagamentoNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PAGAMENTONFE WHERE IDPAGAMENTONFE = @IDPAGAMENTONFE";
                oSQL.ParamByName["IDPAGAMENTONFE"] = IDPagamentoNFe;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static bool Salvar(PagamentoMFe Pagamento, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO PAGAMENTOMFE (IDPAGAMENTOMFE,IDVENDA, ADQUIRENTE, AUTORIZACAO, BANDEIRA, BINCARTAO, DATAEXPIRACAO, DONOCARTAO,
                                    NSU, QTDPARCELAS, ultimosquatrodigitos, VALORCARTAO, MFEENVIADODADOSCARTAO,IDPagamento,IDLocal, DataPagamento) 
                                                 VALUES (@IDPAGAMENTOMFE, @IDVENDA, @ADQUIRENTE, @AUTORIZACAO, @BANDEIRA, @BINCARTAO, @DATAEXPIRACAO, @DONOCARTAO,
                                    @NSU, @QTDPARCELAS, @ULTIMOSQUATRODIGITO, @VALORCARTAO, @MFEENVIADODADOSCARTAO,@IDPagamento,@IDLocal,@DataPagamento)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PAGAMENTOMFE
                                        SET IDVENDA = @IDVENDA,
	                        		        ADQUIRENTE = @ADQUIRENTE,
                                            AUTORIZACAO @AUTORIZACAO,
                                            BANDEIRA =  @BANDEIRA,
                                            BINCARTAO = @BINCARTAO,
                                            DATAEXPIRACAO = @DATAEXPIRACAO,
                                            DONOCARTAO = @DONOCARTAO,
                                            NSU =  @NSU,
                                            QTDPARCELAS = @QTDPARCELAS,
                                            ultimosquatrodigitos = @ULTIMOSQUATRODIGITO,
                                            VALORCARTAO = @VALORCARTAO,
                                            MFEENVIADODADOSCARTAO = @MFEENVIADODADOSCARTAO,
                                            IDPagamento = @IDPagamento,
                                            IDLocal = @IDLocal
                                     WHERE IDPAGAMENTOMFE = @IDPAGAMENTOMFE";
                        break;
                }
                oSQL.ParamByName["IDPAGAMENTOMFE"] = Pagamento.IDPagamentoMFe;
                oSQL.ParamByName["IDVENDA"] = Pagamento.IDPagamentoMFe;
                oSQL.ParamByName["ADQUIRENTE"] = Pagamento.Adquirente;
                oSQL.ParamByName["AUTORIZACAO"] = Pagamento.Autorizacao;
                oSQL.ParamByName["BANDEIRA"] = Pagamento.Bandeira;
                oSQL.ParamByName["BINCARTAO"] = Pagamento.BinCartao;
                oSQL.ParamByName["DATAEXPIRACAO"] = Pagamento.DataExpiracao;
                oSQL.ParamByName["DONOCARTAO"] = Pagamento.DonoCartao;
                oSQL.ParamByName["NSU"] = Pagamento.NSU;
                oSQL.ParamByName["QTDPARCELAS"] = Pagamento.QtdParcelas;
                oSQL.ParamByName["ULTIMOSQUATRODIGITO"] = Pagamento.UltimosQuatroDigitos;
                oSQL.ParamByName["VALORCARTAO"] = Pagamento.ValorCartao;
                oSQL.ParamByName["MFEENVIADODADOSCARTAO"] = Pagamento.MfeEnviadoDadosCartao;
                oSQL.ParamByName["IDPagamento"] = Pagamento.IDPagamento;
                oSQL.ParamByName["IDLocal"] = Pagamento.IDLocal;
                oSQL.ParamByName["DataPagamento"] = Pagamento.DataPagamento;
                return oSQL.ExecSQL() == 1;
            }
        }

    }
}
