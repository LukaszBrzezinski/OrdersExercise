using System;
using System.Collections.Generic;

namespace Shop.Domain
{
    public class Order
    {
        public IReadOnlyCollection<Product> Products { get; }
        public Guid Id { get; }
        public decimal TotalDiscount { get; }
    }
}