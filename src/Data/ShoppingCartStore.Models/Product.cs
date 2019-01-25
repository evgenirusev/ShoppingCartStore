namespace ShoppingCartStore.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ItemId { get; set; }
        public Item Item { get; set; }
    }
}
