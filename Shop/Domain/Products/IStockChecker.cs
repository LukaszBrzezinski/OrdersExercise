namespace Shop.Domain.Products
{
    public interface IStockChecker
    {
        bool InStock(Sku sku, int amount);
    }
}