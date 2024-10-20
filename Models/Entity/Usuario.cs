using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Usuario
    {
        public Usuario()
        {
            Fluxocaixas = new HashSet<Fluxocaixa>();
            InverseIdusuariosupervisorNavigation = new HashSet<Usuario>();
            Itempedidocompras = new HashSet<Itempedidocompra>();
            Itemvenda = new HashSet<Itemvendum>();
            Nfeentrada = new HashSet<Nfeentradum>();
            Nves = new HashSet<Nfe>();
            Pedidocompras = new HashSet<Pedidocompra>();
            SangriacaixaIdusuarioNavigations = new HashSet<Sangriacaixa>();
            SangriacaixaIdusuariocadastroNavigations = new HashSet<Sangriacaixa>();
            Venda = new HashSet<Vendum>();
        }

        public int Idusuario { get; set; }
        public int? Idusuariosupervisor { get; set; }
        public int? Idperfilacesso { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int? Ativo { get; set; }
        public int? Root { get; set; }
        public string Pin { get; set; }
        public string Chaveerp { get; set; }
        public int? Tipodesconto { get; set; }
        public int? Formadesconto { get; set; }
        public int? Isvendedor { get; set; }
        public int? Iscomprador { get; set; }
        public decimal? Descontomaximo { get; set; }

        public virtual Perfilacesso IdperfilacessoNavigation { get; set; }
        public virtual Usuario IdusuariosupervisorNavigation { get; set; }
        public virtual ICollection<Fluxocaixa> Fluxocaixas { get; set; }
        public virtual ICollection<Usuario> InverseIdusuariosupervisorNavigation { get; set; }
        public virtual ICollection<Itempedidocompra> Itempedidocompras { get; set; }
        public virtual ICollection<Itemvendum> Itemvenda { get; set; }
        public virtual ICollection<Nfeentradum> Nfeentrada { get; set; }
        public virtual ICollection<Nfe> Nves { get; set; }
        public virtual ICollection<Pedidocompra> Pedidocompras { get; set; }
        public virtual ICollection<Sangriacaixa> SangriacaixaIdusuarioNavigations { get; set; }
        public virtual ICollection<Sangriacaixa> SangriacaixaIdusuariocadastroNavigations { get; set; }
        public virtual ICollection<Vendum> Venda { get; set; }
    }
}
