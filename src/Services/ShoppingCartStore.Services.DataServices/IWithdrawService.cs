using System.Threading.Tasks;

namespace ShoppingCartStore.Services.DataServices
{
    public interface IWithdrawService
    {
        Task WithdrawFundsAsync(decimal amount, string customerId);
    }
}
