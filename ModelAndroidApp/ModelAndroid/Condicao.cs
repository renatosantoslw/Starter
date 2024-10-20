namespace ModelAndroidApp.ModelAndroid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Condicao")]
    public partial class Condicao
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string Nome { get; set; }

        public int? IDCondicao { get; set; }

        public long ID_Erp { get; set; }

        public short? Transacao { get; set; }

        [StringLength(1)]
        public string Usa_Calendario_Comercial { get; set; }

        public short? Qtd_Parcelas { get; set; }

        public short? Dias_Intervalo { get; set; }

        public decimal? Fator_Dup_Com_Entrada { get; set; }

        public decimal? Fator_Dup_Sem_Entrada { get; set; }

        public decimal? Fator_Cheq_Com_Entrada { get; set; }

        public decimal? Fator_Cheq_Sem_Entrada { get; set; }

      
    }
}
