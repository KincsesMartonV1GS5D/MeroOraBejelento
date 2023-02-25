using Meroora_bejelento.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meroora_bejelento.Models
{
    public class Lakas
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cím")]
        public String Cim { get; set; }

        public int BerloId { get; set; }
        [ForeignKey("BerloId")]
        [ValidateNever]
        public virtual ICollection<Felhasznalo> Berlok { get; set; } = null!;
        public int TulajdonosId { get; set; }
        [ForeignKey("TulajdonosId")]
        [ValidateNever]
        public virtual ICollection<Felhasznalo> Tulajdonosok { get; set; } = null!;

        //    [Required]
        //    [Display(Name = "Bérlő")]
        //    public int BerloId { get; set; }

        //    [ForeignKey("BerloId")]
        //    public virtual Felhasznalo Berlo { get; set; }



        //    [Required]
        //    [Display(Name = "Tulajdonos")]
        //    public int TulajdonosId { get; set; }

        //    [ForeignKey("TulajdonosId")]
        //    public virtual Felhasznalo Tulajdonos { get; set; }
    }
}
