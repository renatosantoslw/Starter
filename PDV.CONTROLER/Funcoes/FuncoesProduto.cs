using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using PDV.DAO;
using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesProduto
    {
        public static DataTable GetProdutos(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                string FiltroCodigo = string.Empty;
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("UPPER(PRODUTO.CODIGO) LIKE '%{0}%'", Codigo.ToUpper()));

                string FiltroDescricao = string.Empty;
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("UPPER(PRODUTO.DESCRICAO) LIKE '%{0}%'", Descricao.ToUpper()));

                oSQL.SQL = string.Format(@"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                                  PRODUTO.CODIGO, 
                                                  PRODUTO.DESCRICAO,
                                                  NCM.codigo AS NCM,
                                                  PRODUTO.EAN,
                                                  PRODUTO.SALDOESTOQUE,
                                                 -- PRODUTO.IMAGEMPRODUTO,
                                                  PRODUTO.VALORCUSTO,
                                                  PRODUTO.VALORVENDA,
                                                  PRODUTO.VALORVENDAPRAZO,
                                                  PRODUTO.PARAVENDER
                                           FROM PRODUTO 
                                            LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
											LEFT JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                                            {0} --comentei porque tem erro nessa linha
                                           ORDER BY PRODUTO.DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetPosicaoEstoque()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT
                                    PRODUTO.CODIGO + '  '+ PRODUTO.DESCRICAO AS PRODUTO,
                                    UNIDADEDEMEDIDA.DESCRICAO+' ('+UNIDADEDEMEDIDA.SIGLA+')' AS UNIDADE,
									MARCA.DESCRICAO AS GRUPO,
                                    PRODUTO.SALDOESTOQUE AS SALDO,
                                    PRODUTO.VALORCUSTO AS CUSTO,
                                    PRODUTO.VALORCUSTO * PRODUTO.SALDOESTOQUE AS TOTALCUSTO
                               FROM PRODUTO
							      INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
								  LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                ORDER BY  PRODUTO";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados;
            }
        }
        public static DataTable GetPosicaoEstoqueChart()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT
                                   TOP 20 cast(PRODUTO.CODIGO as varchar) + '  ' + PRODUTO.DESCRICAO  + '' +
                                     ' (' + UNIDADEDEMEDIDA.SIGLA + ')' AS DESCRICAO,
                                    PRODUTO.SALDOESTOQUE AS VALOR,
                                    PRODUTO.VALORCUSTO AS CUSTO,
                                    PRODUTO.VALORCUSTO * PRODUTO.SALDOESTOQUE AS TOTALCUSTO
                               FROM PRODUTO
							      INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
								  LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                WHERE  PRODUTO.SALDOESTOQUE > 0
                                ORDER BY  Valor
                                    "; // Corrigido por Rodrigo
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados;
            }
        }
        public static DataTable GetPosicaoEstoqueGeralChart()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT
                                    cast(PRODUTO.CODIGO as Varchar) + ' ' + PRODUTO.DESCRICAO  + ' ' +
                                    ' ('+UNIDADEDEMEDIDA.SIGLA+')' AS DESCRICAO,
                                    PRODUTO.SALDOESTOQUE AS ESTOQUE,
                                    PRODUTO.VALORCUSTO AS CUSTO,
                                    PRODUTO.VALORCUSTO * PRODUTO.SALDOESTOQUE AS TOTALCUSTO
                               FROM PRODUTO
							      INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
								  LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                ORDER BY  ESTOQUE desc
                                    ";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados;
            }
        }
        public static DataRow GetProdutoPorCodigoPDV(string Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                    PRODUTO.CODIGO,
                                    PRODUTO.EAN AS CODIGODEBARRAS,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    MARCA.DESCRICAO AS MARCA,
                                    UNIDADEDEMEDIDA.DESCRICAO + ' ('+UNIDADEDEMEDIDA.SIGLA +')' AS UNIDADEDEMEDIDA,
                                    UNIDADEDEMEDIDA.SIGLA AS UNIDADEDEMEDIDASIGLA,
                                    PRODUTO.VALORVENDAPRAZO AS PRECOVENDAPRAZO,
                                    PRODUTO.VALORVENDA AS PRECOVENDA,
                                    PRODUTO.VALORCUSTO AS VALORCUSTO,
                                    cast(NCM.CODIGO as varchar) + ' - ' + NCM.DESCRICAO AS NCM,
                                    PRODUTO.EXTIPI,
                                    PRODUTO.IDINTEGRACAOFISCALNFCE
                               FROM PRODUTO
                                 INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                  LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                  LEFT JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                             WHERE (PRODUTO.EAN = @CODIGO OR PRODUTO.CODIGO = @CODIGO) 
                               AND COALESCE(PRODUTO.ATIVO, 0) = 1";
                oSQL.ParamByName["CODIGO"] = Codigo;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return oSQL.dtDados.Rows[0];
            }
        }

        public static ProdutoPDV GetProdutoPDVPorCodigo(string Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                    PRODUTO.CODIGO,
                                    PRODUTO.EAN AS CODIGODEBARRAS,
                                    PRODUTO.DESCRICAO AS PRODUTO,
                                    MARCA.DESCRICAO AS MARCA,
                                    UNIDADEDEMEDIDA.DESCRICAO +' ('+UNIDADEDEMEDIDA.SIGLA +')' AS UNIDADEDEMEDIDA,
                                    UNIDADEDEMEDIDA.SIGLA AS UNIDADEDEMEDIDASIGLA,
                                    PRODUTO.VALORVENDAPRAZO AS PRECOVENDAPRAZO,
                                    PRODUTO.VALORVENDA AS PRECOVENDA,
                                    PRODUTO.VALORCUSTO AS VALORCUSTO,
                                    cast(NCM.CODIGO as varchar) + ' - ' + NCM.DESCRICAO AS NCM,
                                    PRODUTO.EXTIPI,
                                    PRODUTO.IDINTEGRACAOFISCALNFCE,
                                    PRODUTO.BALANCA,
                                    PRODUTO.REFERENCIA
                               FROM PRODUTO
                                 INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                  LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                  LEFT JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                             WHERE (PRODUTO.EAN = @CODIGO OR PRODUTO.CODIGO = @CODIGO) 
                               AND COALESCE(PRODUTO.ATIVO, 0) = 1";
                oSQL.ParamByName["CODIGO"] = Codigo;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return new DataTableParser<ProdutoPDV>().ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Produto GetProduto(decimal? IDProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPRODUTO,
                            IDUNIDADEDEMEDIDA,
                            IDORIGEMPRODUTO,
                            IDINTEGRACAOFISCALNFE,
                            IDINTEGRACAOFISCALNFCE,
                            IDMARCA,
                            IDNCM,
                            IDSUBCATEGORIA,
                            IDCATEGORIA,
                            CODIGO,
                            DESCRICAO,
                            EXTIPI,
                            EAN,
                            CEST,
                            VALORVENDA,
                            VALORCUSTO,
                            TRIB_MVA,
                            TRIB_REDBCICMS,
                            TRIB_REDBCICMSST,
                            TRIB_ALIQIPI,
                            TRIB_ALIQPIS,
                            TRIB_ALIQCOFINS,
                            TRIB_ALIQICMSDIF,
                            ATIVO,
                            IDALMOXARIFADOENTRADA,
                            IDALMOXARIFADOSAIDA,
                            SALDOESTOQUE,
                            VENDERSEMSALDO,
                            CHAVEERP,
                            VALORVENDAPRAZO,
                            ALTERARDESCRICAO,
                            ESTOQUEMINIMO,
                            ESTOQUEMAXIMO,
                            IMAGEMPRODUTO,
                            IMAGEMPRODUTOLINK,
                            TIPODEPRODUTO,
                            PARAVENDER,
                            BALANCA,
                            REFERENCIA 
                            from PRODUTO
                            WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Produto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static Produto GetProdutoCodigo(string Codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPRODUTO,
                            IDUNIDADEDEMEDIDA,
                            IDORIGEMPRODUTO,
                            IDINTEGRACAOFISCALNFE,
                            IDINTEGRACAOFISCALNFCE,
                            IDMARCA,
                            IDNCM,
                            IDSUBCATEGORIA,
                            IDCATEGORIA,
                            CODIGO,
                            DESCRICAO,
                            EXTIPI,
                            EAN,
                            CEST,
                            VALORVENDA,
                            VALORCUSTO,
                            TRIB_MVA,
                            TRIB_REDBCICMS,
                            TRIB_REDBCICMSST,
                            TRIB_ALIQIPI,
                            TRIB_ALIQPIS,
                            TRIB_ALIQCOFINS,
                            TRIB_ALIQICMSDIF,
                            ATIVO,
                            IDALMOXARIFADOENTRADA,
                            IDALMOXARIFADOSAIDA,
                            SALDOESTOQUE,
                            VENDERSEMSALDO,
                            CHAVEERP,
                            VALORVENDAPRAZO,
                            ALTERARDESCRICAO,
                            ESTOQUEMINIMO,
                            ESTOQUEMAXIMO,
                            IMAGEMPRODUTO,
                            IMAGEMPRODUTOLINK,
                            TIPODEPRODUTO,
                            PARAVENDER,
                            BALANCA,
                            REFERENCIA 
                            FROM PRODUTO P WHERE P.Codigo = @Codigo";
                oSQL.ParamByName["Codigo"] = Codigo;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Produto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static List<Produto> GetProdutoLista()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT P.* FROM PRODUTO P ORDER BY DESCRICAO";
               
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Produto>.ParseDataTable(oSQL.dtDados);
            }
        }

        public static List<Produto> GetProdutosPorTipo(int tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDPRODUTO,
                            IDUNIDADEDEMEDIDA,
                            IDORIGEMPRODUTO,
                            IDINTEGRACAOFISCALNFE,
                            IDINTEGRACAOFISCALNFCE,
                            IDMARCA,
                            IDNCM,
                            IDSUBCATEGORIA,
                            IDCATEGORIA,
                            CODIGO,
                            DESCRICAO,
                            EXTIPI,
                            EAN,
                            CEST,
                            VALORVENDA,
                            VALORCUSTO,
                            TRIB_MVA,
                            TRIB_REDBCICMS,
                            TRIB_REDBCICMSST,
                            TRIB_ALIQIPI,
                            TRIB_ALIQPIS,
                            TRIB_ALIQCOFINS,
                            TRIB_ALIQICMSDIF,
                            ATIVO,
                            IDALMOXARIFADOENTRADA,
                            IDALMOXARIFADOSAIDA,
                            SALDOESTOQUE,
                            VENDERSEMSALDO,
                            CHAVEERP,
                            VALORVENDAPRAZO,
                            ALTERARDESCRICAO,
                            ESTOQUEMINIMO,
                            ESTOQUEMAXIMO,
                            IMAGEMPRODUTO,
                            IMAGEMPRODUTOLINK,
                            TIPODEPRODUTO,
                            PARAVENDER,
                            BALANCA 
                            FROM PRODUTO WHERE TIPODEPRODUTO = @TIPODEPRODUTO ORDER BY DESCRICAO";

                oSQL.ParamByName["TIPODEPRODUTO"] = tipo;

                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Produto>.ParseDataTable(oSQL.dtDados);
            }
        }

        public static DataTable GetProdutoEAN(string EAN)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                                  PRODUTO.CODIGO,
                                                  PRODUTO.EAN AS CODIGODEBARRAS,
                                                  PRODUTO.DESCRICAO,
                                                  MARCA.DESCRICAO AS MARCA,
                                                  UNIDADEDEMEDIDA.DESCRICAO + ' ('+ UNIDADEDEMEDIDA.SIGLA +')' AS UNIDADEDEMEDIDA,
                                                  UNIDADEDEMEDIDA.SIGLA AS UNIDADEDEMEDIDASIGLA,
                                                  PRODUTO.VALORVENDA AS PRECOVENDA,
                                                  cast(NCM.CODIGO as varchar) + ' - ' + NCM.DESCRICAO AS NCM,
                                                  PRODUTO.EXTIPI,
                                                  PRODUTO.SALDOESTOQUE
                                             FROM PRODUTO
                                               INNER JOIN ALMOXARIFADO ON (PRODUTO.IDALMOXARIFADOSAIDA = ALMOXARIFADO.IDALMOXARIFADO)
                                               INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                               LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                               LEFT JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                                            WHERE EAN = @EAN");
                oSQL.ParamByName["EAN"] = EAN;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados;
            }
        }

        public static bool SalvarProduto(Produto _Produto, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO PRODUTO(IDPRODUTO, IDUNIDADEDEMEDIDA, IDORIGEMPRODUTO, IDINTEGRACAOFISCALNFE, IDINTEGRACAOFISCALNFCE, IDMARCA, IDNCM, IDSUBCATEGORIA, IDCATEGORIA, 
                                                         ATIVO, TIPODEPRODUTO, CODIGO, DESCRICAO, EXTIPI, EAN, CEST, VALORVENDA, VALORCUSTO, TRIB_MVA, TRIB_REDBCICMS, 
                                                         TRIB_REDBCICMSST, TRIB_ALIQIPI, TRIB_ALIQPIS, TRIB_ALIQCOFINS, TRIB_ALIQICMSDIF, IDALMOXARIFADOENTRADA, IDALMOXARIFADOSAIDA, VENDERSEMSALDO, ALTERARDESCRICAO, VALORVENDAPRAZO, ESTOQUEMINIMO, ESTOQUEMAXIMO,ImagemProduto,ImagemProdutoLink,
                                                         PARAVENDER,BALANCA,REFERENCIA)
                                         VALUES (@IDPRODUTO, @IDUNIDADEDEMEDIDA, @IDORIGEMPRODUTO, @IDINTEGRACAOFISCALNFE, @IDINTEGRACAOFISCALNFCE, @IDMARCA, @IDNCM, @IDSUBCATEGORIA, @IDCATEGORIA, @ATIVO,
                                                 @TIPODEPRODUTO, @CODIGO, @DESCRICAO, @EXTIPI, @EAN, @CEST, @VALORVENDA, @VALORCUSTO, @TRIB_MVA, @TRIB_REDBCICMS, 
                                                 @TRIB_REDBCICMSST, @TRIB_ALIQIPI, @TRIB_ALIQPIS, @TRIB_ALIQCOFINS, @TRIB_ALIQICMSDIF, @IDALMOXARIFADOENTRADA, @IDALMOXARIFADOSAIDA, @VENDERSEMSALDO, @ALTERARDESCRICAO, @VALORVENDAPRAZO, @ESTOQUEMINIMO, @ESTOQUEMAXIMO,CONVERT(varbinary,@ImagemProduto),@ImagemProdutoLink,
                                                          @PARAVENDER,@BALANCA,@REFERENCIA)";

                        //oSQL.SQL = @"INSERT INTO PRODUTO(IDPRODUTO,IDUNIDADEDEMEDIDA,IDORIGEMPRODUTO,IDINTEGRACAOFISCALNFE,IDINTEGRACAOFISCALNFCE,IDMARCA,IDNCM,IDSUBCATEGORIA,IDCATEGORIA,CODIGO,DESCRICAO,EXTIPI,
                        //             EAN,CEST,VALORVENDA,VALORCUSTO,TRIB_MVA,TRIB_REDBCICMS,TRIB_REDBCICMSST,TRIB_ALIQIPI,TRIB_ALIQPIS,TRIB_ALIQCOFINS,TRIB_ALIQICMSDIF,ATIVO,IDALMOXARIFADOENTRADA,IDALMOXARIFADOSAIDA,
                        //             SALDOESTOQUE,VENDERSEMSALDO,CHAVEERP,VALORVENDAPRAZO,ALTERARDESCRICAO,ESTOQUEMINIMO,ESTOQUEMAXIMO,IMAGEMPRODUTO,IMAGEMPRODUTOLINK,TIPODEPRODUTO,PARAVENDER,BALANCA)
                        //             VALUES (@IDPRODUTO,@IDUNIDADEDEMEDIDA,@IDORIGEMPRODUTO,@IDINTEGRACAOFISCALNFE,@IDINTEGRACAOFISCALNFCE,@IDMARCA,@IDNCM,@IDSUBCATEGORIA,@IDCATEGORIA,@CODIGO,@DESCRICAO,@EXTIPI,
                        //             @EAN,@CEST,@VALORVENDA,@VALORCUSTO,@TRIB_MVA,@TRIB_REDBCICMS,@TRIB_REDBCICMSST,@TRIB_ALIQIPI,@TRIB_ALIQPIS,@TRIB_ALIQCOFINS,@TRIB_ALIQICMSDIF,@ATIVO,@IDALMOXARIFADOENTRADA,
                        //             @IDALMOXARIFADOSAIDA,@SALDOESTOQUE,@VENDERSEMSALDO,@CHAVEERP,@VALORVENDAPRAZO,@ALTERARDESCRICAO,@ESTOQUEMINIMO,@ESTOQUEMAXIMO,@IMAGEMPRODUTO,@IMAGEMPRODUTOLINK,@TIPODEPRODUTO,
                        //             @PARAVENDER,@BALANCA)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE PRODUTO
                                        SET IDUNIDADEDEMEDIDA = @IDUNIDADEDEMEDIDA,
                                            IDORIGEMPRODUTO = @IDORIGEMPRODUTO,
                                            IDINTEGRACAOFISCALNFE = @IDINTEGRACAOFISCALNFE,
                                            IDINTEGRACAOFISCALNFCE = @IDINTEGRACAOFISCALNFCE,
                                            IDMARCA = @IDMARCA,
                                            IDNCM = @IDNCM,
                                            IDSUBCATEGORIA = @IDSUBCATEGORIA,
                                            IDCATEGORIA = @IDCATEGORIA,
                                            TIPODEPRODUTO = @TIPODEPRODUTO,
                                            CODIGO = @CODIGO,
                                            DESCRICAO = @DESCRICAO,
                                            EXTIPI = @EXTIPI,
                                            EAN = @EAN,
                                            CEST = @CEST,
                                            VALORVENDA = @VALORVENDA,
                                            VALORCUSTO = @VALORCUSTO,
                                            TRIB_MVA = @TRIB_MVA,
                                            TRIB_REDBCICMS = @TRIB_REDBCICMS,
                                            TRIB_REDBCICMSST = @TRIB_REDBCICMSST,
                                            TRIB_ALIQIPI = @TRIB_ALIQIPI,
                                            TRIB_ALIQPIS = @TRIB_ALIQPIS,
                                            TRIB_ALIQCOFINS = @TRIB_ALIQCOFINS,
                                            TRIB_ALIQICMSDIF = @TRIB_ALIQICMSDIF,
                                            ATIVO = @ATIVO,
                                            IDALMOXARIFADOENTRADA = @IDALMOXARIFADOENTRADA,
                                            IDALMOXARIFADOSAIDA = @IDALMOXARIFADOSAIDA,
                                            VENDERSEMSALDO = @VENDERSEMSALDO,
                                            ALTERARDESCRICAO = @ALTERARDESCRICAO, 
                                            VALORVENDAPRAZO = @VALORVENDAPRAZO, 
                                            ESTOQUEMINIMO = @ESTOQUEMINIMO, 
                                            ESTOQUEMAXIMO = @ESTOQUEMAXIMO,
                                            ImagemProduto = CONVERT(VARBINARY(max),@ImagemProduto),ImagemProdutoLink = CONVERT(VARBINARY(max),@ImagemProdutoLink),
                                            PARAVENDER = CONVERT(VARBINARY(max),@PARAVENDER),
                                            BALANCA = @BALANCA,
                                            REFERENCIA = @REFERENCIA
                                        WHERE IDPRODUTO = @IDPRODUTO";
                        break;
                }
                oSQL.ParamByName["IDPRODUTO"] = _Produto.IDProduto;
                oSQL.ParamByName["IDUNIDADEDEMEDIDA"] = _Produto.IDUnidadeDeMedida;
                oSQL.ParamByName["IDORIGEMPRODUTO"] = _Produto.IDOrigemProduto;
                oSQL.ParamByName["IDINTEGRACAOFISCALNFE"] = _Produto.IDIntegracaoFiscalNFe;
                oSQL.ParamByName["IDINTEGRACAOFISCALNFCE"] = _Produto.IDIntegracaoFiscalNFCe;
                oSQL.ParamByName["IDMARCA"] = _Produto.IDMarca;
                oSQL.ParamByName["IDNCM"] = _Produto.IDNCM;
                oSQL.ParamByName["IDSUBCATEGORIA"] = _Produto.IDSubCategoria;
                oSQL.ParamByName["IDCATEGORIA"] = _Produto.IDCategoria;
                oSQL.ParamByName["CODIGO"] = _Produto.Codigo;
                oSQL.ParamByName["TIPODEPRODUTO"] = _Produto.TipoDeProduto;
                oSQL.ParamByName["DESCRICAO"] = _Produto.Descricao;
                oSQL.ParamByName["EXTIPI"] = _Produto.EXTipi;
                oSQL.ParamByName["EAN"] = _Produto.EAN;
                oSQL.ParamByName["CEST"] = _Produto.CEST;
                oSQL.ParamByName["VALORVENDA"] = _Produto.ValorVenda;
                oSQL.ParamByName["VALORCUSTO"] = _Produto.ValorCusto;
                oSQL.ParamByName["TRIB_MVA"] = _Produto.Trib_MVA;
                oSQL.ParamByName["TRIB_REDBCICMS"] = _Produto.Trib_RedBCICMS;
                oSQL.ParamByName["TRIB_REDBCICMSST"] = _Produto.Trib_RedBCICMSST;
                oSQL.ParamByName["TRIB_ALIQIPI"] = _Produto.Trib_AliqIPI;
                oSQL.ParamByName["TRIB_ALIQPIS"] = _Produto.Trib_AliqPIS;
                oSQL.ParamByName["TRIB_ALIQCOFINS"] = _Produto.Trib_AliqCOFINS;
                oSQL.ParamByName["TRIB_ALIQICMSDIF"] = _Produto.Trib_AliqICMSDif;
                oSQL.ParamByName["ATIVO"] = _Produto.Ativo;
                oSQL.ParamByName["IDALMOXARIFADOENTRADA"] = _Produto.IDAlmoxarifadoEntrada;
                oSQL.ParamByName["IDALMOXARIFADOSAIDA"] = _Produto.IDAlmoxarifadoSaida;
                oSQL.ParamByName["VENDERSEMSALDO"] = _Produto.VenderSemSaldo;
                oSQL.ParamByName["ALTERARDESCRICAO"] = _Produto.AlterarDescricao;
                oSQL.ParamByName["VALORVENDAPRAZO"] = _Produto.ValorVendaPrazo;
                oSQL.ParamByName["ESTOQUEMINIMO"] = _Produto.EstoqueMinimo;
                oSQL.ParamByName["ESTOQUEMAXIMO"] = _Produto.EstoqueMaximo;
                oSQL.ParamByName["ImagemProduto"] = _Produto.ImagemProduto;
                oSQL.ParamByName["ImagemProdutoLink"] = _Produto.ImagemProdutoLink;
                oSQL.ParamByName["PARAVENDER"] = _Produto.ParaVender;
                oSQL.ParamByName["BALANCA"] = _Produto.Balanca;
                oSQL.ParamByName["REFERENCIA"] = _Produto.Referencia;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool ExisteProdutoVinculadoComVenda(decimal IDProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM ITEMVENDA WHERE IDPRODUTO = @IDPRODUTO
                              UNION
                             SELECT 1 FROM PRODUTONFE WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Remover(decimal IDProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM PRODUTOFORNECEDOR WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.ExecSQL();

                oSQL.ClearAll();
                oSQL.SQL = "DELETE FROM PRODUTO WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetProdutosPorDescricao(string Descricao, bool ValidarIntegracaoNFe, bool ValidarIntegracaoNFCe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                string AndIntegracao = string.Empty;
                if (ValidarIntegracaoNFe)
                    AndIntegracao += " AND PRODUTO.IDINTEGRACAOFISCALNFE IS NOT NULL ";

                if (ValidarIntegracaoNFCe)
                    AndIntegracao += " AND PRODUTO.IDINTEGRACAOFISCALNFCE IS NOT NULL ";


                oSQL.SQL = string.Format(@"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                                  CAST(PRODUTO.CODIGO AS VARCHAR) AS CODIGO,
                                                  PRODUTO.EAN AS CODIGODEBARRAS,
                                                  PRODUTO.DESCRICAO,
                                                   PRODUTO.REFERENCIA,
                                                  MARCA.DESCRICAO AS MARCA,
                                                  UNIDADEDEMEDIDA.DESCRICAO + '(' + UNIDADEDEMEDIDA.SIGLA + ')' AS UNIDADEDEMEDIDA,
                                                  UNIDADEDEMEDIDA.SIGLA AS UNIDADEDEMEDIDASIGLA,
                                                  PRODUTO.VALORVENDA AS PRECOVENDA,
                                                  PRODUTO.SALDOESTOQUE AS ESTOQUE,
                                                  cast(NCM.CODIGO as varchar) + ' - ' + NCM.DESCRICAO AS NCM,
                                                  PRODUTO.EXTIPI
                                             FROM PRODUTO
                                               INNER JOIN ALMOXARIFADO ON (PRODUTO.IDALMOXARIFADOSAIDA = ALMOXARIFADO.IDALMOXARIFADO)
                                               INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                               LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                               LEFT JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                                           WHERE (UPPER(PRODUTO.DESCRICAO) LIKE '%{0}%' OR UPPER(CAST(PRODUTO.CODIGO AS VARCHAR)) LIKE '%{0}%' OR UPPER(CAST(PRODUTO.EAN AS VARCHAR)) LIKE '%{0}%')
                                             AND COALESCE(PRODUTO.ATIVO, 0) = 1
                                             {1}
                                           ORDER BY PRODUTO.DESCRICAO, PRODUTO.EAN", Descricao.ToUpper(), AndIntegracao);
                oSQL.Open();
                //if (oSQL.IsEmpty)
                //    return null;

                return oSQL.dtDados;
            }
        }

        public static DataTable GetProdutosMaisVendidos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {

                oSQL.SQL = @"select 
                            top 10 idproduto ,Upper (descricao) as descricao  ,cast( sum(valorunitarioitem) * sum(quantidade) as decimal) as valor from itemvenda
                            where idvenda not in (select idvenda from venda where status in (0,2))
                            group by idproduto,descricao
                            
                            ";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
        public static DataTable GetProdutosMaisComprado(DateTime dataDe, DateTime dataAte, decimal idOperacao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                                top 10 IDPRODUTO,
                                UPPER (DESCRICAO) AS DESCRICAO,
                                CAST( SUM(VALORUNITARIO) * SUM(QUANTIDADE) AS DECIMAL) AS VALOR 
                            FROM ITEMPEDIDOCOMPRA
                            JOIN PEDIDOCOMPRA ON (PEDIDOCOMPRA.IDPEDIDOCOMPRA = ITEMPEDIDOCOMPRA.IDPEDIDOCOMPRA)
                            WHERE PEDIDOCOMPRA.IDPEDIDOCOMPRA NOT IN (SELECT PEDIDOCOMPRA.IDPEDIDOCOMPRA FROM PEDIDOCOMPRA WHERE STATUS IN (0, 2))
                            AND (PEDIDOCOMPRA.DATAEMISSAO BETWEEN @DATADE AND @DATAATE)
                            AND PEDIDOCOMPRA.IDTIPODEOPERACAO = @IDOPERACAO
                            GROUP BY IDPRODUTO, DESCRICAO
                            ORDER BY  VALOR DESC
                            
                            ";
                oSQL.ParamByName["DATADE"] = dataDe.Date;
                oSQL.ParamByName["DATAATE"] = dataAte.Date;
                oSQL.ParamByName["IDOPERACAO"] = idOperacao;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetProdutosDAV()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {

                oSQL.SQL = string.Format(@"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                                  PRODUTO.CODIGO,
                                                  PRODUTO.EAN AS CODIGODEBARRAS,
                                                  PRODUTO.DESCRICAO,
                                                  MARCA.DESCRICAO AS MARCA,
                                                  UNIDADEDEMEDIDA.DESCRICAO+' ('+UNIDADEDEMEDIDA.SIGLA+')' AS UNIDADEDEMEDIDA,
                                                  UNIDADEDEMEDIDA.SIGLA AS UNIDADEDEMEDIDASIGLA,
                                                  PRODUTO.VALORVENDA AS PRECOVENDA,
                                                  PRODUTO.SALDOESTOQUE AS ESTOQUE,
                                                  CAST(NCM.CODIGO AS VARCHAR)+' - '+NCM.DESCRICAO AS NCM,
                                                  PRODUTO.EXTIPI
                                             FROM PRODUTO
                                               INNER JOIN ALMOXARIFADO ON (PRODUTO.IDALMOXARIFADOSAIDA = ALMOXARIFADO.IDALMOXARIFADO)
                                               INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                               LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                               LEFT JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                                           
                                             WHERE COALESCE(PRODUTO.ATIVO, 0) = 1 --AND PRODUTO.EAN IS NOT NULL
                                            AND PRODUTO.PARAVENDER = 1
                                           ORDER BY PRODUTO.DESCRICAO, PRODUTO.EAN");
                oSQL.Open();
                //if (oSQL.IsEmpty)
                //    return null;

                return oSQL.dtDados;
            }
        }
        public static DataTable GetProdutosDAC()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {

                oSQL.SQL = string.Format(@"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                                  PRODUTO.CODIGO,
                                                  PRODUTO.EAN AS CODIGODEBARRAS,
                                                  PRODUTO.DESCRICAO,
                                                  
                                                  MARCA.DESCRICAO AS MARCA,
                                                  UNIDADEDEMEDIDA.DESCRICAO+' ('+UNIDADEDEMEDIDA.SIGLA+')' AS UNIDADEDEMEDIDA,
                                                  UNIDADEDEMEDIDA.SIGLA AS UNIDADEDEMEDIDASIGLA,
                                                  PRODUTO.VALORCUSTO AS PRECO,
                                                  cast(NCM.CODIGO as varchar)+' - '+NCM.DESCRICAO AS NCM,
                                                  PRODUTO.EXTIPI
                                             FROM PRODUTO
                                               INNER JOIN ALMOXARIFADO ON (PRODUTO.IDALMOXARIFADOSAIDA = ALMOXARIFADO.IDALMOXARIFADO)
                                               INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                               LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                               LEFT JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                                           
                                             WHERE COALESCE(PRODUTO.ATIVO, 0) = 1 AND PRODUTO.EAN IS NOT NULL
                                            
                                           ORDER BY PRODUTO.DESCRICAO, PRODUTO.EAN");
                oSQL.Open();
                //if (oSQL.IsEmpty)
                //    return null;

                return oSQL.dtDados;
            }
        }
        public static decimal GetProximoCodigo(string Tabela, string Campo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format("SELECT COALESCE(MAX(CAST({0} AS NUMERIC)), '0') FROM {1}", Campo, Tabela);


                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 1;

                return Convert.ToDecimal(oSQL.dtDados.Rows[0][0]);
            }
        }

        public static bool ExisteTributoVigenteProduto(decimal IDProduto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1
                              FROM PRODUTO
                                INNER JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM
                                               AND NCM.TIPO = 0
                                              -- AND COALESCE(PRODUTO.EXTIPI::NUMERIC(2), -1) = COALESCE(NCM.EX, -1)
                                               AND CONVERT(DATE, GETDATE()) BETWEEN NCM.VIGENCIAINICIO AND NCM.VIGENCIAFIM) 
                             WHERE PRODUTO.IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Produto GetProdutoPorCodigoEFornecedor(string CProd, decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT P.* 
                              FROM PRODUTO P
                               INNER JOIN PRODUTOFORNECEDOR ON (P.IDPRODUTO = PRODUTOFORNECEDOR.IDPRODUTO)
                             WHERE PRODUTOFORNECEDOR.CPROD = @CPROD
                              AND (PRODUTOFORNECEDOR.IDFORNECEDOR = @IDFORNECEDOR)";
                oSQL.ParamByName["CPROD"] = CProd;
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Produto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


        public static Produto GetProdutoPorCodigoEFornecedorNOVO(string CProd, decimal IDFornecedor)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT P.* 
                              FROM PRODUTO P
                               INNER JOIN CONVERSAOUNIDADEDEMEDIDA ON (P.IDPRODUTO = CONVERSAOUNIDADEDEMEDIDA.IDPRODUTO)
                             WHERE CONVERSAOUNIDADEDEMEDIDA.CODIGOPRODUTOFORNECEDOR = @CPROD
                              AND (CONVERSAOUNIDADEDEMEDIDA.IDFORNECEDOR = @IDFORNECEDOR)";
                oSQL.ParamByName["CPROD"] = CProd;
                oSQL.ParamByName["IDFORNECEDOR"] = IDFornecedor;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Produto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


        public static Produto GetProdutoPorEAN(string EAN)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT P.* FROM PRODUTO P WHERE P.EAN = @EAN";
                oSQL.ParamByName["EAN"] = EAN;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Produto>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetProdutosPorNCM(string Descricao, decimal NCM)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                                  PRODUTO.CODIGO,
                                                  PRODUTO.EAN AS CODIGODEBARRAS,
                                                  PRODUTO.DESCRICAO,
                                                  MARCA.DESCRICAO AS MARCA,
                                                  UNIDADEDEMEDIDA.DESCRICAO+' ('+UNIDADEDEMEDIDA.SIGLA+')' AS UNIDADEDEMEDIDA,
                                                  UNIDADEDEMEDIDA.SIGLA AS UNIDADEDEMEDIDASIGLA,
                                                  PRODUTO.VALORVENDA AS PRECOVENDA,
                                                  cast(NCM.CODIGO as varchar)+' - '+NCM.DESCRICAO AS NCM,
                                                  PRODUTO.EXTIPI
                                             FROM PRODUTO
                                               INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                               INNER JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                                                LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                           WHERE (UPPER(PRODUTO.DESCRICAO) LIKE '%%' OR UPPER(CAST(PRODUTO.CODIGO AS VARCHAR)) LIKE '%%' OR UPPER(CAST(PRODUTO.EAN AS VARCHAR)) LIKE '%%')
                                             AND COALESCE(PRODUTO.ATIVO, 0) = 1
                                           ORDER BY PRODUTO.DESCRICAO, PRODUTO.EAN", Descricao.ToUpper());
                oSQL.ParamByName["NCM"] = NCM;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return oSQL.dtDados;
            }
        }

        public static bool AtualizarValorCusto(decimal IDProduto, decimal ValorCusto)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE PRODUTO SET VALORCUSTO = @VALORCUSTO WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.ParamByName["VALORCUSTO"] = ValorCusto;
                return oSQL.ExecSQL() == 1;
            }
        }


        public static bool AtualizarRegraImpostoNFCE(decimal IDProduto, decimal? IdIntegracaoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE PRODUTO SET IDINTEGRACAOFISCALNFCE = @IDINTEGRACAOFISCAL WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.ParamByName["IDINTEGRACAOFISCAL"] = IdIntegracaoFiscal;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool AtualizarRegraImpostoNFe(decimal IDProduto, decimal? IdIntegracaoFiscal)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE PRODUTO SET IDINTEGRACAOFISCALNFE = @IDINTEGRACAOFISCAL WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.ParamByName["IDINTEGRACAOFISCAL"] = IdIntegracaoFiscal;
                return oSQL.ExecSQL() == 1;
            }
        }



        public static bool AtualizarValorVenda(decimal IDProduto, decimal ValorVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE PRODUTO SET VALORVENDA = @VALORVENDA WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.ParamByName["VALORVENDA"] = ValorVenda;
                return oSQL.ExecSQL() == 1;
            }
        }



        public static bool AtualizarSaldoEstoque(decimal IDProduto, decimal Estoque)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "UPDATE PRODUTO SET SALDOESTOQUE = @SALDOESTOQUE WHERE IDPRODUTO = @IDPRODUTO";
                oSQL.ParamByName["IDPRODUTO"] = IDProduto;
                oSQL.ParamByName["SALDOESTOQUE"] = Estoque;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetProdutosParaInentario(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = string.Format(@"SELECT DISTINCT PRODUTO.IDPRODUTO,
                                                  PRODUTO.CODIGO,
                                                  PRODUTO.EAN AS CODIGODEBARRAS,
                                                  PRODUTO.DESCRICAO,
                                                  MARCA.DESCRICAO AS MARCA,
                                                  UNIDADEDEMEDIDA.DESCRICAO+' ('+UNIDADEDEMEDIDA.SIGLA+')' AS UNIDADEDEMEDIDA,
                                                  UNIDADEDEMEDIDA.SIGLA AS UNIDADEDEMEDIDASIGLA,
                                                  PRODUTO.VALORVENDA AS PRECOVENDA,
                                                  cast(NCM.CODIGO as varchar)+' - '+NCM.DESCRICAO AS NCM,
                                                  PRODUTO.EXTIPI
                                             FROM PRODUTO
                                               INNER JOIN UNIDADEDEMEDIDA ON (PRODUTO.IDUNIDADEDEMEDIDA = UNIDADEDEMEDIDA.IDUNIDADEDEMEDIDA)
                                               INNER JOIN NCM ON (PRODUTO.IDNCM = NCM.IDNCM)
                                                LEFT JOIN MARCA ON (PRODUTO.IDMARCA = MARCA.IDMARCA)
                                           WHERE (UPPER(PRODUTO.DESCRICAO) LIKE '%{0}%' OR UPPER(CAST(PRODUTO.CODIGO AS VARCHAR)) LIKE '%{0}%' OR UPPER(CAST(PRODUTO.EAN AS VARCHAR)) LIKE '%{0}%')
                                             AND COALESCE(PRODUTO.ATIVO, 0) = 1
                                           ORDER BY PRODUTO.DESCRICAO, PRODUTO.EAN", Descricao.ToUpper());
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return oSQL.dtDados;
            }
        }
        public static Image ConvertByteToImage(byte[] pic)
        {
            if (pic != null)
            {
                try
                {
                    MemoryStream ImageDataStream = new MemoryStream();
                    ImageDataStream.Write(pic, 0, pic.Length);
                    ImageDataStream.Position = 0;
                    pic = System.Text.UnicodeEncoding.Convert(Encoding.Unicode, Encoding.Default, pic);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ImageDataStream);
                    return img;
                }
                catch
                {
                    return null;
                }

            }
            else return null;
        }
        public static byte[] ConvertImageToByte(System.Drawing.Image foto)
        {
            if (foto == null)
                return null;
            Bitmap bmp = new Bitmap(foto);
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            stream.Flush();
            byte[] pic = stream.ToArray();
            return pic;
        }
        public static string AdicionarArquivo(Stream fileStream)
        {
            try
            {
                CloudinaryDotNet.Account conta = new CloudinaryDotNet.Account("onedesenvolvimento", "488424732444216", "4WXZu2YXtfejB3uImKkeyeten7E");

                CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(conta);

                string urlDaImagem = string.Empty;

                string fileName = string.Format("{0}.jpg", DateTime.Now.AddHours(3).ToFileTime().ToString());

                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(fileName, fileStream),
                    Transformation = new Transformation().Crop("fill").Width(120).Height(120)
                };
                ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
                urlDaImagem = uploadResult.Uri.AbsoluteUri;
                return urlDaImagem;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static bool ExisteCodigoDeBarras(decimal idproduto,  string codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PRODUTO WHERE EAN = @EAN AND IDPRODUTO != @IDPRODUTO ";
                oSQL.ParamByName["IDPRODUTO"] = idproduto;
                oSQL.ParamByName["EAN"] = codigo;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static bool ExisteCodigoDeBarras(string codigo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PRODUTO WHERE EAN = @EAN";
                oSQL.ParamByName["EAN"] = codigo;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static decimal? GetCount()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT COUNT(*) FROM PRODUTO";
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return Convert.ToDecimal(oSQL.dtDados.Rows[0][0]);
            }
        }
    }
}