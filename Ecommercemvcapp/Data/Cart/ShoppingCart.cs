using Ecommercemvcapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommercemvcapp.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;

        }
        public void AddItemtoCart(Movie movie)
        {
            var item = _context.ShoppingCartItems.FirstOrDefault(x => x.Id == movie.Id && x.ShoppingCartId==ShoppingCartId);
            if (item==null)
            {
                item = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(item);
            }
            else
            {
                item.Amount++;
            }
            _context.SaveChangesAsync();
        }
        public void RemoveitemFromCart(Movie movie)
        {
            var item = _context.ShoppingCartItems.FirstOrDefault(x => x.Id == movie.Id && x.ShoppingCartId == ShoppingCartId);
            if (item != null)
            {
               if(item.Amount > 1)
                {
                    item.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(item);
                }
                _context.SaveChangesAsync();
            }
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId)
                .Include(x => x.Movie).ToList());
        }

        public double ShoppingitemsTotal()
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).
                Select(n=>n.Movie.Price * n.Amount).Sum();
            return total;   
               
        }
    }
}
