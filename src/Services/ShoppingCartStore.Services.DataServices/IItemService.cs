namespace ShoppingCartStore.Services.DataServices
{
    using ShoppingCartStore.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemService
    {
        Task Save(string productId, int quantity, string cartId);

        Task Delete(Item item);

        Task<IEnumerable<Item>> All();

        Task<IEnumerable<Item>> AllByCartId(string cartId);

        Task<Item> FindByProductId(string productId);
    }
}
