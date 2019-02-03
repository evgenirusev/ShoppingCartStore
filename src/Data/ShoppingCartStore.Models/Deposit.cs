namespace ShoppingCartStore.Models
{
    using System;

    public class Deposit : BaseModel
    {
        public decimal Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
