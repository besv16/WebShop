using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using ProjectPreparing.Project.Core.Models;

namespace ProjectPreparing.Project.Core.Repositories.Implementations
{
    public class CheckoutRepository
    {
        private string ConnectionString;

        public CheckoutRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<CheckoutViewModel> GetAll()
        {
            //List<CheckoutViewModel> cart;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<CheckoutViewModel>("select * from cart").ToList();
            }
        }

        public void PostToOrder(string Firstname, string Lastname, string Email, int Phone, string City, int Zipcode, string cookie)
        {
            string sql = @"INSERT INTO Orders 
                         (Firstname, Lastname, Email, Phone, City, Zipcode, CookieId) 
                         VALUES 
                         (@Firstname, @Lastname, @Email, @Phone, @City, @Zipcode, @cookie)";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Firstname, Lastname, Email, Phone, City, Zipcode, cookie });
            }
        }
    }
}
