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
    public class CustomerRepository : ICustomerRepository
    {
        public bool Delete(int customerid)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Query<Customer>("GetCustomers", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
