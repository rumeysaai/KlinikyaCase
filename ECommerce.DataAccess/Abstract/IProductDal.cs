using ECommerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        public void AddProduct(Product product);

        public void DeleteProduct(Product product);

        public List<Product> GetAll();

        public Product GetProductById(int id);

        public List<Product> ListAllProduct();

        public void UpdateProduct(Product product);
    }
}
