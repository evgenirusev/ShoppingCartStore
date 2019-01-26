using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartStore.Common.ViewModels.Product;
using ShoppingCartStore.Models;

namespace SoppingCartStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            ProductViewModel testProductOne = new ProductViewModel();
            testProductOne.Id = "1";
            testProductOne.Name = "Name One";
            testProductOne.Price = 4.99M;

            ProductViewModel testProductTwo = new ProductViewModel();
            testProductTwo.Id = "2";
            testProductTwo.Name = "Name Two";
            testProductTwo.Price = 8.99M;

            products.Add(testProductOne);
            products.Add(testProductTwo);

            return View(products);
        }
    }
}