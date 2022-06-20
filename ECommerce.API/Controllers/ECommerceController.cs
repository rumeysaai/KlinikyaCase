using ECommerce.DataAccess.Abstract;
using ECommerce.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommerceController : ControllerBase
    {
        private readonly IProductDal productDal;
        private readonly ICategoryDal categoryDal;
        private readonly IUserDal userDal;
        private readonly IOrderDal orderDal;

        public ECommerceController(IProductDal productDal, ICategoryDal categoryDal, IUserDal userDal, IOrderDal orderDal)
        {
            this.productDal = productDal;
            this.categoryDal = categoryDal;
            this.userDal = userDal;
            this.orderDal = orderDal;
        }

        [HttpGet("GetAllProducts")]
        public List<Product> GetAllProducts()
        {
            return productDal.ListAllProduct();
        }

        [HttpGet("GetProductById/{Id}")]
        public Product GetProductById(int Id)
        {
            return productDal.GetProductById(Id);
        }

        [HttpPost("UserRegister")]
        public IActionResult UserRegister(User user)
        {
            userDal.Insert(user);
            return Ok(user);
        }

        [HttpGet("GetAllCategories")]
        public List<Category> GetAllCategories()
        {
            return categoryDal.GetListAll();
        }
        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            var u = userDal.GetListAll().Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (u == null)
            {
                return BadRequest();
            }

            return Ok(u);
        }
        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(List<Product> productList)
        {
            Order order = new Order();

            try
            {
                double total = 0;

                foreach (var item in productList)
                {
                    total += item.Price;
                }

                order.TotalPrice = total;
                orderDal.Insert(order);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(order);
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            productDal.Insert(product);
            return Ok(product);
        }
    }

}
