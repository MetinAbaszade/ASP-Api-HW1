using WebApiDemo.Entities;
using WebApiDemo.Models;

namespace WebApiDemo.DataAccess
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductModel> GetProductWithDetails();
    }
}
