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
using Microsoft.AspNetCore.Http;


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
            this.checkoutService = new CheckoutService(new CheckoutRepository(this.connectionString), new CartRepository(this.connectionString));
        }

        public IActionResult Index()
        {
            var cartId = Request.Cookies["customerCookie"];
            var Cart = this.checkoutService.GetAll(cartId);
            //var cart = this.checkoutService.GetAll();
            //return View(cart);
            return View(Cart);
        }

        [HttpPost]
        public IActionResult Index(CheckoutViewModel model, string cookie, string customerCookie)
        {
            this.checkoutService.PostToOrder(model.Firstname, model.Lastname, model.Email, model.Phone, model.City, model.Zipcode, Request.Cookies["customerCookie"]);
            
            // DELETE CART, UNSET COOKIE
            cookie = Request.Cookies["customerCookie"];
            this.checkoutService.DeleteCart(cookie);

            return RedirectToAction("Index");
        }

    }
}