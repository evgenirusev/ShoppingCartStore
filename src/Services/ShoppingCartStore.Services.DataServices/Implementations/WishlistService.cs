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

    public class WishlistService : BaseService<Wishlist>, IWishlistService
    {
        private IProductService _productService;
        private IProductsWishlistsService _productsWishlistsService;

        public WishlistService(IRepository<Wishlist> repository, IMapper mapper,
            UserManager<Customer> userManager, IProductService productService, 
            IProductsWishlistsService productsWishlistsService)
            : base(repository, mapper, userManager)
        {
            _productService = productService;
            _productsWishlistsService = productsWishlistsService;
        }

        public async Task AddToWishlistAsync(string productId, string customerId)
        {
            var wishlist = await this.GetWishListAsync(customerId);

            ProductsWishlists pw = new ProductsWishlists();
            pw.ProductId = productId;
            pw.WishlistId = wishlist.Id;

            wishlist.ProductsWishlists.Add(pw);

            await this.Repository.SaveChangesAsync();
        }

        private async Task<Wishlist> GetWishListAsync(string customerId)
        {
            var wishlist = this.Repository.All()
                .Where(wl => wl.CustomerId == customerId).FirstOrDefault();

            if (wishlist == null)
            {
                wishlist = await this.CreateAndRetrieveAsync(customerId);
            }

            return wishlist;
        }

        private async Task<Wishlist> CreateAndRetrieveAsync(string customerId)
        {
            Wishlist wishlist = new Wishlist();
            wishlist.CustomerId = customerId;

            await Repository.AddAsync(wishlist);
            await Repository.SaveChangesAsync();

            return wishlist;
        }

        public async Task<ICollection<ProductViewModel>> FindWishlistProductsByCustomerId(string customerId)
        {
            var wlEntity = await this.GetWishListAsync(customerId);
            var wlServiceModel = new WishlistServiceModel();

            wlServiceModel.CustomerId = customerId;
            wlServiceModel.Id = wlEntity.Id;

            return _productsWishlistsService.FindProductsByWishlist(wlServiceModel);
        }
    }
}
