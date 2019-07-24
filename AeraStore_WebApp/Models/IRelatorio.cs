using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AeraStore_WebApp.Models
{
    public interface IRelatorio
    {
        Task ImprimirAsync(HttpContext context);
    }
}