using System.Collections.Generic;

namespace ShoppingCartStore.Models
{
    public class Brand : BaseModel
    {
        public Brand()
        {
        }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
