using ShoppingCartStore.Common.BindingModels.Order;
using ShoppingCartStore.Common.CustomAttributes;
using ShoppingCartStore.Common.ViewModels.Item;
using System.Collections.Generic;

namespace ShoppingCartStore.Common.ViewModels.Cart
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            Price = 0;
            CreateOrderBindingModel = new CreateOrderBindingModel();
        }

        public List<ItemViewModel> Items { get; set; }

        public CreateOrderBindingModel CreateOrderBindingModel { get; set; }

        [AmountLessThan("CustomerBalance", ErrorMessage = "Inadequate funds, consider making a deposit.")]
        public decimal Price { get; set; }

        public decimal CustomerBalance { get; set; }
    }
}
