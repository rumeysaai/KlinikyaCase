using ECommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using var ec = new EcommerceContext();
            ec.Remove(entity);
            ec.SaveChanges();
        }

        public List<T> GetListAll()
        {
            using var ec = new EcommerceContext();
            return ec.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var ec = new EcommerceContext();
            return ec.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            using var ec = new EcommerceContext();
            ec.Add(entity);
            ec.SaveChanges();
        }
        
        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var ec = new EcommerceContext();
            return ec.Set<T>().Where(filter).ToList();
        }

        public void Update(T entity)
        {
            using var ec = new EcommerceContext();
            ec.Update(entity);
            ec.SaveChanges();
        }
    }
}
