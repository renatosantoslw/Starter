namespace BaseProdutos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProdutoBase
    {
        [Key]
        public Guid GuidProduto { get; set; }

        [StringLength(255)]
        public string Gtin { get; set; }

        [StringLength(255)]
        public string DescricaoNormalizada { get; set; }

        [StringLength(255)]
        public string DescricaoUpper { get; set; }

        [StringLength(255)]
        public string DescricaoAcento { get; set; }

        [StringLength(60)]
        public string Peso { get; set; }

        [StringLength(60)]
        public string Ncm { get; set; }

        [StringLength(60)]
        public string Cest { get; set; }

        [StringLength(255)]
        public string Marca { get; set; }

        [StringLength(255)]
        public string Categoria { get; set; }

        [StringLength(255)]
        public string Embalagem { get; set; }

        public decimal Quantidade { get; set; }

        public decimal PrecoMedio { get; set; }

        [StringLength(255)]
        public string ImgGtin { get; set; }

        [StringLength(255)]
        public string FotoPng { get; set; }

        [StringLength(255)]
        public string FotoGif { get; set; }

        [StringLength(255)]
        public string FotoTabloidePng { get; set; }

        [StringLength(255)]
        public string FotoTabloideGif { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CriadoEm { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AtualizadoEm { get; set; }
    }
}
