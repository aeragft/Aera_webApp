using System.ComponentModel.DataAnnotations;

namespace AeraStore_WebApp.Models
{
    public class ItemOrder : BaseModel
    {
        [Required]
        public Order Order { get; private set; }
        [Required]
        public Product Product { get; private set; }
        [Required]
        public int Quantity { get; private set; }
        [Required]
        public decimal Value { get; set; }

        public ItemOrder() { }

        public ItemOrder(Order order, Product product, int quantity, decimal value)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
            Value = value;
            
        }
    }
}