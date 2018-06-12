using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class ClientRepository : IClientRepository
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
