namespace ShoppingCartStore.Services.DataServices
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task AddToCart(string userId, string productId, ISession session);

        int? GetProductCountFromSession(ISession session);
    }
}
