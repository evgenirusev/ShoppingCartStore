namespace SoppingCartStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CartController : Controller
    {
        public IActionResult AddToCart(string productId)
        {
            return Json("Success");
        }
    }
}
