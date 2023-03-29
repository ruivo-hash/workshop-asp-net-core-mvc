using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSalesMvc.Data;
using WebSalesMvc.Models.ViewModels;

namespace WebSalesMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebSalesMvcContext _context;

        public HomeController(ILogger<HomeController> logger, WebSalesMvcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var seed = new SeedingService(_context);
            seed.Seed();
            return View();
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