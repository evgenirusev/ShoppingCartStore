namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.ViewModels.Transaction;
    using ShoppingCartStore.Models.Enum;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransactionService
    {
        Task CreateTransactionAsync(string customerId, decimal price, TransactionType type);

        Task<IEnumerable<TransactionViewModel>> GetAllTransactionsById(string id);
    }
}
