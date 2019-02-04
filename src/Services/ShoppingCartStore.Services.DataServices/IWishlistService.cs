namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.ViewModels.Product;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWishlistService
    {
        Task AddToWishlistAsync(string productId, string customerId);

        Task<ICollection<ProductViewModel>> FindWishlistProductsByCustomerId(string customerId);
    }
}
