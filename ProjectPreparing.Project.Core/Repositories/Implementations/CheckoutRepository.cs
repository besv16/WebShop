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

        public void PostToOrder(string Firstname, string Lastname, string Email, int Phone, string City, int Zipcode)
        {
            // I samma SQL-sats ska vi göra en SELECT-sats som hämtar ut ID ifrån Order-tabellen
            string sql = @"INSERT INTO Orders 
                         (Firstname, Lastname, Email, Phone, City, Zipcode) 
                         VALUES 
                         (@Firstname, @Lastname, @Email, @Phone, @City, @Zipcode)";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(sql, new { Firstname, Lastname, Email, Phone, City, Zipcode });
            }
        }
    }
}
