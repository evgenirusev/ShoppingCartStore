namespace SoppingCartStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Common.Constants;
    using ShoppingCartStore.Common.ViewModels.Cart;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Services.DataServices;
    using System.Threading.Tasks;

    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<Customer> _userManager;
        private IOrderService _orderService;
        private ICustomerService _customerService;

        public CartController(ICartService cartService, UserManager<Customer> userManager, 
            IOrderService orderService, ICustomerService customerService)
        {
            _cartService = cartService;
            _userManager = userManager;
            _orderService = orderService;
            _customerService = customerService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var customer = _userManager
                .FindByNameAsync(this.User.Identity.Name).Result;
            var cartViewModel = _cartService.GetCartViewModelByCustomerId(customer.Id);
            cartViewModel.CustomerBalance = customer.Balance;
            return View(cartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CartViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(ActionConstants.Index, ActionConstants.Cart);
            }

            var customer = _userManager
                .FindByNameAsync(this.User.Identity.Name).Result;

            await _orderService.CreateAsync(model.CreateOrderBindingModel.DeliveryAddress
                , model.CreateOrderBindingModel.OrderNote
                , customer.Id, model.CreateOrderBindingModel.ItemIds);

            await _customerService.SubtractBalance(model.Price, customer);

            await _cartService.DeletePersistedCartByCustomerId(customer.Id);

            _cartService.ClearSessionCart(HttpContext.Session);

            return this.RedirectToPage(PageConstants.OrdersSuccess);
        }

        public async Task<IActionResult> AddToCart(string id)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                await _cartService.AddToPersistedCartAsync(id, this.User.Identity.Name);
            }

            await _cartService.AddToSessionCartAsync(id, HttpContext.Session);
            return this.RedirectToAction(ActionConstants.Index, ActionConstants.Products);
        }

        public async Task<IActionResult> RemoveFromCart(string id)
        {
            string customerId = _userManager
                .FindByNameAsync(this.User.Identity.Name).Result.Id;
            await _cartService.RemoveItemFromCartAsync(id, customerId, HttpContext.Session);
            return this.RedirectToAction(ActionConstants.Index, ActionConstants.Cart);
        }
    }
}
