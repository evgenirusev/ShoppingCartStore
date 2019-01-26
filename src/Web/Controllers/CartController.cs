namespace SoppingCartStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Services.DataServices;

    public class CartController : Controller
    {
        private ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult AddToCart(string id)
        {
            this.cartService.AddToCart(null, id, HttpContext.Session);
            return this.RedirectToAction("Index", "Products");
        }
    }
}
