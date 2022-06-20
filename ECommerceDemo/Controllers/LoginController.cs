using ECommerceDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDemo.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if(MainModel.Instance.IsLoggedIn)
            {
                MainModel.Instance.IsLoggedIn = false;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            var httpClient = new HttpClient();
            var jsonUser = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44330/api/ECommerce/Login", content);

            if (response.IsSuccessStatusCode)
            {
                MainModel.Instance.IsLoggedIn = true;
                var jsonString = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<User>(jsonString);
                MainModel.Instance.User = value;
                
                return RedirectToAction("Index", "Product");
            }

            MainModel.Instance.IsLoggedIn = false;
            return View(MainModel.Instance);
        }

    }
}
