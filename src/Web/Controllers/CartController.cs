namespace SoppingCartStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Services.DataServices;
    using System.Threading.Tasks;

    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<Customer> _userManager;

        public CartController(ICartService cartService, UserManager<Customer> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            string customerId = _userManager
                .FindByNameAsync(this.User.Identity.Name).Result.Id;
            var cartViewModel = _cartService.GetCartViewModelByCustomerId(customerId);
            return View(cartViewModel);
        }

        public async Task<IActionResult> AddToCart(string id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                await _cartService.AddToPersistedCart(id, this.User.Identity.Name);
            }
            await _cartService.AddToSessionCart(id, HttpContext.Session);
            return this.RedirectToAction("Index", "Products");
        }
    }
}
