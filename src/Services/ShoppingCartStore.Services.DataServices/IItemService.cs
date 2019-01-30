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

        Task<Item> FindByIdAndCustomerUsername(string itemId, string username);

        Task UpdateItemProductQuantity(string itemId, int count);

        Task Delete(Item item);

        ICollection<ItemViewModel> AllViewModelsByCartId(string cartId);

        Task<IEnumerable<Item>> AllByCartId(string cartId);
    }
}
