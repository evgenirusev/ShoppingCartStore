using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartStore.Common.BindingModels.Product;
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

        public IActionResult Index()
        {
            IEnumerable<ProductViewModel> products = _productService.GetAllViewModelsAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductBindingModel model)
        {
            await _productService.CreateAsync(model);
            return this.RedirectToAction("Index", "Products");
        }

        public async Task<IActionResult> Details(string id)
        {
            var productViewModel = _productService.FindById(id);
            return View(productViewModel);
        }
    }
}