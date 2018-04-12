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
                List<CartViewModel> cart;
                using (var connection = new SqlConnection(this.connectionString))
                {
                    cart = connection.Query<CartViewModel>("select Cart.Id, Cart.ShoeId, Shoes.Name, Shoes.Color, Shoes.Price, Shoes.Image from Cart INNER JOIN Shoes ON Cart.ShoeId = Shoes.Id").ToList();
                }

                return View(cart);
            }

            [HttpPost]
            public IActionResult Add(ShoeViewModel model)
            {
                var cookie = Request.Cookies["customerCookie"];
                this.cartService.PostToCart(model.Id, cookie);
                return RedirectToAction("Index");
            }
    }
}