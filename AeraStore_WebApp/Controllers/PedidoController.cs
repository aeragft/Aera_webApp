using AeraStore_WebApp.Models;
using AeraStore_WebApp.Models.ViewModels;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult OrderList(Client client)   
        {
            if (ModelState.IsValid)
            {
                Order order = orderRepository.UpdateClient(client);
                return View(order);
            }
            return RedirectToAction("Client");

            
        }
        public IActionResult BuyChart(string code)
        {
            if(!string.IsNullOrEmpty(code))
            {
                orderRepository.AddItem(code);
            }
            List<ItemOrder> itens = orderRepository.GetOrder().Itens;
            ChartViewModel chartViewModel = new ChartViewModel(itens);
            return View(chartViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public UpDateQTDeResponse UpdateQTD([FromBody]ItemOrder itemOrder)
        {
            return orderRepository.UpdateQTD(itemOrder);
        }
    }
}