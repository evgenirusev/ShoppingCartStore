namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Common.ServiceModels.Wishlist;
    using ShoppingCartStore.Common.ViewModels.Product;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;

    public class ProductsWishlistsService 
        : BaseService<ProductsWishlists>, IProductsWishlistsService
    {
        private IProductService _productService;

        public ProductsWishlistsService(IRepository<ProductsWishlists> repository, IMapper mapper
            , UserManager<Customer> userManager, IProductService productService)
            : base(repository, mapper, userManager)
        {
            _productService = productService;
        }

        public ICollection<ProductViewModel> FindProductsByWishlist(WishlistServiceModel wishlist)
        {
            var wlists = this.Repository.All().Where(wl => wl.WishlistId == wishlist.Id);
            ICollection<ProductViewModel> wlProducts = new List<ProductViewModel>();

            foreach(var wl in wlists)
            {
                wlProducts.Add(_productService.FindById(wl.ProductId));
            }

            return wlProducts;
        }

        public bool ProductAlreadyExists(WishlistServiceModel wlServiceModel, string productId)
        {
            ICollection<ProductsWishlists> productMatches = this.Repository
                .All().Where(wl => wl.WishlistId == wlServiceModel.Id 
                && wl.ProductId == productId).ToList();

            if (productMatches.Count > 0)
            {
                return true;
            }

            return false;
        }

    }
}
