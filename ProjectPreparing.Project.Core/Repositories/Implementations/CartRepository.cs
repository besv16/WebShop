using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;


namespace ProjectPreparing.Project.Core.Repositories.Implementations
{
    public class CartRepository
    {

        private string ConnectionString;

        public CartRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void PostToCart(int Id, string Cookie)
        {
            string sql = "INSERT INTO Cart (ShoeId, CookieId) VALUES (@Id, @cookie)";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Id = Id, Cookie });
            }
        }
    }
}
