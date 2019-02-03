
namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ShoppingCartStore.Common.BindingModels.Category;
    using ShoppingCartStore.Common.ViewModels.Category;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;

    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository, IMapper mapper
            , UserManager<Customer> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public async Task CreateAsync(CreateCategoryBindingModel model)
        {
            Category category = this.Mapper.Map<Category>(model);
            await this.Repository.AddAsync(category);
            await this.Repository.SaveChangesAsync();
        }

        public ICollection<CategoryViewModel> All()
        {
            return Mapper.Map<ICollection<CategoryViewModel>>(this.Repository.All());
        }

        public List<SelectListItem> AllSelectListItems()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach(var category in this.Repository.All())
            {
                selectListItems.Add(new SelectListItem() {
                    Value = category.Id, Text = category.Name, Selected = false });
            }

            selectListItems.Add(new SelectListItem() {
                 Value = "", Text = "All", Selected = true });

            return selectListItems;
        }
    }
}
