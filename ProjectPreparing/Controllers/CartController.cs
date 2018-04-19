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

    public class CartController : Controller
        {
            private static List<CartViewModel> cart = new List<CartViewModel>();
            private readonly string connectionString;
            private CartService cartService;

            public CartController(IConfiguration configuration)
            {
                this.connectionString = configuration.GetConnectionString("ConnectionString");
                this.cartService = new CartService(
                new CartRepository(
                configuration.GetConnectionString("ConnectionString")));
            }
 
            public IActionResult Index()
            {
                var cartId = Request.Cookies["customerCookie"];
                var cart = this.cartService.GetAll(cartId);
                return View(cart);
            }

            [HttpPost]
            public IActionResult Add(ShoeViewModel model)
            {
                var cookie = Request.Cookies["customerCookie"];
                this.cartService.PostToCart(model.Id, cookie);
                return RedirectToAction("Index", "Shoe");
            }

            //[HttpPost]
            //public IActionResult Delete(CartViewModel model)
            //{
            //    var cookie = Request.Cookies["customerCookie"];
            //    this.cartService.DeleteCart(model.Id, cookie);
            //    return RedirectToAction("Index", "Shoe");
            //}
    }
}