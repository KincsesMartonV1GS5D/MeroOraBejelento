using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meroora_bejelento.Models
{
    public class Felhasznalo
    {
        public int Id { get; set; }
        [Display(Name = "Név")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        
        
        [Required]
        [Display(Name = "Szerepkör")]
        public int SzerepkorId { get; set; }

        [ForeignKey("SzerepkorId")]
        [ValidateNever]
        public Szerepkor Szerepkor { get; set; }

    }
}
