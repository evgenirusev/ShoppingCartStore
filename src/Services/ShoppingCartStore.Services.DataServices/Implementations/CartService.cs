using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ShoppingCartStore.Models;
using SoppingCartStore.Common.Helpers;

namespace ShoppingCartStore.Services.DataServices.Implementations
{
    public class CartService : ICartService
    {
        public async Task AddToCart(string userId, string productId, ISession session)
        {
            if (userId != null)
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
    }
}
