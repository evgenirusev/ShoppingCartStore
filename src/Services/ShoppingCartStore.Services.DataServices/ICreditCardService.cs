namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.BindingModels.CreditCard;
    using ShoppingCartStore.Common.ViewModels.CreditCard;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICreditCardService
    {
        Task<string> Create(CreateCreditCardBindingModel model, string username);

        Task<IEnumerable<CreditCardViewModel>> GetAllCreditCardsAsync(string customerId);
    }
}
