using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.PDV;
using PDV.DAO.Entidades;
using System;
using System.Data;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Windows.Forms;


namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesFluxoCaixa
    {
        public static FluxoCaixa GetFluxoCaixa(decimal idFluxo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFLUXOCAIXA,
IDUSUARIO,
VALORCAIXA,
DATAABERTURACAIXA,
DATAFECHAMENTOCAIXA,
ABERTO,
VALORFECHAMENTOCAIXA,
OBSERVACAO,
CAIXAID FROM FLUXOCAIXA WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = idFluxo;
                oSQL.Open();
                if (oSQL.dtDados.Rows.Count == 0)
                    return null;
                return new DataTableParser<FluxoCaixa>().ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetFluxosCaixa(DateTime dateTime1, DateTime dateTime2)
        {

   

            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                                F.IDFLUXOCAIXA, 
                                C.NUMEROCAIXA,
                                U.NOME AS USUARIO,
                                F.DATAABERTURACAIXA,
                                F.VALORCAIXA,
                                F.VALORFECHAMENTOCAIXA,
                                F.OBSERVACAO,
                                F.ABERTO /*= 1 */AS ABERTO
                            FROM FLUXOCAIXA F
                            JOIN CAIXA C ON (C.IDCAIXA = F.CAIXAID)
                            JOIN USUARIO U ON (U.IDUSUARIO = F.IDUSUARIO)
                            WHERE F.DATAABERTURACAIXA BETWEEN @DATETIME1 AND @DATETIME2
                            ORDER BY F.IDFLUXOCAIXA DESC";
                oSQL.ParamByName["DATETIME1"] = dateTime1;
                oSQL.ParamByName["DATETIME2"] = dateTime2;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(FluxoCaixa fluxoCaixa, TipoOperacao tipoOperacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (tipoOperacao)
                {
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE FLUXOCAIXA SET
                                            VALORCAIXA = @VALORCAIXA, 
                                            VALORFECHAMENTOCAIXA = @VALORFECHAMENTOCAIXA
                                    WHERE IDFLUXOCAIXA  = @IDFLUXOCAIXA";
                        break;
                }

                oSQL.ParamByName["VALORCAIXA"] = fluxoCaixa.ValorCaixa;
                oSQL.ParamByName["VALORFECHAMENTOCAIXA"] = fluxoCaixa.ValorFechamentoCaixa;
                oSQL.ParamByName["IDFLUXOCAIXA"] = fluxoCaixa.IDFluxoCaixa;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetDataTableFluxoCaixaAbertoUsuario(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFLUXOCAIXA,
                                    VALORCAIXA,
                                    DATAABERTURACAIXA,
                                    DATAFECHAMENTOCAIXA,
                                    ABERTO,
                                    CAIXAID
                               FROM FLUXOCAIXA
                                   WHERE ABERTO = 1
                                   AND IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados;
            }
        }


        public static FluxoCaixa GetFluxoCaixaAbertoUsuario(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFLUXOCAIXA,
                                    VALORCAIXA,
                                    DATAABERTURACAIXA,
                                    DATAFECHAMENTOCAIXA,
                                    ABERTO,
                                    CAIXAID
                               FROM FLUXOCAIXA
                                   WHERE ABERTO = 1
                                   AND IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
            //    oSQL.ParamByName["DATAATUAL"] = DateTime.Now;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                //     WHERE @DATAATUAL BETWEEN DATAABERTURACAIXA AND COALESCE(DATAFECHAMENTOCAIXA, @DATAATUAL)
                return EntityUtil<FluxoCaixa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static FluxoCaixa GetFluxoCaixaUltimoFechadoUsuario(decimal IDUsuario)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFLUXOCAIXA,
                                    VALORCAIXA,
                                    DATAABERTURACAIXA,
                                    DATAFECHAMENTOCAIXA,
                                    ABERTO
                               FROM FLUXOCAIXA
                                   WHERE @DATAATUAL BETWEEN DATAABERTURACAIXA AND COALESCE(DATAFECHAMENTOCAIXA, @DATAATUAL)
                                   AND ABERTO = 0
                                   AND IDUSUARIO = @IDUSUARIO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.ParamByName["DATAATUAL"] = DateTime.Now;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                //     
                return EntityUtil<FluxoCaixa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static FluxoCaixa GetFluxoCaixaAbertoUsuarioByIdFluxoCaixa(decimal IDUsuario, decimal IdFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDFLUXOCAIXA,
                                    VALORCAIXA,
                                    DATAABERTURACAIXA,
                                    DATAFECHAMENTOCAIXA,
                                    ABERTO
                               FROM FLUXOCAIXA
                                   WHERE ABERTO = 0
                                   AND IDUSUARIO = @IDUSUARIO
                                   AND IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.ParamByName["IDFLUXOCAIXA"] = IdFluxoCaixa;
                //    oSQL.ParamByName["DATAATUAL"] = DateTime.Now;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                //     WHERE @DATAATUAL BETWEEN DATAABERTURACAIXA AND COALESCE(DATAFECHAMENTOCAIXA, @DATAATUAL)
                return EntityUtil<FluxoCaixa>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool AbrirCaixa(decimal ValorCaixa, DateTime DataAbertura, decimal IDUsuario,int CaixaID)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO FLUXOCAIXA
                               (IDFLUXOCAIXA, VALORCAIXA, DATAABERTURACAIXA, DATAFECHAMENTOCAIXA, ABERTO, IDUSUARIO, CaixaID)
                             VALUES
                               (@IDFLUXOCAIXA, @VALORCAIXA, @DATAABERTURACAIXA, NULL, 1, @IDUSUARIO,@CaixaID)";
                oSQL.ParamByName["IDFLUXOCAIXA"] = Sequence.GetNextID("FLUXOCAIXA", "IDFLUXOCAIXA");
                oSQL.ParamByName["VALORCAIXA"] = ValorCaixa;
                oSQL.ParamByName["DATAABERTURACAIXA"] = DataAbertura;
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.ParamByName["CaixaID"] = CaixaID;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool FecharCaixa(decimal Valor, DateTime dataFechamentoCaixa, decimal IDUsuario, string Observacao, decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE FLUXOCAIXA
                               set DATAFECHAMENTOCAIXA = @DATAFECHAMENTOCAIXA,
                                    OBSERVACAO = @OBSERVACAO,
                                    VALORFECHAMENTOCAIXA = @VALORFECHAMENTOCAIXA,
                                   ABERTO = 0
                             WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.ParamByName["DATAFECHAMENTOCAIXA"] = dataFechamentoCaixa;
                oSQL.ParamByName["VALORFECHAMENTOCAIXA"] = Valor;
                oSQL.ParamByName["OBSERVACAO"] = Observacao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static decimal GetTotalSangrias(decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(SUM(VALOR), 0) AS VALORSANGRIA FROM SANGRIACAIXA 
                                    WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;

                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["VALORSANGRIA"]);
            }
        }

        public static decimal GetTotalSuprimento(decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(SUM(VALOR), 0) AS VALOR FROM SUPRIMENTOCAIXA 
                                WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;

                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["VALOR"]);
            }
        }

        public static decimal GetTotalFluxoCaixa(decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(SUM(DUPLICATANFCE.VALOR), 0) AS VALORPAGAMENTOS
                               FROM FLUXOCAIXA
                                  INNER JOIN VENDA ON (FLUXOCAIXA.IDFLUXOCAIXA = VENDA.IDFLUXOCAIXA
                                                   AND VENDA.IDUSUARIO = FLUXOCAIXA.IDUSUARIO )
                                  INNER JOIN DUPLICATANFCE ON (VENDA.IDVENDA = DUPLICATANFCE.IDVENDA)
                             WHERE FLUXOCAIXA.IDFLUXOCAIXA = @IDFLUXOCAIXA AND VENDA.STATUS != @STATUSCANCELADO";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.ParamByName["STATUSCANCELADO"] = StatusPedido.Cancelado;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;

                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["VALORPAGAMENTOS"]);
            }
        }

        public static decimal GetTotalDinheiroFluxoCaixa(decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(SUM(VENDA.DINHEIRO), 0) AS VALORPAGAMENTOS
                               FROM FLUXOCAIXA
                                  INNER JOIN VENDA ON (FLUXOCAIXA.IDFLUXOCAIXA = VENDA.IDFLUXOCAIXA
                            AND VENDA.IDUSUARIO = FLUXOCAIXA.IDUSUARIO )
                             WHERE FLUXOCAIXA.IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;

                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["VALORPAGAMENTOS"]);
            }
        }
    }
}
