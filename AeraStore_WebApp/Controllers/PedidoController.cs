using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AeraStore_WebApp.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IOrderRepository orderRepository;

        public PedidoController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IActionResult OrderList()
        {
            Order order = orderRepository.GetOrder();
            return View(order); 
        }
        public IActionResult BuyChart(string code)
        {
            if(!string.IsNullOrEmpty(code))
            {
                orderRepository.AddItem(code);
            }
            Order order = orderRepository.GetOrder();
            return View(order.Itens);
        }

        [HttpPost]
        public void UpdateQTD()
        {

        }
    }
}