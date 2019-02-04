namespace SoppingCartStore.Web.Components
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Services.DataServices;
    using System.Threading.Tasks;
    
    public class Wishlist : ViewComponent
    {
        private IWishlistService _wishlistService;
        private UserManager<Customer> _userManager;

        public Wishlist(UserManager<Customer> userManager
            , IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string customerId = (await _userManager
                .FindByNameAsync(this.User.Identity.Name)).Id;
            var models = await _wishlistService
                .FindWishlistProductsByCustomerId(customerId);
            return View(models);
        }
    }
}
