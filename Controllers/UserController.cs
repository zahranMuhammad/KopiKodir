using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Filters;
using CoffeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.controllers
{
    [Auth]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            var findUser = await _context.users.FindAsync(id);
            return View(findUser);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool status)
        {
            var findUser = await _context.users.FindAsync(id);

            if (findUser.IsDelete == 0 && status == true)
            {
                findUser.IsDelete = 1;
            }
            else
            {
                findUser.IsDelete = 0;
            }

            _context.users.Update(findUser);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, pesan = "Berhasil Update status" });
        }

    }
}