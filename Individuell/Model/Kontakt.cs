using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Individuell.Model
{
    public class Kontakt
    {
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,10}$")]
        public string Fornavn { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,10}$")]
        public string Etternavn { get; set; }
        [Required]
        public string Epost { get; set; }
        [Required]
        public string Melding { get; set; }
    }
}
