using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories
{
    public class ItemOrderRespository : BaseRepository<ItemOrder>, IItemOrderRespository
    {

        public ItemOrderRespository(ApplicationContext context) : base(context)
        {
        }

        public async Task<ItemOrder> GetItemOrder(int itemOrderId)
        {
            return
                await  dbSet
                        .Where(ip => ip.Id == itemOrderId)
                        .SingleOrDefaultAsync();
        }

        public async Task RemoveItemOrder(int itemOrderId)
        {
            dbSet.Remove(await GetItemOrder(itemOrderId));
        }
    }
}
