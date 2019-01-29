namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Common.ViewModels.Cart;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;
    using SoppingCartStore.Common.Helpers;

    public class CartService : BaseService<Cart>, ICartService
    {
        IItemService _itemService;

        public CartService(IRepository<Cart> repository, IMapper mapper
            , UserManager<Customer> userManager, IItemService itemService)
            : base(repository, mapper, userManager)
        {
            _itemService = itemService;
        }

        public async Task AddToPersistedCart(string productId, string username)
        {
            var cart = FindByUsername(username);
            var item = await _itemService
                .FindByIdAndCustomerUsername(productId, username);

            if (cart == null)
            {
                var customer = await UserManager.FindByNameAsync(username);
                var cartId = await CreateCart(customer);
                await _itemService.Create(productId, 1, cartId);
            }
            else
            {
                if (item != null)
                {
                    await _itemService.UpdateItemProductQuantity(item.Id, 1);
                }
                else
                {
                    await _itemService.Create(productId, 1, cart.Id);
                }
            }
        }

        public async Task AddToSessionCart(string productId, ISession session)
        {
            if (SessionHelper.GetObjectFromJson<int>(session, "productCount") == 0)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(productId, 1));
                SessionHelper.SetObjectAsJson(session, "cart", cart);

                // Initial product count
                SessionHelper.SetObjectAsJson(session, "productCount", 1);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(session, "cart");
                int index = doesExist(productId, session);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item(productId, 1));
                }
                SessionHelper.SetObjectAsJson(session, "cart", cart);

                // Incrementing the product counter
                int productCount = SessionHelper.GetObjectFromJson<int>(session, "productCount");
                SessionHelper.SetObjectAsJson(session, "productCount", productCount + 1);
            }
        }

        private void AddItemsToSession(List<Item> items, ISession session)
        {
            List<Item> resultItems = new List<Item>();

            foreach(var item in items)
            {
                // To avoid JSON "Error Self referencing loop"
                item.Cart = null;

                resultItems.Add(item);
            }

            SessionHelper.SetObjectAsJson(session, "cart", resultItems);
        }

        private int doesExist(string id, ISession session)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public int? GetProductCountFromSession(ISession session)
        {
            int? count = SessionHelper.GetObjectFromJson<int>(session, "productCount");
            if (count != 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }

        public async Task MigrateSessionProducts(string userEmail, ISession session)
        {
            var customer = await UserManager.FindByEmailAsync(userEmail);
            var persistedCart = this.Repository.FindById(customer.CartId);

            if (persistedCart != null)
            {
                await this.DeletePersistedCart(persistedCart);
            }

            string newDbCartId = await this.CreateCart(customer);

            var cartItems = SessionHelper.GetObjectFromJson<List<Item>>(session, "cart");

            foreach(var item in cartItems)
            {
                await _itemService.Create(item.ProductId, item.Quantity, newDbCartId);
            }
        }

        private async Task<string> CreateCart(Customer cartCustomer)
        {
            var cart = new Cart();
            cart.CustomerId = cartCustomer.Id;

            await this.Repository.AddAsync(cart);
            await this.Repository.SaveChangesAsync();

            // Create Bidirectional relation
            cartCustomer.CartId = cart.Id;
            await this.UserManager.UpdateAsync(cartCustomer);

            return cart.Id;
        }

        private async Task DeletePersistedCart(Cart persistedCart)
        {
            List<Item> persistedItems = (await _itemService.AllByCartId(persistedCart.Id)).ToList();
            
            foreach (var item in persistedItems)
            {
                await _itemService.Delete(item);
            }

            this.Repository.Delete(persistedCart);
            await this.Repository.SaveChangesAsync();
        }

        private Cart FindByUsername(string username)
        {
            return this.Repository.All()
                .Where(c => c.Customer.UserName == username).FirstOrDefault();
        }

        public void ClearSessionCart(ISession session)
        {
            SessionHelper.SetObjectAsJson(session, "cart", null);
            SessionHelper.SetObjectAsJson(session, "productCount", 0);
        }

        public async Task<int> GetPersistedCartProductCount(string username, ISession session)
        {
            var cart = FindByUsername(username);

            if (cart == null)
            {
                return 0;
            }

            var cartItems = await _itemService.AllByCartId(cart.Id);

            int productCount = 0;

            foreach (var item in cartItems)
            {
                productCount += item.Quantity;
            }

            return productCount;
        }

        public async Task ManageCartOnCustomerLogin(ISession session, string username)
        {
            var cartFromSession = SessionHelper.GetObjectFromJson<List<Item>>(session, "cart");
            if (cartFromSession != null)
            {
                await MigrateSessionProducts(username, session);
            }
            else
            {
                int productCount = await GetPersistedCartProductCount(username, session);

                if (productCount != 0)
                {
                    SessionHelper.SetObjectAsJson(session, "productCount", productCount);

                    var persistedCart = FindByUsername(username);
                    var persistedItems = await _itemService.AllByCartId(persistedCart.Id);

                    if (persistedItems != null)
                    {
                        AddItemsToSession(persistedItems.ToList(), session);
                    }
                }
            }
        }

        public CartViewModel GetCartViewModelByCustomerId(string customerId)
        {
            var cartViewModel = new CartViewModel();
            Cart cart = this.GetCartEntityByCustomerId(customerId);
            cartViewModel.Items = _itemService.AllViewModelsByCartId(cart.Id);
            return cartViewModel;
        }

        private Cart GetCartEntityByCustomerId(string customerId)
        {
            return Repository.All()
                .Where(c => c.CustomerId == customerId).FirstOrDefault();
        }
    }
}
