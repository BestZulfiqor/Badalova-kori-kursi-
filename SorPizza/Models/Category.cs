using System.ComponentModel.DataAnnotations;

namespace SorPizza.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
