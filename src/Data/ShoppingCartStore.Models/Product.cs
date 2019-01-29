﻿using System;
using System.Collections.Generic;

namespace ShoppingCartStore.Models
{
    public class Product : BaseModel
    {
        public Product()
        {
            Items = new List<Item>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURI { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}