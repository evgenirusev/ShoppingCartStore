using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartStore.Services.DataServices
{
    public interface IOrderService
    {
        Task Create(string deliveryAddress, string orderNote
            , string customerId, ICollection<string> itemIds);
    }
}
