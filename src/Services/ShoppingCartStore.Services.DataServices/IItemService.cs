namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.ViewModels.Item;
    using ShoppingCartStore.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemService
    {
        Task<Item> Create(string productId, int quantity, string cartId);

        Task<IEnumerable<Item>> All();

        Task<Item> FindByProductId(string productId);

        // Refactor: all methods should use customerId instead of username
        // for the purpose of having consistent conventions
        Task<Item> FindByProductIdAndCustomerUsername(string productId, string username);

        Task<Item> FindByIdAndCustomerId(string itemId, string customerId);

        Task UpdateItemProductQuantity(string itemId, int count);

        Task Delete(Item item);

        ICollection<ItemViewModel> AllViewModelsByCartId(string cartId);

        Task<IEnumerable<Item>> AllByCartId(string cartId);

        Task DeleteByCartIdAndProductId(string cartId, string productId);
    }
}
