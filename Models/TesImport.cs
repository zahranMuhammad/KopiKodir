using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeShop.Models
{
    [Table("IMPORTDATA")]
    public class TesImport
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("KD_SATKER")]
        public int KdSatker { get; set; }
        [Column("KD_COA")]
        public string KdCoa { get; set; }
        [Column("PAGU")]
        public string Pagu { get; set; }
        [Column("REALISASI")]
        public string Realisasi { get; set; }
        [Column("SISA_PAGU")]
        public string SisaPagu { get; set; } 
    }
}