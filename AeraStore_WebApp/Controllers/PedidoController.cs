using Microsoft.AspNetCore.Mvc;

namespace AeraStore_WebApp.Controllers
{
    public class PedidoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}