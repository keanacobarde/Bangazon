using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string PaymentId { get; set; }
        [Required]
        public bool IsOrderOpen { get; set; }
        [Required]
        public ICollection<Product> Products { get; set; }
    }
}
