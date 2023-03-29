using Microsoft.AspNetCore.Mvc;

namespace WebSalesMvc.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
