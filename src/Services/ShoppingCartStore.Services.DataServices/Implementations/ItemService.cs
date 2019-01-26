using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShoppingCartStore.Data.Common.Repositories;
using ShoppingCartStore.Models;

namespace ShoppingCartStore.Services.DataServices.Implementations
{
    public class ItemService : BaseService<Item>, IItemService
    {
        public ItemService(IRepository<Item> repository,
            IMapper mapper, UserManager<Customer> userManager) 
            : base(repository, mapper, userManager)
        {
        }

        public async Task Save(string productId, int quantity, string cartId)
        {
            Item item = new Item();
            item.ProductId = productId;
            item.Quantity = quantity;
            item.CartId = cartId;
            await this.Repository.AddAsync(item);
            await this.Repository.SaveChangesAsync();
        }
    }
}
