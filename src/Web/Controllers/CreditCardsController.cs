namespace SoppingCartStore.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Common.BindingModels.CreditCard;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Services.DataServices;
    using System.Threading.Tasks;

    [Authorize]
    public class CreditCardsController : Controller
    {
        private ICreditCardService creditCardService;
        private UserManager<Customer> userManager;

        public CreditCardsController(ICreditCardService creditCardService, UserManager<Customer> userManager)
        {
            this.creditCardService = creditCardService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCreditCardBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.creditCardService.Create(model, this.User.Identity.Name);

            return this.RedirectToAction("Index", "CreditCards");
        }

        public async Task<IActionResult> Index()
        {
            string customerId = (await userManager.FindByNameAsync(this.User.Identity.Name)).Id;
            var creditCards = await this.creditCardService.GetAllCreditCardsAsync(customerId);
            return View(creditCards);
        }
    }
}