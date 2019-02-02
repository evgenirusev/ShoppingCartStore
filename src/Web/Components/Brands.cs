namespace SoppingCartStore.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ShoppingCartStore.Common.ViewModels.Brand;
    using ShoppingCartStore.Services.DataServices;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Brands : ViewComponent
    {
        private IBrandService _brandService;

        public Brands(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SelectListItem> brands = _brandService.AllSelectListItems();
            return View(brands);
        }
    }
}
