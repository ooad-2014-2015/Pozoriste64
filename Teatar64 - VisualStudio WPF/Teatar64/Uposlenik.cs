using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teatar64
{
    class Uposlenik : Osoba
    {
        private DateTime datumRodjenja{get; set;}
        private DateTime datumUposlenja { get; set; }
        private double plata { get; set; }
        public void LogIn(string user, string password)
        {

        }
        public DateTime dajDatumRodjenja() { return datumRodjenja; }
        public DateTime dajDatumUposlenja() { return datumUposlenja; }
        public double dajPlatu() { return plata; }
    }
}
