using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        List<Order> GetAllByCustomerId(int customerId);
        List<Order> GetAllByBusinessDetails(int businessId);
        Order GetById(int orderId);
        int Insert(Order order);
        bool Update(Order order);
        bool Delete(int orderid);
    }
}
