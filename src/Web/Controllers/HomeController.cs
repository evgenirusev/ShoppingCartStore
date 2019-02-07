using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartStore.Common.Constants;
using ShoppingCartStore.Common.ViewModels;

namespace SoppingCartStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(ActionConstants.Index, ControllerConstants.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
