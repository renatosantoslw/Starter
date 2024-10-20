using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesMarca
    {
        public static bool Existe(decimal IDMarca)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MARCA WHERE IDMARCA = @IDMARCA";
                oSQL.ParamByName["IDMARCA"] = IDMarca;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static bool Existe(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM MARCA WHERE DESCRICAO = @DESCRICAO";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }
        public static Marca GetMarca(decimal IDMarca)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMARCA,
                                    CODIGO,
                                    DESCRICAO,
                                    MARCADEVEICULO,
                                    MARCADEPRODUTO
                               FROM MARCA
                             WHERE IDMARCA = @IDMARCA";
                oSQL.ParamByName["IDMARCA"] = IDMarca;
                oSQL.Open();
                return EntityUtil<Marca>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
        public static Marca GetMarca(string descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 IDMARCA,
                                    CODIGO,
                                    DESCRICAO,
                                    MARCADEVEICULO,
                                    MARCADEPRODUTO
                               FROM MARCA
                             WHERE DESCRICAO = @DESCRICAO ";
                oSQL.ParamByName["DESCRICAO"] = descricao;
                oSQL.Open();
                return EntityUtil<Marca>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetMarcas(string Codigo, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Codigo))
                    Filtros.Add(string.Format("(UPPER(CODIGO) LIKE UPPER('%{0}%'))", Codigo));

                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT IDMARCA,
                                    CODIGO,
                                    DESCRICAO,
                                    MARCADEVEICULO,
                                    MARCADEPRODUTO
                               FROM MARCA {0}
                             ORDER BY DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static List<Marca> GetMarcas()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMARCA,
                                    CODIGO,
                                    DESCRICAO,
                                    MARCADEVEICULO,
                                    MARCADEPRODUTO
                               FROM MARCA
                             ORDER BY CODIGO, DESCRICAO";
                oSQL.Open();
                return new DataTableParser<Marca>().ParseDataTable(oSQL.dtDados);
            }
        }

       
        public static List<Marca> GetMarcasDeVeiculo()
        {
            //filtra a consulta por marcas de veículo            
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMARCA,
                                    CODIGO,
                                    DESCRICAO,
                                    MARCADEVEICULO,
                                    MARCADEPRODUTO
                               FROM MARCA
                                WHERE MARCADEVEICULO = true
                             ORDER BY CODIGO, DESCRICAO";
                oSQL.Open();
                return new DataTableParser<Marca>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static List<Marca> GetMarcasDeProduto()
        {
            //filtra a consulta por marcas de produto            
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMARCA,
                                    CODIGO,
                                    DESCRICAO,
                                    MARCADEVEICULO,
                                    MARCADEPRODUTO
                               FROM MARCA
                                WHERE MARCADEPRODUTO IS NOT NULL
                             ORDER BY CODIGO, DESCRICAO";
                oSQL.Open();
                return new DataTableParser<Marca>().ParseDataTable(oSQL.dtDados);
            }
        }
        public static bool Salvar(Marca _Marca, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO MARCA (IDMARCA, CODIGO, DESCRICAO, MARCADEVEICULO, MARCADEPRODUTO ) 
                                    VALUES (@IDMARCA, @CODIGO, @DESCRICAO, @MARCADEVEICULO, @MARCADEPRODUTO)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE MARCA
                                      SET CODIGO = @CODIGO,
                                          DESCRICAO = @DESCRICAO,
                                          MARCADEVEICULO = @MARCADEVEICULO,
                                          MARCADEPRODUTO = @MARCADEPRODUTO
                                     WHERE IDMARCA = @IDMARCA";
                        break;
                }
                oSQL.ParamByName["IDMARCA"] = _Marca.IDMarca;
                oSQL.ParamByName["CODIGO"] = _Marca.Codigo;
                oSQL.ParamByName["DESCRICAO"] = _Marca.Descricao;
                oSQL.ParamByName["MARCADEVEICULO"] = _Marca.MarcaDeVeiculo;
                oSQL.ParamByName["MARCADEPRODUTO"] = _Marca.MarcaDeProduto;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDMarca)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM PRODUTO WHERE IDMARCA = @IDMARCA";
                oSQL.ParamByName["IDMARCA"] = IDMarca;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("A Marca tem vínculo com produto e não pode ser removido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM MARCA WHERE IDMARCA = @IDMARCA";
                oSQL.ParamByName["IDMARCA"] = IDMarca;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}
