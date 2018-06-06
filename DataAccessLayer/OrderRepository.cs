using System.Collections.Generic;
using BusinessLayer.Entities;
using BusinessLayer.Interfaces;

namespace DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        public bool Delete(int orderid)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetAllByBusinessDetails(int businessId)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetAllByCustomerId(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public Order GetById(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(Order order)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
