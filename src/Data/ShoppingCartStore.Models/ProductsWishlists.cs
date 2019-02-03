namespace ShoppingCartStore.Models
{
    public class ProductsWishlists
    {
        public string WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
