using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Vendum
    {
        public Vendum()
        {
            Duplicatanfces = new HashSet<Duplicatanfce>();
            Itemvenda = new HashSet<Itemvendum>();
        }

        public int Idvenda { get; set; }
        public int? Idcomandautilizada { get; set; }
        public int? Idcomanda { get; set; }
        public int? Idusuario { get; set; }
        public int? Idcliente { get; set; }
        public int? Idfluxocaixa { get; set; }
        public decimal? Quantidadeitens { get; set; }
        public decimal? Valortotal { get; set; }
        public DateTime? Datacadastro { get; set; }
        public string Chaveerp { get; set; }
        public decimal? Dinheiro { get; set; }
        public decimal? Troco { get; set; }
        public long? Status { get; set; }
        public int? Idformapagamento { get; set; }
        public string Observacao { get; set; }
        public int? Idvendedor { get; set; }
        public int? Idtipodeoperacao { get; set; }
        public string Motivodecancelamento { get; set; }
        public string Idrespostafiscal { get; set; }
        public int? Tipodevenda { get; set; }
        public int? Idcomprador { get; set; }
        public DateTime? Datafaturamento { get; set; }
        public bool? Romaneio { get; set; }
        public int? Idromaneio { get; set; }
        public string Pagamentodescricao { get; set; }
        public string Pagamentosdescricao { get; set; }
        public string Obra { get; set; }
        public decimal? Valoravistaproposto { get; set; }

        public virtual Comandum IdcomandaNavigation { get; set; }
        public virtual Comandum IdcomandautilizadaNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Duplicatanfce> Duplicatanfces { get; set; }
        public virtual ICollection<Itemvendum> Itemvenda { get; set; }
    }
}
