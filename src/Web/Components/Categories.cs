namespace SoppingCartStore.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<SelectListItem> categories = _categoryService.AllSelectListItems();
            return View(categories);
        }
    }
}
