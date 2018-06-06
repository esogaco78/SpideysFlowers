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
    public class BusinessRepository : IBusinessRepository
    {
        public bool Delete(int businessid)
        {
            throw new NotImplementedException();
        }

        public List<Business> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Query<Business>("SELECT * FROM Businesses", commandType: CommandType.Text).ToList(); ;
            }
        }

        public Business GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Business business)
        {
            throw new NotImplementedException();
        }

        public bool Update(Business business)
        {
            throw new NotImplementedException();
        }
    }
}
