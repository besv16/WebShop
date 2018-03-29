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

    public class CheckoutController : Controller
    {
        private static List<CartViewModel> cart = new List<CartViewModel>();
        private readonly string connectionString;

        public CheckoutController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IActionResult Index()
        {
            List<CartViewModel> cart;
            using (var connection = new SqlConnection(this.connectionString))
            {
                cart = connection.Query<CartViewModel>("select * from Cart INNER JOIN Shoes ON Cart.ShoeId = Shoes.Id").ToList();
            }
            return View(cart);
        }

        //[HttpPost]
        //public IActionResult Index(CheckoutViewModel model)
        //{
        //    List<CheckoutViewModel> checkout;
        //    string sql = "INSERT INTO Order (CartId) VALUES (@)";
        //    using (var connection = new SqlConnection(this.connectionString))
        //    {

        //        //connection.Execute(sql, new { Id = model.Id });
        //    }

        //    return RedirectToAction("Index");
        //}
        
    }
}