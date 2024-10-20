using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System.Data;

namespace PDV.CONTROLER.FuncoesRelatorios
{
    public class FuncoesPedidoVendaTermica
    {

        public static DataTable GetPedidosVendaTermica(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT VENDA.IDVENDA,
                                    VENDA.QUANTIDADEITENS,
                                    SUM(ITEMVENDA.SUBTOTAL) AS VALORTOTAL,
                                    VENDA.DINHEIRO,
                                    VENDA.TROCO,
                                    USUARIO.IDUSUARIO,
                                    USUARIO.NOME AS USUARIO,                             
                                    COALESCE(CLIENTE.IDCLIENTE, -1) AS IDCLIENTE,
                                    COALESCE(COALESCE(CLIENTE.NOMEFANTASIA, CLIENTE.NOME), '<Não Informado>') AS CLIENTE,
                                    COALESCE(CLIENTE.CNPJ, CLIENTE.CPF) AS CPFCNPJ,
                                    ENDERECO.TELEFONE,
                                    ENDERECO.LOGRADOURO + CAST(ENDERECO.NUMERO AS VARCHAR) + ENDERECO.COMPLEMENTO AS LOGRADOURO,
                                    ENDERECO.BAIRRO,
                                    MUNICIPIO.DESCRICAO + UNIDADEFEDERATIVA.SIGLA AS MUNICIPIO,
                                    'NFCE-'+ CAST(MOVIMENTOFISCAL.IDMOVIMENTOFISCAL AS VARCHAR) AS IDMOVIMENTOFISCAL
                               FROM VENDA
                                  LEFT JOIN MOVIMENTOFISCAL ON (VENDA.IDVENDA = MOVIMENTOFISCAL.IDVENDA)
                                 INNER JOIN USUARIO ON (VENDA.IDUSUARIO = USUARIO.IDUSUARIO)
                                 INNER JOIN ITEMVENDA ON VENDA.IDVENDA = ITEMVENDA.IDVENDA
                                  LEFT JOIN CLIENTE ON (VENDA.IDCLIENTE = CLIENTE.IDCLIENTE)
                                  LEFT JOIN ENDERECO ON (CLIENTE.IDENDERECO = ENDERECO.IDENDERECO)
                                  LEFT JOIN MUNICIPIO ON (ENDERECO.IDMUNICIPIO = MUNICIPIO.IDMUNICIPIO)
                                  LEFT JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                             WHERE VENDA.IDVENDA = @IDVENDA
                               GROUP BY 
VENDA.IDVENDA,
VENDA.QUANTIDADEITENS,
VENDA.DINHEIRO,
VENDA.TROCO,
USUARIO.IDUSUARIO,
USUARIO.NOME,
CLIENTE.IDCLIENTE,
CLIENTE.NOMEFANTASIA,
CLIENTE.NOME,
CLIENTE.CNPJ, 
CLIENTE.CPF,
ENDERECO.TELEFONE,
ENDERECO.LOGRADOURO,
ENDERECO.NUMERO,
ENDERECO.COMPLEMENTO,
ENDERECO.BAIRRO,
MUNICIPIO.DESCRICAO,
UNIDADEFEDERATIVA.SIGLA,
MOVIMENTOFISCAL.IDMOVIMENTOFISCAL";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetItensPedidoVendaTermica(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT ITEMVENDA.IDITEMVENDA,
                                    PRODUTO.CODIGO,
                                    PRODUTO.IDPRODUTO,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    CAST(ITEMVENDA.QUANTIDADE AS VARCHAR)+' '+UNIDADEDEMEDIDA.SIGLA AS QUANTIDADE,
                                    ITEMVENDA.VALORUNITARIOITEM AS VALORUNITARIOITEM,                                     
                                    ITEMVENDA.SUBTOTAL AS VALORTOTAL,
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

        public static DataTable GetDAV(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                            V.IDVENDA AS CODIGO,
                            V.DATACADASTRO AS DATA ,
                            U.NOME AS VENDEDOR,
                            CASE
								WHEN CLI.NOME IS NOT NULL THEN CLI.NOME
								WHEN CLI.NOME IS NULL THEN CLI.NOMEFANTASIA
								WHEN CLI.NOMEFANTASIA IS NULL AND CLI.NOME IS NULL THEN CLI.RAZAOSOCIAL
								
							END AS CLIENTE, 
                            CASE WHEN CLI.TIPODOCUMENTO = 0 THEN CLI.CNPJ ELSE CLI.CPF END AS DOCUMENTO,
                            CASE WHEN CON.TELEFONE IS NULL THEN CON.CELULAR ELSE CON.TELEFONE END AS TELEFONE,
                            E.LOGRADOURO + ', ' + E.NUMERO + ', ' +  E.CEP  + ', ' +  E.BAIRRO + ', ' +  MC.DESCRICAO + ' - ' +  UF.SIGLA AS ENDERECO,
                            PRO.IDPRODUTO AS CODIGOPRODUTO, 
                            IV.DESCRICAO AS PRODUTO,
                            IV.QUANTIDADE AS QUANTIDADE,
                            UN.SIGLA AS UN,
                            IV.VALORUNITARIOITEM AS VALOR,
                            IV.DESCONTOVALOR AS DESCONTO,
                            V.VALORTOTAL AS VALORTOTAL,
                            V.OBSERVACAO AS OBSERVACAO,
                            V.PAGAMENTOSDESCRICAO AS PAGAMENTOSDESCRICAO,
                            IV.ALTURA AS ALTURA,
                            IV.LARGURA AS LARGURA,
                            IV.AREA AS AREA,
                            V.OBRA AS OBRA,
                            V.VALORAVISTAPROPOSTO AS VALORAVISTAPROPOSTO,
                           PRO.IMAGEMPRODUTO as IMAGEMPRODUTO
                            FROM VENDA V
                            LEFT JOIN ITEMVENDA IV ON IV.IDVENDA = V.IDVENDA
                            LEFT JOIN PRODUTO PRO ON PRO.IDPRODUTO = IV.IDPRODUTO
                            LEFT JOIN UNIDADEDEMEDIDA UN ON UN.IDUNIDADEDEMEDIDA = PRO.IDUNIDADEDEMEDIDA
                            LEFT JOIN CLIENTE CLI ON CLI.IDCLIENTE = V.IDCLIENTE
                            LEFT JOIN FORMADEPAGAMENTO F ON F.IDFORMADEPAGAMENTO = V.IDFORMAPAGAMENTO
                            LEFT JOIN USUARIO U ON U.IDUSUARIO = V.IDVENDEDOR
                            LEFT JOIN ENDERECO E ON E.IDENDERECO = CLI.IDENDERECO
                            LEFT JOIN MUNICIPIO MC ON MC.IDMUNICIPIO = E.IDMUNICIPIO
                            LEFT JOIN UNIDADEFEDERATIVA UF ON UF.IDUNIDADEFEDERATIVA = MC.IDUNIDADEFEDERATIVA
							LEFT JOIN CONTATO CON ON CON.IDCONTATO = CLI.IDCONTATO
                           WHERE v.idvenda = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetDAVProdutoAcabadoSomente(decimal IDVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                            V.IDVENDA AS CODIGO,
                            V.DATACADASTRO AS DATA ,
                            U.NOME AS VENDEDOR,
                            CASE
								WHEN CLI.NOME IS NOT NULL THEN CLI.NOME
								WHEN CLI.NOME IS NULL THEN CLI.NOMEFANTASIA
								WHEN CLI.NOMEFANTASIA IS NULL AND CLI.NOME IS NULL THEN CLI.RAZAOSOCIAL
								
							END AS CLIENTE, 
                            CASE WHEN CLI.TIPODOCUMENTO = 0 THEN CLI.CNPJ ELSE CLI.CPF END AS DOCUMENTO,
                            CASE WHEN CON.TELEFONE IS NULL THEN CON.CELULAR ELSE CON.TELEFONE END AS TELEFONE,
                            E.LOGRADOURO + ', ' + E.NUMERO + ', ' +  E.CEP  + ', ' +  E.BAIRRO + ', ' +  MC.DESCRICAO + '- ' +  UF.SIGLA AS ENDERECO,
                            PRO.IDPRODUTO AS CODIGOPRODUTO, 
                            IV.DESCRICAO AS PRODUTO,
                            IV.QUANTIDADE AS QUANTIDADE,
                            UN.SIGLA AS UN,
                            IV.VALORUNITARIOITEM AS VALOR,
                            IV.DESCONTOVALOR AS DESCONTO,
                            V.VALORTOTAL AS VALORTOTAL,
                            V.OBSERVACAO AS OBSERVACAO,
                            V.PAGAMENTOSDESCRICAO AS PAGAMENTOSDESCRICAO,
                            IV.ALTURA AS ALTURA,
                            IV.LARGURA AS LARGURA,
                            IV.AREA AS AREA,
                            V.OBRA AS OBRA,
                            V.VALORAVISTAPROPOSTO AS VALORAVISTAPROPOSTO,
                           PRO.IMAGEMPRODUTO as IMAGEMPRODUTO
                            FROM VENDA V
                            LEFT JOIN ITEMVENDA IV ON IV.IDVENDA = V.IDVENDA
                            LEFT JOIN PRODUTO PRO ON PRO.IDPRODUTO = IV.IDPRODUTO
                            LEFT JOIN UNIDADEDEMEDIDA UN ON UN.IDUNIDADEDEMEDIDA = PRO.IDUNIDADEDEMEDIDA
                            LEFT JOIN CLIENTE CLI ON CLI.IDCLIENTE = V.IDCLIENTE
                            LEFT JOIN FORMADEPAGAMENTO F ON F.IDFORMADEPAGAMENTO = V.IDFORMAPAGAMENTO
                            LEFT JOIN USUARIO U ON U.IDUSUARIO = V.IDVENDEDOR
                            LEFT JOIN ENDERECO E ON E.IDENDERECO = CLI.IDENDERECO
                            LEFT JOIN MUNICIPIO MC ON MC.IDMUNICIPIO = E.IDMUNICIPIO
                            LEFT JOIN UNIDADEFEDERATIVA UF ON UF.IDUNIDADEFEDERATIVA = MC.IDUNIDADEFEDERATIVA
							LEFT JOIN CONTATO CON ON CON.IDCONTATO = CLI.IDCONTATO
                           WHERE v.idvenda = @IDVENDA AND PRO.TIPODEPRODUTO = @TIPODEPRODUTO";
                oSQL.ParamByName["IDVENDA"] = IDVenda;
                oSQL.ParamByName["TIPODEPRODUTO"] = Produto.ProdutoAcabado;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

    }
}
