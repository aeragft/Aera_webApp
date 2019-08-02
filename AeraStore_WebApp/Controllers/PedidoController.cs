using AeraStore_WebApp.Models;
using AeraStore_WebApp.Models.ViewModels;
using AeraStore_WebApp.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderList(Client client)   
        {
            if (ModelState.IsValid)
            {
                 
                return View(await orderRepository.UpdateClient(client));
            }
            return RedirectToAction("Client");

            
        }
        public async Task<IActionResult> BuyChart(string code)
        {
            if(!string.IsNullOrEmpty(code))
            {
                await orderRepository.AddItem(code);
            }
            Order order = await orderRepository.GetOrder();
            List<ItemOrder> itens = order.Itens;
            ChartViewModel chartViewModel = new ChartViewModel(itens);
            return View(chartViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<UpDateQTDeResponse> UpdateQTD([FromBody]ItemOrder itemOrder)
        {
            return await orderRepository.UpdateQTD(itemOrder);
        }
    }
}