namespace ShoppingCartStore.Models
{
    public class ProductsOrder
    {
        public int ProductQuantity { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
