using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.controllers_ApiController
{
    [Route("odata/[controller]")]
    public class ApiSupplierController : Controller
    {
        private readonly AppDbContext _context;
        public ApiSupplierController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            Console.WriteLine("hi dari api supplier");
            return Ok(_context.suppliers);
        }
    }
}