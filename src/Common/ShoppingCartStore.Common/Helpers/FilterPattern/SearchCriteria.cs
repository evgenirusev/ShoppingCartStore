namespace ShoppingCartStore.Common.Helpers.FilterPattern
{
    using ShoppingCartStore.Models;
    using System.Collections.Generic;

    public class SearchCriteria : Criteria<Product>
    {
        private string _searchPattern;

        public SearchCriteria(string searchPattern)
        {
            _searchPattern = searchPattern;
        }

        public ICollection<Product> MeetCriteria(ICollection<Product> products)
        {
            var filteredProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.Name.ToLower().Contains(_searchPattern.ToLower()))
                {
                    filteredProducts.Add(product);
                }
            }

            return filteredProducts;
        }
    }
}
