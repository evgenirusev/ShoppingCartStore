namespace SoppingCartStore.Web.Pages.Categories
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using ShoppingCartStore.Common.BindingModels.Category;
    using ShoppingCartStore.Services.DataServices;
    using System.Threading.Tasks;

    [Authorize(Roles = "Administrator")]
    public class CreateModel : PageModel
    {
        private ICategoryService _categoryService;

        public CreateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]
        public CreateCategoryBindingModel Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            await _categoryService.CreateAsync(Input);

            return this.RedirectToPage("/Categories/Success");
        }
    }
}