using CommonLayer.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IOrderRL
    {
        public OrderModel AddOrder(OrderModel orderModel, int UserId);
        public bool CancelOrder(int OrderId);
        public List<GetOrderModel> GetOrders();
    }
}
