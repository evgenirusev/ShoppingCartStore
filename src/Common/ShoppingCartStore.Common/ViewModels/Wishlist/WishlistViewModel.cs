namespace ShoppingCartStore.Common.ViewModels.Wishlist
{
    using ShoppingCartStore.Common.ViewModels.Product;
    using System.Collections.Generic;

    public class WishlistViewModel
    {
        public ICollection<ProductViewModel> roductName { get; set; }
    }
}
