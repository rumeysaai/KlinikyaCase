using ECommerce.DataAccess.Abstract;
using ECommerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework
{
    public class OrderRepository:GenericRepository<Order>, IOrderDal

    {
    }
}
