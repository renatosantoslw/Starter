using IntegradorZeusPDV.DB;
using IntegradorZeusPDV.DB.DB.Controller;
using IntegradorZeusPDV.DB.DB.Utils;
using IntegradorZeusPDV.MODEL.ClassesPDV;

namespace IntegradorZeusPDV.CONTROLLER.Funcoes
{
    public class FuncoesCliente
    {
        public static bool Salvar(Cliente Cli)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                if (!Existe(Cli.ChaveERP))
                {
                    oSQL.SQL = @"INSERT INTO CLIENTE 
                                    (IDCLIENTE, CPF, CNPJ, TIPODOCUMENTO, RAZAOSOCIAL, NOMEFANTASIA, NOME, ATIVO, CHAVEERP)
                                  VALUES 
                                    (@IDCLIENTE, @CPF, @CNPJ, @TIPODOCUMENTO, @RAZAOSOCIAL, @NOMEFANTASIA, @NOME, @ATIVO, @CHAVEERP)";
                    oSQL.ParamByName["IDCLIENTE"] = Sequence.GetNextID("CLIENTE", "IDCLIENTE");
                    oSQL.ParamByName["CPF"] = Cli.CPF;
                    oSQL.ParamByName["CNPJ"] = Cli.CNPJ;
                    oSQL.ParamByName["TIPODOCUMENTO"] = Cli.TipoDocumento;
                }
                else
                {
                    oSQL.SQL = @"UPDATE CLIENTE 
                                    SET RAZAOSOCIAL = @RAZAOSOCIAL,
                                        NOMEFANTASIA = @NOMEFANTASIA,
                                        NOME = @NOME,
                                        ATIVO = @ATIVO
                                 WHERE CHAVEERP = @CHAVEERP";
                }
                oSQL.ParamByName["RAZAOSOCIAL"] = Cli.RazaoSocial;
                oSQL.ParamByName["NOMEFANTASIA"] = Cli.NomeFantasia;
                oSQL.ParamByName["NOME"] = Cli.Nome;
                oSQL.ParamByName["ATIVO"] = Cli.Ativo;
                oSQL.ParamByName["CHAVEERP"] = Cli.ChaveERP;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Existe(string ChaveERP)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1 FROM CLIENTE WHERE CHAVEERP = @CHAVEERP";
                oSQL.ParamByName["CHAVEERP"] = ChaveERP;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static Cliente GetCliente(decimal IDCliente)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDCLIENTE,
                                    TIPODOCUMENTO,
                                    CNPJ,
                                    CPF,
                                    RAZAOSOCIAL,
                                    INSCRICAOESTADUAL,
                                    INSCRICAOMUNICIPAL,
                                    IDENDERECO,
                                    IDCONTATO,
                                    NOME,
                                    NOMEFANTASIA,
                                    CONSUMIDORFINAL,
                                    ESTRANGEIRO,
                                    DOCESTRANGEIRO,
                                    TIPOCONTRIBUINTE
                             FROM CLIENTE
                             WHERE IDCLIENTE = @IDCLIENTE";
                oSQL.ParamByName["IDCLIENTE"] = IDCliente;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<Cliente>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }
    }
}
