using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeShop.Models
{
    [Table("TRANSAKSI")]
    public class Transaksi
    {
        [Column("ID")]
        public int Id {get; set;}
        [Column("TANGGAL")]
        public DateTime Tanggal {get; set;}
        [Column("NOMINAL")]
        public decimal? Nominal {get; set;}
        [Column("ID_USERCOFFE")]
        public int UserId {get; set;}
        [Column("METODE_PEMBAYARAN")]
        public string MetodePembayaran {get; set;}
        [Column("STATUS")]
        public string Status {get; set;}
        [Column("JUMLAH_BAYAR")]
        public decimal? JumlahBayar { get; set; }
        [Column("TANGGAL_SAMPAI")]
        public DateTime? TanggalSampai { get; set; }

        // relasi
        public User user { get; set; }

        public ICollection<DetailTransaksi> detailTransaksis {get; set;}
    }
}