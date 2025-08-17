using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace CoffeShop.controllers
{
    public class TransaksiController : Controller
    {
        private readonly AppDbContext _context;
        public TransaksiController(AppDbContext context)
        {
            _context = context;
        }

        [Auth]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DetailPenjualan(int id)
        {
            var findDetail = await _context.detailTransaksis.Include(d =>d.produk).Where(d => d.TransaksiId == id).ToListAsync();

            // return Ok(findDetail);
            return View("~/Views/Transaksi/Detail.cshtml", findDetail);
        }   

    }
}  
        