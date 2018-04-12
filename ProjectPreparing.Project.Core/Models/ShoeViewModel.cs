using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ProjectPreparing.Project.Core.Models
{
    using ProjectPreparing.Project.Core.Models;
    public class ShoeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
    }
}