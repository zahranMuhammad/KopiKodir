using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeShop.Models
{
    [Table("PRODUK")]
    public class Produk
    {
        [Column("ID")]
        public int id {get; set;}
        [Column("NAMA")]
        public string Nama {get; set;}
        [Column("DESKRIPSI")]
        public string Deskripsi {get; set;}
        [Column("GAMBAR_PRODUK")]
        public string GambarProduk {get; set;}
        [Column("HARGA")]
        public decimal HargaProduk {get; set;}
        [Column("STOK")]
        public int Stok {get; set;}
        [Column("IS_DELETE")]
        public int IsDelete {get; set;}
        [Column("ID_USERCOFFE")]
        public int UserId {get; set;}

        // relasi
        public User user {get; set;}

        public ICollection<DetailTransaksi> DetailTransaksis {get; set;}
    }
}