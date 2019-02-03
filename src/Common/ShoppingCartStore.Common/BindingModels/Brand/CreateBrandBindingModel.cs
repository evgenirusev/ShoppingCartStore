using System.ComponentModel.DataAnnotations;

namespace ShoppingCartStore.Common.BindingModels.Brand
{
    public class CreateBrandBindingModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
