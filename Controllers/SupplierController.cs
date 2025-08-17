using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace CoffeShop.controllers
{
    public class SupplierController : Controller
    {
        private readonly AppDbContext _context;
        public SupplierController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var findS = await _context.suppliers.FindAsync(id);
            return View(findS);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Store(Supplier supplier)
        {
            string query = "INSERT INTO SUPPLIER (nama, email, alamat) VALUES (:nama, :email, :alamat)";

            OracleParameter nama = new OracleParameter("nama", supplier.Nama);
            OracleParameter email = new OracleParameter("email", supplier.Email);
            OracleParameter alamat = new OracleParameter("alamat", supplier.Alamat);

            await _context.Database.ExecuteSqlRawAsync(query, nama, email, alamat);

            return Ok(new { success = true, pesan = "Data berhasil ditambahkan" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(
            String Nama,
            String Email,
            String Alamat,
            int id
        )
        {
            string query = "UPDATE SUPPLIER SET NAMA = :nama, EMAIL = :email, ALAMAT = :alamat WHERE ID = :id";

            OracleParameter nama = new OracleParameter("nama", Nama);
            OracleParameter email = new OracleParameter("email", Email);
            OracleParameter alamat = new OracleParameter("alamat", Alamat);
            OracleParameter Id = new OracleParameter("id", id);

            await _context.Database.ExecuteSqlRawAsync(query, nama, email, alamat, Id);

            return Ok(new { success = true, pesan = "Data berhasil diupdate" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string query = "DELETE FROM SUPPLIER WHERE ID = :id";

            OracleParameter Id = new OracleParameter("id", id);

            await _context.Database.ExecuteSqlRawAsync(query, Id);
            return Ok("Data berhasil dihapus");
        }
    }
}