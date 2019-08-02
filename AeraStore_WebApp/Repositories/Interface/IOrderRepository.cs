using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeraStore_WebApp.Models;

namespace AeraStore_WebApp.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<Order> GetOrder();
        Task AddItem(string code);
        Task<UpDateQTDeResponse> UpdateQTD(ItemOrder itemOrder);
        Task<Order> UpdateClient(Client client);

    }
}
