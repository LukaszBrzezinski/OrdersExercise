using System.Collections.Generic;

namespace Shop.Domain.Products
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts(IEnumerable<Sku> products);
    }
}