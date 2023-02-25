using System.ComponentModel.DataAnnotations;

namespace Meroora_bejelento.Models
{
    public class Berlo
    {
        // 22,23 from udemy
        [Key] //using DataAnnotations
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? AspnetId { get; set; }
        public string? Name { get; set; }
        public int DimBerlId { get; set; }
        public int DimBermId { get; set; }
        public string? BermCim { get; set; }
        public DateTime SzerzKelte { get; set; } = DateTime.Now;
        public DateTime SzerzLejarat { get; set; } = DateTime.Now;
        public DateTime LastLogOn { get; set; } = DateTime.Now;
        public int LeolvKezdonap { get; set; }
        public int LeolvMaxNap { get; set; }
        public bool aktiv { get; set; }


    }
}
