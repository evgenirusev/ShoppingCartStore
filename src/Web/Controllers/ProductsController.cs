using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartStore.Common.BindingModels.Product;
using ShoppingCartStore.Common.ViewModels.Cart;
using ShoppingCartStore.Common.ViewModels.Product;
using ShoppingCartStore.Services.DataServices;

namespace SoppingCartStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;
        private ICartService _cartService;

        public ProductsController(ICartService cartService, IProductService productService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductViewModel> products = await _productService.GetAllViewModelsAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductBindingModel model)
        {
            await _productService.Create(model);
            return this.RedirectToAction("Index", "Products");
        }
    }
}