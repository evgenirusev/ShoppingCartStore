namespace ShoppingCartStore.Services.DataServices.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using ShoppingCartStore.Data.Common.Repositories;
    using ShoppingCartStore.Models;

    public class WishlistService : BaseService<Wishlist>, IWishlistService
    {
        public WishlistService(IRepository<Wishlist> repository, IMapper mapper
            , UserManager<Customer> userManager)
            : base(repository, mapper, userManager)
        {
        }

        public async Task AddToWishlistAsync(string productId, string customerId)
        {
            var wishlist = await this.GetWishListAsync(customerId);

            ProductsWishlists pw = new ProductsWishlists();
            pw.ProductId = productId;
            pw.WishlistId = wishlist.Id;

            wishlist.ProductsWishlists.Add(pw);
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
    }
}
