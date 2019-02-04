using ShoppingCartStore.Common.BindingModels.Order;
using ShoppingCartStore.Common.ViewModels.Item;
using System.Collections.Generic;

namespace ShoppingCartStore.Common.ViewModels.Cart
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            Price = 0;
        }

        public List<ItemViewModel> Items { get; set; }

        public CreateOrderBindingModel CreateOrderBindingModel { get; set; }

        public decimal Price { get; set; }

        public decimal CustomerBalance { get; set; }
    }
}
