using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public int UnitInStock { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}
