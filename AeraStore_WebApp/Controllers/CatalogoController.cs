using Microsoft.AspNetCore.Mvc;

namespace AeraStore_WebApp.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Catalogo()
        {
            ViewData["Message"] = "Sua Janela de Catalogo";

            return View();
        }
    }
}