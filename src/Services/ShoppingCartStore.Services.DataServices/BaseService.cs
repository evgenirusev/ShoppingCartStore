namespace ShoppingCartStore.Services.DataServices
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Common;
    using ShoppingCartStore.Common.Exceptions;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;
    using System.Threading.Tasks;

    public abstract class BaseService<T> where T : class
    {
        protected BaseService(IRepository<T> repository,
            IMapper mapper,
            UserManager<Customer> userManager)
        {
            this.Mapper = mapper;
            this.Repository = repository;
            this.UserManager = userManager;
        }

        protected IMapper Mapper { get; private set; }

        protected IRepository<T> Repository { get; private set; }

        protected UserManager<Customer> UserManager { get; private set; }

        protected async Task<Customer> GetUserByNamedAsync(string name)
        {
            var customer = await this.UserManager.FindByNameAsync(name);

            Validator.ThrowIfNull(customer, new InvalidUserException());

            return customer;
        }
    }
}
