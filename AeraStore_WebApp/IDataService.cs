using System.Threading.Tasks;

namespace AeraStore_WebApp
{
    public interface IDataService
    {
        Task SetupInitialDB();
    }
}