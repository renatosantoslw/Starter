using PDV.DAO.Atributos;

namespace PDV.DAO.GridViewModels
{
    public class ServicoGridViewModel
    {
        [CampoTabela(nameof(IDServico))]
        public decimal IDServico { get; set; }


        [CampoTabela(nameof(Descricao))]
        public string Descricao { get; set; }


        [CampoTabela(nameof(Categoria))]
        public string Categoria { get; set; }


        [CampoTabela(nameof(UnidadeDeMedida))]
        public string UnidadeDeMedida { get; set; }


        [CampoTabela(nameof(Valor))]
        public decimal Valor { get; set; }

        public ServicoGridViewModel()
        {

        }
    }
}
