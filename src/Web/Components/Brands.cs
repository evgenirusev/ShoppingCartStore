namespace SoppingCartStore.Web.Components
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ShoppingCartStore.Common.BindingModels.Product;
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
            var model = new FilterBindingModel();
            List<SelectListItem> brands = _brandService.AllSelectListItems();
            model.Items = brands;
            
            return View(model);
        }
    }
}
