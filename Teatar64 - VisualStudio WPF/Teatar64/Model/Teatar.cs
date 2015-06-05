using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    class Teatar : Prostorija
    {
        public Double velicinaPozornice { get; set; }
        public Teatar(int broj, String naziv, double velicina) : base(broj, naziv)
        {
            velicinaPozornice = velicina;
        }
    }

    class Sala : Prostorija
    {
        public Sala(int broj, string naziv) : base(broj, naziv) { }
    }
}
