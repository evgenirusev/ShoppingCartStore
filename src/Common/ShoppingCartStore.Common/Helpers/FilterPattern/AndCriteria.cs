using System.Collections.Generic;
using ShoppingCartStore.Models;

namespace ShoppingCartStore.Common.Helpers.FilterPattern
{
    public class AndCriteria : Criteria<Product>
    {
        private Criteria<Product> _firstCriteria;
        private Criteria<Product> _secondCriteria;

        public AndCriteria(Criteria<Product> firstCriteria
            , Criteria<Product> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public ICollection<Product> MeetCriteria(ICollection<Product> products)
        {
            ICollection<Product> firstCriteriaProducts = _firstCriteria.MeetCriteria(products);
            return _secondCriteria.MeetCriteria(firstCriteriaProducts);
        }
    }
}
