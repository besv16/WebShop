using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ProjectPreparing.Project.Core.Models
{
    public class CartViewModel
    {
        //public List<CartViewModel> Cart { get; set; }
        //From CartViewModel
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public Guid CookieId { get; set; }

        // From ShoeViewModel
        public string Name { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }

        //// From CheckoutViewModel
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        //public string City { get; set; }
        //public string Zipcode { get; set; }
    }
}
