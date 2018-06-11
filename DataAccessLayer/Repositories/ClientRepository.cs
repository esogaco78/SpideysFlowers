using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BusinessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class ClientRepository : IClientInterface
    {
        public List<Client> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                return db.Query<Client>("GetClients", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
