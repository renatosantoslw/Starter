using System;

namespace PDV.DAO.Entidades.Estoque.NFeImportacao
{
    public class NFeEntrada
    {
        public decimal IDNFeEntrada { get; set; }
        public decimal IDFornecedor { get; set; }
        public decimal? IDTransportadora { get; set; }
        public decimal? IDPedidoCompra { get; set; }

        public string CUF { get; set; }
        public int CNF { get; set; }
        public string NATOPE { get; set; }
        public int INDPAG { get; set; }
        public int MODDOC { get; set; }
        public int SERIE { get; set; }
        public int NNF { get; set; }
        public DateTime? DHEMI { get; set; }
        public DateTime? DHSAIENT { get; set; }
        public int TPNF { get; set; }
        public int? IDDEST { get; set; }
        public string CMUNFG { get; set; }
        public int TPIMP { get; set; }
        public int TPEMIS { get; set; }
        public int CDV { get; set; }
        public int TPAMB { get; set; }
        public int FINNFE { get; set; }
        public int? INDFINAL { get; set; }
        public int? INDPRES { get; set; }
        public int PROCEMI { get; set; }
        public string VERPROC { get; set; }
        public DateTime? DHCONT { get; set; } = null;
        public string XJUST { get; set; }
        public int MODFRETE { get; set; }
        public string PLACA { get; set; }
        public string UF { get; set; }
        public int? QVOL { get; set; }
        public string ESP { get; set; }
        public string MARCA { get; set; }
        public string NVOL { get; set; }
        public decimal? PESOL { get; set; }
        public decimal? PESOB { get; set; }
        public string INFADFISCO { get; set; }
        public string INFCPL { get; set; }
        public string XCAMPO { get; set; }
        public string XTEXTO { get; set; }
        public decimal VBC { get; set; }
        public decimal VICMS { get; set; }
        public decimal VBCST { get; set; }
        public decimal VST { get; set; }
        public decimal VPROD { get; set; }
        public decimal VFRETE { get; set; }
        public decimal VSEG { get; set; }
        public decimal VDESC { get; set; }
        public decimal VIPI { get; set; }
        public decimal VPIS { get; set; }
        public decimal VCOFINS { get; set; }
        public decimal VOUTRO { get; set; }
        public decimal VNF { get; set; }
        public decimal VTOTTRIB { get; set; }
        public decimal? VICMSUFDEST { get; set; }
        public decimal? VICMSUFREMET { get; set; }
        public decimal? VFCPUFDEST { get; set; }
        public string AUTCNPJ { get; set; }
        public string AUTCPF { get; set; }
        public string CHNFE { get; set; }
        public string NPROT { get; set; }
        public int CSTAT { get; set; }
        public string XMOTIVO { get; set; }

        public decimal IDUsuario { get; set; }
        public DateTime DataImportacao { get; set; }

        public NFeEntrada() { }
    }
}