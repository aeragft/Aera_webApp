using AeraStore_WebApp.Models;

namespace AeraStore_WebApp.Repositories.Interface
{
    public interface IItemOrderRespository
    {
        void UpdateQTD(ItemOrder itemOrder);
    }
}
