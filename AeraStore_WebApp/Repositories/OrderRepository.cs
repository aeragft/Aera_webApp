using AeraStore_WebApp.Models;
using AeraStore_WebApp.Models.ViewModels;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IItemOrderRespository itemOrderRespository;
        private readonly IClientRepository clientRepository;

        public OrderRepository(ApplicationContext context, 
            IHttpContextAccessor contextAccessor, 
            IItemOrderRespository itemOrderRespository, 
            IClientRepository clientRepository) : base(context)
        {
            this.contextAccessor = contextAccessor;
            this.itemOrderRespository = itemOrderRespository;
            this.clientRepository = clientRepository;
        }

        public async Task AddItem(string code)
        {
            var product = await context.Set<Product>()
                .Where(p => p.Code == code)
                .SingleOrDefaultAsync();

            if(product == null)
            {
                throw new ArgumentException("Product is Not Found!");
            }

            var order = await GetOrder();

            var itemOrder = await context.Set<ItemOrder>()
                                .Where(i => i.Product.Code == code && i.Order.Id == order.Id)
                                .SingleOrDefaultAsync();

            if(itemOrder == null)
            {
                itemOrder = new ItemOrder(order, product, 1, product.Cost);
                await context.Set<ItemOrder>()
                    .AddAsync(itemOrder);

                await context.SaveChangesAsync();
            }

        }

        public async Task<Order> GetOrder()
        {
            var orderId = GetOrderId();
            var order = await dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Product)
                .Include(p => p.Client)
                .Where(o => o.Id == orderId)
                .SingleOrDefaultAsync();

            if(order == null)
            {
                order = new Order();
                dbSet.Add(order);
                await context.SaveChangesAsync();
                SetOrderId(order.Id);
            }
            return order;
        }

        private int? GetOrderId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("orderId");   
        }

        private void SetOrderId(int orderId)
        {
            contextAccessor.HttpContext.Session.SetInt32("orderId", orderId);
        }

        public async Task<UpDateQTDeResponse> UpdateQTD(ItemOrder itemOrder)
        {
            var itemorderDB = await itemOrderRespository.GetItemOrder(itemOrder.Id);
            

            if (itemorderDB != null)
            {
                itemorderDB.UpDateQTDe(itemOrder.Quantity);

                if(itemOrder.Quantity == 0)
                {
                   await itemOrderRespository.RemoveItemOrder(itemOrder.Id);
                }

                await context.SaveChangesAsync();

                var order = await GetOrder();
                var chartViewModel = new ChartViewModel(order.Itens);

                return new UpDateQTDeResponse(itemorderDB, chartViewModel);
            }

            throw new ArgumentException("ItemOrder not found!");
        }

        public async Task<Order> UpdateClient(Client client)
        {
            var order = await GetOrder();
            await clientRepository.UpdateCli(order.Client.Id, client);
            return order;
        }
    }
    
}
