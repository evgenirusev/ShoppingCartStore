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

        public async Task<IActionResult> AddToCart(string id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                await this.cartService.AddToPersistedCart(id, this.User.Identity.Name);
            }
            else
            {
                this.cartService.AddToSessionCart(id, HttpContext.Session);
            }

            return this.RedirectToAction("Index", "Products");
        }
    }
}
