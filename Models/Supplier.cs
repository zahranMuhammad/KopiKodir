using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeShop.Models
{
    [Table("SUPPLIER")]
    public class Supplier
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAMA")]
        public string Nama { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("ALAMAT")]
        public string Alamat { get; set; }
    }
}