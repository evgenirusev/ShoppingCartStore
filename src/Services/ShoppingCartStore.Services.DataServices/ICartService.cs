namespace ShoppingCartStore.Services.DataServices
{
    using Microsoft.AspNetCore.Http;
    using ShoppingCartStore.Common.ViewModels.Cart;
    using System.Threading.Tasks;

    public interface ICartService
    {
        int? GetProductCountFromSession(ISession session);

        Task MigrateSessionProductsAsync(string userEmail, ISession session);

        Task AddToPersistedCartAsync(string productId, string username);

        Task AddToSessionCartAsync(string productId, ISession session);

        void ClearSessionCart(ISession session);

        Task<int> GetPersistedCartProductCountAsync(string username, ISession session);

        Task ManageCartOnCustomerLoginAsync(ISession session, string username);

        CartViewModel GetCartViewModelByCustomerId(string customerId);

        Task RemoveItemFromCartAsync(string productId, string customerId, ISession session);

        Task RemoveItemFromSessionAsync(string productId, ISession session);
    }
}
