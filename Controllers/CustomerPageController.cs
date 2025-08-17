using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CoffeShop.Filters;
using CoffeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoffeShop.controllers
{
    [Auth]
    public class CustomerPageController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerPageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetKeranjang()
        {
            var findUser = await _context.users.Where(u => u.Email == HttpContext.Session.GetString("Email")).FirstOrDefaultAsync();

            var transaksi = await _context.transaksis.Where(t => t.Status == "Keranjang" && t.UserId == findUser.Id).FirstOrDefaultAsync();
            var transaksiDetails = await _context.detailTransaksis
                .Where(d => d.TransaksiId == transaksi.Id)
                .Include(d => d.produk)
                .OrderBy(d => d.Id)
                .ToListAsync();

            var groupedDetails = transaksiDetails
                .GroupBy(d => d.TransaksiId)
                .Select(group => new
                {
                    transaksiId = group.Key,
                    details = group.Select(d => new
                    {
                        d.Id,
                        d.JumlaBarang,
                        d.Total,
                        produk = new
                        {
                            d.produk.id,
                            d.produk.Nama,
                            d.produk.GambarProduk,
                            d.produk.Deskripsi,
                            d.produk.Stok,
                        }
                    }).ToList()
                }).ToList();

            return new JsonResult(new { success = true, data = groupedDetails });

        }

        public async Task<IActionResult> Index()
        {
            var dataProduk = await _context.produks.ToListAsync();
            var findUser = await _context.users.Where(u => u.Email == HttpContext.Session.GetString("Email")).FirstOrDefaultAsync();

            var TransaksiKeranjang = await _context.transaksis
                                    .Where(t => t.Status == "Keranjang" && t.UserId == findUser.Id)
                                    .FirstOrDefaultAsync();

            List<DetailTransaksi> DetailTransaksiKeranjang = new List<DetailTransaksi>();

            if (TransaksiKeranjang != null)
            {
                DetailTransaksiKeranjang = await _context.detailTransaksis
                    .Where(d => d.TransaksiId == TransaksiKeranjang.Id)
                    .ToListAsync();
            }

            ViewBag.DataKeranjang = DetailTransaksiKeranjang;

            return View("~/Views/CustomerPage/Index.cshtml", dataProduk);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Console.WriteLine("tes");
            var findProduk = await _context.produks.FindAsync(id);
            return View("~/Views/CustomerPage/Detail.cshtml", findProduk);
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailTransaksi(int id, int qty)
        {
            var findProduk = await _context.produks.FindAsync(id);
            var findUser = await _context.users.Where(u => u.Email == HttpContext.Session.GetString("Email")).FirstOrDefaultAsync();

            var TransaksiKeranjang = await _context.transaksis
                                    .Where(t => t.Status == "Keranjang" && t.UserId == findProduk.id)
                                    .FirstOrDefaultAsync();

            List<DetailTransaksi> DetailTransaksiKeranjang = new List<DetailTransaksi>();

            if (TransaksiKeranjang != null)
            {
                DetailTransaksiKeranjang = await _context.detailTransaksis
                    .Where(d => d.TransaksiId == TransaksiKeranjang.Id)
                    .ToListAsync();
            }

            ViewBag.Qty = qty;
            ViewBag.DataKeranjang = DetailTransaksiKeranjang;
            ViewBag.dataUser = findUser;

            return View("~/Views/CustomerPage/DetailTransaksi.cshtml", findProduk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutOneProduk(int ProdukId, int JumlahBeli, decimal Total, string Metode)
        {
            var findUser = await _context.users.Where(u => u.Email == HttpContext.Session.GetString("Email")).FirstOrDefaultAsync();

            if (Metode == "SALDO")
            {
                if (findUser.Saldo < Total)
                {
                    return BadRequest(new { success = false, Pesan = "Saldo tidak mencukupi." });
                }

                var TransaksiBaru = new Transaksi
                {
                    Tanggal = DateTime.Today,
                    Nominal = Total,
                    UserId = findUser.Id,
                    MetodePembayaran = Metode,
                    Status = "Sedang Dalam Perjalanan",
                    JumlahBayar = Total
                };

                _context.transaksis.Add(TransaksiBaru);
                await _context.SaveChangesAsync();

                findUser.Saldo -= Total;

                int TransaksiId = TransaksiBaru.Id;

                var findProduk = await _context.produks.FindAsync(ProdukId);
                findProduk.Stok = findProduk.Stok - JumlahBeli;

                var detailTransaksiBaru = new DetailTransaksi
                {
                    JumlaBarang = JumlahBeli,
                    Total = Total,
                    ProdukId = ProdukId,
                    TransaksiId = TransaksiId
                };

                _context.detailTransaksis.Add(detailTransaksiBaru);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, Pesan = "Berhasil Silakan Tunggu Pesanan Anda Datang" });
            }
            else if (Metode == "COD")
            {
                var TransaksiBaru = new Transaksi
                {
                    Tanggal = DateTime.Today,
                    Nominal = Total,
                    UserId = findUser.Id,
                    MetodePembayaran = Metode,
                    Status = "Sedang Dalam Perjalanan"
                };

                _context.transaksis.Add(TransaksiBaru);
                await _context.SaveChangesAsync();

                int TransaksiId = TransaksiBaru.Id;

                var findProduk = await _context.produks.FindAsync(ProdukId);
                findProduk.Stok = findProduk.Stok - JumlahBeli;

                var detailTransaksiBaru = new DetailTransaksi
                {
                    JumlaBarang = JumlahBeli,
                    Total = Total,
                    ProdukId = ProdukId,
                    TransaksiId = TransaksiId
                };

                _context.detailTransaksis.Add(detailTransaksiBaru);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, Pesan = "Berhasil Silakan Tunggu Pesanan Anda Dan Harap Bayar Dengan Nominal " + Total.ToString("N0") + " Yang Tertera Jika Pesanan Sudah Datang" });
            }

            return BadRequest(new { success = false, Pesan = "Metode pembayaran tidak valid." });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TambahKeranjang(int ProdukId, int jumlahBeli)
        {
            var findUser = await _context.users.Where(u => u.Email == HttpContext.Session.GetString("Email")).FirstOrDefaultAsync();
            var findTransaksi = await _context.transaksis.Where(t => t.Status == "Keranjang" && t.UserId == findUser.Id).FirstOrDefaultAsync();

            int transaksiId = 0;

            if (findTransaksi == null)
            {
                var transaksiBaru = new Transaksi
                {
                    Tanggal = DateTime.Today,
                    Nominal = 0,
                    MetodePembayaran = "Keranjang",
                    Status = "Keranjang",
                    UserId = findUser.Id,
                    JumlahBayar = 0
                };

                _context.transaksis.Add(transaksiBaru);
                await _context.SaveChangesAsync();

                transaksiId = transaksiBaru.Id;
            }
            else
            {
                transaksiId = findTransaksi.Id;
            }

            var idProduk = ProdukId;
            var findProduk = await _context.produks.FindAsync(ProdukId);
            var total = findProduk.HargaProduk * jumlahBeli;
            var findDetail = await _context.detailTransaksis.Where(d => d.TransaksiId == transaksiId && d.ProdukId == idProduk).FirstOrDefaultAsync();

            if (findDetail == null)
            {
                var detailTransaksiBaru = new DetailTransaksi
                {
                    JumlaBarang = jumlahBeli,
                    ProdukId = ProdukId,
                    Total = total,
                    TransaksiId = transaksiId
                };

                _context.detailTransaksis.Add(detailTransaksiBaru);
            }
            else
            {
                findDetail.JumlaBarang += jumlahBeli;
                findDetail.Total = findDetail.JumlaBarang * findProduk.HargaProduk;
            }

            await _context.SaveChangesAsync();

            return Ok(new { success = true, pesan = "Berhasil Menambahkan Ke Keranjang" });
        }

        [HttpGet("CustomerPage/DeleteKeranjang/{detailId}")]
        public async Task<IActionResult> DeleteKeranjang(int detailId)
        {
            var findDetail = await _context.detailTransaksis.FindAsync(detailId);

            _context.detailTransaksis.Remove(findDetail);
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

        [HttpGet("CustomerPage/KeranjangCheckout/{transaksiId}")]
        public async Task<IActionResult> KeranjangCheckout(int transaksiId)
        {
            var getDetail = await _context.detailTransaksis.Include(d => d.produk).Where(d => d.TransaksiId == transaksiId).ToListAsync();
            var totalHargaBeli = await _context.detailTransaksis.Where(d => d.TransaksiId == transaksiId).SumAsync(d => d.Total);
            var findUserlogin = await _context.users.Where(u => u.Email == HttpContext.Session.GetString("Email")).FirstOrDefaultAsync();

            ViewBag.totalBayar = totalHargaBeli;
            ViewBag.TransaksiId = transaksiId;
            ViewBag.dataUser = findUserlogin;
            return View("~/Views/CustomerPage/DetailTransaksiKeranjang.cshtml", getDetail);
        }

        [HttpPost("/CustomerPage/CheckoutKeranjang")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutKeranjang(int TransaksiId, string Metode)
        {
            var findDetail = await _context.detailTransaksis.Where(d => d.TransaksiId == TransaksiId).ToListAsync();
            var Total = await _context.detailTransaksis.Where(d => d.TransaksiId == TransaksiId).SumAsync(d => d.Total);
            var findUser = await _context.users.Where(u => u.Email == HttpContext.Session.GetString("Email")).FirstOrDefaultAsync();

            if (Metode == "SALDO")
            {
                if (findUser.Saldo < Total)
                {
                    return BadRequest(new { success = false, Pesan = "Saldo tidak mencukupi." });
                }

                foreach (var detail in findDetail)
                {
                    var findProduk = await _context.produks.FindAsync(detail.ProdukId);
                    findProduk.Stok = findProduk.Stok - detail.JumlaBarang;
                }

                var findTransaksi = await _context.transaksis.FindAsync(TransaksiId);
                findTransaksi.MetodePembayaran = Metode;
                findTransaksi.Status = "Sedang Dalam Perjalanan";
                findTransaksi.Nominal = Total;
                findTransaksi.JumlahBayar = Total;
                findUser.Saldo -= Total;

                await _context.SaveChangesAsync();
                return Ok(new { success = true, pesan = "Berhasil Silakan Tunggu Pesanan Anda Datang" });
            }
            else if (Metode == "COD")
            {
                foreach (var detail in findDetail)
                {
                    var findProduk = await _context.produks.FindAsync(detail.ProdukId);
                    findProduk.Stok = findProduk.Stok - detail.JumlaBarang;
                }

                var findTransaksi = await _context.transaksis.FindAsync(TransaksiId);
                findTransaksi.MetodePembayaran = Metode;
                findTransaksi.Status = "Sedang Dalam Perjalanan";
                findTransaksi.Nominal = Total;

                await _context.SaveChangesAsync();
                return Ok(new { success = true, pesan = "Berhasil Silakan Tunggu Pesanan Anda Dan Harap Bayar Dengan Nominal " + Total.ToString("N0") + " Yang Tertera Jika Pesanan Sudah Datang" });
            }

            return BadRequest(new { success = false, Pesan = "Metode pembayaran tidak valid." });

        }

        // profile
        public async Task<IActionResult> Profile()
        {
            var emailUser = HttpContext.Session.GetString("Email");
            var findUser = await _context.users.Where(u => u.Email == emailUser).FirstOrDefaultAsync();
            var transaksiList = await _context.transaksis
                .Where(t => t.UserId == findUser.Id)
                .ToListAsync();

            var list = new List<(DetailTransaksi Detail, Transaksi Transaksi)>();

            foreach (var transaksi in transaksiList)
            {
                var details = await _context.detailTransaksis
                    .Where(d => d.TransaksiId == transaksi.Id)
                    .Include(d => d.produk)
                    .ToListAsync();

                foreach (var detail in details)
                {
                    list.Add((detail, transaksi));
                }
            }

            ViewBag.dataUser = findUser;
            return View("~/Views/CustomerPage/Profile.cshtml", list);
        }

        [HttpGet]
        public async Task<IActionResult> Selesai(int id)
        {
            var findTransaksi = await _context.transaksis.FindAsync(id);

            findTransaksi.Status = "Selesai";

            await _context.SaveChangesAsync(); 

            return Ok(new { success = true, pesan = "Pesana Selesai" });
        }
    }
}