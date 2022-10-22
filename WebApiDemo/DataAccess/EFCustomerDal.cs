using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess
{
    public class EFCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
    }
}
