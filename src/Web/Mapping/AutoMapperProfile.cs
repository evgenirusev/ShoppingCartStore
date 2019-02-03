using AutoMapper;
using ShoppingCartStore.Common.BindingModels.Brand;
using ShoppingCartStore.Common.BindingModels.Category;
using ShoppingCartStore.Common.BindingModels.CreditCard;
using ShoppingCartStore.Common.BindingModels.Product;
using ShoppingCartStore.Common.ViewModels.Brand;
using ShoppingCartStore.Common.ViewModels.Category;
using ShoppingCartStore.Common.ViewModels.CreditCard;
using ShoppingCartStore.Common.ViewModels.Order;
using ShoppingCartStore.Models;

namespace SoppingCartStore.Web.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            ConfigureProducts();
            ConfigureCategories();
            ConfigureBrands();
            ConfigureOrders();
            ConfigureCreditCards();
        }

        private void ConfigureProducts()
        {
            this.CreateMap<CreateProductBindingModel, Product>();
            this.CreateMap<Product, CreateProductBindingModel>();
        }

        private void ConfigureCategories()
        {
            this.CreateMap<CreateCategoryBindingModel, Category>();
            this.CreateMap<Category, CategoryViewModel>();
        }

        private void ConfigureBrands()
        {
            this.CreateMap<CreateBrandBindingModel, Brand>();
            this.CreateMap<Brand, BrandViewModel>();
        }

        private void ConfigureOrders()
        {
            this.CreateMap<Order, OrderViewModel>();
        }

        private void ConfigureCreditCards()
        {
            this.CreateMap<CreateCreditCardBindingModel, CreditCard>();
            this.CreateMap<CreditCard, CreditCardViewModel>();
        }
    }
}
