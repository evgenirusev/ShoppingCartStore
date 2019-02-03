namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Common;
    using ShoppingCartStore.Common.BindingModels.Product;
    using ShoppingCartStore.Common.Helpers.FilterPattern;
    using ShoppingCartStore.Common.ViewModels.Product;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;
    using System;
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

        public async Task CreateAsync(CreateProductBindingModel model)
        {
            Validator.ThrowIfNull(model);

            var product = this.Mapper.Map<Product>(model);

            product.CategoryId = model.CategoryId;
            product.CreatedAt = DateTime.Now;

            await this.Repository.AddAsync(product);
            await this.Repository.SaveChangesAsync();
        }

        public ICollection<ProductViewModel> 
            GetAllViewModelsFilteredAsync(FilterBindingModel model)
        {
            // TODO: Refactor repository architechture efficient data retrieving
            ICollection<Product> products = Repository.All().ToList<Product>();

            // Filter design pattern
            if (model.CategoryIdFilter != null)
            {
                CategoryCriteria categoryCriteria 
                    = new CategoryCriteria(model.CategoryIdFilter);
                products = categoryCriteria.MeetCriteria(products);
            }

            if (model.BrandIdFilter != null)
            {
                BrandCriteria brandCriteria = new BrandCriteria(model.BrandIdFilter);
                products = brandCriteria.MeetCriteria(products);
            }

            if (model.SearchFilter != null)
            {
                SearchCriteria searchCriteria =
                    new SearchCriteria(model.SearchFilter);
                products = searchCriteria.MeetCriteria(products);
            }

            return this.Mapper.Map<ICollection<ProductViewModel>>(products);
        }

        public ICollection<ProductViewModel> GetAllViewModelsAsync()
        {
            return this.Mapper
                .Map<ICollection<ProductViewModel>>(Repository.All());
        }
    }
}
