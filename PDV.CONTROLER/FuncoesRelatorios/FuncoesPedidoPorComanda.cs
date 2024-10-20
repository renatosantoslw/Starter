using PDV.DAO.DB.Controller;
using System.Data;

namespace PDV.CONTROLER.FuncoesRelatorios
{
    public class FuncoesPedidoPorComanda
    {
        public static DataTable GetPedidoPorComanda(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT VENDA.IDVENDA,
                                    VENDA.QUANTIDADEITENS,
                                    VENDA.VALORTOTAL,
                                    USUARIO.IDUSUARIO,
                                    USUARIO.NOME AS USUARIO,
                             
                                    COALESCE(CLIENTE.IDCLIENTE, -1) AS IDCLIENTE,
                                    COALESCE(COALESCE(CLIENTE.NOMEFANTASIA, CLIENTE.NOME), '<Não Informado>') AS CLIENTE,
                                    COALESCE(CLIENTE.CNPJ, CLIENTE.CPF) AS CPFCNPJ,
                                    ENDERECO.TELEFONE,
                                    ENDERECO.LOGRADOURO + ', ' + CAST(ENDERECO.NUMERO AS VARCHAR) + ', ' + ENDERECO.COMPLEMENTO AS LOGRADOURO,
                                    ENDERECO.BAIRRO,
                                    MUNICIPIO.DESCRICAO+'/'+UNIDADEFEDERATIVA.SIGLA AS MUNICIPIO,
                             
                                    COMANDA.CODIGO AS CODIGOCOMANDA,
                                    COMANDA.DESCRICAO AS DESCRICAOCOMANDA
                             
                               FROM VENDA
                                 LEFT JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                                 LEFT JOIN ITEMVENDA ON VENDA.IDVENDA = ITEMVENDA.IDVENDA
                                 LEFT JOIN COMANDA ON (VENDA.IDCOMANDA = COMANDA.IDCOMANDA)
                                  LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                  LEFT JOIN ENDERECO ON (CLIENTE.IDENDERECO = ENDERECO.IDENDERECO)
                                  LEFT JOIN MUNICIPIO ON (ENDERECO.IDMUNICIPIO = MUNICIPIO.IDMUNICIPIO)
                                  LEFT JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                             WHERE VENDA.IDVENDA = @IDVENDA
                               --AND VENDA.IDCOMANDA IS NOT NULL
                               --AND VENDA.IDCOMANDAUTILIZADA IS NULL";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetItensPedidoPorComanda(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ITEMVENDA.IDITEMVENDA,
                                    PRODUTO.CODIGO,
                                    PRODUTO.IDPRODUTO,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    ITEMVENDA.DESCRICAO AS DESCRICAO,
                                    ITEMVENDA.QUANTIDADE+' '+UNIDADEDEMEDIDA.SIGLA AS QUANTIDADE,
                                    ITEMVENDA.VALORUNITARIOITEM - ITEMVENDA.DESCONTOVALOR AS VALORUNITARIOITEM,
                                    ITEMVENDA.QUANTIDADE * (ITEMVENDA.VALORUNITARIOITEM - ITEMVENDA.DESCONTOVALOR) AS VALORTOTAL,
                                    ITEMVENDA.QUANTIDADE AS QTD,
                                    ITEMVENDA.DESCONTOVALOR
                               FROM ITEMVENDA
                                 INNER JOIN PRODUTO ON (ITEMVENDA.IDPRODUTO = PRODUTO.IDPRODUTO)
                                 LEFT JOIN UNIDADEDEMEDIDA ON PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA
                             WHERE ITEMVENDA.IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }


    }
}
