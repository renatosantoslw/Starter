using System;

namespace PDV.DAO.Atributos
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Struct)]
    public class CampoTabela : Attribute
    {
        public string Nome;

        public CampoTabela(string Nome)
        {
            this.Nome = Nome;
        }
    }
}
