using System.ComponentModel.DataAnnotations;

namespace AeraStore_WebApp.Models
{
    public class Product : BaseModel
    {
        public Product()
        {

        }

        [Required]
        public string Code { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal UnitaryValue { get; set; }

        public Product(string code, string name,string description, string category, decimal unitaryValue)
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;
            this.Category = category;
            this.UnitaryValue = unitaryValue;
        }

    }
}
