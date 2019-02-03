using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShoppingCartStore.Common;
using ShoppingCartStore.Common.BindingModels.Deposit;
using ShoppingCartStore.Data.Common.Repositories;
using ShoppingCartStore.Models;
using ShoppingCartStore.Models.Enum;
using System;
using System.Threading.Tasks;

namespace ShoppingCartStore.Services.DataServices.Implementations
{
    public class DepositService : BaseService<Deposit>, IDepositService
    {
        private ITransactionService _transactionService;

        public DepositService(IRepository<Deposit> repository,
            IMapper mapper, UserManager<Customer> userManager
            , ITransactionService transactionService)
            : base(repository, mapper, userManager)
        {
            _transactionService = transactionService;
        }

        public async Task CreateDepositAsync(CreateDepositBindingModel model, string username)
        {
            Validator.ThrowIfNull(model);
            Validator.ThrowIfNull(username);

            if (model.Amount < 0)
            {
                throw new ArgumentNullException();
            }

            var customer = await this.GetUserByNamedAsync(username);

            var deposit = this.Mapper.Map<Deposit>(model);
            deposit.CustomerId = customer.Id;
            deposit.CreatedAt = DateTime.Now;

            customer.Balance += model.Amount;

            await _transactionService.CreateTransactionAsync(customer.Id,
                model.Amount,
                TransactionType.Deposit);

            await this.Repository.AddAsync(deposit);
            await this.Repository.SaveChangesAsync();
        }
    }
}
