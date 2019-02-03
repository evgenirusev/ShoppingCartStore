using ShoppingCartStore.Models.Enum;
using System;

namespace ShoppingCartStore.Models
{
    public class Transaction
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Price { get; set; }

        public TransactionType Type { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
