using ShoppingCartStore.Common.BindingModels.Product;
using ShoppingCartStore.Common.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartStore.Services.DataServices
{
    public interface IProductService
    {
        Task Create(CreateProductBindingModel model);

        Task<IEnumerable<ProductViewModel>> GetAllViewModelsAsync();

        ProductViewModel FindById(string id);
    }
}
