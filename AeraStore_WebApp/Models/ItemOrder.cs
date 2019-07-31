using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AeraStore_WebApp.Models
{
    [DataContract]
    public class ItemOrder : BaseModel
    {
        [Required]
        [DataMember]
        public Order Order { get; private set; }
        [Required]
        [DataMember]
        public Product Product { get; private set; }
        [Required]
        [DataMember]
        public int Quantity { get; private set; }
        [Required]
        [DataMember]
        public decimal UniValue { get; set; }

        public ItemOrder() { }

        public ItemOrder(Order order, Product product, int quantity, decimal uniValue)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
            UniValue = uniValue;
            
        }
    }
}