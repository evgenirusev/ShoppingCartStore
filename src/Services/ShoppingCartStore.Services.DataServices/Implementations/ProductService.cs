namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartStore.Common;
    using ShoppingCartStore.Common.BindingModels.Product;
    using ShoppingCartStore.Common.ViewModels.Product;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository,
            IMapper mapper, UserManager<Customer> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public ProductViewModel FindById(string id)
        {
            var product = Repository.All().Where(p => p.Id == id).First();
            return Mapper.Map<ProductViewModel>(product);
        }

        public async Task Create(CreateProductBindingModel model)
        {
            Validator.ThrowIfNull(model);

            var product = this.Mapper.Map<Product>(model);

            await this.Repository.AddAsync(product);
            await this.Repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllViewModelsAsync()
        {
            return this.Mapper.Map<IEnumerable<ProductViewModel>>(this.Repository.All());
        }
    }
}
