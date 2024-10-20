
using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades
{
    public class Servico
    {
        [CampoTabela(nameof(IDServico))]
        public decimal IDServico { get; set; }


        [CampoTabela(nameof(Descricao))]
        public string Descricao { get; set; }


        [CampoTabela(nameof(IDCategoria))]
        public decimal IDCategoria { get; set; }


        [CampoTabela(nameof(IDUnidadeDeMedida))]
        public decimal IDUnidadeDeMedida { get; set; }


        [CampoTabela(nameof(Valor))]
        public decimal Valor { get; set; }

        public Servico()
        {

        }
    }
}
