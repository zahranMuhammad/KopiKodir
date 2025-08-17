using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Filters;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.ApiController
{
    [Auth]
    [Route("odata/[controller]")]
    public class ApiProdukController : Controller
    {
        private readonly AppDbContext _context;

        public ApiProdukController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            Console.WriteLine("Tes");
            return Ok(_context.produks);
        }
    }
}