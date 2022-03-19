using Shop.Application.Dtos;
using Shop.Domain;
using System;
using System.Collections.Generic;

namespace Shop.Application
{
    public interface IOrderService
    {
        public void PlaceOrder(AddOrderDto order);
        public void AbandonOrder(Guid orderId);
        public void AddProducts(IEnumerable<Guid> products);
        public OrderDto GetOrder(Guid id);
        public void DispatchOrder(Guid id, Carrier carrier);
        public void PayForOrder(Guid orderId, decimal amount, string transactionNumber);
    }
}