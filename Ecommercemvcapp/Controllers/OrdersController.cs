using Ecommercemvcapp.Data.Cart;
using Ecommercemvcapp.Data.Services;
using Ecommercemvcapp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercemvcapp.Controllers
{
    public class OrdersController : Controller
    {
        public readonly IMoviesServices _moviServices;
        public readonly ShoppingCart _cart;

        public OrdersController(IMoviesServices moviServices, ShoppingCart cart)
        {
            _moviServices = moviServices;
            _cart = cart;
        }
        public IActionResult Index()
        {
            var items = _cart.GetShoppingCartItems();
            _cart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                shoppingCart = _cart,
                ShoppingCartTotal = _cart.ShoppingitemsTotal()
        };
            return View(response);
        }
    }
}
