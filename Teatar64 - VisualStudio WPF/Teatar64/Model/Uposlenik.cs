using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64.Model
{
    public class Uposlenik : Osoba
    {
        public String datumRodjenja{get; set;}
        public String datumUposlenja { get; set; }
        public String sifra { get; set; }
        private double plata { get; set; }
        public Uposlenik(String ime, String prezime, String dR, String dU, Double pl, String sif)
            : base(ime, prezime)
        {
            datumRodjenja = dR;
            datumUposlenja = dU;
            plata = pl;
            sifra = sif;
        }
        public String dajDatumRodjenja() { return datumRodjenja; }
        public String dajDatumUposlenja() { return datumUposlenja; }
        public double dajPlatu() { return plata; }
    }
}
