using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ShoppingCartStore.Common.BindingModels.Product
{
    public class FilterBindingModel
    {
        public List<SelectListItem> Items { get; set; }
        public string CategoryIdFilter { get; set; }
        public string BrandIdFilter { get; set; }
        public string SearchFilter { get; set; }
    }
}
