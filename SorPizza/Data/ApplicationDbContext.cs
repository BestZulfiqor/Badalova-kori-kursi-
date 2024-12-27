using Microsoft.EntityFrameworkCore;
using SorPizza.Models;

namespace SorPizza.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PizzaSize> PizzaSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Добавляем начальные данные для категорий
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Классические", Description = "Традиционные пиццы" },
                new Category { Id = 2, Name = "Фирменные", Description = "Особые рецепты" },
                new Category { Id = 3, Name = "Острые", Description = "Для любителей остренького" }
            );

            // Добавляем несколько пицц
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza 
                { 
                    Id = 1, 
                    Name = "Маргарита", 
                    Description = "Томатный соус, моцарелла, базилик", 
                    Price = 89.0m, 
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQWt2tl4rRCdXNhdwV5zC-jf9ki2Ipg_Ceh_Q&s",
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Pizza 
                { 
                    Id = 2, 
                    Name = "Пепперони", 
                    Description = "Томатный соус, пепперони, моцарелла", 
                    Price = 99.0m, 
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSn_BFLxdQLqiqJOtDwS5Jm6D2Mg2OVkMGpGw&s",
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Pizza 
                { 
                    Id = 3, 
                    Name = "Четыре сыра", 
                    Description = "Соус альфредо, моцарелла, горгонзола, пармезан, чеддер", 
                    Price = 109.0m, 
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSwu3kmyVWPPE6ks6GyY6P61nhueZfXkCPa6w&s",
                    IsAvailable = true,
                    CategoryId = 2
                },
                new Pizza 
                { 
                    Id = 4, 
                    Name = "Дьябло", 
                    Description = "Острый томатный соус, пепперони, халапеньо, красный перец", 
                    Price = 105.0m, 
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSeRy4cMBDqKYYkzPUR-kqKsPIBqXYuCxUG_Q&s",
                    IsAvailable = true,
                    CategoryId = 3
                }
            );

            // Добавляем размеры для пицц
            modelBuilder.Entity<PizzaSize>().HasData(
                new PizzaSize { Id = 1, PizzaId = 1, Name = "25 см", SizeInCm = 25, AdditionalPrice = 0 },
                new PizzaSize { Id = 2, PizzaId = 1, Name = "30 см", SizeInCm = 30, AdditionalPrice = 20 },
                new PizzaSize { Id = 3, PizzaId = 1, Name = "35 см", SizeInCm = 35, AdditionalPrice = 40 },
                new PizzaSize { Id = 4, PizzaId = 2, Name = "25 см", SizeInCm = 25, AdditionalPrice = 0 },
                new PizzaSize { Id = 5, PizzaId = 2, Name = "30 см", SizeInCm = 30, AdditionalPrice = 20 },
                new PizzaSize { Id = 6, PizzaId = 2, Name = "35 см", SizeInCm = 35, AdditionalPrice = 40 }
            );
        }
    }
}
