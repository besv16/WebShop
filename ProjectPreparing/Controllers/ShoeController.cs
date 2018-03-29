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

    public class ShoeController : Controller
    {
        private static List<ShoeViewModel> shoe = new List<ShoeViewModel>();

        private readonly string connectionString;
 
        public ShoeController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IActionResult Index()
        {
            List<ShoeViewModel> shoe;
            using (var connection = new SqlConnection(this.connectionString))
            {
                shoe = connection.Query<ShoeViewModel>("select * from Shoes").ToList();
            }
            return View(shoe);
        }

        // SKAPA COOKIEN HÄR!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        // Testar att lägga in flera produkter (ShoeId) i samma rad i Cart-tabellen 

        [HttpPost]
        public IActionResult Index(CartViewModel model)
        {
                string sql = "INSERT INTO Cart (ShoeId) VALUES (@Id)";
                
                using (var connection = new SqlConnection(this.connectionString))
                {
                  connection.Execute(sql, new { Id = model.Id });
                }

            return RedirectToAction("Index");
        }        

        //public IActionResult CartCounter()
        //{
        //    List<CartViewModel> cart;
        //    using (var connection = new SqlConnection(this.connectionString))
        //    {
        //        cart = connection.Query<CartViewModel>("select * from Cart").ToList();
        //    }

        //    return View(cart);
        //}
    }
}