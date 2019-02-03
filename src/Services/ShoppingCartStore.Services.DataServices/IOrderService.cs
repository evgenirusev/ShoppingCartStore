using ShoppingCartStore.Common.ViewModels.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartStore.Services.DataServices
{
    public interface IOrderService
    {
        Task CreateAsync(string deliveryAddress, string orderNote
            , string customerId, ICollection<string> itemIds);

        Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(string customerId);
    }
}
