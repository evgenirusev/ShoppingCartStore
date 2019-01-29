namespace ShoppingCartStore.Services.DataServices
{
    using Microsoft.AspNetCore.Http;
    using ShoppingCartStore.Common.ViewModels.Cart;
    using System.Threading.Tasks;

    public interface ICartService
    {
        int? GetProductCountFromSession(ISession session);

        Task MigrateSessionProducts(string userEmail, ISession session);

        Task AddToPersistedCart(string productId, string username);

        Task AddToSessionCart(string productId, ISession session);

        void ClearSessionCart(ISession session);

        Task<int> GetPersistedCartProductCount(string username, ISession session);

        Task ManageCartOnCustomerLogin(ISession session, string username);

        CartViewModel GetCartViewModelByCustomerId(string customerI);
    }
}
