using ECommerce.DataAccess.Abstract;
using ECommerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework
{
    public class ProductRepository : IProductDal
    {
        public void AddProduct(Product product)
        {
            using var ec = new EcommerceContext();
            ec.Add(product);
            ec.SaveChanges();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            using var ec = new EcommerceContext();
            ec.Remove(product);
            ec.SaveChanges();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetListAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            using var ec = new EcommerceContext();
            return ec.Products.Find(id);
        }

        public void Insert(Product entity)
        {
            using var ec = new EcommerceContext();
            ec.Add(entity);
            ec.SaveChanges();
            
        }

        public List<Product> ListAllProduct()
        {
            using var ec = new EcommerceContext();
            return ec.Products.ToList();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            using var ec = new EcommerceContext();
            ec.Update(product);
            ec.SaveChanges();
        }
       
    }
}
