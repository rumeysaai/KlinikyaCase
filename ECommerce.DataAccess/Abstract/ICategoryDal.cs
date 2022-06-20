using ECommerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
