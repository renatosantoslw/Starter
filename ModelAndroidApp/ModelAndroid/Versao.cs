using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ModelAndroidApp.ModelAndroid
{
    [Table("Versao")]
    public partial class Versao
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public int Numero { get; set; }

      
    }
}
