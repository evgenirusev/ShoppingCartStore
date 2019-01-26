using AutoMapper;
using ShoppingCartStore.Common.BindingModels.Product;
using ShoppingCartStore.Models;

namespace SoppingCartStore.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureProducts();
        }

        private void ConfigureProducts()
        {
            this.CreateMap<CreateProductBindingModel, Product>();
            this.CreateMap<Product, CreateProductBindingModel>();
        }
    }
}
