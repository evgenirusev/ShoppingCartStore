using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartStore.Services.DataServices
{
    public interface IOrderService
    {
        Task CreateAsync(string deliveryAddress, string orderNote
            , string customerId, ICollection<string> itemIds);
    }
}
