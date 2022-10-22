using WebApiDemo.Entities;
using WebApiDemo.Models;

namespace WebApiDemo.DataAccess
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<Order> GetCustomerOrders(string CustomerID);
    }
}
