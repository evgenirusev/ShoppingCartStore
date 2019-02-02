namespace ShoppingCartStore.Services.DataServices
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ShoppingCartStore.Common.BindingModels.Category;
    using ShoppingCartStore.Common.ViewModels.Category;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task CreateAsync(CreateCategoryBindingModel model);

        ICollection<CategoryViewModel> All();

        List<SelectListItem> AllSelectListItems();
    }
}
