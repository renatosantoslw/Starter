using System;
using System.Data;
using PDV.DAO.DB.Controller;
using PDV.DAO.DB.Utils;
using PDV.DAO.Entidades.Estoque.NFeImportacao;
using System.Text;

namespace PDV.CONTROLER.Funcoes
{
    public class FuncoesNFeEntrada
    {
        public static bool Salvar(NFeEntrada NFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"INSERT INTO NFEENTRADA (IDNFEENTRADA, IDFORNECEDOR, IDTRANSPORTADORA, IDPEDIDOCOMPRA, CUF, CNF, NATOPE, INDPAG, MODDOC, SERIE, NNF, DHEMI, DHSAIENT,
                                                     TPNF, IDDEST, CMUNFG, TPIMP, TPEMIS, CDV, TPAMB, FINNFE, INDFINAL, INDPRES, PROCEMI, VERPROC, DHCONT, XJUST, MODFRETE, PLACA, 
                                                     UF, QVOL, ESP, MARCA, NVOL, PESOL, PESOB, INFADFISCO, INFCPL, XCAMPO, XTEXTO, VBC, VICMS, VBCST, VST, VPROD, VFRETE, VSEG, 
                                                     VDESC, VIPI, VPIS, VCOFINS, VOUTRO, VNF, VTOTTRIB, VICMSUFDEST, VICMSUFREMET, VFCPUFDEST, AUTCNPJ, AUTCPF, CHNFE, NPROT, CSTAT, XMOTIVO, IDUSUARIO, DATAIMPORTACAO)
                               VALUES (@IDNFEENTRADA, @IDFORNECEDOR, @IDTRANSPORTADORA, @IDPEDIDOCOMPRA, @CUF, @CNF, @NATOPE, @INDPAG, @MODDOC, @SERIE, @NNF, @DHEMI, @DHSAIENT,
                                       @TPNF, @IDDEST, @CMUNFG, @TPIMP, @TPEMIS, @CDV, @TPAMB, @FINNFE, @INDFINAL, @INDPRES, @PROCEMI, @VERPROC, @DHCONT, @XJUST, @MODFRETE, @PLACA,
                                       @UF, @QVOL, @ESP, @MARCA, @NVOL, @PESOL, @PESOB, @INFADFISCO, @INFCPL, @XCAMPO, @XTEXTO, @VBC, @VICMS, @VBCST, @VST, @VPROD, @VFRETE, @VSEG,
                                       @VDESC, @VIPI, @VPIS, @VCOFINS, @VOUTRO, @VNF, @VTOTTRIB, @VICMSUFDEST, @VICMSUFREMET, @VFCPUFDEST, @AUTCNPJ, @AUTCPF, @CHNFE, @NPROT, @CSTAT, @XMOTIVO, @IDUSUARIO, @DATAIMPORTACAO)";
                oSQL.ParamByName["IDNFEENTRADA"] = NFe.IDNFeEntrada;
                oSQL.ParamByName["IDFORNECEDOR"] = NFe.IDFornecedor;
                oSQL.ParamByName["IDTRANSPORTADORA"] = NFe.IDTransportadora;
                oSQL.ParamByName["IDPEDIDOCOMPRA"] = NFe.IDPedidoCompra;
                oSQL.ParamByName["CUF"] = NFe.CUF;
                oSQL.ParamByName["CNF"] = NFe.CNF;
                oSQL.ParamByName["NATOPE"] = NFe.NATOPE;
                oSQL.ParamByName["INDPAG"] = NFe.INDPAG;
                oSQL.ParamByName["MODDOC"] = NFe.MODDOC;
                oSQL.ParamByName["SERIE"] = NFe.SERIE;
                oSQL.ParamByName["NNF"] = NFe.NNF;
                oSQL.ParamByName["DHEMI"] = NFe.DHEMI;


                NFe.DHSAIENT= NFe.DHSAIENT.ToString().Contains("01/01/0001 00:00:00") ? NFe.DHSAIENT = DateTime.Now.ToLocalTime() : NFe.DHSAIENT = NFe.DHSAIENT;

                oSQL.ParamByName["DHSAIENT"] = NFe.DHSAIENT;

                //localx


