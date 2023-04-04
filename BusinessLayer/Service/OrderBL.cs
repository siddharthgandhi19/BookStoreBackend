using BusinessLayer.Interface;
using CommonLayer.Models.Order;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class OrderBL : IOrderBL
    {
        IOrderRL iOrderRL;
        public OrderBL(IOrderRL iOrderRL)
        {
            this.iOrderRL = iOrderRL;
        }

        public OrderModel AddOrder(OrderModel orderModel, int UserId)
        {
            try
            {
                return iOrderRL.AddOrder(orderModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CancelOrder(int OrderId)
        {
            try
            {
                return iOrderRL.CancelOrder(OrderId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GetOrderModel> GetOrders(int UserId)
        {
            try
            {
                return iOrderRL.GetOrders(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
