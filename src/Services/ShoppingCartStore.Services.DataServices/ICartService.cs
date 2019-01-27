namespace ShoppingCartStore.Services.DataServices
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task AddToCart(string username, string productId, ISession session);

        int? GetProductCountFromSession(ISession session);

        int? GetProductCountFromDb(ISession session);

        Task MigrateSessionProducts(string userEmail, ISession session);
    }
}
