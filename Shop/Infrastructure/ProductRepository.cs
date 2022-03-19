using Shop.Domain;
using System;
using System.Collections.Generic;

namespace Shop.Infrastructure
{
    internal class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts(IEnumerable<Sku> products)
        {
            throw new NotImplementedException();
        }
    }
}
