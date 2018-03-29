using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPreparing.Models
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
    }
}
