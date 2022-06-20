using System.Collections.Generic;

namespace ECommerceDemo.Models
{
    public class MainModel
    {
        public static MainModel Instance { get; set; }
        static MainModel()
        {
            Instance = new MainModel();
            Instance.User = new User();
        }
        public User User { get; set; }
        public List<Product> ProductList { get; set; }

        public Product SelectedProduct { get; set; }

        public List<Category> CategoryList { get; set; }

        public bool IsLoggedIn { get; set; }

        public List<Product> Basket { get; set; }
        public Order Order { get; set; }

    }
}
