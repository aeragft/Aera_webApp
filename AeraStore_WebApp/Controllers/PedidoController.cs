using Microsoft.AspNetCore.Mvc;

namespace AeraStore_WebApp.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult OrderList()
        {
            return View();
        }
    }
}