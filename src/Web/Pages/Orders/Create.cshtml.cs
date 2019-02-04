using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCartStore.Common.ViewModels.Cart;
using ShoppingCartStore.Models;
using ShoppingCartStore.Services.DataServices;
using System.Threading.Tasks;

namespace SoppingCartStore.Web.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private IProductService _productService;
        private UserManager<Customer> _userManager;
        private ICartService _cartService;
        private IOrderService _orderService;

        public CreateModel(IProductService productService
            , UserManager<Customer> userManager, ICartService cartService,
            IOrderService orderService)
        {
            _productService = productService;
            _userManager = userManager;
            _cartService = cartService;
            _orderService = orderService;
        }

        [BindProperty]
        public CartViewModel Input { get; set; }

        public async Task OnGet()
        {
            await this.InitModel();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            string customerId = _userManager
                .FindByNameAsync(this.User.Identity.Name).Result.Id;

            await _orderService.CreateAsync(Input.CreateOrderBindingModel.DeliveryAddress,
                Input.CreateOrderBindingModel.OrderNote
                , customerId, Input.CreateOrderBindingModel.ItemIds);

            _cartService.ClearSessionCart(HttpContext.Session);

            return this.RedirectToPage("/Orders/Success");
        }

        private async Task InitModel()
        {
            var customer = await _userManager.FindByNameAsync(this.User.Identity.Name);
            this.Input.CustomerBalance = customer.Balance;
            this.Input = _cartService.GetCartViewModelByCustomerId(customer.Id);
        }
    }
}