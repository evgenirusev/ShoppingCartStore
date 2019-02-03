using System.Collections.Generic;
using ShoppingCartStore.Models;

namespace ShoppingCartStore.Common.Helpers.FilterPattern
{
    public class BrandCriteria : Criteria<Product>
    {
        private string _brandId;

        public BrandCriteria(string brandId)
        {
            _brandId = brandId;
        }

        public ICollection<Product> MeetCriteria(ICollection<Product> products)
        {
            var filteredProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.BrandId == _brandId)
                {
                    filteredProducts.Add(product);
                }
            }

            return filteredProducts;
        }
    }
}