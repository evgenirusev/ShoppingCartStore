using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartStore.Common.BindingModels.Product;
using ShoppingCartStore.Common.ViewModels.Product;
using ShoppingCartStore.Models;
using ShoppingCartStore.Services.DataServices;

namespace SoppingCartStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductViewModel> products = await _productService.GetAllProductsAsync();
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