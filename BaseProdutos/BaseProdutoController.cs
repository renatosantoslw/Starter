using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProdutos
{
    public static class BaseProdutosController
    {
        public static List<ProdutoBase> GetProdutos(string pesquisa)
        {
            var contexto = new ContextoBaseProdutos();
            return contexto.Database.SqlQuery<ProdutoBase>(
                $@"SELECT * FROM Produtos 
                    WHERE DescricaoUpper LIKE ('%{pesquisa}%')
                    OR Gtin = @pesquisa ",
                    new SqlParameter("@pesquisa", pesquisa))
                .ToList();
        }

        public static List<ProdutoBaseConsulta> GetProdutosPorEAN(string pesquisa)
        {
            var contexto = new ContextoBaseProdutos();
            return contexto.Database.SqlQuery<ProdutoBaseConsulta>(
                $@"SELECT Ncm, Gtin, PrecoMedio, Categoria, DescricaoUpper, Cest, Marca FROM Produtos WHERE Gtin = @pesquisa ",
                    new SqlParameter("@pesquisa", pesquisa))
                .ToList();
        }
    }

    public class ProdutoBaseConsulta
    {
        public string Ncm { get; set; }

        public string Gtin { get; set; }


        public decimal PrecoMedio { get; set; }

        public string Categoria { get; set; }

        public string DescricaoUpper { get; set; }
        public string Cest { get; set; }
        public string Marca { get; set; }

    }
}
