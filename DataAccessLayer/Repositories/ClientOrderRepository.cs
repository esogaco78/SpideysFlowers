using BusinessLayer.Entities;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer
{
    public class ClientOrderRepository : IClientOrderRepository
    {
        public List<ClientOrder> GetClientOrders(int id, ClientType type)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                if (type == ClientType.Customer)
                {
                    return db.Query<ClientOrder>("GetOrdersByCustomerId", new { CustomerId = id }, commandType: CommandType.StoredProcedure).ToList();
                }
                else
                {
                    return db.Query<ClientOrder>("GetOrdersByBusinessId", new { BusinessId = id }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
        }
    }
}
