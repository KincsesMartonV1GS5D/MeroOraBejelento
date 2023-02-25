using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Meroora_bejelento.Models
{
    public class Szerepkor
    {
        public int Id { get; set; }
        [Display(Name = "Név")]
        public string Name { get; set; }
        
    }
}