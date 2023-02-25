using System.ComponentModel.DataAnnotations;

namespace Meroora_bejelento.Models
{
    public class Company
    {
        // 22,23 from udemy
        [Key] //using DataAnnotations
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
