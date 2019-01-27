namespace SoppingCartStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Services.DataServices;
    using System.Threading.Tasks;

    public class CartController : Controller
    {
        private ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult AddToCart(string id)
        {
            // TODO: refactor
            this.cartService.AddToCart(this.User.Identity.Name, id, HttpContext.Session);
            return this.RedirectToAction("Index", "Products");
        }
    }
}
