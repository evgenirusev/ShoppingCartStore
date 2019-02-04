namespace ShoppingCartStore.Models
{
    using System.Collections.Generic;

    public class Wishlist : BaseModel
    {
        public Wishlist()
        {
            ProductsWishlists = new List<ProductsWishlists>();
        }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<ProductsWishlists> ProductsWishlists { get; set; }
    }
}
