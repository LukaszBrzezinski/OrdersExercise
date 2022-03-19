namespace Shop.Domain
{
    public interface IStockChecker
    {
        bool InStock(Sku sku, int amount);
    }
}