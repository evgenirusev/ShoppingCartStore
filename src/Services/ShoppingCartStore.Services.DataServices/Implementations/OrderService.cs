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

            order.Id = Guid.NewGuid().ToString();
            order.OrderNote = orderNote;
            order.DeliveryAddress = deliveryAddress;
            order.CustomerId = customerId;
            order.CreatedAt = DateTime.Now;

            foreach (var itemId in itemIds)
            {
                var item = await _itemService
                    .FindByIdAndCustomerId(itemId, customerId);

                var productOrder = new ProductsOrder();
                productOrder.OrderId = order.Id;
                productOrder.ProductId = item.ProductId;
                productOrder.ProductQuantity = item.Quantity;

                order.ProductsOrder.Add(productOrder);
            }

            await this.Repository.AddAsync(order);
            await this.Repository.SaveChangesAsync();
        }
    }
}
