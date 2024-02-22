using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int QuantityAvailable { get; set; }
        public float Price { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
