using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCartStore.Common.BindingModels.Order;
using ShoppingCartStore.Services.DataServices;

namespace SoppingCartStore.Web.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private IItemService _itemService;

        public CreateModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        [BindProperty]
        public CreateOrderBindingModel Input { get; set; }

        public IActionResult OnPost()
        {
            // TODO: implement persistence

            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            return this.RedirectToPage("/Orders/Index");
        }
    }
}