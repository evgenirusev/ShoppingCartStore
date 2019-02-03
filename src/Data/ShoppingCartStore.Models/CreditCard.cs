namespace ShoppingCartStore.Models
{
    using System;

    public class CreditCard : BaseModel
    {
        public string Number { get; set; }

        public string CVV { get; set; }

        public DateTime DateRegistered { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
