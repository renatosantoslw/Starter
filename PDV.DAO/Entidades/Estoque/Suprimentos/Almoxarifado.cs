using PDV.DAO.Atributos;

namespace PDV.DAO.Entidades.Estoque.Suprimentos
{
    public class Almoxarifado
    {
        [CampoTabela("IDALMOXARIFADO")]
        public int IDAlmoxarifado { get; set; } = -1;

        [CampoTabela("DESCRICAO")]
        public string Descricao { get; set; }

        [CampoTabela("TIPO")]
        public decimal Tipo { get; set; } = 1; // 1 - Estoque, 2 - Produção, 3 - Quarentena

        public string DescricaoApresentacao
        {
            get
            {
                string _Tipo = "<Não Informado>";
                switch (Tipo)
                {
                    case 1:
                        _Tipo = "Estoque";
                        break;
                    case 2:
                        _Tipo = "Produção";
                        break;
                    case 3:
                        _Tipo = "Quarentena";
                        break;
                }
                return $"[Descricao]: {Descricao}, [Tipo]: {_Tipo}";
            }
        }

        public Almoxarifado() { }
    }
}
