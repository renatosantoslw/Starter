using PDV.DAO.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.DAO.Entidades
{
    public class Tabela
    {
        [CampoTabela("ID")]
        [MaxLength(18)]
        public decimal ID { get; set; }

        [CampoTabela("Nome")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [CampoTabela("Grupo")]
        public string Grupo { get; set; }
    }
}
