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
        private int? GetPedido()
        {
            return contextAccessor.HttpContext.Session.GetInt32("orderId");   
        }

        private void SetOrder(int orderId)
        {
            contextAccessor.HttpContext.Session.SetInt32("orderId", orderId);
        }
    }
}
