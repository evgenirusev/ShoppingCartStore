namespace ShoppingCartStore.Models
{
    using Microsoft.AspNetCore.Identity;
    
    public class Customer : IdentityUser
    {
        public Customer()
        {
        }

        public decimal Balance { get; set; }
    }
}
