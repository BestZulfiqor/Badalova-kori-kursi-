using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SorPizza.Data;
using SorPizza.Models;

namespace SorPizza.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int pizzaId)
        {
            var pizza = await _context.Pizzas
                .Include(p => p.Sizes)
                .FirstOrDefaultAsync(p => p.Id == pizzaId);

            if (pizza == null)
            {
                return NotFound();
            }

            return View(new Order 
            { 
                OrderItems = new List<OrderItem> 
                { 
                    new OrderItem { PizzaId = pizza.Id, Pizza = pizza, Quantity = 1 } 
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                order.Status = OrderStatus.Pending;
                
                // Рассчитываем общую сумму заказа
                decimal total = 0;
                foreach (var item in order.OrderItems)
                {
                    var pizza = await _context.Pizzas
                        .Include(p => p.Sizes)
                        .FirstOrDefaultAsync(p => p.Id == item.PizzaId);
                    
                    if (pizza != null)
                    {
                        var size = pizza.Sizes.FirstOrDefault(s => s.Name == item.SelectedSize);
                        item.Price = (pizza.Price + (size?.AdditionalPrice ?? 0)) * item.Quantity;
                        total += item.Price;
                    }
                }
                
                order.TotalAmount = total;
                
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("OrderConfirmation", new { id = order.Id });
            }
            
            return View(order);
        }

        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Pizza)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
