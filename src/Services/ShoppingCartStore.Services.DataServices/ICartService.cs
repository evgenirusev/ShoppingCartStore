namespace ShoppingCartStore.Services.DataServices
{
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task AddToCart(string userId, string itemId);
    }
}
