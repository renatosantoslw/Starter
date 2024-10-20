using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesRomaneio
    {
        public static bool SalvarRomaneio(Romaneio _Romaneio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ROMANEIO WHERE IDROMANEIO = @IDROMANEIO";
                oSQL.ParamByName["IDROMANEIO"] = _Romaneio.IDRomaneio;
                oSQL.Open();
                bool ExisteVenda = !oSQL.IsEmpty;
                oSQL.ClearAll();

                if (!ExisteVenda)
                    oSQL.SQL = @"INSERT INTO ROMANEIO(
                                         IDROMANEIO, EMPRESA, STATUS, DATAINCLUSAO, IDUSUARIO, TRANSPORTADORAID, TRANSPORTADORANOME, 
                                         VEICULOID, VEICULODESCRICAO, MOTORISTANOME, MOTORISTAID, TOTALITENS, VALORTOTAL, OBSERVACAO)
                                 VALUES (@IDROMANEIO, @EMPRESA, @STATUS, @DATAINCLUSAO, @IDUSUARIO, @TRANSPORTADORAID, @TRANSPORTADORANOME, 
                                         @VEICULOID, @VEICULODESCRICAO, @MOTORISTANOME, @MOTORISTAID, @TOTALITENS, @VALORTOTAL, @OBSERVACAO)";
                else
                    oSQL.SQL = @"UPDATE ROMANEIO
                                   SET  IDROMANEIO         = @IDROMANEIO,
                                        EMPRESA            = @EMPRESA,
                                        STATUS             = @STATUS,
                                        DATAINCLUSAO       = @DATAINCLUSAO,
                                        IDUSUARIO          = @IDUSUARIO,
                                        TRANSPORTADORAID   = @TRANSPORTADORAID,
                                        TRANSPORTADORANOME = @TRANSPORTADORANOME,
                                        VEICULOID          = @VEICULOID,
                                        VEICULODESCRICAO   = @VEICULODESCRICAO,
                                        MOTORISTANOME      = @MOTORISTANOME,
                                        MOTORISTAID        = @MOTORISTAID,
                                        TOTALITENS         = @TOTALITENS,
                                        VALORTOTAL         = @VALORTOTAL,
                                        OBSERVACAO         = @OBSERVACAO
                                   WHERE IDROMANEIO = @IDROMANEIO";
                oSQL.ParamByName["IDROMANEIO"] = _Romaneio.IDRomaneio;
                oSQL.ParamByName["EMPRESA"] = _Romaneio.Empresa;
                oSQL.ParamByName["STATUS"] = int.Parse(_Romaneio.Status);
                oSQL.ParamByName["DATAINCLUSAO"] = _Romaneio.DataInclusao;
                oSQL.ParamByName["IDUSUARIO"] = _Romaneio.IDUsuario;
                oSQL.ParamByName["TRANSPORTADORAID"] = _Romaneio.TransportadoraID;
                oSQL.ParamByName["TRANSPORTADORANOME"] = _Romaneio.TransportadoraNome;
                oSQL.ParamByName["VEICULODESCRICAO"] = _Romaneio.VeiculoDescricao;
                oSQL.ParamByName["VEICULOID"] = _Romaneio.VeiculoID;
                oSQL.ParamByName["VEICULODESCRICAO"] = _Romaneio.VeiculoDescricao;
                oSQL.ParamByName["MOTORISTANOME"] = _Romaneio.MotoristaNome;
                oSQL.ParamByName["MOTORISTAID"] = _Romaneio.MotoristaID;
                oSQL.ParamByName["TOTALITENS"] = _Romaneio.TotalItens;
                oSQL.ParamByName["VALORTOTAL"] = _Romaneio.ValorTotal;
                oSQL.ParamByName["OBSERVACAO"] = _Romaneio.Observacao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static DataTable GetRomaneios()
        {
            //0-Aberto 1-Fechado 2-Cancelado 3 Entregue
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                                        IDROMANEIO         ,
                                        EMPRESA           ,
                                        CASE 
                                        WHEN STATUS = 0 THEN 'ABERTO' 
                                        WHEN STATUS = 1 THEN 'FECHADO' 
                                        WHEN STATUS = 2 THEN 'CANCELADO' 
                                        WHEN STATUS = 3 THEN 'ENTREGUE'  
                                        END     AS STATUS ,
                                        DATAINCLUSAO       ,
                                        IDUSUARIO          ,
                                        TRANSPORTADORAID   ,
                                        TRANSPORTADORANOME ,
                                        VEICULOID          ,
                                        VEICULODESCRICAO   ,
                                        MOTORISTANOME     ,
                                        MOTORISTAID       ,
                                        TOTALITENS        ,
                                        VALORTOTAL        ,
                                        OBSERVACAO         
                            FROM ROMANEIO
                             ORDER BY IDROMANEIO DESC";
                oSQL.Open();

                return oSQL.dtDados;
            }
        }

        public static Romaneio GetRomaneioPorID(decimal IDROMANEIO)
        {
            //0-Aberto 1-Fechado 2-Cancelado 3 Entregue
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                                        IDROMANEIO         ,
                                        EMPRESA           ,
                                        CASE 
                                        WHEN STATUS = 0 THEN 'ABERTO' 
                                        WHEN STATUS = 1 THEN 'FECHADO' 
                                        WHEN STATUS = 2 THEN 'CANCELADO' 
                                        WHEN STATUS = 3 THEN 'ENTREGUE'  
                                        END     AS STATUS ,
                                        DATAINCLUSAO       ,
                                        IDUSUARIO          ,
                                        TRANSPORTADORAID   ,
                                        TRANSPORTADORANOME ,
                                        VEICULOID          ,
                                        VEICULODESCRICAO   ,
                                        MOTORISTANOME     ,
                                        MOTORISTAID       ,
                                        TOTALITENS        ,
                                        VALORTOTAL        ,
                                        case when OBSERVACAO is null then '.' end as    OBSERVACAO      
                            FROM ROMANEIO
                            WHERE IDROMANEIO = @IDROMANEIO
                             ORDER BY IDROMANEIO DESC";
                oSQL.ParamByName["IDROMANEIO"] = IDROMANEIO;
                oSQL.Open();

                if (oSQL.IsEmpty)
                    return null;
                return EntityUtil<Romaneio>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }


        public static DataTable GetRomaneiosVendas(decimal IDROMANEIO)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 
                                        RV.IDROMANEIOVENDA         ,
                                        RV.DATAFATURAMENTO      ,
                                        RV.IDROMANEIO           ,
                                        RV.IDVENDA               ,
                                        RV.VALORTOTAL           ,
                                        CLIENTE              ,
                                        CONT.TELEFONE AS TELEFONE,
                                        TOTALITENS           ,
                                        ENDE.LOGRADOURO AS LOGRADOURO,
                                        ENDE.NUMERO AS NUMERO, 
                                        ENDE.CEP AS CEP,
                                        ENDE.BAIRRO AS BAIRRO, 
                                        MUN.DESCRICAO AS CIDADE,
                                        UF.SIGLA AS UF,
                                        CASE WHEN RV.STATUS = 0  THEN 'ABERTO' WHEN  RV.STATUS = 1 THEN  'ENTREGUE'  WHEN RV.STATUS = 2 THEN 'CANCELADO' END as STATUS,
                                        RV.OBSERVACAO            
                            FROM ROMANEIOVENDA RV
							     LEFT JOIN VENDA V ON V.IDVENDA = RV.IDVENDA
                                 LEFT JOIN CLIENTE CLI ON CLI.IDCLIENTE = V.IDCLIENTE
                                 LEFT JOIN ENDERECO ENDE ON ENDE.IDENDERECO = CLI.IDENDERECO 
                                 LEFT JOIN MUNICIPIO MUN ON MUN.IDMUNICIPIO = ENDE.IDMUNICIPIO
                                 LEFT JOIN UNIDADEFEDERATIVA UF ON UF.IDUNIDADEFEDERATIVA = ENDE.IDUNIDADEFEDERATIVA
                                 LEFT JOIN CONTATO CONT ON CONT.IDCONTATO = CLI.IDCONTATO
                            WHERE RV.IDROMANEIO = @IDROMANEIO
                            ORDER BY MUN.DESCRICAO DESC";
                oSQL.ParamByName["IDROMANEIO"] = IDROMANEIO;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;
                return oSQL.dtDados;
            }
        }

        public static bool SalvarRomaneioItens(RomaneioVenda _ROMANEIOVENDAVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM ROMANEIOVENDA WHERE IDROMANEIOVENDA = @IDROMANEIOVENDA";
                oSQL.ParamByName["IDROMANEIOVENDA"] = _ROMANEIOVENDAVenda.IDRomaneioVenda;
                oSQL.Open();
                bool ExisteVenda = !oSQL.IsEmpty;
                oSQL.ClearAll();

                if (!ExisteVenda)
                    oSQL.SQL = @"INSERT INTO ROMANEIOVENDA(
                                         IDROMANEIOVENDA, DATAFATURAMENTO, IDROMANEIO, IDVENDA, VALORTOTAL, CLIENTE, TOTALITENS,STATUS, OBSERVACAO)
                                 VALUES (@IDROMANEIOVENDA,@DATAFATURAMENTO,@IDROMANEIO,@IDVENDA,@VALORTOTAL,@CLIENTE,@TOTALITENS,@STATUS,@OBSERVACAO)";
                else
                    oSQL.SQL = @"UPDATE ROMANEIOVENDA
                                 IDROMANEIOVENDA, DATAFATURAMENTO, IDROMANEIO, IDVENDA, VALORTOTAL, CLIENTE, TOTALITENS, OBSERVACAO
                                 SET  IDROMANEIOVENDA         = @IDROMANEIOVENDA,
                                        DATAFATURAMENTO       = @DATAFATURAMENTO,
                                        IDROMANEIO            = @IDROMANEIO,
                                        IDVENDA               = @IDVENDA,
                                        VALORTOTAL            = @VALORTOTAL,
                                        CLIENTE               = @CLIENTE,
                                        TOTALITENS            = @TOTALITENS,
                                        STATUS = @STATUS,
                                        OBSERVACAO            = @OBSERVACAO
                                   WHERE IDROMANEIOVENDA = @IDROMANEIOVENDA";
                oSQL.ParamByName["IDROMANEIOVENDA"] = _ROMANEIOVENDAVenda.IDRomaneioVenda;
                oSQL.ParamByName["DATAFATURAMENTO"] = _ROMANEIOVENDAVenda.DataFaturamento;
                oSQL.ParamByName["IDROMANEIO"] = _ROMANEIOVENDAVenda.IDRomaneio;
                oSQL.ParamByName["IDVENDA"] = _ROMANEIOVENDAVenda.IDVenda;
                oSQL.ParamByName["VALORTOTAL"] = _ROMANEIOVENDAVenda.ValorTotal;
                oSQL.ParamByName["CLIENTE"] = _ROMANEIOVENDAVenda.Cliente;
                oSQL.ParamByName["TOTALITENS"] = _ROMANEIOVENDAVenda.TotalItens;
                oSQL.ParamByName["OBSERVACAO"] = _ROMANEIOVENDAVenda.Observacao;
                oSQL.ParamByName["STATUS"] = _ROMANEIOVENDAVenda.Status;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static void RomaneioStatus(decimal idRomaneio, int Status)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //0-Aberto 1-Fechado 2-Cancelado 3 Entregue

                oSQL.SQL = @"UPDATE ROMANEIO
                                 SET  STATUS     = @STATUS
                                   WHERE IDROMANEIO = @IDROMANEIO";
                oSQL.ParamByName["IDROMANEIO"] = idRomaneio;
                oSQL.ParamByName["STATUS"] = Status;
                oSQL.ExecSQL();

                oSQL.ClearAll();

                if (Status == 2)
                {
                    oSQL.SQL = @"DELETE FROM ROMANEIOVENDA";
                    oSQL.ParamByName["IDROMANEIO"] = idRomaneio;
                    oSQL.ExecSQL();

                    oSQL.ClearAll();

                    oSQL.SQL = @"UPDATE VENDA SET ROMANEIO = null, IDROMANEIO = null
                            WHERE IDROMANEIO = @IDROMANEIO";
                    oSQL.ParamByName["IDROMANEIO"] = idRomaneio;
                    oSQL.ExecSQL();
                }
            }

        }

        public static void Excluir(decimal idRomaneio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //0-Aberto 1-Fechado 2-Cancelado 3 Entregue

                oSQL.SQL = @"DELETE FROM  ROMANEIO
                                   WHERE IDROMANEIO = @IDROMANEIO";
                oSQL.ParamByName["IDROMANEIO"] = idRomaneio;
                oSQL.ExecSQL();

                oSQL.ClearAll();

                oSQL.SQL = @"DELETE FROM ROMANEIOVENDA";
                oSQL.ParamByName["IDROMANEIO"] = idRomaneio;
                oSQL.ExecSQL();

                oSQL.ClearAll();

                oSQL.SQL = @"UPDATE VENDA SET ROMANEIO = null, IDROMANEIO = null
                            WHERE IDROMANEIO = @IDROMANEIO";
                oSQL.ParamByName["IDROMANEIO"] = idRomaneio;
                oSQL.ExecSQL();
            }
            }

        public static void AtualizarStatusRomaneioVenda(decimal IDRomaneioVenda, int Status)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"UPDATE ROMANEIOVENDA SET STATUS = @STATUS
                            WHERE IDROMANEIOVENDA = @IDROMANEIO";
                oSQL.ParamByName["IDROMANEIO"] = IDRomaneioVenda;
                oSQL.ParamByName["STATUS"] = Status;
                oSQL.ExecSQL();

            }
        }
    }
    }
