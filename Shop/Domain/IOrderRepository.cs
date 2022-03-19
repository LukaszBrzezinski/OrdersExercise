using System;

namespace Shop.Domain
{
    public interface IOrderRepository
    {
        public Order GetOrder(Guid id);
        public void UpdateOrder(Guid id);
    }
}