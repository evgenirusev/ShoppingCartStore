namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.BindingModels.Category;
    using ShoppingCartStore.Common.ViewModels.Category;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryBindingModel model);

        ICollection<CategoryViewModel> All();
    }
}
