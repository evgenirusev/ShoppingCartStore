namespace ShoppingCartStore.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class Customer : IdentityUser
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public decimal Balance { get; set; }

        public string CartId { get; set; }
        public Cart Cart { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
