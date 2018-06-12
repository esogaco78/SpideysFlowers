using BusinessLayer.Entities;
using BusinessLayer.Helpers;
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
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                DynamicParameters p = new DynamicParameters();
                p.Add("@CustomerId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    FirstName = StringHelpers.ConvertToTitleCase(customer.FirstName),
                    LastName = StringHelpers.ConvertToTitleCase(customer.LastName),
                    StreetAddress = StringHelpers.ConvertToTitleCase(customer.StreetAddress),
                    City = StringHelpers.ConvertToTitleCase(customer.City),
                    Region = StringHelpers.ConvertToTitleCase(customer.Region),
                    Code = StringHelpers.ConvertToTitleCase(customer.Code),
                    PhoneNumber = StringHelpers.CleanPhoneNumber(customer.PhoneNumber),
                    Email = customer.Email.ToLower()
                });
                db.Execute("SaveCustomer", p, commandType: CommandType.StoredProcedure);

                return p.Get<int>("@CustomerId");
            }
        }

        public bool Update(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                int result = db.Execute("UpdateCustomer", new
                {
                    CustomerId = customer.CustomerId,
                    FirstName = StringHelpers.ConvertToTitleCase(customer.FirstName),
                    LastName = StringHelpers.ConvertToTitleCase(customer.LastName),
                    StreetAddress = StringHelpers.ConvertToTitleCase(customer.StreetAddress),
                    City = StringHelpers.ConvertToTitleCase(customer.City),
                    Region = StringHelpers.ConvertToTitleCase(customer.Region),
                    Code = StringHelpers.ConvertToTitleCase(customer.Code),
                    PhoneNumber = StringHelpers.CleanPhoneNumber(customer.PhoneNumber),
                    Email = customer.Email.ToLower()
                }, commandType: CommandType.StoredProcedure);

                return result != 0;
            }
        }
    }
}
