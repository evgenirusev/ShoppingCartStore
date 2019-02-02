namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Common.ViewModels.Item;
    using ShoppingCartStore.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemService
    {
        Task<Item> CreateAsync(string productId, int quantity, string cartId);

        Task<IEnumerable<Item>> AllAsync();

        Task<Item> FindByProductIdAsync(string productId);
        
        Task<Item> FindByProductIdAndCustomerUsernameAsync(string productId, string username);

        Task<Item> FindByIdAndCustomerIdAsync(string itemId, string customerId);

        Task UpdateItemProductQuantityAsync(string itemId, int count);

        Task DeleteAsync(Item item);

        ICollection<ItemViewModel> AllViewModelsByCartIdAsync(string cartId);

        Task<IEnumerable<Item>> AllByCartIdAsync(string cartId);

        Task DeleteByCartIdAndProductIdAsync(string cartId, string productId);
    }
}
