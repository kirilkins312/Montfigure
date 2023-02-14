using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHPTH.Data;
using SHPTH.Data.Services;
using SHPTH.Data.ViewModels;
using SHPTH.Models;
using SHPTH.Models.Order;
using System.Drawing;
using System.Security.Claims;

namespace SHPTH.Controllers
{
    public class OrdersController : Controller
    {
        public readonly ShoppingCart _shoppingCart;
        public readonly SHPTHContext _context;
        public readonly IOrdersService _orders;

        public OrdersController( ShoppingCart shoppingCart, SHPTHContext context, IOrdersService orders)
        {
            
            _shoppingCart = shoppingCart;
            _context = context;
            _orders = orders;


        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
           

            var orders1 = await _orders.GetOrderByUserIdAndRoleAsync(userId, userRole);
            return View(orders1);
        }

        public IActionResult ShoppingCart()
        {
             var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<RedirectToActionResult> AddToShopingCart(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
               return RedirectToAction("Login", "Account");
            }
            var item = await _context.Cloth
                .FirstOrDefaultAsync(m => m.Id == id);
            if(item != null)
            {
                _shoppingCart.AddItemToCard(item); 
            }
            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _context.Cloth
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _orders.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
           

            return View("OrderCompleted");

           

        }


    }
}
