using PDV.DAO.DB.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.CONTROLER.FuncoesRelatorios
{
    public class FuncoesCabecalho
    {
        public static DataTable GetDadosEmitente()
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT TOP 1 EMITENTE.IDEMITENTE,
                                    EMITENTE.NOMEFANTASIA,
                                    EMITENTE.RAZAOSOCIAL,
                                    EMITENTE.CNPJ,
                                    EMITENTE.INSCRICAOESTADUAL,
                                    EMITENTE.LOGOMARCA,
                                    EMITENTE.ULTIMALINHACABECALHO,
                                    EMITENTE.FONE,
                             
                                    ENDERECO.LOGRADOURO+', '+ CAST(ENDERECO.NUMERO AS VARCHAR) AS LOGRADOURO,
                                    ENDERECO.BAIRRO,
                                    MUNICIPIO.DESCRICAO AS MUNICIPIO,
                                    UNIDADEFEDERATIVA.SIGLA,
                                    ENDERECO.CEP,
                                    CURRENT_TIMESTAMP AS DATAEMISSAO                             
                               FROM EMITENTE
                                 INNER JOIN ENDERECO ON (EMITENTE.IDENDERECO = ENDERECO.IDENDERECO)
                                 INNER JOIN UNIDADEFEDERATIVA ON (ENDERECO.IDUNIDADEFEDERATIVA = UNIDADEFEDERATIVA.IDUNIDADEFEDERATIVA)
                                 INNER JOIN MUNICIPIO ON (ENDERECO.IDMUNICIPIO = MUNICIPIO.IDMUNICIPIO)
                             ";
                oSQL.Open();
                return oSQL.dtDados;
            }
        }
    }
}
