using Microsoft.AspNetCore.Mvc;
using ShoppingCartStore.Common.ViewModels.Cart;
using ShoppingCartStore.Services.DataServices;
using System.Threading.Tasks;

namespace SoppingCartStore.Web.Components
{
    public class Cart : ViewComponent
    {
        private ICartService cartService;

        public Cart(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CartComponentViewModel();
            viewModel.ItemsCount = this.cartService.GetProductCountFromSession(HttpContext.Session);
            return View(viewModel);
        }
    }
}
