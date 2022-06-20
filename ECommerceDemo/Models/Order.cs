﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDemo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public User User { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
