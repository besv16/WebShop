using Dapper;
using ProjectPreparing.Project.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjectPreparing.Project.Core.Repositories.Implementations
{
    public class ShoeRepository : IShoeRepository
    {

        private string ConnectionString;

        public ShoeRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<ShoeViewModel> GetAll()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<ShoeViewModel>("select * from Shoes").ToList();
            }
        }
    }
}
