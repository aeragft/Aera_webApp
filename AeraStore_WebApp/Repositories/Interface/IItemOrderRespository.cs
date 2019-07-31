using AeraStore_WebApp.Models;

namespace AeraStore_WebApp.Repositories.Interface
{
    public interface IItemOrderRespository
    {
        ItemOrder GetItemOrder(int itemOrderId);
    }
}
