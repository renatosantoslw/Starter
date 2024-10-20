using PDV.DAO.Entidades.PDV;

namespace PDV.UTIL.Components
{
    public static class ItemVendaUtil
    {
        public static decimal GetTotalItem(decimal quantidade, decimal preco, decimal desconto, decimal area = 1)
        {
            return area * quantidade * (preco - desconto);
        }

        public static decimal GetTotalItem(ItemVenda item)
        {
            if (item.Area == 0)
                item.Area = 1;
            return GetTotalItem(item.Quantidade, item.ValorUnitarioItem, item.DescontoValor, item.Area);
        }
    }
}