using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ShoppingCartStore.Data.Common.Repositories;
using ShoppingCartStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartStore.Services.DataServices.Implementations
{
    class OrderService : BaseService<Order>, IOrderService
    {
        IItemService _itemService;

        public OrderService(IRepository<Order> repository, IMapper mapper
            , UserManager<Customer> userManager, IProductService productService
            , IItemService itemService)
            : base(repository, mapper, userManager)
        {
            _itemService = itemService;
        }

        public async Task Create(string deliveryAddress, string orderNote
            , string customerId, ICollection<string> itemIds)
        {
            Order order = new Order();
            List<Item> items = new List<Item>();

            foreach(var item in items)
            {

            }

            order.OrderNote = orderNote;
            order.CustomerId = customerId;
            order.CreatedAt = DateTime.Now;

            // TODO: Persist
        }
    }
}
