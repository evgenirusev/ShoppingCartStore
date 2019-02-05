namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;

    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository, IMapper mapper
            , UserManager<Customer> userManager) : base(repository, mapper, userManager)
        {
        }

        public async Task SubtractBalance(decimal amount, Customer customer)
        {
            if (amount > customer.Balance)
            {
                throw new InvalidOperationException();
            }

            customer.Balance -= amount;

            await this.UserManager.UpdateAsync(customer);
        }
    }
}
