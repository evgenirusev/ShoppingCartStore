namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.ViewModels.Wishlist;
    using System.Threading.Tasks;

    public interface IWishlistService
    {
        Task AddToWishlistAsync(string productId, string customerId);

        Task<WishlistViewModel> FindByCustomerId(string customerId);
    }
}
