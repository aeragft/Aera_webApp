using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AeraStore_WebApp.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly IProductRepository productRepository;

        public CatalogoController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Catalogo()
        {
            return View(productRepository.GetProducts());
        }
    }
}