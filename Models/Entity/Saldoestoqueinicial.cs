using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Saldoestoqueinicial
    {
        public int Idsaldoestoqueinicial { get; set; }
        public int? Idalmoxarifado { get; set; }
        public int? Idproduto { get; set; }
        public DateTime? Datacadastro { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? Valor { get; set; }

        public virtual Almoxarifado IdalmoxarifadoNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
    }
}
