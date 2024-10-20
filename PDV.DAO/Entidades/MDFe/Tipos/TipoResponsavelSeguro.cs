using System.Collections.Generic;

namespace PDV.DAO.Entidades.MDFe.Tipos
{
    public class TipoResponsavelSeguro
    {
        public decimal IDResponsavelSeguro { get; set; }
        public string Descricao { get; set; }

        public TipoResponsavelSeguro() { }

        public static List<TipoResponsavelSeguro> GetTipos()
        {
            List<TipoResponsavelSeguro> Tipos = new List<TipoResponsavelSeguro>();
            Tipos.Add(new TipoResponsavelSeguro { IDResponsavelSeguro = 1, Descricao = "Emitente do MDF-E" });
            Tipos.Add(new TipoResponsavelSeguro { IDResponsavelSeguro = 2, Descricao = "Responsável Pela Contratação do Serviço de Transporte (Contratante)" });
            return Tipos;
        }
    }
}
