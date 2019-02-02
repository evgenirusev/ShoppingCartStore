namespace SoppingCartStore.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ShoppingCartStore.Common.BindingModels.Product;
    using ShoppingCartStore.Common.ViewModels.Category;
    using ShoppingCartStore.Services.DataServices;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Categories : ViewComponent
    {
        private ICategoryService _categoryService;

        public Categories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FilterBindingModel();
            List<SelectListItem> categories = _categoryService.AllSelectListItems();
            model.Items = categories;
            
            return View(model);
        }
    }
}
