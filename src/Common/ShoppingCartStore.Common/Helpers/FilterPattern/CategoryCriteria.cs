namespace ShoppingCartStore.Common.Helpers.FilterPattern
{
    using ShoppingCartStore.Models;
    using System.Collections.Generic;

    public class CategoryCriteria : Criteria<Product>
    {
        private string _categoryId;

        public CategoryCriteria(string categoryId)
        {
            _categoryId = categoryId;
        }

        public ICollection<Product> MeetCriteria(ICollection<Product> products)
        {
            var filteredProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.CategoryId == _categoryId)
                {
                    filteredProducts.Add(product);
                }
            }

            return filteredProducts;
        }
    }
}
