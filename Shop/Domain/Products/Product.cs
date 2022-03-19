namespace Shop.Domain.Products
{
    public class Product
    {
        public Sku Sku { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Discount { get; }

    }
}