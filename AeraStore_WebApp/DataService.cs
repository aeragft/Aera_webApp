using AeraStore_WebApp.Repositories;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AeraStore_WebApp
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;
        private readonly IProductRepository productRepository;

        public DataService(ApplicationContext context, IProductRepository productRepository)
        {
            this.context = context;
            this.productRepository = productRepository;
        }

        public async Task SetupInitialDB()
        {
            await context.Database.MigrateAsync();
        }
    }
}
