namespace SoppingCartStore.Web.Pages.Withdraw
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using ShoppingCartStore.Common.BindingModels.Withdraw;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Services.DataServices;

    [Authorize]
    public class IndexModel : PageModel
    {
        private IWithdrawService _withdrawService;
        private UserManager<Customer> _userManager;

        public IndexModel(UserManager<Customer> userManager
            , IWithdrawService withdrawService)
        {
            _userManager = userManager;
            _withdrawService = withdrawService;
            this.Input = new WithdrawBindingModel();
        }

        [BindProperty]
        public WithdrawBindingModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            await this._withdrawService.WithdrawFundsAsync(this.Input.WithdrawAmount, this.User.Identity.Name);
            return this.RedirectToPage("/Withdraw/Success");
        }
    }
}