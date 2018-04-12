using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace ProjectPreparing.Project.Core.Repositories.Implementations
{
    public class CheckoutRepository
    {
        private string ConnectionString;

        public CheckoutRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void PostToOrder(string Firstname)
        {
            string sql = "INSERT INTO Orders (Firstname) VALUES (@Firstname)";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Firstname });
            }
        }
    }
}
