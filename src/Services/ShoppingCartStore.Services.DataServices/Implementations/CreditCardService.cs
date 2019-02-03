namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Common;
    using ShoppingCartStore.Common.BindingModels.CreditCard;
    using ShoppingCartStore.Common.ViewModels.CreditCard;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    class CreditCardService : BaseService<CreditCard>, ICreditCardService
    {
        public CreditCardService(IRepository<CreditCard> repository,
            IMapper mapper,
            UserManager<Customer> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public async Task<string> Create(CreateCreditCardBindingModel model, string username)
        {
            Validator.ThrowIfNull(model);

            var client = await this.GetUserByNamedAsync(username);

            var creditCard = this.Mapper.Map<CreditCard>(model);
            creditCard.CustomerId = client.Id;
            creditCard.DateRegistered = DateTime.Now;

            await this.Repository.AddAsync(creditCard);
            await this.Repository.SaveChangesAsync();

            return creditCard.Id;
        }

        public async Task<IEnumerable<CreditCardViewModel>> GetAllCreditCardsAsync(string id)
        {
            return this.Mapper.Map<IEnumerable<CreditCardViewModel>>(
                this.Repository.All().Where(c => c.CustomerId == id));
        }
    }
}
