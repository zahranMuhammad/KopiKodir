using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeShop.Models
{
    [Table("USERCOFFEE")]
    public class User
    {
        [Column("ID")]
        public int Id {get; set;}
        [Column("NAMA")]
        public string Nama {get; set;}
        [Column("EMAIL")]
        public string Email {get; set;}
        [Column("TGL_LAHIR")]
        public DateTime TglLahir {get; set;}
        [Column("ALAMAT")]
        public string Alamat {get; set;}
        [Column("PASSWORD")]
        public string Password {get; set;}
        [Column("IS_DELETE")]
        public int IsDelete {get; set;}
        [Column("ROLE")]
        public string Role {get; set;}
        [Column("NO_HP")]
        public string NoHp {get; set;}
        [Column("SALDO")]
        public decimal Saldo { get; set; }

        // relasi
        public ICollection<Produk> Produks { get; set; }
        public ICollection<Transaksi> Transaksis {get; set;}
    }
}