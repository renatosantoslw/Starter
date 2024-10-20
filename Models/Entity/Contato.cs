using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Entity
{
    public partial class Contato
    {
        public int Idcontato { get; set; }
        public string Email { get; set; }
        public string Emailalternativo { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
    }
}
