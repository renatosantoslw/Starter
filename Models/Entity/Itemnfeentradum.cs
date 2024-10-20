using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Itemnfeentradum
    {
        public Itemnfeentradum()
        {
            Movimentoestoques = new HashSet<Movimentoestoque>();
        }

        public int Iditemnfeentrada { get; set; }
        public int? Idnfeentrada { get; set; }
        public int? Idproduto { get; set; }
        public int? Idconversaounidadedemedida { get; set; }
        public string Cean { get; set; }
        public string Xprod { get; set; }
        public string Ncm { get; set; }
        public string Cest { get; set; }
        public string Cfop { get; set; }
        public string Ucom { get; set; }
        public decimal? Qcom { get; set; }
        public decimal? Vuncom { get; set; }
        public decimal? Vprod { get; set; }
        public string Ceantrib { get; set; }
        public string Utrib { get; set; }
        public decimal? Qtrib { get; set; }
        public decimal? Vuntrib { get; set; }
        public decimal? Vfrete { get; set; }
        public decimal? Vseg { get; set; }
        public decimal? Vdesc { get; set; }
        public decimal? Voutro { get; set; }
        public int? Indtot { get; set; }
        public decimal? Vtottrib { get; set; }
        public string Orig { get; set; }
        public string Csticms { get; set; }
        public int? Modbc { get; set; }
        public decimal? Predbc { get; set; }
        public decimal? Vbcicms { get; set; }
        public decimal? Picms { get; set; }
        public decimal? Vicms { get; set; }
        public int? Modbcst { get; set; }
        public decimal? Pmvast { get; set; }
        public decimal? Predbcst { get; set; }
        public decimal? Vbcst { get; set; }
        public decimal? Picmsst { get; set; }
        public decimal? Vicmsst { get; set; }
        public decimal? Vbcufdest { get; set; }
        public decimal? Pfcpufdest { get; set; }
        public decimal? Picmsufdest { get; set; }
        public decimal? Picmsinter { get; set; }
        public decimal? Picmsinterpart { get; set; }
        public decimal? Vfcpufdest { get; set; }
        public decimal? Vicmsufdest { get; set; }
        public decimal? Vicmsufremet { get; set; }
        public string Cenq { get; set; }
        public string Cstipi { get; set; }
        public decimal? Vbcipi { get; set; }
        public decimal? Pipi { get; set; }
        public decimal? Vipi { get; set; }
        public string Cstpis { get; set; }
        public decimal? Vbcpis { get; set; }
        public decimal? Ppis { get; set; }
        public decimal? Vpis { get; set; }
        public string Cstcofins { get; set; }
        public decimal? Vbcofins { get; set; }
        public decimal? Pcofins { get; set; }
        public decimal? Vcofins { get; set; }
        public string Cprod { get; set; }

        public virtual Conversaounidadedemedidum IdconversaounidadedemedidaNavigation { get; set; }
        public virtual Nfeentradum IdnfeentradaNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
        public virtual ICollection<Movimentoestoque> Movimentoestoques { get; set; }
    }
}
