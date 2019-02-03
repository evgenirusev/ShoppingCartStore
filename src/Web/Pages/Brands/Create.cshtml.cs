namespace SoppingCartStore.Web.Pages.Brands
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using ShoppingCartStore.Common.BindingModels.Brand;
    using ShoppingCartStore.Services.DataServices;
    using System.Threading.Tasks;

    [Authorize(Roles = "Administrator")]
    public class CreateModel : PageModel
    {
        private IBrandService _brandService;

        public CreateModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [BindProperty]
        public CreateBrandBindingModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            await _brandService.CreateAsync(Input);

            return this.RedirectToPage("/Brands/Success");
        }
    }
}