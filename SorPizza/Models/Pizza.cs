using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SorPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public string ImageUrl { get; set; } = string.Empty;
        
        public bool IsAvailable { get; set; } = true;
        
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        
        public List<PizzaSize> Sizes { get; set; } = new List<PizzaSize>();
    }

    public class PizzaSize
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // например: "Маленькая", "Средняя", "Большая"
        public int SizeInCm { get; set; } // размер в сантиметрах
        [Column(TypeName = "decimal(18,2)")]
        public decimal AdditionalPrice { get; set; } // дополнительная цена для этого размера
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }
    }
}
