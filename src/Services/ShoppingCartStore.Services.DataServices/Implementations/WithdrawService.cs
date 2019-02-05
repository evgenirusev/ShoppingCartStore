namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Models.Enum;

    public class WithdrawService : BaseService<Customer>, IWithdrawService
    {
        private ITransactionService _transactionService;

        public WithdrawService(IRepository<Customer> repository,
            IMapper mapper, UserManager<Customer> userManager
            , ITransactionService transactionService)
            : base(repository, mapper, userManager)
        {
            _transactionService = transactionService;
        }

        public async Task WithdrawFundsAsync(decimal amount, string customerName)
        {
            if (amount <= 0)
            {
                throw new ArgumentNullException();
            }

            var customer = await this.UserManager.FindByNameAsync(customerName);

            customer.Balance -= amount;

            await _transactionService
                .CreateTransactionAsync(customer.Id, amount, TransactionType.Withdraw);

            await this.Repository.SaveChangesAsync();
        }
    }
}
