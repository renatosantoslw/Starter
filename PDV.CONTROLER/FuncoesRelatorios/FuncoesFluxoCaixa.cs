using PDV.DAO.DB.Controller;
using System;
using System.Data;

namespace PDV.CONTROLER.FuncoesRelatorios
{
    public class FuncoesFluxoCaixa
    {
        public static DataTable GetDados_FluxoCaixa(decimal IDUsuario, decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //VENDA.VALORTOTAL - SUM(ITEMVENDA.DESCONTOVALOR) AS VALORTOTAL,
                oSQL.SQL = @"SELECT VENDA.IDVENDA,
                                    VENDA.QUANTIDADEITENS,
                                    VENDA.VALORTOTAL AS VALORTOTAL, 
                                    VENDA.DATACADASTRO,
                             
                                    COMANDA.IDCOMANDA,
                                    COALESCE(COMANDA.DESCRICAO, '<Não Informado>') AS COMANDA,
                             
                                    COALESCE(CLIENTE.IDCLIENTE, -1) AS IDCLIENTE,
                                    CASE
                                         WHEN CLIENTE.IDCLIENTE IS NULL THEN '<Não Informado>'
                                         WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA ELSE CLIENTE.NOME
                                    END AS NOMECLIENTE,
                             
                                    USUARIO.IDUSUARIO,
                                    USUARIO.NOME AS USUARIO,
                                    SUM(ITEMVENDA.DESCONTOVALOR) AS VALORDESCONTO
                               FROM VENDA
                             INNER JOIN ITEMVENDA ON (VENDA.IDVENDA = ITEMVENDA.IDVENDA)
                             INNER JOIN DUPLICATANFCE ON (VENDA.IDVENDA = DUPLICATANFCE.IDVENDA)
                             INNER JOIN FLUXOCAIXA ON (VENDA.IDFLUXOCAIXA = FLUXOCAIXA.IDFLUXOCAIXA)
                              LEFT JOIN COMANDA ON (VENDA.IDCOMANDAUTILIZADA = COMANDA.IDCOMANDA)
                             INNER JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                              LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                             WHERE VENDA.IDUSUARIO = @IDUSUARIO
                             AND VENDA.IDFLUXOCAIXA = @IDFLUXOCAIXA
                             GROUP BY VENDA.IDVENDA,VENDA.QUANTIDADEITENS,VENDA.VALORTOTAL
							 ,VENDA.DATACADASTRO,COMANDA.IDCOMANDA,COMANDA.DESCRICAO,
							 CLIENTE.IDCLIENTE,CLIENTE.NOMEFANTASIA,CLIENTE.NOME,CLIENTE.TIPODOCUMENTO
							 , USUARIO.IDUSUARIO,USUARIO.NOME";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetDados_FluxoCaixaPagamentos(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DUPLICATANFCE.IDDUPLICATANFCE,
                                    DUPLICATANFCE.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.DESCRICAO AS FORMADEPAGAMENTO,
                                    DUPLICATANFCE.VALOR AS VALORPAGAMENTO,
                                    COALESCE(BANDEIRACARTAO.DESCRICAO, '<Não Informado>') AS BANDEIRACARTAO
                               FROM DUPLICATANFCE
                                 INNER JOIN FORMADEPAGAMENTO ON (DUPLICATANFCE.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                                  LEFT JOIN BANDEIRACARTAO ON (FORMADEPAGAMENTO.IDBANDEIRACARTAO = BANDEIRACARTAO.IDBANDEIRACARTAO)
                             WHERE DUPLICATANFCE.IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetDados_FluxoCaixaProdutos(decimal IdFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ITEMVENDA.DESCRICAO, 
	                            SUM(ITEMVENDA.QUANTIDADE) AS QUANTIDADE, 
                                ITEMVENDA.VALORUNITARIOITEM AS VALORUNITARIO,
	                            ITEMVENDA.SUBTOTAL AS TOTAL
                            FROM ITEMVENDA 
                            JOIN VENDA ON (VENDA.IDVENDA = ITEMVENDA.IDVENDA)
                            WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA
                            GROUP BY DESCRICAO, ITEMVENDA.VALORUNITARIOITEM, ITEMVENDA.SUBTOTAL";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IdFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetDados_TotalVendasPorCliente(decimal IdFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
	                            COALESCE(CASE
				                            WHEN CLIENTE.TIPODOCUMENTO = 0 THEN CLIENTE.NOMEFANTASIA ELSE CLIENTE.NOME
			                             END, 
		                            '<Não informado>') AS CLIENTE,
	                            SUM(VENDA.VALORTOTAL) AS TOTAL
                            FROM VENDA
                            LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                            WHERE IDFLUXOCAIXA = @IDFLUXOCAIXA
                            GROUP BY CLIENTE.NOMEFANTASIA,CLIENTE.NOME,CLIENTE.TIPODOCUMENTO";
                oSQL.ParamByName["IDFLUXOCAIXA"] = IdFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetDados_FluxoCaixaSangrias(decimal IDUsuario, decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDSANGRIACAIXA,
                                    IDUSUARIO,
                                    IDFLUXOCAIXA,
                                    DATASANGRIA,
                                    VALOR,
                                    OBSERVACAO
                               FROM SANGRIACAIXA

                             WHERE SANGRIACAIXA.IDUSUARIO = @IDUSUARIO
                             AND SANGRIACAIXA.IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetDados_FluxoCaixaAberturaFechamento(decimal IDUsuario, decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT VALORCAIXA,
                                    IDUSUARIO,
                                    IDFLUXOCAIXA,
                                    DATAABERTURACAIXA,
                                    DATAFECHAMENTOCAIXA,
                                    ABERTO,
                                    VALORFECHAMENTOCAIXA,
                                    OBSERVACAO
                               FROM FLUXOCAIXA

                             WHERE FLUXOCAIXA.IDUSUARIO = @IDUSUARIO
                             AND FLUXOCAIXA.IDFLUXOCAIXA = @IDFLUXOCAIXA";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetDados_FluxoCaixaPagamentosTotalizador(decimal IDUsuario, decimal IDFluxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DUPLICATANFCE.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.DESCRICAO AS FORMADEPAGAMENTO,
                                    SUM(DUPLICATANFCE.VALOR - DUPLICATANFCE.TROCO) AS VALORPAGAMENTO
                               FROM DUPLICATANFCE
                                 INNER JOIN VENDA ON (DUPLICATANFCE.IDVENDA  = VENDA.IDVENDA)
                                 INNER JOIN FORMADEPAGAMENTO ON (DUPLICATANFCE.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)
                                  LEFT JOIN BANDEIRACARTAO ON (FORMADEPAGAMENTO.IDBANDEIRACARTAO = BANDEIRACARTAO.IDBANDEIRACARTAO)
                             WHERE VENDA.IDUSUARIO = @IDUSUARIO
                               AND VENDA.IDFLUXOCAIXA = @IDFLUXOCAIXA
                             GROUP BY DUPLICATANFCE.IDFORMADEPAGAMENTO,
                                      FORMADEPAGAMENTO.DESCRICAO,
                                      BANDEIRACARTAO.DESCRICAO";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFluxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataRow GetTotaisVendaDiaMesAno()
        {
            int ano = DateTime.Today.Year, mes = DateTime.Today.Month, dia = DateTime.Today.Day;
            
                
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
	                            (SELECT COALESCE(SUM(VALORTOTAL), 0) FROM VENDA
	                            WHERE DATACADASTRO >= @DIA AND TIPODEVENDA = 1) 
	                            AS TOTALDIA,
	                            (SELECT COALESCE(SUM(VALORTOTAL), 0) FROM VENDA
	                            WHERE DATACADASTRO >= @MES AND TIPODEVENDA = 1) 
	                            AS TOTALMES,
	                            (SELECT COALESCE(SUM(VALORTOTAL), 0) FROM VENDA
	                            WHERE DATACADASTRO >= @ANO AND TIPODEVENDA = 1) 
	                            AS TOTALANO";
                oSQL.ParamByName["DIA"] = new DateTime(ano, mes, dia);
                oSQL.ParamByName["MES"] = new DateTime(ano, mes, 1);
                oSQL.ParamByName["ANO"] = new DateTime(ano, 1, 1);
                oSQL.Open();
                if (oSQL.dtDados.Rows.Count == 0)
                    return null;
                return oSQL.dtDados.Rows[0];
            }
        }
    }
}
