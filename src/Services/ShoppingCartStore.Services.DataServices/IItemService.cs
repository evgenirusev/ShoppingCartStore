namespace ShoppingCartStore.Services.DataServices
{
    using System.Threading.Tasks;

    public interface IItemService
    {
        Task Save(string productId, int quantity, string cartId);
    }
}
