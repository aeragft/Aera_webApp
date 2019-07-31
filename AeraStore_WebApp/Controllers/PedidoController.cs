using AeraStore_WebApp.Models;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AeraStore_WebApp.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IItemOrderRespository itemOrderRespository;

        public PedidoController(IOrderRepository orderRepository, 
            IItemOrderRespository itemOrderRespository)
        {
            this.orderRepository = orderRepository;
            this.itemOrderRespository = itemOrderRespository;
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
        public void UpdateQTD([FromBody]ItemOrder itemOrder)
        {
            itemOrderRespository.UpdateQTD(itemOrder);
        }
    }
}