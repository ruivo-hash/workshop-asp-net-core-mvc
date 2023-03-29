using WebSalesMvc.Data;
using WebSalesMvc.Models;

namespace WebSalesMvc.Services
{
    public class SellersService
    {
        private readonly WebSalesMvcContext _context;

        public SellersService(WebSalesMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
