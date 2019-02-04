namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.ServiceModels.Wishlist;
    using ShoppingCartStore.Common.ViewModels.Product;
    using System.Collections.Generic;

    interface IProductsWishlistsService
    {
        ICollection<ProductViewModel> FindByWishlistId(WishlistServiceModel wishlist);
    }
}
