namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.ServiceModels.Wishlist;
    using ShoppingCartStore.Common.ViewModels.Product;
    using System.Collections.Generic;

    public interface IProductsWishlistsService
    {
        ICollection<ProductViewModel> FindProductsByWishlist(WishlistServiceModel wishlist);
    }
}
