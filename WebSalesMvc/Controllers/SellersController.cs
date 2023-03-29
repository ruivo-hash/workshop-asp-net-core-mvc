using Microsoft.AspNetCore.Mvc;
using WebSalesMvc.Services;

namespace WebSalesMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellerService;

        public SellersController(SellersService sellerServices)
        {
            _sellerService = sellerServices;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
    }
}
