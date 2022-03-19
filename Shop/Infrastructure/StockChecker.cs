using Shop.Domain;
using Shop.Domain.Products;

namespace Shop.Infrastructure
{
    internal class StockChecker : IStockChecker
    {
        public bool InStock(Sku sku, int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}