namespace SoppingCartStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Services.DataServices;
    using System.Threading.Tasks;

    public class WishlistController : Controller
    {
        private IWishlistService _wishlistService;
        private UserManager<Customer> _userManager;

        public WishlistController(UserManager<Customer> userManager
            , IWishlistService wishlistService)
        {
            _userManager = userManager;
            _wishlistService = wishlistService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AddToWishlist(string id)
        {
            string customerId = (await _userManager
                .FindByNameAsync(this.User.Identity.Name)).Id;

            if (await _wishlistService.DoesProductAlreadyExist(id, customerId))
            {
                return this.RedirectToAction("ProductExistsErrorPage", "Wishlist");
            }

            await _wishlistService.AddToWishlistAsync(id, customerId);
            return this.RedirectToAction("Index", "Products");
        }

        public IActionResult ProductExistsErrorPage()
        {
            return View();
        }
    }
}
