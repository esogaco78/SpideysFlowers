using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Query<Order>("GetOrders", commandType: CommandType.StoredProcedure).ToList();
            }
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
