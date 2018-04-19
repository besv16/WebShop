﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ProjectPreparing.Project.Core.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public Guid CookieId { get; set; }
        
        public string Name { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }
}
