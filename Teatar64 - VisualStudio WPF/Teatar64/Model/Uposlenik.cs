using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    class Uposlenik : Osoba
    {
        private String datumRodjenja{get; set;}
        private String datumUposlenja { get; set; }
        private double plata { get; set; }
        public Uposlenik(String ime, String prezime, String dR, String dU)
            : base(ime, prezime)
        {
            datumRodjenja = dR;
            datumUposlenja = dU;
        }
        public String dajDatumRodjenja() { return datumRodjenja; }
        public String dajDatumUposlenja() { return datumUposlenja; }
        public double dajPlatu() { return plata; }
    }
}
