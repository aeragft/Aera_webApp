using System.Collections.Generic;
using System.Linq;
using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;

namespace AeraStore_WebApp.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {

        }

        public IList<Product> GetProducts()
        {
            return dbSet.ToList();
        }

        public void SaveProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                if(!dbSet.Where(p => p.Code == product.Code).Any())
                {
                    dbSet.Add(new Product(product.Code, product.Name, product.Description, product.Category, product.Cost));
                }
            }
            context.SaveChanges();
        }
    }
}
