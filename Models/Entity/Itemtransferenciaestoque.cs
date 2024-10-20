using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Itemtransferenciaestoque
    {
        public Itemtransferenciaestoque()
        {
            Movimentoestoques = new HashSet<Movimentoestoque>();
        }

        public int Iditemtransferenciaestoque { get; set; }
        public int? Idtransferenciaestoque { get; set; }
        public int? Idproduto { get; set; }
        public int? Idalmoxarifadoentrada { get; set; }
        public int? Idalmoxarifadosaida { get; set; }
        public decimal? Quantidade { get; set; }

        public virtual Almoxarifado IdalmoxarifadoentradaNavigation { get; set; }
        public virtual Almoxarifado IdalmoxarifadosaidaNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
        public virtual Transferenciaestoque IdtransferenciaestoqueNavigation { get; set; }
        public virtual ICollection<Movimentoestoque> Movimentoestoques { get; set; }
    }
}
