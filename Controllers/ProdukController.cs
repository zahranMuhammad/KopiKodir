using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Filters;
using CoffeShop.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace CoffeShop.controllers
{
    [Auth]
    public class ProdukController : Controller
    {
        private readonly AppDbContext _context;

        public ProdukController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(
            [FromForm] string Nama,
            [FromForm] decimal Harga,
            [FromForm] int Stok,
            [FromForm] IFormFile GambarProduk,
            [FromForm] string Deskripsi
        )
        {
            var namaRequst = Nama?.ToLower();
            var findProduk = await _context.produks.FirstOrDefaultAsync(p => p.Nama.ToLower() == namaRequst);

            if (findProduk != null)
            {
                return BadRequest(new { success = false, pesan = "Produk ini sudah tersedia" });
            }

            string imgPath = null;
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "gambarProduks");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            if (GambarProduk != null && GambarProduk.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(GambarProduk.FileName);
                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await GambarProduk.CopyToAsync(stream);
                }

                imgPath = "/gambarProduks/" + fileName;
            }

            var newProduk = new Produk
            {
                Nama = Nama,
                HargaProduk = Harga,
                Stok = Stok,
                GambarProduk = imgPath,
                Deskripsi = Deskripsi,
                UserId = 2,
                IsDelete = 1
            };

            // simpan ke db
            _context.produks.Add(newProduk);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, pesan = "Produk berhasil ditambahkan" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var findProduk = await _context.produks.FirstOrDefaultAsync(p => p.id == id);
            return View(findProduk);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var findProduk = await _context.produks.FirstOrDefaultAsync(p => p.id == id);
            return View(findProduk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(
            [FromForm] string Nama,
            [FromForm] decimal Harga,
            [FromForm] int Stok,
            [FromForm] IFormFile GambarProduk,
            [FromForm] string Deskripsi,
            int id
        )
        {
            var findProduk = await _context.produks.FirstOrDefaultAsync(p => p.id == id);
            var namaProduk = Nama?.ToLower();
            var produkSama = await _context.produks.FirstOrDefaultAsync(p => p.Nama.ToLower() == namaProduk && p.id != id);

            // cek jika ada produk yang sama
            if (produkSama != null)
            {
                return BadRequest(new { success = false, pesan = "Produk ini sudah tersedia" });
            }

            findProduk.Nama = Nama;
            findProduk.HargaProduk = Harga;
            findProduk.Stok = Stok;
            findProduk.Deskripsi = Deskripsi;

            // jika ada gambar
            if (GambarProduk != null && GambarProduk.Length > 0)
            {

                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "gambarProduks");
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var fileName = Guid.NewGuid() + Path.GetExtension(GambarProduk.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await GambarProduk.CopyToAsync(stream);
                }

                findProduk.GambarProduk = "/gambarProduks/" + fileName;
            }

            _context.produks.Update(findProduk);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, pesan = "Data berhasil diedit" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool status)
        {
            var findProduk = await _context.produks.FindAsync(id);

            if (findProduk.IsDelete == 0 && status == true)
            {
                findProduk.IsDelete = 1;
            }
            else
            {
                findProduk.IsDelete = 0;
            }

            _context.produks.Update(findProduk);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, pesan = "Berhasil Update status" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile importFile)
        {
            var produkList = new List<Produk>();

            using (var stream = new MemoryStream())
            {
                await importFile.CopyToAsync(stream);
                stream.Position = 0;

                var extension = Path.GetExtension(importFile.FileName).ToLower();

                if (extension == ".csv")
                {
                    Console.WriteLine("ini file csv");
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = await reader.ReadLineAsync();
                            var values = line.Split(',');

                            if (values.Length >= 7)
                            {
                                produkList.Add(new Produk
                                {
                                    Nama = values[0],
                                    Deskripsi = values[1],
                                    GambarProduk = values[2],
                                    HargaProduk = decimal.Parse(values[3], CultureInfo.InvariantCulture),
                                    Stok = int.Parse(values[4]),
                                    IsDelete = int.Parse(values[5]),
                                    UserId = int.Parse(values[6])
                                });
                            }
                        }
                    }
                }
                else if (extension == ".xlsx" || extension == ".xls")
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var package = new ExcelPackage(stream))
                    {
                        var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (workSheet == null)
                        {
                            return BadRequest(new { success = false, pesan = "File tidak ditemukan"});
                        }

                        int rowCount = workSheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            string nama = workSheet.Cells[row, 2].Text;

                            var findProdukSame = await _context.produks.Where(p => p.Nama == nama).FirstOrDefaultAsync();

                            if (findProdukSame != null)
                            {
                                return BadRequest(new { success = false, pesan = "Di dalam file ini sudah ada nama produk yang sama" });
                            }

                            if (string.IsNullOrEmpty(nama)) continue;

                            var produk = new Produk
                            {
                                Nama = nama,
                                Deskripsi = workSheet.Cells[row, 3].Text,
                                GambarProduk = workSheet.Cells[row, 4].Text,
                                HargaProduk = decimal.TryParse(workSheet.Cells[row, 5].Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var harga) ? harga : 0,
                                Stok = int.TryParse(workSheet.Cells[row, 6].Text, out var stok) ? stok : 0,
                                IsDelete = int.TryParse(workSheet.Cells[row, 7].Text, out var del) ? del : 0,
                                UserId = int.TryParse(workSheet.Cells[row, 8].Text, out var uid) ? uid : 0
                            };

                            produkList.Add(produk);
                        }
                    }
                }
                else
                {
                    return BadRequest(new {success = false, pesan = "Format file yang anda upload tidak sesuai"});
                }
            }

            _context.produks.AddRange(produkList);
            await _context.SaveChangesAsync();

            return Ok(new {success = true, pesan = "Berhasil import"});
        }    
    }
}  