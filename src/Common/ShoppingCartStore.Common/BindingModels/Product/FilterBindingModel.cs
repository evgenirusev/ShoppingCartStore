using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ShoppingCartStore.Common.BindingModels.Product
{
    public class FilterBindingModel
    {
        public List<SelectListItem> Items { get; set; }
        public int? CategoryFilterApplied { get; set; }
        public int? BrandFilterApplied { get; set; }
    }
}
