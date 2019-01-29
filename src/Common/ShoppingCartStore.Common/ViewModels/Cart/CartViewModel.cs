using ShoppingCartStore.Common.ViewModels.Item;
using System.Collections.Generic;

namespace ShoppingCartStore.Common.ViewModels.Cart
{
    public class CartViewModel
    {
        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}
