using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.ApiController
{
    public class ApiDeliverController : Controller
    {
        private readonly AppDbContext _context;

        public ApiDeliverController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            return Ok(_context.transaksis.Include(t => t.user).Where(t => t.Status != "Keranjang"));
        }
    }
}