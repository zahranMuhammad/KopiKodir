using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.ApiController
{
    [Route("odata/[controller]")]
    public class ApiTesImportController : Controller
    {
        private readonly AppDbContext _context;

        public ApiTesImportController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.tesImports);
        }
    }
}