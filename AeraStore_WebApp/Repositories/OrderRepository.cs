using AeraStore_WebApp.Models;
using AeraStore_WebApp.Models.ViewModels;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IItemOrderRespository itemOrderRespository;
        private readonly IClientRepository clientRepository;

        public OrderRepository(ApplicationContext context, IHttpContextAccessor contextAccessor, IItemOrderRespository itemOrderRespository, IClientRepository clientRepository) : base(context)
        {
            this.contextAccessor = contextAccessor;
            this.itemOrderRespository = itemOrderRespository;
            this.clientRepository = clientRepository;
        }

        public void AddItem(string code)
        {
            var product = context.Set<Product>()
                .Where(p => p.Code == code)
                .SingleOrDefault();

            if(product == null)
            {
                throw new ArgumentException("Product is Not Found!");
            }

            var order = GetOrder();

            var itemOrder = context.Set<ItemOrder>()
                .Where(i => i.Product.Code == code && i.Order.Id == order.Id)
                .SingleOrDefault();

            if(itemOrder == null)
            {
                itemOrder = new ItemOrder(order, product, 1, product.Cost);
                context.Set<ItemOrder>()
                    .Add(itemOrder);
                context.SaveChanges();
            }

        }

        public Order GetOrder()
        {
            var orderId = GetOrderId();
            var order = dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Product)
                .Include(p => p.Client)
                .Where(o => o.Id == orderId)
                .SingleOrDefault();

            if(order == null)
            {
                order = new Order();
                dbSet.Add(order);
                context.SaveChanges();
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

        public UpDateQTDeResponse UpdateQTD(ItemOrder itemOrder)
        {
            var itemorderDB = itemOrderRespository.GetItemOrder(itemOrder.Id);
            

            if (itemorderDB != null)
            {
                itemorderDB.UpDateQTDe(itemOrder.Quantity);

                if(itemOrder.Quantity == 0)
                {
                    itemOrderRespository.RemoveItemOrder(itemOrder.Id);
                }

                context.SaveChanges();
                var chartViewModel = new ChartViewModel(GetOrder().Itens);

                return new UpDateQTDeResponse(itemorderDB, chartViewModel);
            }

            throw new ArgumentException("ItemOrder not found!");
        }

        public Order UpdateClient(Client client)
        {
            var order = GetOrder();
            clientRepository.UpdateCli(order.Client.Id, client);
            return order;
        }
    }
    
}
