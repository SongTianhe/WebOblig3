using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Individuell.Model
{
    public class NorWayFAQ
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public string Question { get; set; }
        public string Svar { get; set; }
        public int Positiv { get; set; }
        public int Negativ { get; set; }
    }
}
