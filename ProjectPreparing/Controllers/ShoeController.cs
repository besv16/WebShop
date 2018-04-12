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
    using ProjectPreparing.Project.Core.Models;
    using ProjectPreparing.Project.Core.Repositories.Implementations;
    using ProjectPreparing.Project.Core.Services;

    public class ShoeController : Controller
    {
        private static List<ShoeViewModel> shoe = new List<ShoeViewModel>();

        private readonly ShoeService shoeService;

        public ShoeController(IConfiguration configuration)
        {
            this.shoeService = new ShoeService(
                new ShoeRepository(
                configuration.GetConnectionString("ConnectionString")));
        }

        public IActionResult Index()
        {
            List<ShoeViewModel> shoe;
            shoe = this.shoeService.GetAll();

            if (Request.Cookies["customerCookie"] == null)
            {
                var GuId = Guid.NewGuid();
                Response.Cookies.Append("customerCookie", GuId.ToString());
            }

            return View(shoe);
        }
    }
}