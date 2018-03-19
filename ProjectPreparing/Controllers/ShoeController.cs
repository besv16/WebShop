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

        [HttpPost]
        public IActionResult Index(ShoeViewModel model)
        {
            List<ShoeViewModel> shoe;
            string sql = "INSERT INTO Cart (Name, Color, Price, Image) VALUES (@Name, @Color, @Price, @Image)";
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute(sql, new { Name = model.Name, Color = model.Color, Price = model.Price, Image = model.Image });
            }

            return View();
        }
    }
}