using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCartStore.Common.ViewModels.Order;
using ShoppingCartStore.Models;
using ShoppingCartStore.Services.DataServices;

namespace SoppingCartStore.Web.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private UserManager<Customer> _userManager;
        private IOrderService _orderService;

        public IndexModel(UserManager<Customer> userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
        }

        public List<OrderViewModel> ViewModels { get; set; }

        public async Task OnGetAsync()
        {
            await this.InitViewModels();
        }

        private async Task InitViewModels()
        {
            string id = (await _userManager
                .FindByNameAsync(this.User.Identity.Name)).Id;
            this.ViewModels = (await _orderService.GetAllOrdersAsync(id)).ToList();
        }
    }
}