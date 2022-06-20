using ECommerceDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ECommerceDemo.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44330/api/ECommerce/GetAllProducts");
            var jsonString = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            MainModel.Instance.ProductList = values;

            return View(MainModel.Instance);
        }

        public async Task<IActionResult> ProductReadAll(int id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44330/api/ECommerce/GetProductById/" + id);
            var jsonString = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<Product>(jsonString);
            MainModel.Instance.SelectedProduct = value;
            return View(MainModel.Instance);
        }

        public IActionResult AddBasket(int id)
        {
            var p = MainModel.Instance.ProductList.FirstOrDefault(r => r.Id == id);

            if (MainModel.Instance.Basket == null)
                MainModel.Instance.Basket = new List<Product>();
            
            if (p != null)
                MainModel.Instance.Basket.Add(p);
            
            return View("Index", MainModel.Instance);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product pr)
        {
            var httpClient = new HttpClient();
            var jsonProduct = JsonConvert.SerializeObject(pr);
            StringContent content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44330/api/ECommerce/AddProduct", content);

            if (response.IsSuccessStatusCode)
            {
                MainModel.Instance.IsLoggedIn = true;
                MainModel.Instance.SelectedProduct = pr;
                return RedirectToAction("Index", "Product");
            }
            MainModel.Instance.IsLoggedIn = false;

            return View(MainModel.Instance);
        }
    }

}
