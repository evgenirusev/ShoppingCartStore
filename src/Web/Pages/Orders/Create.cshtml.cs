using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCartStore.Common.BindingModels.Order;
using ShoppingCartStore.Models;
using ShoppingCartStore.Services.DataServices;
using System.Threading.Tasks;

namespace SoppingCartStore.Web.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private IOrderService _orderService;
        private UserManager<Customer> _userManager;
        private ICartService _cartService;

        public CreateModel(IOrderService orderService
            , UserManager<Customer> userManager, ICartService cartService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _cartService = cartService;
        }

        [BindProperty]
        public CreateOrderBindingModel Input { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            string customerId = _userManager
                .FindByNameAsync(this.User.Identity.Name).Result.Id;

            await _orderService.CreateAsync(Input.DeliveryAddress, Input.OrderNote
                , customerId, Input.ItemIds);

            _cartService.ClearSessionCart(HttpContext.Session);

            return this.RedirectToPage("/Orders/Success");
        }
    }
}