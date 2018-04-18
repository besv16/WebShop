using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using ProjectPreparing.Project.Core.Models;

namespace ProjectPreparing.Project.Core.Repositories.Implementations
{
    public class CartRepository
    {
        private string ConnectionString;

        public CartRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<CartViewModel> GetAll()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                return connection.Query<CartViewModel>("select Cart.Id, Cart.ShoeId, Shoes.Name, Shoes.Color, Shoes.Price, Shoes.Image from Cart INNER JOIN Shoes ON Cart.ShoeId = Shoes.Id").ToList();
            }
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
