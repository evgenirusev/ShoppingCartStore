namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Common.ViewModels.Transaction;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Models.Enum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        public TransactionService(IRepository<Transaction> repository,
            IMapper mapper,
            UserManager<Customer> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public async Task CreateTransactionAsync(string customerId, decimal price, TransactionType type)
        {
            var transaction = new Transaction();
            transaction.CustomerId = customerId;
            transaction.Price = price;
            transaction.Type = type;
            transaction.CreatedAt = DateTime.Now;

            await this.Repository.AddAsync(transaction);
            await this.Repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransactionViewModel>> GetAllTransactionsById(string id)
        {
            return this.Mapper.Map<IEnumerable<TransactionViewModel>>(this.Repository
                .All().Where(x => x.CustomerId == id));
        }
    }
}
