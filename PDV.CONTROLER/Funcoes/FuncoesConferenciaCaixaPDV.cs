using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public static class FuncoesConferenciaCaixaPDV
    {
        public static bool SalvarConferencia(ConferenciaCaixaPDV Conferencia)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO CONFERENCIACAIXAPDV
                               (            IDCONFERENCIACAIXAPDV ,
	                                        DATA ,
	                                        IDFLUXOCAIXA ,
	                                        IDFORMAPAGAMENTO,
	                                        NOMEFORMAPAGAMENTO,
	                                        VALORDIGITADO ,
	                                        VALORCALCULADO ,
	                                        DIFERENCA )
                             VALUES
                               (            @IDCONFERENCIACAIXAPDV ,
	                                        @DATA ,
	                                        @IDFLUXOCAIXA ,
	                                        @IDFORMAPAGAMENTO,
	                                        @NOMEFORMAPAGAMENTO,
	                                        @VALORDIGITADO ,
	                                        @VALORCALCULADO ,
	                                        @DIFERENCA )";
                oSQL.ParamByName["IDCONFERENCIACAIXAPDV"] = Sequence.GetNextID("CONFERENCIACAIXAPDV", "IDCONFERENCIACAIXAPDV");
                oSQL.ParamByName["DATA"] = Conferencia.Data;
                oSQL.ParamByName["IDFLUXOCAIXA"] = Conferencia.IdFluxoCaixa;
                oSQL.ParamByName["IDFORMAPAGAMENTO"] = Conferencia.IdFormaPagamento;
                oSQL.ParamByName["NOMEFORMAPAGAMENTO"] = Conferencia.NomeFormaPagamento;
                oSQL.ParamByName["VALORDIGITADO"] = Conferencia.valordigitado;
                oSQL.ParamByName["VALORCALCULADO"] = Conferencia.valorcalculado;
                oSQL.ParamByName["DIFERENCA"] = Conferencia.diferenca;
                return oSQL.ExecSQL() == 1;
            }
        }


        public static DataTable GetConferenciasPorFluxo(decimal idFluxo)
        {
            using(SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONFERENCIACAIXAPDV,
DATA,
IDFLUXOCAIXA,
IDFORMAPAGAMENTO,
NOMEFORMAPAGAMENTO,
VALORDIGITADO,
VALORCALCULADO,
DIFERENCA FROM CONFERENCIACAIXAPDV WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA";

                oSQL.ParamByName["IDFLUXOCAIXA"] = idFluxo;

                oSQL.Open();

                return oSQL.dtDados;
            }
        }
    }
}