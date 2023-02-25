using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meroora_bejelento.Models.ViewModels
{
    public class FelhasznaloVM
    {
        public Felhasznalo Felhasznalo { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SzerepkorList { get; set; }
    }
}
