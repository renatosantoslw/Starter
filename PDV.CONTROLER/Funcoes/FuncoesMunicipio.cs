using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Enum;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesMunicipio
    {
        public static int ConverterUF(string texto)
        {
            switch (texto)
            {
                case "RO":
                    return 11;
                    break;
                case "AC":
                    return 12;
                    break;
                case "AM":
                    return 13;
                    break;
                case "RR":
                    return 14;
                    break;
                case "PA":
                    return 15;
                    break;
                case "AP":
                    return 16;
                    break;
                case "TO":
                    return 17;
                    break;
                case "MA":
                    return 21;
                    break;
                case "PI":
                    return 22;
                    break;
                case "CE":
                    return 23;
                    break;
                case "RN":
                    return 24;
                    break;
                case "PB":
                    return 25;
                    break;
                case "PE":
                    return 26;
                    break;
                case "AL":
                    return 27;
                    break;
                case "SE":
                    return 28;
                    break;
                case "BA":
                    return 29;
                    break;
                case "MG":
                    return 31;
                    break;
                case "ES":
                    return 32;
                    break;
                case "RJ":
                    return 33;
                    break;
                case "SP":
                    return 35;
                    break;
                case "PR":
                    return 41;
                    break;
                case "SC":
                    return 42;
                    break;
                case "RS":
                    return 43;
                    break;
                case "MS":
                    return 50;
                    break;
                case "MT":
                    return 51;
                    break;
                case "GO":
                    return 52;
                    break;
                case "DF":
                    return 53;
                    break;
                case "AN":
                    return 91;
                    break;
                case "EX":
                    return 99;
                    break;

            }
            return 11;
        }
        public static Municipio GetMunicipio(decimal IDMunicipio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT MUNICIPIO.IDMUNICIPIO,
                                    MUNICIPIO.DESCRICAO,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA,
                                    MUNICIPIO.CODIGOIBGE
                               FROM MUNICIPIO
                                 INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                               WHERE MUNICIPIO.IDMUNICIPIO = @IDMUNICIPIO";
                oSQL.ParamByName["IDMUNICIPIO"] = IDMunicipio;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Municipio>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static Municipio GetMunicipioDescricao(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT MUNICIPIO.IDMUNICIPIO,
                                    MUNICIPIO.DESCRICAO,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA,
                                    MUNICIPIO.CODIGOIBGE
                               FROM MUNICIPIO
                                 INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                               WHERE MUNICIPIO.DESCRICAO like '@IDMUNICIPIO'";
                oSQL.ParamByName["DESCRICAO"] = Descricao;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Municipio>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }



        public static Municipio GetMunicipioPorCodigo(decimal CodigoIBGE)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT MUNICIPIO.IDMUNICIPIO,
                                    MUNICIPIO.DESCRICAO,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA,
                                    MUNICIPIO.CODIGOIBGE
                               FROM MUNICIPIO
                                 INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                               WHERE MUNICIPIO.CODIGOIBGE = @CODIGOIBGE";
                oSQL.ParamByName["CODIGOIBGE"] = CodigoIBGE;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Municipio>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetMunicipios(string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                List<string> Filtros = new List<string>();
                if (!string.IsNullOrEmpty(Descricao))
                    Filtros.Add(string.Format("(UPPER(MUNICIPIO.DESCRICAO) LIKE UPPER('%{0}%'))", Descricao));

                oSQL.SQL = string.Format(
                           @"SELECT MUNICIPIO.IDMUNICIPIO,
                                    MUNICIPIO.DESCRICAO,
                                    UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA,
                                    UNIDADEFEDERATIVA.DESCRICAO AS UNIDADEFEDERATIVA
                             FROM MUNICIPIO
                               INNER JOIN UNIDADEFEDERATIVA ON (MUNICIPIO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                             {0} ORDER BY MUNICIPIO.DESCRICAO, UNIDADEFEDERATIVA.DESCRICAO", Filtros.Count > 0 ? "WHERE " + string.Join(" AND ", Filtros.ToArray()) : string.Empty);
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool Salvar(Municipio _Municipio, TipoOperacao Op)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Op)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = "INSERT INTO MUNICIPIO (IDMUNICIPIO, IDUNIDADEFEDERATIVA, DESCRICAO, CODIGOIBGE) VALUES (@IDMUNICIPIO, @IDUNIDADEFEDERATIVA, @DESCRICAO, @CODIGOIBGE)";
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE MUNICIPIO
                                        SET DESCRICAO = @DESCRICAO,
                                            IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA,
                                            CODIGOIBGE = @CODIGOIBGE
                                      WHERE IDMUNICIPIO = @IDMUNICIPIO";
                        break;
                }
                oSQL.ParamByName["IDMUNICIPIO"] = _Municipio.IDMunicipio;
                oSQL.ParamByName["DESCRICAO"] = _Municipio.Descricao;
                oSQL.ParamByName["CODIGOIBGE"] = _Municipio.CodigoIBGE;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = _Municipio.IDUnidadeFederativa;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDMunicipio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM MUNICIPIO WHERE IDMUNICIPIO = @IDMUNICIPIO";
                oSQL.ParamByName["IDMUNICIPIO"] = IDMunicipio;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool Remover(decimal IDMunicipio)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM ENDERECO WHERE IDMUNICIPIO = @IDMUNICIPIO";
                oSQL.ParamByName["IDMUNICIPIO"] = IDMunicipio;
                oSQL.Open();
                if (!oSQL.IsEmpty)
                    throw new Exception("O Município tem vinculo com Endereço e não pode ser remvido.");

                oSQL.ClearAll();
                oSQL.SQL = @"DELETE FROM MUNICIPIO WHERE IDMUNICIPIO = @IDMUNICIPIO";
                oSQL.ParamByName["IDMUNICIPIO"] = IDMunicipio;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static List<Municipio> GetMunicipios(decimal IDUnidadeFederativa)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDMUNICIPIO, 
                                    IDUNIDADEFEDERATIVA,
                                    DESCRICAO,
                                    CODIGOIBGE
                             FROM MUNICIPIO 
                               WHERE IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA";
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = IDUnidadeFederativa;
                oSQL.Open();
                return new DataTableParser<Municipio>().ParseDataTable(oSQL.dtDados);
            }
        }
    }
}
