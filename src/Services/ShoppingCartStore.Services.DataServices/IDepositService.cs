namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.BindingModels.Deposit;
    using System.Threading.Tasks;

    public interface IDepositService
    {
        Task CreateDepositAsync(CreateDepositBindingModel model, string username);
    }
}
