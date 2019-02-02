namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.BindingModels.Brand;
    using ShoppingCartStore.Common.ViewModels.Brand;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBrandService
    {
        Task CreateAsync(CreateBrandBindingModel model);

        ICollection<BrandViewModel> All();
    }
}
