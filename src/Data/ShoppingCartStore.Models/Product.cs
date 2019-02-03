using System;
using System.Collections.Generic;

namespace ShoppingCartStore.Models
{
    public class Product : BaseModel
    {
        public Product()
        {
            Items = new List<Item>();
            ProductsOrder = new List<ProductsOrder>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURI { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public string BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<ProductsOrder> ProductsOrder { get; set; }

        public ICollection<ProductsWishlists> ProductsWishlists { get; set; }
    }
}