namespace ShoppingCartStore.Models
{
    public class Cart : BaseModel
    {
        public Cart()
        {
        }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
