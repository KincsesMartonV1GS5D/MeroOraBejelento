using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Meroora_bejelento.Models
{
    public class Leolvasas
    {
        public int Id { get; set; }
        public int Allas { get; set; }
        public string AllasFoto { get; set; }
        public int Ertek { get; set; }
        public int Fogyasztas { get; set; }
        //ez majd kell
        //public int MeroOraId { get; set; }
        //[ForeignKey("MeroOraId")]
        //public virtual ICollection<MeroOra> Orak { get; set; } = null!;

        //ez majd kell
        //public int BerloId { get; set; }
        //[ForeignKey("BerloId")]
        //public virtual ICollection<Felhasznalo> Berlok { get; set; } = null!;

    }
}
