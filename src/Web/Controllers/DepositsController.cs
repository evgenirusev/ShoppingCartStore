namespace SoppingCartStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DepositsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}