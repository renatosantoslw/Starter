using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.Financeiro;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesContaCobranca
    {
        public static bool Existe(decimal IDContaCobranca)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM CONTACOBRANCA WHERE IDCONTACOBRANCA = @IDCONTACOBRANCA";
                oSQL.ParamByName["IDCONTACOBRANCA"] = IDContaCobranca;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        //public static ContaCobranca GetContaCobrancaPorContaBancaria(decimal IDContaBancaria)
        //{
        //    using (SQLQuery oSQL = new SQLQuery())
        //    {
        //        oSQL.SQL = "SELECT * FROM CONTACOBRANCA WHERE IDCONTABANCARIA = @IDCONTABANCARIA";
        //        oSQL.ParamByName["IDCONTABANCARIA"] = IDContaBancaria;
        //        oSQL.Open();
        //        if (oSQL.IsEmpty)
        //            return null;

        //        return EntityUtil<ContaCobranca>.ParseDataRow(oSQL.dtDados.Rows[0]);
        //    }
        //}

        public static ContaCobranca GetContaCobranca(decimal IDContaCobranca)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCONTACOBRANCA,
IDCONTABANCARIA,
LEIAUTE,
ESPECIEDOC,
ACEITE,
CARTEIRA,
REGISTRO,
ESPECIE,
CEDENTE,
NOSSONUMERO,
ATIVO,
INSTRUCOES,
DIASPAGTO,
TAXA,
LOCALPAGTO,
VALORMULTA,
PERCENTUALJUROS,
IDFORMADEPAGAMENTO,
VARIACAOCARTEIRA,
CNAB,
NUMEROREMESSA FROM CONTACOBRANCA WHERE IDCONTACOBRANCA = @IDCONTACOBRANCA";
                oSQL.ParamByName["IDCONTACOBRANCA"] = IDContaCobranca;
                oSQL.Open();
                if (EntityUtil<ContaCobranca>.ParseDataRow(oSQL.dtDados.Rows[0]) != null)
                    return EntityUtil<ContaCobranca>.ParseDataRow(oSQL.dtDados.Rows[0]);
                else
                    return null;
            }
        }

        public static DataTable GetContasCobrancas(string Cedente, string Conta, string Numero)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT CONTACOBRANCA.IDCONTACOBRANCA,
                                     CONTACOBRANCA.CEDENTE,
                                     CONTACOBRANCA.NOSSONUMERO,
                                     CONTABANCARIA.NOME AS CONTA,
                                     CONTACOBRANCA.ATIVO
                               FROM CONTACOBRANCA
                                 INNER JOIN CONTABANCARIA ON (CONTACOBRANCA.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                             WHERE UPPER(CONTACOBRANCA.CEDENTE) LIKE '%{Cedente.ToUpper()}%'
                                OR UPPER(CONTABANCARIA.NOME) LIKE '%{Conta.ToUpper()}%'
                                OR UPPER(CAST(CONTACOBRANCA.NOSSONUMERO AS VARCHAR)) LIKE  '%{Numero.ToUpper()}%'";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(ContaCobranca Conta, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO CONTACOBRANCA(IDCONTACOBRANCA, IDCONTABANCARIA, LEIAUTE, ESPECIEDOC, ACEITE, 
                                                               CARTEIRA, REGISTRO, ESPECIE, CEDENTE, NOSSONUMERO, ATIVO, INSTRUCOES, 
                                                               DIASPAGTO, TAXA, LOCALPAGTO, IDFORMADEPAGAMENTO, VALORMULTA, PERCENTUALJUROS, VARIACAOCARTEIRA, CNAB, NUMEROREMESSA)
                                       VALUES (@IDCONTACOBRANCA, @IDCONTABANCARIA, @LEIAUTE, @ESPECIEDOC, @ACEITE, 
                                       @CARTEIRA, @REGISTRO, @ESPECIE, @CEDENTE, @NOSSONUMERO, @ATIVO, @INSTRUCOES, 
                                       @DIASPAGTO, @TAXA, @LOCALPAGTO, @IDFORMADEPAGAMENTO, @VALORMULTA, @PERCENTUALJUROS, @VARIACAOCARTEIRA, @CNAB, @NUMEROREMESSA)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE CONTACOBRANCA
                                       SET  IDCONTABANCARIA    = @IDCONTABANCARIA, 
                                            LEIAUTE            = @LEIAUTE, 
                                            ESPECIEDOC         = @ESPECIEDOC, 
                                            ACEITE             = @ACEITE, 
                                            CARTEIRA           = @CARTEIRA, 
                                            REGISTRO           = @REGISTRO, 
                                            ESPECIE            = @ESPECIE, 
                                            CEDENTE            = @CEDENTE, 
                                            NOSSONUMERO        = @NOSSONUMERO, 
                                            ATIVO              = @ATIVO,
                                            INSTRUCOES         = @INSTRUCOES, 
                                            DIASPAGTO          = @DIASPAGTO, 
                                            TAXA               = @TAXA,
                                            LOCALPAGTO         = @LOCALPAGTO,
                                            IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO,
                                            VALORMULTA         = @VALORMULTA,
                                            PERCENTUALJUROS    = @PERCENTUALJUROS,
                                            CNAB               = @CNAB,
                                            VARIACAOCARTEIRA   = @VARIACAOCARTEIRA,
                                            NUMEROREMESSA      = @NUMEROREMESSA
                                     WHERE IDCONTACOBRANCA  = @IDCONTACOBRANCA";
                        break;
                }
                oSQL.ParamByName["IDCONTACOBRANCA"] = Conta.IDContaCobranca;
                oSQL.ParamByName["IDCONTABANCARIA"] = Conta.IDContaBancaria;
                oSQL.ParamByName["LEIAUTE"] = Conta.Leiaute;
                oSQL.ParamByName["ESPECIEDOC"] = Conta.EspecieDoc;
                oSQL.ParamByName["ACEITE"] = Conta.Aceite;
                oSQL.ParamByName["CARTEIRA"] = Conta.Carteira;
                oSQL.ParamByName["REGISTRO"] = Conta.Registro;
                oSQL.ParamByName["ESPECIE"] = Conta.Especie;
                oSQL.ParamByName["CEDENTE"] = Conta.Cedente;
                oSQL.ParamByName["NOSSONUMERO"] = Conta.NossoNumero;
                oSQL.ParamByName["ATIVO"] = Conta.Ativo;
                oSQL.ParamByName["INSTRUCOES"] = Conta.Instrucoes;
                oSQL.ParamByName["DIASPAGTO"] = Conta.DiasPagto;
                oSQL.ParamByName["TAXA"] = Conta.Taxa;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = Conta.IDFormaDePagamento;
                oSQL.ParamByName["VALORMULTA"] = Conta.ValorMulta;
                oSQL.ParamByName["PERCENTUALJUROS"] = Conta.PercentualJuros;
                oSQL.ParamByName["LOCALPAGTO"] = Conta.LocalPagto;
                oSQL.ParamByName["VARIACAOCARTEIRA"] = Conta.VariacaoCarteira;
                oSQL.ParamByName["NUMEROREMESSA"] = Conta.NumeroRemessa;
                oSQL.ParamByName["CNAB"] = Conta.CNAB;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDContaCobranca)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM CONTACOBRANCA WHERE IDCONTACOBRANCA = @IDCONTACOBRANCA";
                oSQL.ParamByName["IDCONTACOBRANCA"] = IDContaCobranca;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<ContaCobranca> GetContasCobranca()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT CONTACOBRANCA.IDCONTACOBRANCA,
                                    CONTACOBRANCA.LEIAUTE + ' - ' + BANCO.NOME AS DESCRICAO,
                                    CONTACOBRANCA.IDCONTABANCARIA,
                                    CONTACOBRANCA.IDFORMADEPAGAMENTO
                               FROM CONTACOBRANCA
                                 INNER JOIN CONTABANCARIA ON (CONTACOBRANCA.IDCONTABANCARIA = CONTABANCARIA.IDCONTABANCARIA)
                                 INNER JOIN BANCO ON (CONTABANCARIA.IDBANCO = BANCO.IDBANCO)
                             WHERE CONTACOBRANCA.ATIVO = 1";
                oSQL.Open();
                return new DataTableParser<ContaCobranca>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool UpdateNossoNumero(decimal IDContaCobranca, decimal NossoNumero)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE CONTACOBRANCA SET NOSSONUMERO = @NOSSONUMERO WHERE IDCONTACOBRANCA = @IDCONTACOBRANCA";
                oSQL.ParamByName["IDCONTACOBRANCA"] = IDContaCobranca;
                oSQL.ParamByName["NOSSONUMERO"] = NossoNumero;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static decimal GetNossoNumero(decimal IDContaCobranca)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(NOSSONUMERO, 1) AS NOSSONUMERO FROM CONTACOBRANCA WHERE IDCONTACOBRANCA = @IDCONTACOBRANCA";
                oSQL.ParamByName["IDCONTACOBRANCA"] = IDContaCobranca;
                oSQL.Open();
                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["NOSSONUMERO"]);
            }
        }
    }
}
