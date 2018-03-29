using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;


namespace ProjectPreparing.Controllers
{

    using ProjectPreparing.Models;

        public class CartController : Controller
        {

            private static List<CartViewModel> cart = new List<CartViewModel>();
            private readonly string connectionString;

            public CartController(IConfiguration configuration)
            {
                this.connectionString = configuration.GetConnectionString("ConnectionString");
            }

            public IActionResult Index()
            {
            List<CartViewModel> cart;
            using (var connection = new SqlConnection(this.connectionString))
            {
                cart = connection.Query<CartViewModel>("select Cart.Id, Cart.ShoeId, Shoes.Name, Shoes.Color, Shoes.Price, Shoes.Image from Cart INNER JOIN Shoes ON Cart.ShoeId = Shoes.Id").ToList();
            }

            return View(cart);
            }

        [HttpPost]
        public IActionResult Index(CheckoutViewModel model)
        {
            List<CheckoutViewModel> order;
            string sql = "INSERT INTO Order (CartId, ) VALUES (@Id, )";
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute(sql, new { Id = model.Id });
            }
            return RedirectToAction("Index", "Checkout");
        }

    }
}