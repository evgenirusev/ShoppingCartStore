using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShoppingCartStore.Common.ViewModels.Item;
using ShoppingCartStore.Data.Common.Repositories;
using ShoppingCartStore.Models;

namespace ShoppingCartStore.Services.DataServices.Implementations
{
    public class ItemService : BaseService<Item>, IItemService
    {
        private IProductService _productService;

        public ItemService(IRepository<Item> repository, IMapper mapper
            , UserManager<Customer> userManager, IProductService productService) 
            : base(repository, mapper, userManager)
        {
            _productService = productService;
        }

        public async Task<Item> Create(string productId, int quantity, string cartId)
        {
            Item item = new Item();
            item.ProductId = productId;
            item.Quantity = quantity;
            item.CartId = cartId;
            await this.Repository.AddAsync(item);
            await this.Repository.SaveChangesAsync();
            return item;
        }

        public async Task Delete(Item item)
        {
            this.Repository.Delete(item);
            await this.Repository.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Item>> All()
        {
            return this.Repository.All();
        }

        public async Task<IEnumerable<Item>> AllByCartId(string cartId)
        {
            return Repository.All().Where(i => i.CartId == cartId);
        }

        public async Task<Item> FindByProductId(string productId)
        {
            return Repository.All().FirstOrDefault(i => i.ProductId == productId);
        }

        public async Task<Item> FindByIdAndCustomerUsername
            (string productId, string username)
        {
            return Repository.All().FirstOrDefault(i => i.ProductId == productId 
                    && i.Cart.Customer.UserName == username);
        }

        public async Task UpdateItemProductQuantity(string itemId, int count)
        {
            var item = this.Repository.FindById(itemId);
            item.Quantity += count;
            this.Repository.Update(item);
            await this.Repository.SaveChangesAsync();
        }

        public IEnumerable<ItemViewModel> AllViewModelsByCartId(string cartId)
        {
            var itemViewModels = new List<ItemViewModel>();

            var itemEntities = GetItemEntitiesByCartId(cartId);

            foreach (var itemEntity in itemEntities)
            {
                ItemViewModel itemViewModel = new ItemViewModel();
                var productViewModel = _productService.FindById(itemEntity.ProductId);
                itemViewModel.Product = productViewModel;
                itemViewModel.ProductQuantity = itemEntity.Quantity;
                itemViewModels.Add(itemViewModel);
            }

            return itemViewModels;
        }

        private IEnumerable<Item> GetItemEntitiesByCartId(string cartId)
        {
            return Repository.All().Where(i => i.CartId == cartId);
        }
    }
}
