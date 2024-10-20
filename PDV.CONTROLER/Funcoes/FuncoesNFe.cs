using Newtonsoft.Json.Schema;
using PDV.DAO.Custom;
using PDV.DAO.DB.Controller;
using PDV.DAO.Entidades;
using PDV.DAO.Entidades.NFe;
using PDV.DAO.Enum;
using System.Linq;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesNFe
    {
        public static NFe GetNFe(decimal IDNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNFE,
IDCLIENTE,
IDTIPOATENDIMENTO,
IDFINALIDADE,
IDCFOP,
IDUSUARIO,
IDTRANSPORTADORA,
EMISSAO,
SAIDA,
MODELO,
SERIE,
PLACA,
ANTT,
VEICULO,
FRETEPOR,
INFORMACOESCOMPLEMENTARES,
INDPAGAMENTO,
IDFORMADEPAGAMENTO,
IDVENDA FROM NFE WHERE IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = IDNFe;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<NFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static NFe GetNFePorVenda(decimal idVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNFE,
IDCLIENTE,
IDTIPOATENDIMENTO,
IDFINALIDADE,
IDCFOP,
IDUSUARIO,
IDTRANSPORTADORA,
EMISSAO,
SAIDA,
MODELO,
SERIE,
PLACA,
ANTT,
VEICULO,
FRETEPOR,
INFORMACOESCOMPLEMENTARES,
INDPAGAMENTO,
IDFORMADEPAGAMENTO,
IDVENDA FROM NFE WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = idVenda;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return EntityUtil<NFe>.ParseDataRow(oSQL.dtDados.Rows[0]);
            }
        }

        public static bool GetNFeFoiGerada(decimal IdVenda)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNFE,
IDCLIENTE,
IDTIPOATENDIMENTO,
IDFINALIDADE,
IDCFOP,
IDUSUARIO,
IDTRANSPORTADORA,
EMISSAO,
SAIDA,
MODELO,
SERIE,
PLACA,
ANTT,
VEICULO,
FRETEPOR,
INFORMACOESCOMPLEMENTARES,
INDPAGAMENTO,
IDFORMADEPAGAMENTO,
IDVENDA FROM NFE WHERE IDVENDA = @IDVENDA";
                oSQL.ParamByName["IDVENDA"] = IdVenda;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return false;

                return true;
            }
        }
        public static bool Salvar(NFe nfe, TipoOperacao Tipo)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                switch (Tipo)
                {
                    case TipoOperacao.INSERT:
                        oSQL.SQL = @"INSERT INTO NFE(IDNFE, IDTIPOATENDIMENTO, IDFINALIDADE, IDCFOP, IDUSUARIO, IDTRANSPORTADORA, IDVENDA, 
                                                     EMISSAO, SAIDA, MODELO, SERIE, PLACA, ANTT, 
                                                     VEICULO, FRETEPOR, INFORMACOESCOMPLEMENTARES, IDCLIENTE, INDPAGAMENTO, IDFORMADEPAGAMENTO)
                                         VALUES (@IDNFE, @IDTIPOATENDIMENTO, @IDFINALIDADE, @IDCFOP, @IDUSUARIO, @IDTRANSPORTADORA,  @IDVENDA,
                                                 @EMISSAO, @SAIDA, @MODELO, @SERIE, @PLACA, @ANTT, 
                                                 @VEICULO, @FRETEPOR, @INFORMACOESCOMPLEMENTARES, @IDCLIENTE, @INDPAGAMENTO, @IDFORMADEPAGAMENTO)";
                        oSQL.ParamByName["EMISSAO"] = nfe.Emissao;
                        oSQL.ParamByName["SAIDA"] = nfe.Saida;

                        break;
                    case TipoOperacao.UPDATE:
                        oSQL.SQL = @"UPDATE NFE
                                       SET IDTIPOATENDIMENTO = @IDTIPOATENDIMENTO, 
                                           IDFINALIDADE = @IDFINALIDADE,
                                           IDCFOP = @IDCFOP,
                                           IDUSUARIO = @IDUSUARIO,
                                           IDVENDA = @IDVENDA,
                                           IDTRANSPORTADORA = @IDTRANSPORTADORA,
                                           MODELO = @MODELO, 
                                           SERIE = @SERIE, 
                                           PLACA = @PLACA, 
                                           ANTT = @ANTT,
                                           VEICULO = @VEICULO, 
                                           FRETEPOR = @FRETEPOR, 
                                           INFORMACOESCOMPLEMENTARES = @INFORMACOESCOMPLEMENTARES,
                                           IDCLIENTE = @IDCLIENTE,
                                           INDPAGAMENTO = @INDPAGAMENTO,
                                           IDFORMADEPAGAMENTO = @IDFORMADEPAGAMENTO
                                     WHERE IDNFE = @IDNFE";
                        break;
                }
                oSQL.ParamByName["IDTIPOATENDIMENTO"] = nfe.IDTipoAtendimento;
                oSQL.ParamByName["IDFINALIDADE"] = nfe.IDFinalidade;
                oSQL.ParamByName["IDCFOP"] = nfe.IDCFOP;
                oSQL.ParamByName["IDUSUARIO"] = nfe.IDUsuario;
                oSQL.ParamByName["IDTRANSPORTADORA"] = nfe.IDTransportadora;
                oSQL.ParamByName["MODELO"] = nfe.Modelo;
                oSQL.ParamByName["SERIE"] = nfe.Serie;
                oSQL.ParamByName["PLACA"] = nfe.Placa;
                oSQL.ParamByName["ANTT"] = nfe.ANTT;
                oSQL.ParamByName["VEICULO"] = nfe.Veiculo;
                oSQL.ParamByName["FRETEPOR"] = nfe.FretePor;
                oSQL.ParamByName["INFORMACOESCOMPLEMENTARES"] = nfe.InformacoesComplementares;
                oSQL.ParamByName["IDNFE"] = nfe.IDNFe;
                oSQL.ParamByName["IDCLIENTE"] = nfe.IDCliente;
                oSQL.ParamByName["INDPAGAMENTO"] = nfe.INDPagamento;
                oSQL.ParamByName["IDFORMADEPAGAMENTO"] = nfe.IDFormaDePagamento;
                oSQL.ParamByName["IDVENDA"] = nfe.IDVenda;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool Excluir(decimal idNFe)
        {
            using(SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "DELETE FROM NFE WHERE IDNFE = @IDNFE";
                oSQL.ParamByName["IDNFE"] = idNFe;

                return oSQL.ExecSQL() == 1;

            }
        }
    }
}
