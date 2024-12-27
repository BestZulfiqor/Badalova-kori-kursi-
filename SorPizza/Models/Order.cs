using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SorPizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Required]
        public string Address { get; set; } = string.Empty;
        
        public DateTime OrderDate { get; set; } = DateTime.Now;
        
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        
        public string? Comments { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }
        public int Quantity { get; set; }
        public string SelectedSize { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Preparing,
        OnDelivery,
        Delivered,
        Cancelled
    }
}
