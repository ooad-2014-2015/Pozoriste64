using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    class Prostorija
    {
        public int brojMjesta { get; set; }
        public String nazivProstorije { get; set; }
        public int DajBrojMjesta() { return brojMjesta; }
        public Prostorija(int broj, string naziv)
        {
            brojMjesta = broj;
            nazivProstorije = naziv;
        }
    }
}
