using System.Collections.Generic;

namespace ShoppingCartStore.Models
{
    public class Cart : BaseModel
    {
        public Cart()
        {
            this.Items = new List<Item>();
        }

        public List<Item> Items { get; set; }
        
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
