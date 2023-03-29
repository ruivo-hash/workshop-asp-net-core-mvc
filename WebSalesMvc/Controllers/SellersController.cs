using Microsoft.AspNetCore.Mvc;
using WebSalesMvc.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
