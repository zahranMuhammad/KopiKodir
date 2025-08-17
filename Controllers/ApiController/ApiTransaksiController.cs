using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Filters;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.controllers
{
    [Auth]
    [Route("odata/[controller]")]
    public class ApiTransaksiController : Controller
    {
        private readonly AppDbContext _context;

        public ApiTransaksiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.transaksis);
        }
    }
}