using System.Collections.Generic;

namespace Shop.Domain
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts(IEnumerable<Sku> products);
    }
}