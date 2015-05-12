using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64
{
    class Osoba
    {
        private string ime { get; set; }
        private string prezime { get; set; }
        public string DajIme() { return ime; }
        public string DajPrezime() { return prezime; }
    }
}
