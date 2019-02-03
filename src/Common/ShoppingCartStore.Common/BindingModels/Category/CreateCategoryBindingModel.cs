using System.ComponentModel.DataAnnotations;

namespace ShoppingCartStore.Common.BindingModels.Category
{
    public class CreateCategoryBindingModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
