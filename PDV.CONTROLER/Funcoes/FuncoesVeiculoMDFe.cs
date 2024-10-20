using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades.MDFe;
using PDV.DAO.Enum;
using System.Collections.Generic;
using System.Data;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesVeiculoMDFe
    {
        public static List<Veiculo> GetVeiculos()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDVEICULO,
PLACA,
MODELO,
RENAVAM,
TARAEMKG,
CAPACIDADEEMKG,
CAPACIDADEEMM3,
ANOFABRICACAO,
ANOMODELO,
TIPOPROPRIEDADE,
TIPOVEICULO,
TIPORODADO,
TIPOCARROCERIA,
IDMARCA,
ATIVO,
VEICULOEMUSOMDFE,
IDUNIDADEFEDERATIVA FROM VEICULO";
                oSQL.Open();
                return new DataTableParser<Veiculo>().ParseDataTable(oSQL.dtDados);
            }
        }

        public static bool Salvar(Veiculo veiculo, TipoOperacao Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Tipo)
                {
                    case TipoOperacao.INSERT:
                        /*
                         idveiculo, placa, certificadopropriedade, modelo, renavam, taraemkg, 
            capacidadeemkg, capacidadeemm3, anofabricacao, anomodelo, tipopropriedade, 
            tipoveiculo, tiporodado, tipocarroceria, idmarca, ativo, veiculoemusomdfe, 
            idunidadefederativa*/
                        oSQL.SQL = @"INSERT INTO VEICULO(IDVEICULO, PLACA,  MODELO, RENAVAM, TARAEMKG, 
                                                         CAPACIDADEEMKG, CAPACIDADEEMM3, ANOFABRICACAO, ANOMODELO, 
                                                         TIPOPROPRIEDADE, TIPOVEICULO, TIPORODADO, TIPOCARROCERIA, IDMARCA, 
                                                         ATIVO, VEICULOEMUSOMDFE, IDUNIDADEFEDERATIVA)
                                    VALUES 
                                       (@IDVEICULO, @PLACA, @MODELO, @RENAVAM, @TARAEMKG,
                                        @CAPACIDADEEMKG, @CAPACIDADEEMM3, @ANOFABRICACAO, @ANOMODELO, @TIPOPROPRIEDADE, 
                                        @TIPOVEICULO, @TIPORODADO, @TIPOCARROCERIA, @IDMARCA, @ATIVO, @VEICULOEMUSOMDFE, @IDUNIDADEFEDERATIVA)";
                        oSQL.ParamByName["VEICULOEMUSOMDFE"] = 0;
                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE VEICULO
                                       SET PLACA = @PLACA, 
                                           MODELO = @MODELO, 
                                           RENAVAM = @RENAVAM, 
                                           TARAEMKG = @TARAEMKG, 
                                           CAPACIDADEEMKG = @CAPACIDADEEMKG, 
                                           CAPACIDADEEMM3 = @CAPACIDADEEMM3, 
                                           ANOFABRICACAO = @ANOFABRICACAO, 
                                           ANOMODELO = @ANOMODELO,  
                                           TIPOPROPRIEDADE = @TIPOPROPRIEDADE, 
                                           TIPOVEICULO = @TIPOVEICULO, 
                                           TIPORODADO = @TIPORODADO, 
                                           TIPOCARROCERIA = @TIPOCARROCERIA, 
                                           IDMARCA = @IDMARCA, 
                                           ATIVO = @ATIVO, 
                                           IDUNIDADEFEDERATIVA = @IDUNIDADEFEDERATIVA
                                        WHERE IDVEICULO = @IDVEICULO";
                        break;
                }
                oSQL.ParamByName["IDVEICULO"] = veiculo.IDVeiculo;
                oSQL.ParamByName["PLACA"] = veiculo.Placa;
                oSQL.ParamByName["MODELO"] = veiculo.Modelo;
                oSQL.ParamByName["RENAVAM"] = veiculo.Renavam;
                oSQL.ParamByName["TARAEMKG"] = veiculo.TaraEmKG;
                oSQL.ParamByName["CAPACIDADEEMKG"] = veiculo.CapacidadeEmKG;
                oSQL.ParamByName["CAPACIDADEEMM3"] = veiculo.CapacidadeEmM3;
                oSQL.ParamByName["ANOFABRICACAO"] = veiculo.AnoFabricacao;
                oSQL.ParamByName["ANOMODELO"] = veiculo.AnoModelo;
                oSQL.ParamByName["TIPOPROPRIEDADE"] = veiculo.TipoPropriedade;
                oSQL.ParamByName["TIPOVEICULO"] = veiculo.TipoVeiculo;
                oSQL.ParamByName["TIPORODADO"] = veiculo.TipoRodado;
                oSQL.ParamByName["TIPOCARROCERIA"] = veiculo.TipoCarroceria;
                oSQL.ParamByName["IDMARCA"] = veiculo.IDMarca;
                oSQL.ParamByName["ATIVO"] = veiculo.Ativo;
                oSQL.ParamByName["IDUNIDADEFEDERATIVA"] = veiculo.IDUnidadefederativa;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Remover(decimal IDVeiculo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM VEICULO WHERE IDVEICULO = @IDVEICULO";
                oSQL.ParamByName["IDVEICULO"] = IDVeiculo;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(decimal IDVeiculo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT 1 FROM VEICULO WHERE IDVEICULO = @IDVEICULO";
                oSQL.ParamByName["IDVEICULO"] = IDVeiculo;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Veiculo GetVeiculo(decimal IDVeiculo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDVEICULO,
PLACA,
MODELO,
RENAVAM,
TARAEMKG,
CAPACIDADEEMKG,
CAPACIDADEEMM3,
ANOFABRICACAO,
ANOMODELO,
TIPOPROPRIEDADE,
TIPOVEICULO,
TIPORODADO,
TIPOCARROCERIA,
IDMARCA,
ATIVO,
VEICULOEMUSOMDFE,
IDUNIDADEFEDERATIVA FROM VEICULO WHERE IDVEICULO = @IDVEICULO";
                oSQL.ParamByName["IDVEICULO"] = IDVeiculo;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Veiculo>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static DataTable GetVeiculos(string PLACA, string Descricao)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT IDVEICULO,
                                     PLACA,
                                     MODELO, 
                                     ATIVO
                             FROM VEICULO
                               WHERE UPPER(PLACA) LIKE UPPER('%{PLACA}%')
                                AND UPPER(MODELO) LIKE UPPER('%{Descricao}%')";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static DataTable GetVeiculoEProprietarioMDFe(decimal IDMDFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT VEICULOTRACAOMDFE.IDVEICULO,
                                    VEICULOTRACAOMDFE.IDMDFE,
                                    VEICULOTRACAOMDFE.IDPROPRIETARIOVEICULOMDFE
                               FROM VEICULOTRACAOMDFE
                             WHERE VEICULOTRACAOMDFE.IDMDFE = @IDMDFE";
                oSQL.ParamByName["IDMDFE"] = IDMDFe;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
