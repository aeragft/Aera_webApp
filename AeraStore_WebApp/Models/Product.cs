using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AeraStore_WebApp.Models
{
    public class Product : BaseModel
    {
        public Product()
        {

        }

        [Required]
        public string Code { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Cost { get; set; }

        public Product(string code, string name,string description, string category, decimal cost)
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;
            this.Category = category;
            this.Cost = cost;
        }
    }
}
