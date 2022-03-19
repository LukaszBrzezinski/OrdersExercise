using System;

namespace Shop.Domain.Orders
{
    public interface IOrderRepository
    {
        public Order GetOrder(Guid id);
        public void UpdateOrder(Guid id);
    }
}