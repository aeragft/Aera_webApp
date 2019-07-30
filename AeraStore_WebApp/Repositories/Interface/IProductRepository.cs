using AeraStore_WebApp.Models;
using System.Collections.Generic;

namespace AeraStore_WebApp.Repositories.Interface
{
    public interface IProductRepository
    {
        void SaveProducts(List<Product> products);
        IList<Product> GetProducts();
    }
}