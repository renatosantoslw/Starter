using PDV.DAO.DB.Controller;
using System.Data;

namespace PDV.CONTROLER.FuncoesRelatorios
{
    public class FuncoesComandaEmAberto
    {
        public static DataTable GetDados_ComandasEmAberto(decimal IDUsuario, decimal IDFLuxoCaixa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT COALESCE(SUM(ITEMVENDA.QUANTIDADE), 0) AS QUANTIDADEITENS,
                                    COALESCE(SUM(ITEMVENDA.QUANTIDADE * ITEMVENDA.VALORUNITARIOITEM) - SUM(ITEMVENDA.DESCONTOVALOR), 0) AS VALORTOTAL,
                                    VENDA.DATACADASTRO,
                                    CASE WHEN COMANDA IS NULL THEN '<Não Informado>' ELSE COALESCE(CLIENTE.CPF, CLIENTE.CNPJ) END AS CLIENTE,
                                    COMANDA.DESCRICAO AS COMANDA,
                                    USUARIO.IDUSUARIO,
                                    USUARIO.NOME AS USUARIO
                               FROM VENDA
                                 INNER JOIN COMANDA ON (VENDA.IDCOMANDA = COMANDA.IDCOMANDA)
                                 INNER JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                                  LEFT JOIN ITEMVENDA ON (VENDA.IDVENDA = ITEMVENDA.IDVENDA)
                                  LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                              WHERE VENDA.IDCOMANDA IS NOT NULL
                                AND VENDA.IDCOMANDAUTILIZADA IS NULL
                                AND VENDA.IDUSUARIO = @IDUSUARIO
                                AND VENDA.IDFLUXOCAIXA = @IDFLUXOCAIXA
                             GROUP BY 3,4,5,6,7";
                oSQL.ParamByName["IDUSUARIO"] = IDUsuario;
                oSQL.ParamByName["IDFLUXOCAIXA"] = IDFLuxoCaixa;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}