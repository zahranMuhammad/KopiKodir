using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using CoffeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Daftar()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActionDaftar(User user)
        {
            var findUser = await _context.users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();

            if (findUser != null)
            {
                return BadRequest(new { pesan = "User ini sudah terdaftar" });
            }

            var newUser = new User
            {
                Nama = user.Nama,
                Email = user.Email,
                TglLahir = user.TglLahir,
                Alamat = user.Alamat,
                NoHp = user.NoHp,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                IsDelete = 0,
                Saldo = 0,
                Role = "user"
            };

            _context.users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { pesan = "Berhasil daftar sekarang silakan login" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> actionLogin(string Email, string Password)
        {
            var findUser = await _context.users.Where(u => u.Email == Email).FirstOrDefaultAsync();

            if (findUser == null)
            {
                return BadRequest(new { pesan = "User belum terdaftar" });
            }

            bool isPasswordvalid = BCrypt.Net.BCrypt.Verify(Password, findUser.Password);
            if (!isPasswordvalid)
            {
                return BadRequest(new { pesan = "Password yang anda masukkan salah" });
            }

            HttpContext.Session.SetString("Nama", findUser.Nama);
            HttpContext.Session.SetString("Nama", findUser.Nama);
            HttpContext.Session.SetString("Role", findUser.Role);
            HttpContext.Session.SetString("Email", findUser.Email);
            return Ok(new { pesan = "Berhasil Login", role = findUser.Role });
        }

        [HttpGet("Auth/Logout/{email}")]
        public async Task<IActionResult> Logout(string email)
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Auth");
        }
    }
}