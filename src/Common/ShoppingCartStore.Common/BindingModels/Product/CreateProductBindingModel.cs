using System.ComponentModel.DataAnnotations;

namespace ShoppingCartStore.Common.BindingModels.Product
{
    public class CreateProductBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURI { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
