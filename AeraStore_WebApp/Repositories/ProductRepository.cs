using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;

namespace AeraStore_WebApp.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
