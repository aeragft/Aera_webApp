using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeraStore_WebApp.Models;

namespace AeraStore_WebApp.Repositories.Interface
{
    public interface IOrderRepository
    {
        Order GetOrder();
        void AddItem(string code);
        UpDateQTDeResponse UpdateQTD(ItemOrder itemOrder);
        Order UpdateClient(Client client);

    }
}
