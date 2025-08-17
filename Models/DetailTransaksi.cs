using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeShop.Models
{
    [Table("DETAIL_TRANSAKSI")]   
    public class DetailTransaksi
    {
        [Column("ID")]
        public int Id {get; set;}
        [Column("JUMLAH_BARANG")]
        public int JumlaBarang {get; set;}
        [Column("TOTAL")]
        public decimal Total {get; set;}
        [Column("ID_PRODUK")]
        public int ProdukId {get; set;}
        [Column("ID_TRANSAKSI")]
        public int TransaksiId {get; set;}

        // relasi
        public Produk produk {get; set;}
    }
}