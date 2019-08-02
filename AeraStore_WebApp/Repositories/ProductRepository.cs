using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AeraStore_WebApp.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await dbSet.ToListAsync();
        }

        public async Task SaveProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                if(!await dbSet.Where(p => p.Code == product.Code).AnyAsync())
                {
                    await dbSet.AddAsync(new Product(product.Code, product.Name, product.Description, product.Category, product.Cost));
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
