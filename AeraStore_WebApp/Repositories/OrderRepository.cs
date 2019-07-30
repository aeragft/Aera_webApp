using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        public OrderRepository(ApplicationContext context, IHttpContextAccessor contextAccessor) : base(context)
        {
            this.contextAccessor = contextAccessor;
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
            var order = dbSet.
                Where(o => o.Id == orderId)
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
    }
}
