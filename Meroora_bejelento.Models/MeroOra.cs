using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meroora_bejelento.Models
{
    public class MeroOra
    {
        public int Id { get; set; }
        [Display(Name = "Név")]
        public string Name { get; set; }
        [Display(Name = "Mintafotó")]
        [ValidateNever]
        public string MintaFoto { get; set; }
        [Display(Name = "Gyáriszám")]
        public string Gyariszam { get; set; }
        [Display(Name = "Mértékegység")]
        public string MertekEgyseg { get; set; }
        [Display(Name = "Egységár")]
        public int EgysegAr { get; set; }
        [Display(Name = "Tipus")]
        public int TipusId { get; set; }
        [ForeignKey("TipusId")]
        [ValidateNever]
        public MeroOraTipus MeroOraTipus { get; set; }

        // ez majd kell hogy melyik hazhoz tartozik a meroora
        //[Required]
        //[Display(Name = "Lakás")]
        //public int LakasId { get; set; }

        //[ForeignKey("LakasId")]
        //[ValidateNever]
        //public Lakas Lakas { get; set; }


    }
}