                oSQL.ParamByName["TPNF"] = NFe.TPNF;
                oSQL.ParamByName["IDDEST"] = NFe.IDDEST;
                oSQL.ParamByName["CMUNFG"] = NFe.CMUNFG;
                oSQL.ParamByName["TPIMP"] = NFe.TPIMP;
                oSQL.ParamByName["TPEMIS"] = NFe.TPEMIS;
                oSQL.ParamByName["CDV"] = NFe.CDV;
                oSQL.ParamByName["TPAMB"] = NFe.TPAMB;
                oSQL.ParamByName["FINNFE"] = NFe.FINNFE;
                oSQL.ParamByName["INDFINAL"] = NFe.INDFINAL;
                oSQL.ParamByName["INDPRES"] = NFe.INDPRES;
                oSQL.ParamByName["PROCEMI"] = NFe.PROCEMI;
                oSQL.ParamByName["VERPROC"] = NFe.VERPROC;
                oSQL.ParamByName["DHCONT"] = NFe.DHCONT;
                oSQL.ParamByName["XJUST"] = NFe.XJUST;
                oSQL.ParamByName["MODFRETE"] = NFe.MODFRETE;
                oSQL.ParamByName["PLACA"] = NFe.PLACA;
                oSQL.ParamByName["UF"] = NFe.UF;
                oSQL.ParamByName["QVOL"] = NFe.QVOL;
                oSQL.ParamByName["ESP"] = NFe.ESP;
                oSQL.ParamByName["MARCA"] = NFe.MARCA;
                oSQL.ParamByName["NVOL"] = NFe.NVOL;
                oSQL.ParamByName["PESOL"] = NFe.PESOL;
                oSQL.ParamByName["PESOB"] = NFe.PESOB;
                oSQL.ParamByName["INFADFISCO"] = NFe.INFADFISCO;
                oSQL.ParamByName["INFCPL"] = NFe.INFCPL;
                oSQL.ParamByName["XCAMPO"] = NFe.XCAMPO;
                oSQL.ParamByName["XTEXTO"] = NFe.XTEXTO;
                oSQL.ParamByName["VBC"] = NFe.VBC;
                oSQL.ParamByName["VICMS"] = NFe.VICMS;
                oSQL.ParamByName["VBCST"] = NFe.VBCST;
                oSQL.ParamByName["VST"] = NFe.VST;
                oSQL.ParamByName["VPROD"] = NFe.VPROD;
                oSQL.ParamByName["VFRETE"] = NFe.VFRETE;
                oSQL.ParamByName["VSEG"] = NFe.VSEG;
                oSQL.ParamByName["VDESC"] = NFe.VDESC;
                oSQL.ParamByName["VIPI"] = NFe.VIPI;
                oSQL.ParamByName["VPIS"] = NFe.VPIS;
                oSQL.ParamByName["VCOFINS"] = NFe.VCOFINS;
                oSQL.ParamByName["VOUTRO"] = NFe.VOUTRO;
                oSQL.ParamByName["VNF"] = NFe.VNF;
                oSQL.ParamByName["VTOTTRIB"] = NFe.VTOTTRIB;
                oSQL.ParamByName["VICMSUFDEST"] = NFe.VICMSUFDEST;
                oSQL.ParamByName["VICMSUFREMET"] = NFe.VICMSUFREMET;
                oSQL.ParamByName["VFCPUFDEST"] = NFe.VFCPUFDEST;
                oSQL.ParamByName["AUTCNPJ"] = NFe.AUTCNPJ;
                oSQL.ParamByName["AUTCPF"] = NFe.AUTCPF;
                oSQL.ParamByName["CHNFE"] = NFe.CHNFE;
                oSQL.ParamByName["NPROT"] = NFe.NPROT;
                oSQL.ParamByName["CSTAT"] = NFe.CSTAT;
                oSQL.ParamByName["XMOTIVO"] = NFe.XMOTIVO;
                oSQL.ParamByName["IDUSUARIO"] = NFe.IDUsuario;
                oSQL.ParamByName["DATAIMPORTACAO"] = NFe.DataImportacao;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static bool PodeRemoverNFe(decimal IDNFeEntrada)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT 1
                               FROM CONTAPAGAR
                                 INNER JOIN BAIXAPAGAMENTO ON (CONTAPAGAR.IDCONTAPAGAR = BAIXAPAGAMENTO.IDCONTAPAGAR)
                             WHERE CONTAPAGAR.IDNFEENTRADA = @IDNFEENTRADA";
                oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                oSQL.Open();
                return oSQL.IsEmpty;
            }
        }

        public static DataTable GetImportacoes(string Chave, DateTime Inicio, DateTime Fim)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = $@"SELECT DISTINCT NFEENTRADA.IDNFEENTRADA,
                                     USUARIO.NOME AS USUARIO,
                                     FORNECEDOR.RAZAOSOCIAL,
                                     NFEENTRADA.CHNFE,
                                     NFEENTRADA.DATAIMPORTACAO,
                                     NFEENTRADA.DHEMI,
                                     NFEENTRADA.VNF
                                FROM NFEENTRADA
                                  INNER JOIN FORNECEDOR ON (NFEENTRADA.IDFORNECEDOR = FORNECEDOR.IDFORNECEDOR)
                                  INNER JOIN USUARIO ON (NFEENTRADA.IDUSUARIO = USUARIO.IDUSUARIO)
                              WHERE CAST(NFEENTRADA.DATAIMPORTACAO AS DATE) BETWEEN @INICIO AND @FIM
                                AND NFEENTRADA.CHNFE LIKE '%{Chave}%'";
                oSQL.ParamByName["INICIO"] = Inicio;
                oSQL.ParamByName["FIM"] = Fim;
                oSQL.Open();
                return oSQL.dtDados;
            }
        }

        public static bool IsNFeImportada(string ChaveNFe)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = @"SELECT IDNFEENTRADA,
                        IDFORNECEDOR,
                        IDTRANSPORTADORA,
                        IDPEDIDOCOMPRA,
                        CUF,
                        CNF,
                        NATOPE,
                        INDPAG,
                        MODDOC,
                        SERIE,
                        NNF,
                        DHEMI,
                        DHSAIENT,
                        TPNF,
                        IDDEST,
                        CMUNFG,
                        TPIMP,
                        TPEMIS,
                        CDV,
                        TPAMB,
                        FINNFE,
                        INDFINAL,
                        INDPRES,
                        PROCEMI,
                        VERPROC,
                        DHCONT,
                        XJUST,
                        MODFRETE,
                        PLACA,
                        UF,
                        QVOL,
                        ESP,
                        MARCA,
                        NVOL,
                        PESOL,
                        PESOB,
                        INFADFISCO,
                        INFCPL,
                        XCAMPO,
                        XTEXTO,
                        VBC,
                        VICMS,
                        VBCST,
                        VST,
                        VPROD,
                        VFRETE,
                        VSEG,
                        VDESC,
                        VIPI,
                        VPIS,
                        VCOFINS,
                        VOUTRO,
                        VNF,
                        VTOTTRIB,
                        VICMSUFDEST,
                        VICMSUFREMET,
                        VFCPUFDEST,
                        AUTCNPJ,
                        AUTCPF,
                        CHNFE,
                        NPROT,
                        CSTAT,
                        XMOTIVO,
                        DATAIMPORTACAO,
                        IDUSUARIO FROM NFEENTRADA WHERE CHNFE = @CHNFE";
                oSQL.ParamByName["CHNFE"] = ChaveNFe;
                oSQL.Open();
                return !oSQL.IsEmpty;
            }
        }

        public static bool SalvarXML(byte[] Xml, decimal IDNFeEntrada)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "INSERT INTO NFEENTRADAXML (IDNFEENTRADAXML, IDNFEENTRADA, XML) VALUES (@IDNFEENTRADAXML, @IDNFEENTRADA, @XML)";
                oSQL.ParamByName["IDNFEENTRADAXML"] = Sequence.GetNextID("NFEENTRADAXML", "IDNFEENTRADAXML");
                oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                oSQL.ParamByName["XML"] = Xml;
                return oSQL.ExecSQL() == 1;
            }
        }

        public static string GetXML(decimal IDNFeEntrada)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT XML FROM NFEENTRADAXML WHERE IDNFEENTRADA = @IDNFEENTRADA";
                oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return null;

                return Encoding.UTF8.GetString((byte[])oSQL.dtDados.Rows[0]["XML"]);

            }
        }


        public static decimal GetIdPedidoCompra(decimal IDNFeEntrada)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                oSQL.SQL = "SELECT IDPEDIDOCOMPRA FROM NFEENTRADA WHERE IDNFEENTRADA = @IDNFEENTRADA";
                oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                oSQL.Open();
                if (oSQL.IsEmpty)
                    return 0;
   
                return Convert.ToDecimal(oSQL.dtDados.Rows[0]["IDPEDIDOCOMPRA"]);
            }
        }


        public static bool Remover(decimal IDNFeEntrada)
        {
            using (SQLQuery oSQL = new SQLQuery())
            {
                //oSQL.SQL = "DELETE FROM CLASSIFICACAOCONTAPAGAR WHERE IDCONTAPAGAR IN (SELECT IDCONTAPAGAR FROM CONTAPAGAR WHERE IDNFEENTRADA = @IDNFEENTRADA)";
                //oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                //oSQL.ExecSQL();

                oSQL.SQL = "DELETE FROM CONTAPAGAR WHERE IDCONTAPAGAR IN (SELECT IDCONTAPAGAR FROM CONTAPAGAR WHERE IDNFEENTRADA = @IDNFEENTRADA)";
                oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                oSQL.ExecSQL();


                oSQL.SQL = "DELETE FROM ITEMNFEENTRADA WHERE IDNFEENTRADA = @IDNFEENTRADA";
                oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                oSQL.ExecSQL();

                oSQL.SQL = "DELETE FROM NFEENTRADAXML WHERE IDNFEENTRADA = @IDNFEENTRADA";
                oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                oSQL.ExecSQL();

                oSQL.SQL = "DELETE FROM NFEENTRADA WHERE IDNFEENTRADA = @IDNFEENTRADA";
                oSQL.ParamByName["IDNFEENTRADA"] = IDNFeEntrada;
                return oSQL.ExecSQL() == 1;
            }
        }
    }
}