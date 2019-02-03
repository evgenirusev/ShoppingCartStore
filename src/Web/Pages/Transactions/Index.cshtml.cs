namespace SoppingCartStore.Web.Pages.Transactions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using ShoppingCartStore.Common.ViewModels.Transaction;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Services.DataServices;

    [Authorize]
    public class IndexModel : PageModel
    {
        ITransactionService _transactionService;
        UserManager<Customer> _userManager;

        public IndexModel(ITransactionService transactionService
            , UserManager<Customer> userManager)
        {
            _transactionService = transactionService;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            await InitViewModels();
        }

        public List<TransactionViewModel> TransactionViewModels { get; set; }

        private async Task InitViewModels()
        {
            string id = (await _userManager
                .FindByNameAsync(this.User.Identity.Name)).Id;
            this.TransactionViewModels = (await _transactionService
                .GetAllTransactionsById(id)).ToList();
        }
    }
}