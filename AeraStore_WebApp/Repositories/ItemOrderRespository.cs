using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories
{
    public class ItemOrderRespository : BaseRepository<ItemOrder>, IItemOrderRespository
    {

        private readonly IItemOrderRespository itemOrderRespository;

        public ItemOrderRespository(ApplicationContext context) : base(context)
        {
        }

        public ItemOrder GetItemOrder(int itemOrderId)
        {
            return
            dbSet
                .Where(ip => ip.Id == itemOrderId)
                .SingleOrDefault();
        }
    }
}
