using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using ProjectPreparing.Models;
using ProjectPreparing.Project.Core.Models;
using ProjectPreparing.Project.Core.Repositories.Implementations;
using ProjectPreparing.Project.Core.Services;

namespace ProjectPreparing.Controllers
{

    public class CheckoutController : Controller
    {
        private static List<CheckoutViewModel> checkout = new List<CheckoutViewModel>();
        private readonly string connectionString;
        private CheckoutService checkoutService;

        public CheckoutController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            checkoutService = new CheckoutService(new CheckoutRepository(this.connectionString));
        }
        
        public IActionResult Index()
        {
            //List<CartViewModel> cart;
            //using (var connection = new SqlConnection(this.connectionString))
            //{
            //    cart = connection.Query<CartViewModel>("select * from Cart").ToList();
            //}

            //List<CheckoutViewModel> customerInfo;
            return View();
        }

        [HttpPost]
        public IActionResult Index(CheckoutViewModel model)
        {
            var cookie = Request.Cookies["customerCookie"];
            this.checkoutService.PostToOrder(model.Firstname);
            return RedirectToAction("Index");
        }
    }
}