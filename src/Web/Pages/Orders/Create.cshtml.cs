using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCartStore.Common.BindingModels.Order;
using ShoppingCartStore.Models;
using ShoppingCartStore.Services.DataServices;

namespace SoppingCartStore.Web.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private IOrderService _orderService;
        private UserManager<Customer> _userManager;

        public CreateModel(IOrderService orderService, UserManager<Customer> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [BindProperty]
        public CreateOrderBindingModel Input { get; set; }

        public IActionResult OnPost()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }
            string customerId = _userManager
                .FindByNameAsync(this.User.Identity.Name).Result.Id;

            _orderService.Create(Input.DeliveryAddress, Input.OrderNote
                , customerId, Input.ItemIds);
            
            return this.RedirectToPage("/Orders/Success");
        }
    }
}