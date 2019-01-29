using System.Collections.Generic;

namespace ShoppingCartStore.Models
{
    public class Item : BaseModel
    {
        public Item()
        {
        }

        public Item(string productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public int Quantity { get; set; }

        public string CartId { get; set; }
        public Cart Cart { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
