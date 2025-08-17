using CoffeShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Produk> produks { get; set; }
        public DbSet<Transaksi> transaksis { get; set; }
        public DbSet<DetailTransaksi> detailTransaksis { get; set; }
        public DbSet<TesImport> tesImports { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
    }
}