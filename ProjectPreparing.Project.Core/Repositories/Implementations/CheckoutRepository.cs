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
        private readonly CheckoutRepository checkoutRepository;

        public CheckoutRepository(CheckoutRepository checkoutRepository)
        {
            this.checkoutRepository = checkoutRepository;
        }

        private string ConnectionString;

        public CheckoutRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
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

        public void DeleteCart(string cookie)
        {
            string sql2 = "DELETE FROM Cart WHERE CookieId = @cookie";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql2, new { cookie });
            }
        }
    }
}
