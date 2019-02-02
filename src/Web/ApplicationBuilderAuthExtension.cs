namespace SoppingCartStore.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using ShoppingCartStore.Common.BindingModels.Brand;
    using ShoppingCartStore.Common.BindingModels.Category;
    using ShoppingCartStore.Common.BindingModels.Product;
    using ShoppingCartStore.Models;
    using ShoppingCartStore.Services.DataServices;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class ApplicationBuilderAuthExtension
    {
        private const string DefaultAdminPassword = "admin";
        private const string adminUsername = "admin";
        private const string adminEmail = "admin@email.com";

        private static readonly IdentityRole[] roles =
        {
            new IdentityRole("Administrator"),
            new IdentityRole("User")
        };

        public async static void SeedRolesAsync(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Customer>>();
                
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }
            }
        }

        public static void SeedProducts(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();

            using (scope)
            {
                var categoryService = scope.ServiceProvider.GetRequiredService<ICategoryService>();
                var brandService = scope.ServiceProvider.GetRequiredService<IBrandService>();
                var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

                // REFACTOR
                var allCategories = categoryService.All();
                var allBrands = brandService.All();
                var allProducts = productService.GetAllViewModelsAsync();

                if (allCategories.Count > 0 || allBrands.Count > 0 || allProducts.Count > 0)
                {
                    return;
                }

                foreach (var category in GetPreconfiguredCategories())
                {
                    categoryService.CreateAsync(category);
                }

                foreach (var brand in GetPreconfiguredBrands())
                {
                    brandService.CreateAsync(brand);
                }

                var products = GetPreconfiguredProducts();

                foreach (var product in products)
                {
                    productService.CreateAsync(product).Wait();
                }
            }
        }

        static IEnumerable<CreateBrandBindingModel> GetPreconfiguredBrands()
        {
            return new List<CreateBrandBindingModel>()
            {
                new CreateBrandBindingModel() { Id = "06abc896-b926-409e-b8b3-2fe37e89ee96", Name = "Apple"},
                new CreateBrandBindingModel() { Id = "14f01a3d-0269-406b-8bc8-f71f0016d0d5", Name = "Samsung"},
                new CreateBrandBindingModel() { Id = "5b1b6837-12dd-4fd6-a18b-f3f830109b0a", Name = "Huawei"},
                new CreateBrandBindingModel() { Id = "a611856c-a84f-42ef-af58-76cb16dc81fb", Name = "Razer"},
                new CreateBrandBindingModel() { Id = "3ce3e570-bdeb-475a-be70-1b317158e622", Name = "Panasonic"}
            };
        }

        static IEnumerable<CreateCategoryBindingModel> GetPreconfiguredCategories()
        {
            return new List<CreateCategoryBindingModel>()
            {
                new CreateCategoryBindingModel() { Id = "d8b0d5b4-8272-441d-bfe2-d563ee2b6f2e", Name = "Phones", Description = "This category consists of phone products"},
                new CreateCategoryBindingModel() { Id = "f77a0cb3-8740-4a09-b182-a10dfa244e95", Name = "Peripherals", Description = "This category consists of peripheral products" },
                new CreateCategoryBindingModel() { Id = "c3f07476-4f57-48b9-8415-f42e5cc3b7ea", Name = "Laptops", Description = "This category consists of laptop products" },
                new CreateCategoryBindingModel() { Id = "1c2453a3-0ca7-4c55-a4a4-baeaa4843a38", Name = "Cameras", Description = "This category consists of printers" }
            };
        }

        static IEnumerable<CreateProductBindingModel> GetPreconfiguredProducts()
        {
            return new List<CreateProductBindingModel>()
            {
                new CreateProductBindingModel() { Name = "IPhone 8", Price = 499.99M, CategoryId = "d8b0d5b4-8272-441d-bfe2-d563ee2b6f2e", BrandId = "06abc896-b926-409e-b8b3-2fe37e89ee96", Description = "Despite the glamorous allure of an edge-to-edge OLED display and futuristic-feeling facial recognition functionality, not everyone will be persuaded to part with $1,000 or more for the iPhone X. For now, whether you’re on the upgrade cycle from the iPhone 6S or just looking for a more affordable iPhone, the iPhone 8 is for you. As our review shows, it may be refinement, rather than revolution, but it’s a damn good phone all the same.", ImageURI = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/image/AppleInc/aos/published/images/i/ph/iphone7/plus/iphone7-plus-black-select-2016?wid=513&hei=556&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1472430090682" },
                new CreateProductBindingModel() { Name = "IPhone X", Price = 1299.99M, CategoryId = "d8b0d5b4-8272-441d-bfe2-d563ee2b6f2e", BrandId = "06abc896-b926-409e-b8b3-2fe37e89ee96", Description = "Moving beyond its new design, additional enhancements and improvements in the iPhone 8 include wireless charging capabilities, a faster 10-nanometer, six-core A11 Bionic processor that offers higher performance while utilizing less power, an all-glass body, a front-facing camera that's integrated into the display.", ImageURI = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/image/AppleInc/aos/published/images/i/ph/iphone/xs/iphone-xs-max-select-2018-group?wid=578&hei=982&fmt=jpeg&qlt=80&op_usm=0.5,0.5&.v=1536616752354" },
                new CreateProductBindingModel() { Name = "Panasonic TOUGHBOOK I9", Price = 1499.99M, CategoryId = "c3f07476-4f57-48b9-8415-f42e5cc3b7ea", BrandId = "3ce3e570-bdeb-475a-be70-1b317158e622", Description = "The Panasonic TOUGHBOOK I9 is a fully rugged, lightweight laptop that easily detaches to become a 10.1 tablet.With a gloved multi - touch sunlight - viewable display, a hot - swap battery and a kickstand, it is tough and flexible enough for rugged outdoor environments.", ImageURI = "https://cdn.ozone.bg/media/catalog/product/cache/1/image/a4e40ebdc3e371adff845072e1c73f37/g/e/82d9e9a25ab7e71416efdad840082892/geyming-laptop-msi-ps42-modern-8rc-14-ips-level-anti-glare-siv-36.jpg" },
                new CreateProductBindingModel() { Name = "IPhone 8", Price = 499.99M, CategoryId = "d8b0d5b4-8272-441d-bfe2-d563ee2b6f2e", BrandId = "06abc896-b926-409e-b8b3-2fe37e89ee96", Description = "Moving beyond its new design, additional enhancements and improvements in the iPhone 8 include wireless charging capabilities, a faster 10-nanometer, six-core A11 Bionic processor that offers higher performance while utilizing less power, an all-glass body, a front-facing camera that's integrated into the display.", ImageURI = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/image/AppleInc/aos/published/images/i/ph/iphone8/plus/iphone8-plus-gold-select-2018?wid=513&hei=556&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1522347727972" },
                new CreateProductBindingModel() { Name = "Huawei Mate 20 PRO", Price = 699.99M, CategoryId = "d8b0d5b4-8272-441d-bfe2-d563ee2b6f2e", BrandId = "5b1b6837-12dd-4fd6-a18b-f3f830109b0a", Description = "Moving beyond its new design, additional enhancements and improvements in the Huawei Mate 20 PRO include wireless charging capabilities, a faster 10-nanometer, six-core A11 Bionic processor that offers higher performance while utilizing less power, an all-glass body, a front-facing camera that's integrated into the display.", ImageURI = "https://cf3.s3.souqcdn.com/item/2018/10/24/39/75/36/47/item_XL_39753647_156790110.jpg" },
                new CreateProductBindingModel() { Name = "Razer Elite Mouse", Price = 79.95M, CategoryId = "f77a0cb3-8740-4a09-b182-a10dfa244e95", BrandId = "a611856c-a84f-42ef-af58-76cb16dc81fb", Description = "Equipped with the new esports-grade 16,000 DPI optical sensor and true tracking at 450 Inches Per Second (IPS), the Razer DeathAdder Elite ergonomic mouse gives you the absolute advantage.", ImageURI = "https://www.overclockers.co.uk/media/image/thumbnail/KB12NRA_192933_800x800.jpg" },
                new CreateProductBindingModel() { Name = "Panasonic HD W180", Price = 499.99M, CategoryId = "1c2453a3-0ca7-4c55-a4a4-baeaa4843a38", BrandId = "3ce3e570-bdeb-475a-be70-1b317158e622", Description = "Moving beyond its new design, additional enhancements and improvements in the Panasonic W180 include wireless charging capabilities, a faster 10-nanometer, six-core A11 Bionic processor that offers higher performance while utilizing less power, an all-glass body, a front-facing camera that's integrated into the display.", ImageURI = "https://i1.adis.ws/i/pcec/HC-W580K_ALT01?$PLP-Product-Thumbnail-Desktop$" },
                new CreateProductBindingModel() { Name = "Panasonic HQ220", Price = 599.99M, CategoryId = "1c2453a3-0ca7-4c55-a4a4-baeaa4843a38", BrandId = "3ce3e570-bdeb-475a-be70-1b317158e622", Description = "Moving beyond its new design, additional enhancements and improvements in the Panasonic HQ220 include wireless charging capabilities, a faster 10-nanometer, six-core A11 Bionic processor that offers higher performance while utilizing less power, an all-glass body, a front-facing camera that's integrated into the display.", ImageURI = "https://www.bhphotovideo.com/images/images2500x2500/panasonic_dmc_fh10k_lumix_dmc_fh10_digital_camera_910528.jpg" },
                new CreateProductBindingModel() { Name = "Samsung Galaxy S9", Price = 399.95M, CategoryId = "d8b0d5b4-8272-441d-bfe2-d563ee2b6f2e", BrandId = "14f01a3d-0269-406b-8bc8-f71f0016d0d5", Description = "Moving beyond its new design, additional enhancements and improvements in the Samsung Galaxy include wireless charging capabilities, a faster 10-nanometer, six-core A11 Bionic processor that offers higher performance while utilizing less power, an all-glass body, a front-facing camera that's integrated into the display.", ImageURI = "https://images.samsung.com/is/image/samsung/p5/levant/smartphones/galaxy-note9_blue.png?$ORIGIN_PNG$" },
                new CreateProductBindingModel() { Name = "Samsung Galaxy S5", Price = 399.95M, CategoryId = "d8b0d5b4-8272-441d-bfe2-d563ee2b6f2e", BrandId = "14f01a3d-0269-406b-8bc8-f71f0016d0d5", Description = "Moving beyond its new design, additional enhancements and improvements in the Samsung Galaxy include wireless charging capabilities, a faster 10-nanometer, six-core A11 Bionic processor that offers higher performance while utilizing less power, an all-glass body, a front-facing camera that's integrated into the display.", ImageURI = "https://cdn2.gsmarena.com/vv/bigpic/samsung-galaxy-j7-2018.jpg" }
            };
        }
    }
}
