using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AeraStore_WebApp.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly IProductRepository productRepository;

        public CatalogoController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IActionResult> Catalogo()
        {
            return View(await productRepository.GetProducts());
        }
    }
}