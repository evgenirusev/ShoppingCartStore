namespace ShoppingCartStore.Common.Helpers.FilterPattern
{
    using System.Collections.Generic;

    public interface Criteria<T>
    {
        ICollection<T> MeetCriteria(ICollection<T> items);
    }
}
