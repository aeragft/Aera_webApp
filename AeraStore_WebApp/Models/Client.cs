
using System.ComponentModel.DataAnnotations;

namespace AeraStore_WebApp.Models
{
    public class Client : BaseModel
    {
        public Client() { }

        public virtual Order Order {get; set;}
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Telephone { get; set; } = "";
        [Required]
        public string Address { get; set; } = "";
        [Required]
        public string Complement { get; set; } = "";
        [Required]
        public string Neighborhood { get; set; } = "";
        [Required]
        public string County { get; set; } = "";
        [Required]
        public string State { get; set; } = "";
        [Required]
        public string Zipcode { get; set; } = "";




    }
}
