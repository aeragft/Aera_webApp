using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AeraStore_WebApp.Models
{
    public class Order : BaseModel
    {
        public Order()
        {
            Client = new Client();
        }

        public Order (Client client)
        {
            Client = client;
        }

        public List<ItemOrder> Itens { get; private set; } = new List<ItemOrder>();
        [Required]
        public virtual Client Client { get; private set; }
    }
}