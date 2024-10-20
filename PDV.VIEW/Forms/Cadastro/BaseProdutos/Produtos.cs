namespace BaseProdutos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Produtos
    {
        public string GuidProduto { get; set; }
        public string Gtin { get; set; }
        public string DescricaoNormalizada { get; set; }
        public string DescricaoUpper { get; set; }
        public string DescricaoAcento { get; set; }
        public string Peso { get; set; }
        public string Ncm { get; set; }
        public string Cest { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Embalagem { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoMedio { get; set; }
        public string ImgGtin { get; set; }
        public string FotoPng { get; set; }
        public string FotoGif { get; set; }
        public string FotoTabloidePng { get; set; }
        public string FotoTabloideGif { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
