
using ECommerceDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDemo.Controllers
{
    public class RegisterController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User p)
        {
            var httpClient = new HttpClient();
            var jsonUser = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:44330/api/ECommerce/UserRegister", content);

            if (response.IsSuccessStatusCode)
            {
                MainModel.Instance.IsLoggedIn = true;
                MainModel.Instance.User = p;
                return RedirectToAction("Index", "Product");
            }
            MainModel.Instance.IsLoggedIn = false;

            return View(p);

        }
    }
}
