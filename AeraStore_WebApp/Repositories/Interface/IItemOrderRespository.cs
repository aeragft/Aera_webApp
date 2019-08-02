using AeraStore_WebApp.Models;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Repositories.Interface
{
    public interface IItemOrderRespository
    {
        Task<ItemOrder> GetItemOrder(int itemOrderId);
        Task RemoveItemOrder(int itemOrderId);
    }
}
