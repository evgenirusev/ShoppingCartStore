namespace ShoppingCartStore.Services.DataServices
{
    using System.Threading.Tasks;

    public interface IWishlistService
    {
        Task AddToWishlistAsync(string productId, string customerId);
    }
}
