using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPreparing.Project.Core.Models
{
    class CheckoutRowViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ShoeId { get; set; }
        public string ShoeName { get; set; }
        public int ShoePrice {get; set; }
        public Guid CookieId { get; set; }
    }
}
