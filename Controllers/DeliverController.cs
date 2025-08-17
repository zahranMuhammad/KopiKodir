using System;
using System.Collections.Generic;
using System.Linq;
using CoffeShop.Filters;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.controllers
{
    [TypeFilter(typeof(DeliverAttribut))]
    public class DeliverController : Controller
    {
        private readonly AppDbContext _context;

        public DeliverController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTransaksi(int transaksiId, decimal JumlahBayar)
        {
            var findTransaksi = await _context.transaksis.FindAsync(transaksiId);

            if (findTransaksi.Nominal > JumlahBayar)
            {
                return BadRequest(new { success = false, pesan = "Uang yang anda masukkan kurang" });
            }

            findTransaksi.JumlahBayar = JumlahBayar;
            findTransaksi.Status = "Sudah Sampai";
            findTransaksi.TanggalSampai = DateTime.Today;

            await _context.SaveChangesAsync();

            return Ok(new { success = true, pesan = "Berhasil, Transaksi Sudah Sampaii!!" });
        }

    }
}