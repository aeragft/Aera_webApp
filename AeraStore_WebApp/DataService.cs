using AeraStore_WebApp.Repositories;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

        public void SetupInitialDB()
        {
            context.Database.Migrate();
        }
    }
}
