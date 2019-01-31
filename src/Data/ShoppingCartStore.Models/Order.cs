using System;
using System.Collections.Generic;

namespace ShoppingCartStore.Models
{
    public class Order : BaseModel
    {
        public Order()
        {
            ProductsOrder = new List<ProductsOrder>();
        }

        public Order(string orderId, string productId) : this()
        {
            
        }

        public string DeliveryAddress { get; set; }

        public string OrderNote { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<ProductsOrder> ProductsOrder { get; set; }
    }
}
