using System;
using System.Collections.Generic;

namespace ShoppingCartStore.Models
{
    public class Order : BaseModel
    {
        public Order()
        {
            ProductOrders = new List<ProductOrders>();
        }

        public string DeliveryAddress { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<ProductOrders> ProductOrders { get; set; }
    }
}
