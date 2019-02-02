using Microsoft.AspNetCore.Mvc;
using ShoppingCartStore.Common.ViewModels.Cart;
using ShoppingCartStore.Services.DataServices;
using System.Threading.Tasks;

namespace SoppingCartStore.Web.Components
{
    public class Cart : ViewComponent
    {
        private ICartService _cartService;

        public Cart(ICartService cartService)
        {
            this._cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CartComponentViewModel();

            viewModel.ItemsCount = _cartService
                .GetProductCountFromSession(HttpContext.Session);

            return View(viewModel);
        }
    }
}
