using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Nfeentradum
    {
        public Nfeentradum()
        {
            Contapagars = new HashSet<Contapagar>();
            Itemnfeentrada = new HashSet<Itemnfeentradum>();
            Nfeentradaxmls = new HashSet<Nfeentradaxml>();
        }

        public int Idnfeentrada { get; set; }
        public int? Idfornecedor { get; set; }
        public int? Idtransportadora { get; set; }
        public int? Idpedidocompra { get; set; }
        public string Cuf { get; set; }
        public int? Cnf { get; set; }
        public string Natope { get; set; }
        public int? Indpag { get; set; }
        public int? Moddoc { get; set; }
        public int? Serie { get; set; }
        public int? Nnf { get; set; }
        public DateTime? Dhemi { get; set; }
        public DateTime? Dhsaient { get; set; }
        public int? Tpnf { get; set; }
        public int? Iddest { get; set; }
        public string Cmunfg { get; set; }
        public int? Tpimp { get; set; }
        public int? Tpemis { get; set; }
        public int? Cdv { get; set; }
        public int? Tpamb { get; set; }
        public int? Finnfe { get; set; }
        public int? Indfinal { get; set; }
        public int? Indpres { get; set; }
        public int? Procemi { get; set; }
        public string Verproc { get; set; }
        public DateTime? Dhcont { get; set; }
        public string Xjust { get; set; }
        public int? Modfrete { get; set; }
        public string Placa { get; set; }
        public string Uf { get; set; }
        public decimal? Qvol { get; set; }
        public string Esp { get; set; }
        public string Marca { get; set; }
        public string Nvol { get; set; }
        public decimal? Pesol { get; set; }
        public decimal? Pesob { get; set; }
        public string Infadfisco { get; set; }
        public string Infcpl { get; set; }
        public string Xcampo { get; set; }
        public string Xtexto { get; set; }
        public decimal? Vbc { get; set; }
        public decimal? Vicms { get; set; }
        public decimal? Vbcst { get; set; }
        public decimal? Vst { get; set; }
        public decimal? Vprod { get; set; }
        public decimal? Vfrete { get; set; }
        public decimal? Vseg { get; set; }
        public decimal? Vdesc { get; set; }
        public decimal? Vipi { get; set; }
        public decimal? Vpis { get; set; }
        public decimal? Vcofins { get; set; }
        public decimal? Voutro { get; set; }
        public decimal? Vnf { get; set; }
        public decimal? Vtottrib { get; set; }
        public decimal? Vicmsufdest { get; set; }
        public decimal? Vicmsufremet { get; set; }
        public decimal? Vfcpufdest { get; set; }
        public string Autcnpj { get; set; }
        public string Autcpf { get; set; }
        public string Chnfe { get; set; }
        public string Nprot { get; set; }
        public int? Cstat { get; set; }
        public string Xmotivo { get; set; }
        public DateTime? Dataimportacao { get; set; }
        public int? Idusuario { get; set; }

        public virtual Fornecedor IdfornecedorNavigation { get; set; }
        public virtual Pedidocompra IdpedidocompraNavigation { get; set; }
        public virtual Transportadora IdtransportadoraNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Contapagar> Contapagars { get; set; }
        public virtual ICollection<Itemnfeentradum> Itemnfeentrada { get; set; }
        public virtual ICollection<Nfeentradaxml> Nfeentradaxmls { get; set; }
    }
}
