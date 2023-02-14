using Microsoft.EntityFrameworkCore;
using SHPTH.Models.Order;

namespace SHPTH.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly SHPTHContext _context;
        public OrdersService(SHPTHContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Cloths).Include(n => n.User).ToListAsync();

            if(userRole != "Admin")
            {
                 orders =  orders.Where(x => x.UserId== userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order); 
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ClothId = item.Cloth.Id,
                    OrderId = order.ID,
                    Price  = item.Cloth.Price

                };
                await _context.OrderItems.AddAsync(orderItem);
                
            }
            await _context.SaveChangesAsync();
        }
    }
}
