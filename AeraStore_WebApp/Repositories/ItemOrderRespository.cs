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

        public void UpdateQTD(ItemOrder itemOrder)
        {
            var itemorderDB =
            dbSet
                .Where(ip => ip.Id == itemOrder.Id)
                .SingleOrDefault();

            if(itemorderDB != null)
            {
                itemorderDB.UpDateQTDe(itemOrder.Quantity);
                context.SaveChanges();
            }
        }
    }
}
