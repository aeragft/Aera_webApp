using AeraStore_WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories.Interface
{
    public interface IProductRepository
    {
        Task SaveProducts(List<Product> products);
        Task<IList<Product>> GetProducts();
    }
}