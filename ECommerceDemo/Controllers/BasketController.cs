using ECommerceDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDemo.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View(MainModel.Instance);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Order pr)
        {
            var httpClient = new HttpClient();
            var jsonOrder = JsonConvert.SerializeObject(MainModel.Instance.Basket);
            StringContent content = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44330/api/ECommerce/CreateOrder", content);

            if (response.IsSuccessStatusCode)
            {
                return View("SuccessView", MainModel.Instance);
            }

            return View(MainModel.Instance);

        }

    }
}
