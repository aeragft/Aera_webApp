using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;

namespace AeraStore_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public HomeController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Bem Vindo a Sua pagina Inicial Aera Store";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Sua Pagina de Privacidade!";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Client()
        {
            var order = orderRepository.GetOrder();
            if (order == null)
            {
                return RedirectToAction("Catalogo");
            }
            return View();
        }
    }
}
