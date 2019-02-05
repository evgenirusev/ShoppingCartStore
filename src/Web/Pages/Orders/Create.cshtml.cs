using Microsoft.AspNetCore.Authorization;
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
        ICustomerService _customerService;

        public CreateModel(IProductService productService
            , UserManager<Customer> userManager, ICartService cartService,
            IOrderService orderService, ICustomerService customerService)
        {
            _productService = productService;
            _userManager = userManager;
            _cartService = cartService;
            _orderService = orderService;
            _customerService = customerService;
        }

        [BindProperty]
        public CartViewModel Input { get; set; }

        [Authorize]
        public async Task OnGet()
        {
            await this.InitModel();
        }

        [Authorize]
        public async Task<IActionResult> OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToPage();
            }

            var customer = _userManager.FindByNameAsync(this.User.Identity.Name).Result;

            await _orderService.CreateAsync(Input.CreateOrderBindingModel.DeliveryAddress,
                Input.CreateOrderBindingModel.OrderNote
                , customer.Id, Input.CreateOrderBindingModel.ItemIds);

            await _customerService.SubtractBalance(Input.Price, customer);

            await _cartService.DeletePersistedCartByCustomerId(customer.Id);

            _cartService.ClearSessionCart(HttpContext.Session);

            return this.RedirectToPage("/Orders/Success");
        }

        private async Task InitModel()
        {
            var customer = await _userManager.FindByNameAsync(this.User.Identity.Name);
            this.Input = _cartService.GetCartViewModelByCustomerId(customer.Id);
            this.Input.CustomerBalance = customer.Balance;
        }
    }
}