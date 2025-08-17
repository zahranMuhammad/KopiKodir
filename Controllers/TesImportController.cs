using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.controllers
{
    public class TesImportController : Controller
    {
        private readonly AppDbContext _context;

        public TesImportController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/ImportDataTes/Index.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportFile(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                return BadRequest(new { success = false, pesan = "File tidak valid" });
            }

            var listImport = new List<TesImport>();
            using (var stream = new StreamReader(formFile.OpenReadStream()))
            {
                bool isFirstLine = true;
                while (!stream.EndOfStream)
                {
                    var line = await stream.ReadLineAsync();

                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue;
                    }

                    var values = line.Split(',');

                    if (values.Length >= 5)
                    {
                        listImport.Add(new TesImport
                        {
                            KdSatker = int.TryParse(values[0], out var kdSatker) ? kdSatker : 0,
                            KdCoa = values[1],
                            Pagu = values[2],
                            Realisasi = values[3],
                            SisaPagu = values[4]
                        });

                        if (listImport.Count % 1000 == 0)
                        {
                            _context.tesImports.AddRange(listImport);
                            await _context.SaveChangesAsync();
                            listImport.Clear();
                        }
                    }
                }
            
                if (listImport.Any())
                {
                    _context.tesImports.AddRange(listImport);
                    await _context.SaveChangesAsync();
                }
            }

            return Ok(new { success = true, pesan = "berhasil import" });
        }

        [HttpGet]
        public async Task<IActionResult> deleteSemua()
        {
            var allData = _context.tesImports.ToList();
            _context.tesImports.RemoveRange(allData);

            await _context.SaveChangesAsync();

            return Ok(new { success = true, pesan = "Berhasil hapus semua data" });
        }
    }
}