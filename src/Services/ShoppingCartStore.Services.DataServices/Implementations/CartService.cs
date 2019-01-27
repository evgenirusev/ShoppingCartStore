using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ShoppingCartStore.Data.Common.Repositories;
using ShoppingCartStore.Models;
using SoppingCartStore.Common.Helpers;

namespace ShoppingCartStore.Services.DataServices.Implementations
{
    public class CartService : BaseService<Cart>, ICartService
    {
        IItemService _itemService;

        public CartService(IRepository<Cart> repository, IMapper mapper
            , UserManager<Customer> userManager, IItemService itemService)
            : base(repository, mapper, userManager)
        {
            _itemService = itemService;
        }

        public async Task AddToCart(string username, string productId, ISession session)
        {
            if (username != null)
            {
                // TODO: Implement
            }
            else
            {
                StoreProductInSession(productId, session);
            }
        }

        private void StoreProductInSession(string productId, ISession session)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(session, "cart") == null)
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
                int index = isExist(productId, session);
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

        private int isExist(string id, ISession session)
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
            return SessionHelper.GetObjectFromJson<int>(session, "productCount");
        }

        public async Task MigrateSessionProducts(string userEmail, ISession session)
        {
            var customer = await UserManager.FindByEmailAsync(userEmail);

            var persistedCart = this.Repository.FindById(customer.CartId);

            if (persistedCart != null)
            {
                await this.DeletePersistedCart(persistedCart);
            }

            var cartItems = SessionHelper.GetObjectFromJson<List<Item>>(session, "cart");

            foreach(var item in cartItems)
            {
                await _itemService.Save(item.ProductId, item.Quantity, item.CartId);
            }

            var persistedItems = await _itemService.All();

            string persistedCartId = await this.SaveCart(persistedItems, customer.Id);

            // Make the relation customer-cart uni-directional
            customer.CartId = persistedCartId;
            await this.UserManager.UpdateAsync(customer);

            // Clear the session because our cart is now persisted
            SessionHelper.SetObjectAsJson(session, "cart", null);
            SessionHelper.SetObjectAsJson(session, "productCount", null);
        }

        private async Task<string> SaveCart(IEnumerable<Item> items, string customerId)
        {
            var cart = new Cart();

            foreach(var item in items)
            {
                cart.Items.Add(item);
            }

            cart.CustomerId = customerId;
            await this.Repository.AddAsync(cart);
            await this.Repository.SaveChangesAsync();
            return cart.Id;
        }

        private async Task DeletePersistedCart(Cart persistedCart)
        {
            var persistedItems = await _itemService.AllByCartId(persistedCart.Id);

            foreach (var item in persistedItems)
            {
                await _itemService.Delete(item);
            }

            this.Repository.Delete(persistedCart);

            await this.Repository.SaveChangesAsync();
        }

        public int? GetProductCountFromDb(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
