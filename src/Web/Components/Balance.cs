namespace SoppingCartStore.Web.Components
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Common.ViewModels.Customer;
    using ShoppingCartStore.Models;
    using System.Threading.Tasks;

    public class Balance : ViewComponent
    {
        UserManager<Customer> _userManager;
        public Balance(UserManager<Customer> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new BalanceViewModel();
            model.Balance = (await _userManager.FindByNameAsync(User.Identity.Name)).Balance;
            return View(model);
        }
    }
}
