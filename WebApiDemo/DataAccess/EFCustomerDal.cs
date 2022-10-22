using WebApiDemo.Entities;
using WebApiDemo.Models;

namespace WebApiDemo.DataAccess
{
    public class EFCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
        public List<Order> GetCustomerOrders(string CustomerID)
        {
            using (var context = new NorthwindContext())
            {
                var result = from p in context.Customers
                             join o in context.Orders
                             on p.CustomerID equals o.CustomerID
                             where p.CustomerID == CustomerID
                             select o;
                return result.ToList();
            }
        }
    }
}
