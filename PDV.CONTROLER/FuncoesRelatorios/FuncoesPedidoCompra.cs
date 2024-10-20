using PDV.DAO.DB.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.FuncoesRelatorios
{
    public class FuncoesPedidoCompra
    {
        public static DataTable GetPedidoCompraComItens(decimal IDPedidoCompra)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT PEDIDOCOMPRA.IDPEDIDOCOMPRA,
                                    PEDIDOCOMPRA.DATAEMISSAO,
                                    PEDIDOCOMPRA.DATAENTREGA,
                                    PEDIDOCOMPRA.OBSERVACAO,
                                    PEDIDOCOMPRA.PAGAMENTOSDESCRICAO,
                                    CASE 
                                      WHEN PEDIDOCOMPRA.TIPOFRETE = 0 THEN 'CIF'
                                      WHEN PEDIDOCOMPRA.TIPOFRETE = 1 THEN 'FOB'
                                    END AS TIPOFRETE,
                                    USUARIO.IDUSUARIO,
                                    USUARIO.NOME AS USUARIO,
                                    
                                    FORNECEDOR.IDFORNECEDOR,
                                    FORNECEDOR.RAZAOSOCIAL AS FORNECEDOR,
                                    FORNECEDOR.CNPJ AS CNPJFORNECEDOR,
                                    FORNECEDOR.EMAIL AS EMAILFORNECEDOR,
                                    COALESCE(FORNECEDOR.INSCRICAOESTADUAL::VARCHAR, '<Não Informado>') AS IEFORNECEDOR,
                                    ENDERECO.TELEFONE AS FONEFORNECEDOR,
                             
                                    ENDERECO.LOGRADOURO+', '+ENDERECO.NUMERO+' - '+ENDERECO.BAIRRO AS ENDERECOFORNECEDOR,
                                    ENDERECO.CEP AS CEPFORNECEDOR,
                                    UNIDADEFEDERATIVA.SIGLA AS UFFORNECEDOR,
                                    MUNICIPIO.DESCRICAO AS MUNICIPIO,
                                    FORMADEPAGAMENTO.IDFORMADEPAGAMENTO,
                                    FORMADEPAGAMENTO.DESCRICAO AS FORMADEPAGAMENTO,
                             
                                    TRANSPORTADORA.IDTRANSPORTADORA,
                                    TRANSPORTADORA.RAZAOSOCIAL AS TRANSPORTADORA,
                             
                                    ITEMPEDIDOCOMPRA.IDITEMPEDIDOCOMPRA,
                                    PRODUTO.IDPRODUTO,
                                    COALESCE(PRODUTO.EAN, '<Não Informado>') AS CODIGODEBARRAS,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    ITEMPEDIDOCOMPRA.QUANTIDADE,
                                    ITEMPEDIDOCOMPRA.VALORUNITARIO,
                                    ITEMPEDIDOCOMPRA.DESCONTO,
                                    ITEMPEDIDOCOMPRA.TOTAL
                               FROM PEDIDOCOMPRA
                             INNER JOIN USUARIO ON (PEDIDOCOMPRA.IDUSUARIOCADASTRO = USUARIO.IDUSUARIO)
                             INNER JOIN ITEMPEDIDOCOMPRA ON (PEDIDOCOMPRA.IDPEDIDOCOMPRA = ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA)
                             INNER JOIN PRODUTO ON (ITEMPEDIDOCOMPRA.IDPRODUTO = PRODUTO.IDPRODUTO)
                             INNER JOIN FORNECEDOR ON (PEDIDOCOMPRA.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                             INNER JOIN ENDERECO ON (FORNECEDOR.IDENDERECO = ENDERECO.IDENDERECO)
                              LEFT JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                              LEFT JOIN MUNICIPIO ON (ENDERECO.IDMUNICIPIO = MUNICIPIO.IDMUNICIPIO)
                              LEFT JOIN TIPODEOPERACAO ON (TIPODEOPERACAO.IDTIPODEOPERACAO = PEDIDOCOMPRA.IDTIPODEOPERACAO)
                              LEFT JOIN TRANSPORTADORA ON (TIPODEOPERACAO.IDTRANSPORTADORA = TRANSPORTADORA.IDTRANSPORTADORA)
                              LEFT JOIN FORMADEPAGAMENTO ON (PEDIDOCOMPRA.IDFORMADEPAGAMENTO = FORMADEPAGAMENTO.IDFORMADEPAGAMENTO)                              
                             WHERE PEDIDOCOMPRA.IDPEDIDOCOMPRA = @IDPEDIDOCOMPRA";
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = IDPedidoCompra;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
