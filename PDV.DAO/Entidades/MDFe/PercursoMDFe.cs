using PDV.DAO.Atributos;
using System;

namespace PDV.DAO.Entidades.MDFe
{
    public class PercursoMDFe
    {
        [CampoTabela("IDPERCURSOMDFE")]
        public decimal IDPercursoMDFe { get; set; } = -1;

        [CampoTabela("IDMDFE")]
        public decimal IDMDFe { get; set; }

        [CampoTabela("IDUNIDADEFEDERATIVAPERCURSO")]
        public decimal IDUnidadeFederativaPercurso { get; set; }

        [CampoTabela("INICIOVIAGEM")]
        public DateTime? InicioViagem { get; set; } = null;

        public PercursoMDFe() { }
    }
}
