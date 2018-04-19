using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPreparing.Project.Core.Models
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }

        public List<CartViewModel> Cart { get; set; }
    }
}

