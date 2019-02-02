using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShoppingCartStore.Common.BindingModels.Brand;
using ShoppingCartStore.Common.ViewModels.Brand;
using ShoppingCartStore.Data.Common.Repositories;
using ShoppingCartStore.Models;

namespace ShoppingCartStore.Services.DataServices.Implementations
{
    public class BrandService : BaseService<Brand>, IBrandService
    {
        public BrandService(IRepository<Brand> repository, IMapper mapper
            , UserManager<Customer> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public async Task CreateAsync(CreateBrandBindingModel model)
        {
            Brand brand = this.Mapper.Map<Brand>(model);
            await Repository.AddAsync(brand);
            await Repository.SaveChangesAsync();
        }

        public ICollection<BrandViewModel> All()
        {
            return Mapper.Map<ICollection<BrandViewModel>>(Repository.All());
        }
    }
}
